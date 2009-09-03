namespace RSBuild
{
    using System;
    using RSBuild.Entities;
    using RS = Microsoft.SqlServer.ReportingServices;

    /// <summary>
    /// Proxy wrapper.
    /// </summary>
	public class WsWrapper2003 : IWsWrapper
	{
        private const string SERVICE_NAME = "ReportService.asmx";
        private RS.ReportingService _proxy;

		// Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="WsWrapper2003"/> class.
        /// </summary>
        /// <param name="proxy">The report server.</param>
        private WsWrapper2003(RS.ReportingService proxy)
		{
            _proxy = proxy;
		}

        public static bool TryCreate(ReportServerInfo reportServer, out IWsWrapper result, out Exception exception)
        {
            RS.ReportingService proxy = new RS.ReportingService
            {
                Url = reportServer.GetServiceUrl(SERVICE_NAME),
                Timeout = reportServer.Timeout ?? -1,
                Credentials = reportServer.CreateCredentials(SERVICE_NAME)
            };

            try
            {
                proxy.ListSecureMethods();
                result = new WsWrapper2003(proxy);
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

        public void CreateFolder(string folder, string parent)
        {
            _proxy.CreateFolder(folder, parent, null);
        }

        public void CreateDataSource(DataSource source)
        {
            RS.DataSourceDefinition definition = new RS.DataSourceDefinition
            {
                Extension = source.Extension,
                ConnectString = source.ConnectionString,
                CredentialRetrieval = (RS.CredentialRetrievalEnum)source.CredentialRetrieval,
                Enabled = true,
                EnabledSpecified = true,
                ImpersonateUser = false,
                ImpersonateUserSpecified = true,
                Prompt = null,
                WindowsCredentials = source.WindowsCredentials,
            };
            if (source.UserName != null)
            {
                definition.UserName = source.UserName;
                definition.Password = source.Password;
            }
        }

        public void CreateReport(Report report, string reportDir, byte[] reportDefinition)
        {
            if (reportDefinition == null) return;

            RS.Warning[] warnings = _proxy.CreateReport(report.Name, reportDir, true, reportDefinition, null);

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
                    new RS.TimeExpiration { Minutes = report.CacheOption.ExpirationMinutes.Value });
            }
        }
	}
}