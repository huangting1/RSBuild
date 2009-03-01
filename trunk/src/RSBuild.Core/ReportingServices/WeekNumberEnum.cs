namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public enum WeekNumberEnum
    {
        // Fields
        FirstWeek = 0,
        FourthWeek = 3,
        LastWeek = 4,
        SecondWeek = 1,
        ThirdWeek = 2
    }
}

