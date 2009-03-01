namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ScheduleDefinition : ScheduleDefinitionOrReference
    {
        // Methods
        public ScheduleDefinition()
        {
        }


        // Fields
        public DateTime EndDate;
        [XmlIgnore]
        public bool EndDateSpecified;
        [XmlElement("MonthlyRecurrence", typeof(MonthlyRecurrence)), XmlElement("WeeklyRecurrence", typeof(WeeklyRecurrence)), XmlElement("MonthlyDOWRecurrence", typeof(MonthlyDOWRecurrence)), XmlElement("MinuteRecurrence", typeof(MinuteRecurrence)), XmlElement("DailyRecurrence", typeof(DailyRecurrence))]
        public RecurrencePattern Item;
        public DateTime StartDateTime;
    }
}

