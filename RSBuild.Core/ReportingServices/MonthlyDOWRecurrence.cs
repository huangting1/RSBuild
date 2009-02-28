namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class MonthlyDOWRecurrence : RecurrencePattern
    {
        // Methods
        public MonthlyDOWRecurrence()
        {
        }


        // Fields
        public DaysOfWeekSelector DaysOfWeek;
        public MonthsOfYearSelector MonthsOfYear;
        public WeekNumberEnum WhichWeek;
        [XmlIgnore]
        public bool WhichWeekSpecified;
    }
}

