using System;

namespace RSBuild
{
	/// <summary>
	/// Represents info about the report server.
	/// </summary>
	[Serializable]
	public class ReportServerInfo
	{
		private string _Name;
		private string _Protocol;
		private string _Host;
		private string _Path;
		private int _Timeout;
		private string _UserName;
		private string _Password;

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
        /// Gets the protocol.
        /// </summary>
        /// <value>The protocol.</value>
		public string Protocol
		{
			get
			{
				return _Protocol;
			}
		}

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>The host.</value>
		public string Host
		{
			get
			{
				return _Host;
			}
		}

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
		public string Path
		{
			get
			{
				return _Path;
			}
		}

        /// <summary>
        /// Gets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
		public int Timeout
		{
			get
			{
				return _Timeout;
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
        /// Gets the service URL.
        /// </summary>
        /// <value>The service URL.</value>
		public string ServiceUrl
		{
			get
			{
				return string.Format("{0}://{1}/{2}/ReportService.asmx", _Protocol, _Host, _Path);
			}
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
			_Name = name;
			_Protocol = protocol;
			_Host = host;
			_Path = path;
			_UserName = userName;
			_Password = password;
			try
			{
				_Timeout = Convert.ToInt32(timeout, 10);
				if (_Timeout < 0)
				{
					throw new Exception("Invalid timeout value");
				}
				_Timeout *= 0x3e8;
			}
			catch (Exception e)
			{
				Logger.LogException("ReportServerInfo", e);
			}
		}
	}
}
