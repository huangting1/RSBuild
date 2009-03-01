namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class Schedule
    {
        // Methods
        public Schedule()
        {
        }


        // Fields
        public string Creator;
        public ScheduleDefinition Definition;
        public string Description;
        public DateTime LastRunTime;
        [XmlIgnore]
        public bool LastRunTimeSpecified;
        public string Name;
        public DateTime NextRunTime;
        [XmlIgnore]
        public bool NextRunTimeSpecified;
        public bool ReferencesPresent;
        public string ScheduleID;
        public ScheduleStateEnum State;
    }
}

