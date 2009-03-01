namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlInclude(typeof(WeeklyRecurrence)), XmlInclude(typeof(DailyRecurrence)), XmlInclude(typeof(MonthlyDOWRecurrence)), XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices"), XmlInclude(typeof(MinuteRecurrence)), XmlInclude(typeof(MonthlyRecurrence))]
    public class RecurrencePattern
    {
        // Methods
        public RecurrencePattern()
        {
        }

    }
}

