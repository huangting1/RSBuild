namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;

    [XmlRoot(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", IsNullable=false), XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class SessionHeader : SoapHeader
    {
        // Methods
        public SessionHeader()
        {
        }


        // Fields
        public string ExecutionDateTime;
        public string ExpirationDateTime;
        public bool IsNewExecution;
        public string SessionId;
    }
}

