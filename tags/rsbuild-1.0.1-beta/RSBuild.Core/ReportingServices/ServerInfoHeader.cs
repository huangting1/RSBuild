namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;

    [XmlRoot(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", IsNullable=false), XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ServerInfoHeader : SoapHeader
    {
        // Methods
        public ServerInfoHeader()
        {
        }


        // Fields
        public string ReportServerEdition;
        public string ReportServerVersionNumber;
    }
}

