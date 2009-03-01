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

    /// <summary>
	/// The config settings.
	/// </summary>
	public sealed class Settings
	{
		private static readonly string _CurrentDiretory;
		private static readonly Assembly _Assembly;
		private static Hashtable _ReportServers;
		private static Hashtable _DataSources;
		private static ReportGroup[] _ReportGroups;
		private static DBExecution[] _DBExecutions;
		private static StringDictionary _DBConnections;
		private static StringDictionary _GlobalVariables;
		private static string _ConfigFilePath;
		private static readonly Regex GlobalsRegex = new Regex(@"(?<g>\${(?<k>[^}]+)})", RegexOptions.Compiled|RegexOptions.IgnoreCase);

        /// <summary>
        /// Initializes the <see cref="Settings"/> class.
        /// </summary>
		static Settings()
		{
			_CurrentDiretory = Environment.CurrentDirectory;
			_Assembly = Assembly.GetEntryAssembly();
			if (_Assembly == null) 
			{
				_Assembly = Assembly.GetCallingAssembly();
			}
			_ConfigFilePath = string.Format("{0}{1}.config", CurrentDiretory, _Assembly.GetName().Name);
		}

        /// <summary>
        /// Inits this instance.
        /// </summary>
        /// <returns></returns>
		public static bool Init()
		{
			XmlDocument d = null;
			try
			{
				FileInfo f = new FileInfo( ConfigFilePath );
				using (FileStream reader = f.OpenRead())
				{
					d = new XmlDocument();
					d.Load(reader);
				}
			}
			catch (Exception e)
			{
				Logger.LogException("Settings", e.Message);
			}

			if (d != null)
			{
				// Globals
				XmlNodeList list5 = d.SelectNodes("//Settings/Globals/Global");
				_GlobalVariables = new StringDictionary();

				if (list5 != null)
				{
					foreach (XmlNode node in list5) 
					{
						XmlNode key = node.Attributes["Name"];
						if (key != null)
						{
							if (_GlobalVariables.ContainsKey(key.Value))
							{
								_GlobalVariables[key.Value] = node.InnerText;
							}
							else
							{
								_GlobalVariables.Add(key.Value, node.InnerText);
							}
						}
					}
				}

				// ReportServers
				XmlNodeList list6 = d.SelectNodes("//Settings/ReportServers/ReportServer");
				if (list6 != null)
				{
					_ReportServers = new Hashtable();
					foreach(XmlNode node in list6)
					{
						XmlNode n0 = node.Attributes["Name"];
						if (n0 != null)
						{
							string name = ProcessGlobals(n0.Value);
							XmlNode rsHost =node.Attributes["Host"];
							XmlNode rsPath =node.Attributes["Path"];
                            if (rsHost != null && rsPath != null)
							{
                                XmlNode rsProtocol =node.Attributes["Protocol"];
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
								
                                XmlNode rsPassword =node.Attributes["Password"];
                                string password = rsPassword != null
                                    ? ProcessGlobals(rsPassword.Value)
                                    : null;

                                ReportServerInfo rsInfo = new ReportServerInfo(name, protocol, ProcessGlobals(rsHost.Value), ProcessGlobals(rsPath.Value), timeout, userName, password);
								if (_ReportServers.ContainsKey(name))
								{
                                    _ReportServers[name] = rsInfo;
								}
								else
								{
									_ReportServers.Add(name, rsInfo);
								}
							}
						}
					}
				}

				// DataSources
				XmlNodeList list1 = d.SelectNodes("//Settings/DataSources/DataSource");
				if (list1 != null)
				{
					_DataSources = new Hashtable();
					_DBConnections = new StringDictionary();
					foreach (XmlNode node in list1) 
					{
						string name = null;
						string userName = null;
						string password = null;
						string credentialRetrieval = null;
						string connectionString = null;
						string targetFolder = null;
						string reportServer = null;
						bool publish = false;
						bool overwrite = false;
						bool windowsCredentials = false;

						XmlNode n1 = node.Attributes["Name"];

						if (n1 != null)
						{
							name = n1.Value;
							XmlNode n2 = node.Attributes["Publish"];
							XmlNode n3 = node.SelectSingleNode("ConnectionString");
							XmlNode n4 = node.Attributes["Overwrite"];
							XmlNode n5 = node.SelectSingleNode("UserName");
							XmlNode n6 = node.SelectSingleNode("Password");
							XmlNode n7 = node.SelectSingleNode("CredentialRetrieval");
							XmlNode n8 = node.SelectSingleNode("WindowsCredentials");
							XmlNode n9 = node.Attributes["TargetFolder"];
							XmlNode n10 = node.Attributes["ReportServer"];
							
							if (n2 != null)
							{
								publish = (n2.Value.ToLower() == "true");
							}
							if (n3 != null)
							{
								connectionString = ProcessGlobals(n3.InnerText);
							}
							if (n4 != null)
							{
								overwrite = (n4.Value.ToLower() == "true");
							}
							if (n5 != null)
							{
								if (n5.InnerText.Trim().Length > 0)
								{
									userName = ProcessGlobals(n5.InnerText);
								}
							}
							if (n6 != null)
							{
								password = ProcessGlobals(n6.InnerText);
							}
							if (n7 != null)
							{
								credentialRetrieval = ProcessGlobals(n7.InnerText);
							}
							if (n8 != null)
							{
								windowsCredentials = (n8.InnerText.ToLower() == "true");
							}
							if (n9 != null)
							{
								targetFolder = ProcessGlobals(n9.Value);
							}
							if (n10 != null)
							{
								reportServer = ProcessGlobals(n10.Value);
							}

							if (_DataSources.ContainsKey(name))
							{
								_DataSources[name] = new DataSource(name, userName, password, credentialRetrieval, windowsCredentials, connectionString, publish, overwrite, targetFolder, reportServer);
								_DBConnections[name] = ((DataSource)_DataSources[name]).ConnectionString;
							}
							else
							{
								_DataSources.Add(name, new DataSource(name, userName, password, credentialRetrieval, windowsCredentials, connectionString, publish, overwrite, targetFolder, reportServer));
								_DBConnections.Add(name, ((DataSource)_DataSources[name]).ConnectionString);
							}
						}
					}
				}

				// Reports
				XmlNodeList list7 = d.SelectNodes("//Settings/Reports/ReportGroup");
				int k = 0;
				if (list7 != null)
				{
					_ReportGroups = new ReportGroup[list7.Count];
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

										reports[i] = new Report(rpName, string.Format("{0}{1}", Settings.CurrentDiretory, n11.InnerText), collapsedHeight, reportCacheTime);
									}

									i++;
								}
							}

							_ReportGroups[k] = new ReportGroup(rgName, targetFolder, dataSourceName, reportServer, reports);
						}
						k++;
					}
				}

				// Executions
				XmlNodeList list3 = d.SelectNodes("//Settings/DBExecutions/DBExecution");
				int j = 0;
				if (list3 != null)
				{
					_DBExecutions = new DBExecution[list3.Count];
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

							_DBExecutions[j] = new DBExecution(ProcessGlobals(dataSourceName.Value), files);
						}

						j++;
					}
				}

				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// Gets the current diretory.
        /// </summary>
        /// <value>The current diretory.</value>
		public static string CurrentDiretory
		{
			get
			{
				return _CurrentDiretory.EndsWith("\\")? _CurrentDiretory : string.Format("{0}\\", _CurrentDiretory);
			}
		}

        /// <summary>
        /// Gets or sets the config file path.
        /// </summary>
        /// <value>The config file path.</value>
		public static string ConfigFilePath
		{
			get
			{
				return _ConfigFilePath;
			}
			set
			{
				_ConfigFilePath = string.Format("{0}{1}", CurrentDiretory, value);
			}
		}

        /// <summary>
        /// Gets the data sources.
        /// </summary>
        /// <value>The data sources.</value>
		public static Hashtable DataSources
		{
			get
			{				
				return _DataSources;
			}
		}

        /// <summary>
        /// Gets the report groups.
        /// </summary>
        /// <value>The report groups.</value>
		public static ReportGroup[] ReportGroups
		{
			get
			{				
				return _ReportGroups;
			}
		}

        /// <summary>
        /// Gets the DB executions.
        /// </summary>
        /// <value>The DB executions.</value>
		public static DBExecution[] DBExecutions
		{
			get
			{
				return _DBExecutions;
			}
		}

        /// <summary>
        /// Gets the DB connections.
        /// </summary>
        /// <value>The DB connections.</value>
		public static StringDictionary DBConnections
		{
			get
			{
				return _DBConnections;
			}
		}

        /// <summary>
        /// Gets the global variables.
        /// </summary>
        /// <value>The global variables.</value>
		public static StringDictionary GlobalVariables
		{
			get
			{
				return _GlobalVariables;
			}
		}

        /// <summary>
        /// Gets the report servers.
        /// </summary>
        /// <value>The report servers.</value>
		public static Hashtable ReportServers
		{
			get
			{
				return _ReportServers;
			}
		}

		private static string ReplaceMatches(Match match)
		{
			string key = match.Groups["k"].ToString();
			string toReplace = match.Groups["g"].ToString();
			string output = toReplace;
			if (_GlobalVariables.ContainsKey(key))
			{
				output = _GlobalVariables[key];
			}

			return output;
		}

        /// <summary>
        /// Processes the globals.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
		public static string ProcessGlobals(string input)
		{
			string output = input;
			MatchCollection matches = GlobalsRegex.Matches(input);
			output = GlobalsRegex.Replace(output, new MatchEvaluator(ReplaceMatches));

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

				Assembly assembly = _Assembly;

				// get product name
				object[] productAttributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (productAttributes.Length > 0) 
				{
					AssemblyProductAttribute productAttribute = (AssemblyProductAttribute) productAttributes[0];
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
					AssemblyCopyrightAttribute copyrightAttribute = (AssemblyCopyrightAttribute) copyrightAttributes[0];
					copyrightInformation = copyrightAttribute.Copyright;
				}

				// get company information
				object[] companyAttributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (companyAttributes.Length > 0) 
				{
					AssemblyCompanyAttribute companyAttribute = (AssemblyCompanyAttribute) companyAttributes[0];
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
	}
}
