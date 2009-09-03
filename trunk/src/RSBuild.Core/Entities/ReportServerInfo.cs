namespace RSBuild.Entities
{
    using System;
    using System.Net;

    /// <summary>
	/// Represents info about the report server.
	/// </summary>
	[Serializable]
	public class ReportServerInfo
	{
		private readonly string _name;
        private readonly string _protocol;
        private readonly string _host;
        private readonly string _path;
        private readonly int? _timeout;
        private readonly string _userName;
        private readonly string _password;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
		public string Name
		{
			get { return _name; }
		}

        /// <summary>
        /// Gets the protocol.
        /// </summary>
        /// <value>The protocol.</value>
		public string Protocol
		{
			get { return _protocol; }
		}

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>The host.</value>
		public string Host
		{
			get { return _host; }
		}

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
		public string Path 
        {
			get { return _path; }
		}

        /// <summary>
        /// Gets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
		public int? Timeout
		{
			get { return _timeout; }
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
        /// Gets the service URL base.
        /// </summary>
        /// <value>The service URL.</value>
        public string ServiceBaseUrl
        {
            get { return string.Format("{0}://{1}/{2}/", this.Protocol, this.Host, this.Path); }
        }

        /// <summary>
        /// Gets the service URL.
        /// </summary>
        /// <value>The service URL.</value>
		public string GetServiceUrl(string serviceName)
		{
            return this.ServiceBaseUrl + serviceName;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportServerInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="host">The host.</param>
        /// <param name="path">The path.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
		public ReportServerInfo(string name, string protocol, string host, string path, string timeout, string userName, string password)
		{
			_name = name;
			_protocol = protocol;
			_host = host;
			_path = path;
			_userName = userName;
			_password = password;
			try
			{
				_timeout = string.IsNullOrEmpty(timeout) 
                    ? default(int?)
                    : Convert.ToInt32(timeout, 10) * 0x3e8;
				if (_timeout.HasValue && _timeout.Value < 0)
				{
					throw new ArgumentException("Timeout must be greater than or equal to zero");
				}
			}
			catch (Exception e)
			{
				Logger.LogException("ReportServerInfo", e);
			}
		}

        public ICredentials CreateCredentials(string serviceName)
        {
            if (this.UserName == null)
            {
                return CredentialCache.DefaultCredentials;
            }

            string username = this.UserName;
            string domain = string.Empty;

            int index = username.IndexOf('\\');
            if (index > 0)
            {
                domain = username.Substring(0, index);
                username = username.Substring(index + 1);
                if (domain == ".")
                {
                    domain = string.Empty;
                }
            }

            NetworkCredential credential = new NetworkCredential(username, this.Password, domain);
            Uri uri = new Uri(this.GetServiceUrl(serviceName));
            CredentialCache cache = new CredentialCache();
            cache.Add(uri, "NTLM", credential);
            cache.Add(uri, "BASIC", credential);
            return cache;
        }
    }
}
