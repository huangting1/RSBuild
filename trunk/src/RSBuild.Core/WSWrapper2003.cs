namespace RSBuild
{
	using System;
    using Microsoft.SqlServer.ReportingServices;

    /// <summary>
    /// Proxy wrapper.
    /// </summary>
	public class WSWrapper2003 : IWSWrapper
	{
        private const string SERVICE_NAME = "ReportService.asmx";
        private ReportingService _proxy;

		// Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="WSWrapper"/> class.
        /// </summary>
        /// <param name="reportServer">The report server.</param>
		private WSWrapper2003(ReportingService proxy)
		{
            _proxy = proxy;
		}

        public static bool TryCreate(ReportServerInfo reportServer, out IWSWrapper result, out Exception exception)
        {
            ReportingService proxy = new ReportingService()
            {
                Url = reportServer.GetServiceUrl(SERVICE_NAME),
                Timeout = reportServer.Timeout ?? -1,
                Credentials = reportServer.CreateCredentials(SERVICE_NAME)
            };

            try
            {
                proxy.ListSecureMethods();
                result = new WSWrapper2003(proxy);
                exception = null;
                return true;
            }
            catch (Exception e)
            {
                proxy.Dispose();
                result = null;
                exception = e;
                return false;
            }
        }

        public void Dispose()
        {
            _proxy.Dispose();
        }

        public void CreateFolder(string Folder, string Parent)
        {
            _proxy.CreateFolder(Folder, Parent, null);
        }

        public void CreateDataSource(DataSource source)
        {
            DataSourceDefinition definition = new DataSourceDefinition();
            definition.Extension = source.Extension;
            definition.ConnectString = source.ConnectionString;
            definition.CredentialRetrieval = (CredentialRetrievalEnum)source.CredentialRetrieval;
            if (source.UserName != null)
            {
                definition.UserName = source.UserName;
                definition.Password = source.Password;
            }
            definition.Enabled = true;
            definition.EnabledSpecified = true;
            definition.Extension = "SQL";
            definition.ImpersonateUser = false;
            definition.ImpersonateUserSpecified = true;
            definition.Prompt = null;
            definition.WindowsCredentials = source.WindowsCredentials;

            _proxy.CreateDataSource(
                source.Name,
                Util.FormatPath(source.TargetFolder),
                source.Overwrite,
                definition,
                null);
        }

        public void CreateReport(Report report, string reportDir, byte[] reportDefinition)
        {
            if (reportDefinition == null) return;

            Warning[] warnings = _proxy.CreateReport(report.Name, reportDir, true, reportDefinition, null);

            if (warnings != null)
            {
                Logger.LogMessage(string.Format("Report: [{0}] published successfully with some warnings", report.Name));
                //foreach(Warning warning in warnings)
                //{
                //	Logger.LogMessage(warning.Message);
                //}
            }
            else
            {
                Logger.LogMessage(string.Format("Report: [{0}] published successfully with no warnings", report.Name));
            }

            if (report.CacheOption != null
                && report.CacheOption.CacheReport 
                && report.CacheOption.ExpirationMinutes != null)
            {
                _proxy.SetCacheOptions(
                    string.Format("{0}/{1}", reportDir, report.Name),
                    true,
                    new TimeExpiration() { Minutes = report.CacheOption.ExpirationMinutes.Value });
            }
        }
	}
}