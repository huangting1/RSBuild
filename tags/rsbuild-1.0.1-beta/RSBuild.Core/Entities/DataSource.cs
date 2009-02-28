using System;

using Microsoft.SqlServer.ReportingServices;

namespace RSBuild
{
	/// <summary>
	/// Represents a data source.
	/// </summary>
	[Serializable]
	public class DataSource
	{
		private string _Name;
		private string _UserName;
		private string _Password;
		private string _ConnectionString;
		private string _RSConnectionString;
		private CredentialRetrievalEnum _CredentialRetrieval;
		private bool _WindowsCredentials;
		private bool _Publish;
		private bool _Overwrite;
		private string _TargetFolder;
		private ReportServerInfo _ReportServer;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
		public string Name
		{
			get
			{
				return _Name;
			}
		}

        /// <summary>
        /// Gets the user name.
        /// </summary>
        /// <value>The user name.</value>
		public string UserName
		{
			get
			{
				return _UserName;
			}
		}

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>The password.</value>
		public string Password
		{
			get
			{
				return _Password;
			}
		}

        /// <summary>
        /// Gets the credential retrieval enum.
        /// </summary>
        /// <value>The credential retrieval enum.</value>
		public CredentialRetrievalEnum CredentialRetrieval
		{
			get
			{
				return _CredentialRetrieval;
			}
		}

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get
			{
				if (_RSConnectionString.EndsWith(";"))
				{
					_ConnectionString = _RSConnectionString.Substring(0, _RSConnectionString.Length-1);
				}
				else
				{
					_ConnectionString = _RSConnectionString;
				}
				if (_UserName != null)
				{
					_ConnectionString = string.Format("{0};uid={1};pwd={2}", _ConnectionString, _UserName, _Password);
					
				}
				else
				{
					if (_ConnectionString.ToLower().IndexOf("trusted_connection") < 0)
					{
						_ConnectionString = string.Format("{0};Trusted_Connection=yes", _ConnectionString);
					}
				}
				return _ConnectionString;
			}
		}

        /// <summary>
        /// Gets the connection string in RS desired format.
        /// </summary>
        /// <value>The connection string in RS desired format.</value>
		public string RSConnectionString
		{
			get
			{
				return _RSConnectionString;
			}
		}

        /// <summary>
        /// Gets a value indicating whether this <see cref="DataSource"/> should be published.
        /// </summary>
        /// <value><c>true</c> if published; otherwise, <c>false</c>.</value>
		public bool Publish
		{
			get
			{
				return _Publish;
			}
		}

        /// <summary>
        /// Gets a value indicating whether this <see cref="DataSource"/> should be overwritten.
        /// </summary>
        /// <value><c>true</c> if overwrite; otherwise, <c>false</c>.</value>
		public bool Overwrite
		{
			get
			{
				return _Overwrite;
			}
		}

        /// <summary>
        /// Gets a value indicating whether to use windows credentials.
        /// </summary>
        /// <value><c>true</c> if windows credentials; otherwise, <c>false</c>.</value>
		public bool WindowsCredentials
		{
			get
			{
				return _WindowsCredentials;
			}
		}

        /// <summary>
        /// Gets the target folder.
        /// </summary>
        /// <value>The target folder.</value>
		public string TargetFolder
		{
			get
			{
				return _TargetFolder;
			}
		}

        /// <summary>
        /// Gets the report server.
        /// </summary>
        /// <value>The report server.</value>
		public ReportServerInfo ReportServer
		{
			get
			{
				return _ReportServer;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSource"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <param name="credentialRetrieval">The credential retrieval enum.</param>
        /// <param name="windowsCredentials">if set to <c>true</c> [windows credentials].</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="publish">if set to <c>true</c>, publish.</param>
        /// <param name="overwrite">if set to <c>true</c>, overwrite.</param>
        /// <param name="targetFolder">The target folder.</param>
        /// <param name="reportServer">The report server.</param>
		public DataSource(string name, string userName, string password, string credentialRetrieval, bool windowsCredentials, string connectionString, bool publish, bool overwrite, string targetFolder, string reportServer)
		{
			_Name = name;
			_UserName = userName;
			_Password = password;
			_RSConnectionString = connectionString;
			_Publish = publish;
			_Overwrite = overwrite;
			if (targetFolder != null && targetFolder.Length > 0)
			{
				_TargetFolder = targetFolder.Trim();
			}
			if (reportServer != null)
			{
				if (Settings.ReportServers.ContainsKey(reportServer))
				{
					_ReportServer = (ReportServerInfo)Settings.ReportServers[reportServer];
				}
			}

			_CredentialRetrieval = CredentialRetrievalEnum.Integrated;
			if (credentialRetrieval != null)
			{
				try
				{
					_CredentialRetrieval = (CredentialRetrievalEnum)Enum.Parse(typeof(CredentialRetrievalEnum), credentialRetrieval, true);
				}
				catch(ArgumentException e)
				{
					Logger.LogException("DataSource", e.Message);
				}
			}

			_WindowsCredentials = windowsCredentials;
		}

	}
}
