namespace RSBuild
{
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// The config settings.
    /// </summary>
    public sealed class Settings
    {
        #region Static fields/properties

        private readonly Regex GlobalsRegex = new Regex(@"(?<g>\${(?<k>[^}]+)})", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static Assembly DefaultAssembly
        {
            get { return Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly(); }
        }

        public static Settings Load()
        {
            return Load(null);
        }

        public static Settings Load(string settingsFilePath)
        {
            string settingsDir = string.IsNullOrEmpty(settingsFilePath) 
                ? null 
                : Path.GetDirectoryName(settingsFilePath);
            string settingsFileName = string.IsNullOrEmpty(settingsFilePath) 
                ? null
                : Path.GetFileName(settingsFilePath);

            if (string.IsNullOrEmpty(settingsDir))
            {
                settingsDir = Environment.CurrentDirectory;
            }
            if (string.IsNullOrEmpty(settingsFileName))
            {
                settingsFilePath = Path.Combine(settingsDir, DefaultAssembly.GetName().Name + ".config");
            }
            
            return new Settings(settingsFilePath);
        }

        #endregion

        #region Instance fields

        private readonly string _settingsDir;
        
        private Hashtable _reportServers;
        private Hashtable _dataSources;
        private ReportGroup[] _reportGroups;
        private DBExecution[] _dbExecutions;
        private StringDictionary _dbConnections;
        private StringDictionary _globalVariables;

        #endregion

        #region Constructor(s)

        private Settings(string settingsFilePath)
        {
            try
            {
                _settingsDir = Path.GetDirectoryName(settingsFilePath);
                Logger.LogException("Settings", string.Format("Loading RSBuild settings from '{0}'", settingsFilePath));
                XmlDocument d = LoadSettings(settingsFilePath);
                ReadSettings(d);
            }
            catch (Exception e)
            {
                Logger.LogException("Settings", e);
                throw;
            }
        }

        #endregion

        #region Private methods

        private static XmlSchema LoadSettingsSchema()
        {
            Type type = typeof(Settings);
            using (Stream stream = type.Assembly.GetManifestResourceStream(type, "RSBuild.xsd"))
            {
                return XmlSchema.Read(stream, null);
            }
        }

        private XmlDocument LoadSettings(string settingsFilePath)
        {
            XmlSchemaSet xmlSchemas = new XmlSchemaSet { };
            xmlSchemas.Add(LoadSettingsSchema());

            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings()
            {
                CloseInput = true,
                ConformanceLevel = ConformanceLevel.Document,
                ValidationType = ValidationType.Schema,
                ValidationFlags =
                    XmlSchemaValidationFlags.ReportValidationWarnings 
                    | XmlSchemaValidationFlags.ProcessIdentityConstraints,
                Schemas = xmlSchemas
            };

            int errorCount = 0;
            xmlReaderSettings.ValidationEventHandler += (sender, e) =>
            {
                Logger.LogMessage(string.Format(
                    "  [Ln {0} Col {1}] {2}",
                    e.Exception.LineNumber,
                    e.Exception.LinePosition,
                    e.Exception.Message));
                if (e.Severity == XmlSeverityType.Error) errorCount++;
            };

            using (FileStream fileStream = File.OpenRead(settingsFilePath))
            using (XmlReader xmlReader = XmlReader.Create(fileStream, xmlReaderSettings))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlReader);

                if (errorCount > 0)
                {
                    throw new XmlException(string.Format(
                        "{0} XML schema validation errors found in RSBuild settings.", 
                        errorCount));
                }

                return xmlDocument;
            }
        }


        private void ReadSettings(XmlDocument d)
        {
            // Globals
            XmlNodeList list5 = d.SelectNodes("//Settings/Globals/Global");
            _globalVariables = new StringDictionary();

            if (list5 != null)
            {
                foreach (XmlNode node in list5)
                {
                    XmlNode key = node.Attributes["Name"];
                    if (key != null)
                    {
                        if (_globalVariables.ContainsKey(key.Value))
                        {
                            _globalVariables[key.Value] = node.InnerText;
                        }
                        else
                        {
                            _globalVariables.Add(key.Value, node.InnerText);
                        }
                    }
                }
            }

            // ReportServers
            XmlNodeList list6 = d.SelectNodes("//Settings/ReportServers/ReportServer");
            if (list6 != null)
            {
                _reportServers = new Hashtable();
                foreach (XmlNode node in list6)
                {
                    XmlNode n0 = node.Attributes["Name"];
                    if (n0 != null)
                    {
                        string name = ProcessGlobals(n0.Value);
                        XmlNode rsHost = node.Attributes["Host"];
                        XmlNode rsPath = node.Attributes["Path"];
                        if (rsHost != null && rsPath != null)
                        {
                            XmlNode rsProtocol = node.Attributes["Protocol"];
                            string protocol = rsProtocol != null
                                ? ProcessGlobals(rsProtocol.Value)
                                : "http";

                            XmlNode rsTimeout = node.Attributes["Timeout"];
                            string timeout = rsTimeout != null
                                ? ProcessGlobals(rsTimeout.Value)
                                : null;

                            XmlNode rsUserName = node.Attributes["UserName"];
                            string userName = rsUserName != null && rsUserName.Value.Trim().Length > 0
                                ? ProcessGlobals(rsUserName.Value)
                                : null;

                            XmlNode rsPassword = node.Attributes["Password"];
                            string password = rsPassword != null
                                ? ProcessGlobals(rsPassword.Value)
                                : null;

                            ReportServerInfo rsInfo = new ReportServerInfo(name, protocol, ProcessGlobals(rsHost.Value), ProcessGlobals(rsPath.Value), timeout, userName, password);
                            if (_reportServers.ContainsKey(name))
                            {
                                _reportServers[name] = rsInfo;
                            }
                            else
                            {
                                _reportServers.Add(name, rsInfo);
                            }
                        }
                    }
                }
            }

            // DataSources
            XmlNodeList list1 = d.SelectNodes("//Settings/DataSources/DataSource");
            if (list1 != null)
            {
                _dataSources = new Hashtable();
                _dbConnections = new StringDictionary();
                foreach (XmlNode node in list1)
                {
                    XmlNode nameAttribute = node.Attributes["Name"];
                    if (nameAttribute != null)
                    {
                        XmlNode publishAttribute = node.Attributes["Publish"];
                        XmlNode extensionElement = node.SelectSingleNode("Extension");
                        XmlNode connectionStringElement = node.SelectSingleNode("ConnectionString");
                        XmlNode overwriteAttribute = node.Attributes["Overwrite"];
                        XmlNode userNameElement = node.SelectSingleNode("UserName");
                        XmlNode passwordElement = node.SelectSingleNode("Password");
                        XmlNode credentialRetrievalElement = node.SelectSingleNode("CredentialRetrieval");
                        XmlNode windowsCredentialsElement = node.SelectSingleNode("WindowsCredentials");
                        XmlNode targetFolderElement = node.Attributes["TargetFolder"];
                        XmlNode reportServerAttribute = node.Attributes["ReportServer"];

                        string name = nameAttribute.Value;
                        bool publish = publishAttribute != null
                            && Convert.ToBoolean(publishAttribute.Value, CultureInfo.InvariantCulture);
                        bool overwrite = overwriteAttribute != null
                            && Convert.ToBoolean(overwriteAttribute.Value, CultureInfo.InvariantCulture);

                        string extension = extensionElement != null
                           ? ProcessGlobals(extensionElement.InnerText)
                           : null;
                        string connectionString = connectionStringElement != null
                           ? ProcessGlobals(connectionStringElement.InnerText)
                           : null;
                        string userName = userNameElement != null
                            ? ProcessGlobals(userNameElement.InnerText).Trim()
                            : null;
                        string password = passwordElement != null
                            ? ProcessGlobals(passwordElement.InnerText)
                            : null;

                        string credentialRetrieval = credentialRetrievalElement != null
                            ? ProcessGlobals(credentialRetrievalElement.InnerText)
                            : null;
                        bool windowsCredentials = windowsCredentialsElement != null
                            && Convert.ToBoolean(windowsCredentialsElement.Value, CultureInfo.InvariantCulture);

                        string targetFolder = targetFolderElement != null
                            ? ProcessGlobals(targetFolderElement.Value)
                            : null;
                        string reportServer = reportServerAttribute != null
                            ? ProcessGlobals(reportServerAttribute.Value)
                            : null;

                        ReportServerInfo reportServerInfo = reportServer != null && ReportServers.ContainsKey(reportServer)
                            ? (ReportServerInfo)ReportServers[reportServer]
                            : null;
                        DataSource dataSource = new DataSource(name, 
                            userName, password, credentialRetrieval, windowsCredentials, 
                            extension, connectionString, publish, overwrite, 
                            targetFolder, reportServerInfo);
                        _dataSources[name] = dataSource;
                        
                        string dbConnectionString;
                        if (dataSource.TryGetDbConnectionString(out dbConnectionString))
                        {
                            _dbConnections[name] = dbConnectionString;
                        }
                    }
                }
            }

            // Reports
            XmlNodeList list7 = d.SelectNodes("//Settings/Reports/ReportGroup");
            int k = 0;
            if (list7 != null)
            {
                _reportGroups = new ReportGroup[list7.Count];
                foreach (XmlNode node in list7)
                {
                    string rgName = null;
                    string targetFolder = null;
                    string dataSourceName = null;
                    string reportServer = null;
                    int cacheTime = -1;
                    Report[] reports = null;

                    XmlNode n1 = node.Attributes["Name"];
                    XmlNode n2 = node.Attributes["DataSourceName"];
                    XmlNode n3 = node.Attributes["TargetFolder"];
                    XmlNode n4 = node.Attributes["ReportServer"];
                    XmlNode n14 = node.Attributes["CacheTime"];
                    if (n2 != null && n3 != null && n4 != null)
                    {
                        dataSourceName = ProcessGlobals(n2.Value);
                        targetFolder = ProcessGlobals(n3.Value);
                        reportServer = ProcessGlobals(n4.Value);
                        if (n1 != null)
                        {
                            rgName = ProcessGlobals(n1.Value);
                        }
                        if (n14 != null)
                        {
                            cacheTime = int.Parse(ProcessGlobals(n14.Value));
                        }

                        XmlNodeList list2 = node.SelectNodes("Report");
                        int i = 0;
                        if (list2 != null)
                        {
                            reports = new Report[list2.Count];
                            foreach (XmlNode node1 in list2)
                            {
                                string rpName = null;
                                string collapsedHeight = null;
                                int reportCacheTime = cacheTime;
                                XmlNode n11 = node1.SelectSingleNode("FilePath");

                                if (n11 != null)
                                {
                                    XmlNode n12 = node1.Attributes["Name"];
                                    XmlNode n13 = node1.Attributes["CollapsedHeight"];
                                    XmlNode n15 = node1.Attributes["CacheTime"];
                                    if (n12 != null)
                                    {
                                        rpName = ProcessGlobals(n12.Value);
                                    }
                                    if (n13 != null)
                                    {
                                        collapsedHeight = ProcessGlobals(n13.Value);
                                    }
                                    if (n15 != null)
                                    {
                                        reportCacheTime = int.Parse(ProcessGlobals(n15.Value));
                                    }

                                    reports[i] = new Report(rpName, GetFilePath(n11.InnerText), collapsedHeight, reportCacheTime);
                                }

                                i++;
                            }
                        }

                        _reportGroups[k] = CreateReportGroup(rgName, targetFolder, dataSourceName, reportServer, reports);
                    }
                    k++;
                }
            }

            // Executions
            XmlNodeList list3 = d.SelectNodes("//Settings/DBExecutions/DBExecution");
            int j = 0;
            if (list3 != null)
            {
                _dbExecutions = new DBExecution[list3.Count];
                foreach (XmlNode node in list3)
                {
                    XmlNode dataSourceName = node.Attributes["DataSourceName"];

                    if (dataSourceName != null)
                    {
                        StringCollection files = null;
                        XmlNodeList list4 = node.SelectNodes("DBFilePath");
                        if (list4 != null)
                        {
                            files = new StringCollection();
                            foreach (XmlNode node1 in list4)
                            {
                                files.Add(ProcessGlobals(node1.InnerText));
                            }
                        }

                        _dbExecutions[j] = CreateDbExecution(ProcessGlobals(dataSourceName.Value), files);
                    }

                    j++;
                }
            }
        }

        private ReportGroup CreateReportGroup(string name, string targetFolder, string dataSourceName, string reportServer, Report[] reports)
        {
            DataSource dataSource = dataSourceName != null && DataSources.ContainsKey(dataSourceName)
                ? (DataSource)DataSources[dataSourceName]
                : null;
            ReportServerInfo reportServerInfo = reportServer != null && ReportServers.ContainsKey(reportServer)
                ? (ReportServerInfo)ReportServers[reportServer]
                : null;

            return new ReportGroup(name, targetFolder, dataSource, reportServerInfo, reports);
        }

        private DBExecution CreateDbExecution(string dataSourceName, StringCollection files)
        {
            DataSource dataSource = dataSourceName != null && DataSources.ContainsKey(dataSourceName)
                ? (DataSource) DataSources[dataSourceName]
                : null;

            StringCollection filePaths = null;
            if (files != null)
            {
                filePaths = new StringCollection();
                foreach (string file in files)
                {
                    filePaths.Add(GetFilePath(file.Trim()));
                }
            }

            return new DBExecution(dataSource, filePaths);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the data sources.
        /// </summary>
        /// <value>The data sources.</value>
        public Hashtable DataSources
        {
            get { return _dataSources; }
        }

        /// <summary>
        /// Gets the report groups.
        /// </summary>
        /// <value>The report groups.</value>
        public ReportGroup[] ReportGroups
        {
            get { return _reportGroups; }
        }

        /// <summary>
        /// Gets the DB executions.
        /// </summary>
        /// <value>The DB executions.</value>
        public DBExecution[] DBExecutions
        {
            get { return _dbExecutions; }
        }

        /// <summary>
        /// Gets the DB connections.
        /// </summary>
        /// <value>The DB connections.</value>
        public StringDictionary DBConnections
        {
            get { return _dbConnections; }
        }

        /// <summary>
        /// Gets the global variables.
        /// </summary>
        /// <value>The global variables.</value>
        public StringDictionary GlobalVariables
        {
            get { return _globalVariables; }
        }

        /// <summary>
        /// Gets the report servers.
        /// </summary>
        /// <value>The report servers.</value>
        public Hashtable ReportServers
        {
            get { return _reportServers; }
        }

        #endregion

        #region Public methods

        public string GetFilePath(string fileName)
        {
            return Path.IsPathRooted(fileName)
               ? fileName
               : Path.Combine(_settingsDir, fileName);
        }

        /// <summary>
        /// Processes the globals.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public string ProcessGlobals(string input)
        {
            return GlobalsRegex.Replace(input, new MatchEvaluator(ReplaceMatches));
        }

        private string ReplaceMatches(Match match)
        {
            string key = match.Groups["k"].ToString();
            string toReplace = match.Groups["g"].ToString();
            string output = toReplace;
            if (_globalVariables.ContainsKey(key))
            {
                output = _globalVariables[key];
            }

            return output;
        }

        /// <summary>
        /// Gets the logo banner.
        /// </summary>
        /// <value>The logo banner.</value>
        public static string LogoBanner
        {
            get
            {
                string productName;
                Version assemblyVersion;
                string copyrightInformation = null;
                string companyInformation = null;

                Assembly assembly = DefaultAssembly;

                // get product name
                object[] productAttributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (productAttributes.Length > 0)
                {
                    AssemblyProductAttribute productAttribute = (AssemblyProductAttribute)productAttributes[0];
                    productName = productAttribute.Product;
                }
                else
                {
                    productName = assembly.GetName().Name;
                }

                // get assembly version 
                assemblyVersion = assembly.GetName().Version;

                // get copyright information
                object[] copyrightAttributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (copyrightAttributes.Length > 0)
                {
                    AssemblyCopyrightAttribute copyrightAttribute = (AssemblyCopyrightAttribute)copyrightAttributes[0];
                    copyrightInformation = copyrightAttribute.Copyright;
                }

                // get company information
                object[] companyAttributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (companyAttributes.Length > 0)
                {
                    AssemblyCompanyAttribute companyAttribute = (AssemblyCompanyAttribute)companyAttributes[0];
                    companyInformation = companyAttribute.Company;
                }

                StringBuilder logoBanner = new StringBuilder();

                logoBanner.AppendFormat(CultureInfo.InvariantCulture,
                    "{0} {1}", productName, assemblyVersion.ToString(3));

                // output copyright information
                if (!string.IsNullOrEmpty(copyrightInformation))
                {
                    logoBanner.Append(Environment.NewLine);
                    logoBanner.Append(copyrightInformation);
                }

                // output company information
                if (!string.IsNullOrEmpty(companyInformation))
                {
                    logoBanner.Append(Environment.NewLine);
                    logoBanner.Append(companyInformation);
                }

                return logoBanner.ToString();
            }
        }

        #endregion
    }
}
