namespace RSBuild.Entities
{
    using System;
    using System.Text;

    /// <summary>
	/// Represents a data source.
	/// </summary>
	[Serializable]
	public class DataSource
	{
        public const string DefaultExtension = "SQL";

        private readonly string _extension;
        private readonly string _name;
		private readonly string _userName;
		private readonly string _password;
		private readonly string _connectionString;
		private readonly ReportCredential _credentialRetrieval;
		private readonly bool _windowsCredentials;
		private readonly bool _publish;
		private readonly bool _overwrite;
		private readonly string _targetFolder;
		private readonly ReportServerInfo _reportServer;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
		public string Name
		{
			get { return _name; }
		}

        /// <summary>
        /// Gets the user name.
        /// </summary>
        /// <value>The user name.</value>
		public string UserName
		{
			get { return _userName; }
		}

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>The password.</value>
		public string Password
		{
			get { return _password; }
		}

        /// <summary>
        /// Gets the credential retrieval enum.
        /// </summary>
        /// <value>The credential retrieval enum.</value>
		public ReportCredential CredentialRetrieval
		{
			get { return _credentialRetrieval; }
		}

        public string Extension
        {
            get { return _extension; }
        }

        /// <summary>
        /// Gets the connection string in RS desired format.
        /// </summary>
        /// <value>The connection string in RS desired format.</value>
		public string ConnectionString
		{
			get { return _connectionString; }
		}

        /// <summary>
        /// Gets a value indicating whether this <see cref="DataSource"/> should be published.
        /// </summary>
        /// <value><c>true</c> if published; otherwise, <c>false</c>.</value>
		public bool Publish
		{
			get { return _publish; }
		}

        /// <summary>
        /// Gets a value indicating whether this <see cref="DataSource"/> should be overwritten.
        /// </summary>
        /// <value><c>true</c> if overwrite; otherwise, <c>false</c>.</value>
		public bool Overwrite
		{
			get { return _overwrite; }
		}

        /// <summary>
        /// Gets a value indicating whether to use windows credentials.
        /// </summary>
        /// <value><c>true</c> if windows credentials; otherwise, <c>false</c>.</value>
		public bool WindowsCredentials
		{
			get { return _windowsCredentials; }
		}

        /// <summary>
        /// Gets the target folder.
        /// </summary>
        /// <value>The target folder.</value>
		public string TargetFolder
		{
			get { return _targetFolder; }
		}

        /// <summary>
        /// Gets the report server.
        /// </summary>
        /// <value>The report server.</value>
		public ReportServerInfo ReportServer
		{
			get { return _reportServer; }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSource"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <param name="credentialRetrieval">The credential retrieval enum.</param>
        /// <param name="extension">The data source type.</param>
        /// <param name="windowsCredentials">if set to <c>true</c> [windows credentials].</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="publish">if set to <c>true</c>, publish.</param>
        /// <param name="overwrite">if set to <c>true</c>, overwrite.</param>
        /// <param name="targetFolder">The target folder.</param>
        /// <param name="reportServer">The report server.</param>
		public DataSource(string name, string userName, string password, string credentialRetrieval, bool windowsCredentials, string extension, string connectionString, bool publish, bool overwrite, string targetFolder, ReportServerInfo reportServer)
		{
			_name = name;
			_userName = string.IsNullOrEmpty(userName)
                ? null
                : userName.Trim();
			_password = password;
            _extension = string.IsNullOrEmpty(extension)
                ? DefaultExtension
                : extension;
			_connectionString = connectionString;
			_publish = publish;
			_overwrite = overwrite;

            _targetFolder = string.IsNullOrEmpty(targetFolder)
                ? targetFolder
                : targetFolder.Trim();

            _reportServer = reportServer;

			_credentialRetrieval = ReportCredential.Integrated;
			if (credentialRetrieval != null)
			{
				try
				{
					_credentialRetrieval = (ReportCredential)Enum.Parse(typeof(ReportCredential), credentialRetrieval, true);
				}
				catch(ArgumentException e)
				{
					Logger.LogException("DataSource", e.Message);
				}
			}

			_windowsCredentials = windowsCredentials;
		}

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public bool TryGetDbConnectionString(out string result)
        {
            const char SEPARATOR = ';';
            const string OPTION_UID = "uid";
            const string OPTION_PWD = "pwd";
            const string OPTION_TRUSTED_CONNECTION = "trusted_connection";

            if (_extension != DefaultExtension)
            {
                result = null;
                return false;
            }

            var sb = new StringBuilder(_connectionString);
            if (sb.Length > 0 && sb[sb.Length - 1] == SEPARATOR)
            {
                sb.Length -= 1;
            }
            if (_userName != null)
            {
                sb.Append(SEPARATOR).Append(OPTION_UID).Append('=').Append(_userName);
                sb.Append(SEPARATOR).Append(OPTION_PWD).Append('=').Append(_password);
            }
            if (_connectionString.IndexOf(OPTION_TRUSTED_CONNECTION, StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                sb.Append(SEPARATOR).Append(OPTION_TRUSTED_CONNECTION).Append("=yes");
            }

            result = sb.ToString();
            return true;
        }
	}
}
