namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public enum ScheduleStateEnum
    {
        // Fields
        Expired = 3,
        Failing = 4,
        Paused = 2,
        Ready = 0,
        Running = 1
    }
}

