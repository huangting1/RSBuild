namespace RSBuild
{
	using System;
	using System.Net;

	using Microsoft.SqlServer.ReportingServices;

    /// <summary>
    /// Proxy wrapper.
    /// </summary>
	public class WSWrapper : ReportingService
	{
		// Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="WSWrapper"/> class.
        /// </summary>
        /// <param name="reportServer">The report server.</param>
		public WSWrapper(ReportServerInfo reportServer)
		{
			base.Url = reportServer.ServiceUrl;
			if (reportServer.Timeout == 0)
			{
				base.Timeout = -1;
			}
			else
			{
				base.Timeout = reportServer.Timeout;
			}
			if (reportServer.UserName == null)
			{
				base.Credentials = CredentialCache.DefaultCredentials;
			}
			else
			{
				string username = reportServer.UserName;
				string domain = "";
                int index = username.IndexOf('\\');
                if (index > 0)
				{
                    domain = username.Substring(0, index);
                    username = username.Substring(index + 1);
                    if (domain == ".")
					{
                        domain = "";
					}
				}
                NetworkCredential credential = new NetworkCredential(username, reportServer.Password, domain);
				Uri uri = new Uri(reportServer.ServiceUrl);
				CredentialCache cache = new CredentialCache();
				cache.Add(uri, "NTLM", credential);
				cache.Add(uri, "BASIC", credential);
				base.Credentials = cache;
			}
		}

	}
}