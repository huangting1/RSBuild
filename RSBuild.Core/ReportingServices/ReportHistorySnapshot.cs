namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ReportHistorySnapshot
    {
        // Methods
        public ReportHistorySnapshot()
        {
        }


        // Fields
        public DateTime CreationDate;
        public string HistoryID;
        public int Size;
    }
}

