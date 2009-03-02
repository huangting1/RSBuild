namespace RSBuild
{
    using System;
    using Microsoft.SqlServer.ReportingServices2005;

    /// <summary>
    /// Proxy wrapper.
    /// </summary>
    public class WSWrapper2005 : IWSWrapper
    {
        private static string SERVICE_NAME = "ReportService2005.asmx";
        private ReportingService2005 _proxy;

        // Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="WSWrapper"/> class.
        /// </summary>
        /// <param name="reportServer">The report server.</param>
        private WSWrapper2005(ReportingService2005 proxy)
        {
            _proxy = proxy;
        }

        public static bool TryCreate(ReportServerInfo reportServer, out IWSWrapper result, out Exception exception)
        {
            ReportingService2005 proxy = new ReportingService2005()
            {
                Url = reportServer.GetServiceUrl(SERVICE_NAME),
                Timeout = reportServer.Timeout ?? -1,
                Credentials = reportServer.CreateCredentials(SERVICE_NAME)
            };

            try
            {
                proxy.ListSecureMethods();
                result = new WSWrapper2005(proxy);
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
            definition.ConnectString = source.RSConnectionString;
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

        public void CreateReport(ReportGroup reportGroup, Report report)
        {
            byte[] definition = report.Process(reportGroup.TargetFolder, reportGroup.DataSource);
            if (definition == null) return;

            Warning[] warnings = _proxy.CreateReport(
                report.Name,
                Util.FormatPath(reportGroup.TargetFolder),
                true,
                definition,
                null);

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
                    string.Format("{0}/{1}", Util.FormatPath(reportGroup.TargetFolder), report.Name),
                    true,
                    new TimeExpiration() { Minutes = report.CacheOption.ExpirationMinutes.Value });
            }
        }
    }
}