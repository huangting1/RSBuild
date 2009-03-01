namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public enum JobActionEnum
    {
        // Fields
        Render = 0,
        ReportHistoryCreation = 2,
        SnapshotCreation = 1
    }
}

