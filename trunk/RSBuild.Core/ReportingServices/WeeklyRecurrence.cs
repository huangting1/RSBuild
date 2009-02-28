namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class WeeklyRecurrence : RecurrencePattern
    {
        // Methods
        public WeeklyRecurrence()
        {
        }


        // Fields
        public DaysOfWeekSelector DaysOfWeek;
        public int WeeksInterval;
        [XmlIgnore]
        public bool WeeksIntervalSpecified;
    }
}

