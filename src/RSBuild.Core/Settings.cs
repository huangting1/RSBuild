namespace RSBuild
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;
    using RSBuild.Entities;

    /// <summary>
    /// The config settings.
    /// </summary>
    public sealed class Settings
    {
        #region Static fields/properties

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
        
        private readonly IDictionary<string, ReportServerInfo> _reportServers = new Dictionary<string, ReportServerInfo>();
        private readonly IDictionary<string, DataSource> _dataSources = new Dictionary<string, DataSource>();
        private readonly IList<ReportGroup> _reportGroups = new List<ReportGroup>();
        private readonly IList<DbExecution> _dbExecutions = new List<DbExecution>();
        private readonly IDictionary<string, string> _dbConnections = new Dictionary<string, string>();
        private readonly GlobalVariableDictionary _globalVariables = new GlobalVariableDictionary();

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

        private static XmlDocument LoadSettings(string settingsFilePath)
        {
            XmlSchemaSet xmlSchemas = new XmlSchemaSet();
            xmlSchemas.Add(LoadSettingsSchema());

            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
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
            XmlNodeList globalVariableNodes = d.SelectNodes("//Settings/Globals/Global");
            if (globalVariableNodes != null)
            {
                foreach (XmlNode node in globalVariableNodes)
                {
                    XmlNode key = node.Attributes["Name"];
                    if (key != null)
                    {
                        _globalVariables[key.Value] = node.InnerText;
                    }
                }
            }

            // ReportServers
            XmlNodeList reportServerNodes = d.SelectNodes("//Settings/ReportServers/ReportServer");
            if (reportServerNodes != null)
            {
                foreach (XmlNode node in reportServerNodes)
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

                            _reportServers[name] = new ReportServerInfo(name, protocol, ProcessGlobals(rsHost.Value), ProcessGlobals(rsPath.Value), timeout, userName, password);
                        }
                    }
                }
            }

            // DataSources
            XmlNodeList dataSourceNodes = d.SelectNodes("//Settings/DataSources/DataSource");
            if (dataSourceNodes != null)
            {
                foreach (XmlNode node in dataSourceNodes)
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
                            ? PathUtil.FormatPath(ProcessGlobals(targetFolderElement.Value))
                            : null;
                        string reportServer = reportServerAttribute != null
                            ? ProcessGlobals(reportServerAttribute.Value)
                            : null;

                        ReportServerInfo reportServerInfo = reportServer != null && ReportServers.ContainsKey(reportServer)
                            ? ReportServers[reportServer]
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
            XmlNodeList reportGroupNodes = d.SelectNodes("//Settings/Reports/ReportGroup");
            if (reportGroupNodes != null)
            {
                foreach (XmlNode node in reportGroupNodes)
                {
                    XmlNode n1 = node.Attributes["Name"];
                    XmlNode n2 = node.Attributes["DataSourceName"];
                    XmlNode n3 = node.Attributes["TargetFolder"];
                    XmlNode n4 = node.Attributes["ReportServer"];
                    XmlNode n14 = node.Attributes["CacheTime"];
                    if (n2 != null && n3 != null && n4 != null)
                    {
                        string rgName = null;
                        string dataSourceName = ProcessGlobals(n2.Value);
                        string targetFolder = PathUtil.FormatPath(ProcessGlobals(n3.Value));
                        string reportServer = ProcessGlobals(n4.Value);
                        int cacheTime = -1;

                        if (n1 != null)
                        {
                            rgName = ProcessGlobals(n1.Value);
                        }
                        if (n14 != null)
                        {
                            cacheTime = int.Parse(ProcessGlobals(n14.Value));
                        }

                        _reportGroups.Add(
                            CreateReportGroup(rgName, targetFolder, dataSourceName, reportServer, 
                                SelectReports(node, targetFolder, cacheTime)));
                    }
                }
            }

            // Executions
            XmlNodeList dbExecutionNodes = d.SelectNodes("//Settings/DBExecutions/DBExecution");
            if (dbExecutionNodes != null)
            {
                foreach (XmlNode node in dbExecutionNodes)
                {
                    XmlNode dataSourceName = node.Attributes["DataSourceName"];

                    if (dataSourceName != null)
                    {
                        _dbExecutions.Add(CreateDbExecution(
                            ProcessGlobals(dataSourceName.Value), 
                            SelectDbFilePaths(node)));
                    }
                }
            }
        }

        private string ProcessGlobals(string input)
        {
            return _globalVariables.ReplaceVariables(input);
        }

        private ReportGroup CreateReportGroup(string name, string targetFolder, string dataSourceName, string reportServer, IEnumerable<Report> reports)
        {
            DataSource dataSource = dataSourceName != null && DataSources.ContainsKey(dataSourceName)
                ? DataSources[dataSourceName]
                : null;
            ReportServerInfo reportServerInfo = reportServer != null && ReportServers.ContainsKey(reportServer)
                ? ReportServers[reportServer]
                : null;

            return new ReportGroup(name, targetFolder, dataSource, reportServerInfo, reports);
        }

        private IEnumerable<Report> SelectReports(XmlNode reportGroupNode, string targetFolder, int defaultCacheTime)
        {
            XmlNodeList reportNodes = reportGroupNode.SelectNodes("Report");
            if (reportNodes != null)
            {
                foreach (XmlNode reportNode in reportNodes)
                {
                    string rpName = null;
                    string collapsedHeight = null;
                    int reportCacheTime = defaultCacheTime;
                    XmlNode filePathNode = reportNode.SelectSingleNode("FilePath");

                    if (filePathNode != null)
                    {
                        XmlNode nameNode = reportNode.Attributes["Name"];
                        XmlNode collapsedHeightNode = reportNode.Attributes["CollapsedHeight"];
                        XmlNode cacheTimeNode = reportNode.Attributes["CacheTime"];
                        if (nameNode != null)
                        {
                            rpName = ProcessGlobals(nameNode.Value);
                        }
                        if (collapsedHeightNode != null)
                        {
                            collapsedHeight = ProcessGlobals(collapsedHeightNode.Value);
                        }
                        if (cacheTimeNode != null)
                        {
                            reportCacheTime = int.Parse(ProcessGlobals(cacheTimeNode.Value));
                        }

                        var report = new Report(rpName, targetFolder, LoadReportDefinition(filePathNode.InnerText))
                        {
                            CacheOption = reportCacheTime > 0
                                ? new CacheOption(reportCacheTime)
                                : null
                        };
                        if (collapsedHeight != null)
                        {
                            report.BodyHeight = collapsedHeight;
                        }
                        yield return report;
                    }
                }
            }
        }

        private XmlReader LoadReportDefinition(string reportFilePath)
        {
            using (StreamReader reader = File.OpenText(reportFilePath))
            {
                string reportDefinition = _globalVariables.ReplaceVariables(reader.ReadToEnd());
                return XmlReader.Create(new StringReader(reportDefinition));
            }
        }

        private DbExecution CreateDbExecution(string dataSourceName, IEnumerable<string> filePaths)
        {
            DataSource dataSource = dataSourceName != null && DataSources.ContainsKey(dataSourceName)
                ? DataSources[dataSourceName]
                : null;
            return new DbExecution(dataSource, filePaths);
        }

        private IEnumerable<string> SelectDbFilePaths(XmlNode dbExecutionElement)
        {
            XmlNodeList dbFilePathNodes = dbExecutionElement.SelectNodes("DBFilePath");
            if (dbFilePathNodes != null)
            {
                foreach (XmlNode dbFilePathNode in dbFilePathNodes)
                {
                    string dbFilePath = ProcessGlobals(dbFilePathNode.InnerText);
                    yield return GetFilePath(dbFilePath.Trim());
                }
            }
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the data sources.
        /// </summary>
        /// <value>The data sources.</value>
        public IDictionary<string, DataSource> DataSources
        {
            get { return _dataSources; }
        }

        /// <summary>
        /// Gets the report groups.
        /// </summary>
        /// <value>The report groups.</value>
        public IList<ReportGroup> ReportGroups
        {
            get { return _reportGroups; }
        }

        /// <summary>
        /// Gets the DB executions.
        /// </summary>
        /// <value>The DB executions.</value>
        public IList<DbExecution> DbExecutions
        {
            get { return _dbExecutions; }
        }

        /// <summary>
        /// Gets the DB connections.
        /// </summary>
        /// <value>The DB connections.</value>
        public IDictionary<string, string> DbConnections
        {
            get { return _dbConnections; }
        }

        /// <summary>
        /// Gets the global variables.
        /// </summary>
        /// <value>The global variables.</value>
        public GlobalVariableDictionary GlobalVariables
        {
            get { return _globalVariables; }
        }

        /// <summary>
        /// Gets the report servers.
        /// </summary>
        /// <value>The report servers.</value>
        public IDictionary<string, ReportServerInfo> ReportServers
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
        /// Gets the logo banner.
        /// </summary>
        /// <value>The logo banner.</value>
        public static string LogoBanner
        {
            get
            {
                string productName;
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
                Version assemblyVersion = assembly.GetName().Version;

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
