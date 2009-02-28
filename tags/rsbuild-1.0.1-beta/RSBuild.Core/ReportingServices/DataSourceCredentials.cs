namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class DataSourceCredentials
    {
        // Methods
        public DataSourceCredentials()
        {
        }


        // Fields
        public string DataSourceName;
        public string Password;
        public string UserName;
    }
}

