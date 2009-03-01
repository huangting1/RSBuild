namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices"), XmlRoot(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", IsNullable=false)]
    public class BatchHeader : SoapHeader
    {
        // Methods
        public BatchHeader()
        {
        }


        // Fields
        public string BatchID;
    }
}

