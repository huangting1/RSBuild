namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ScheduleReference : ScheduleDefinitionOrReference
    {
        // Methods
        public ScheduleReference()
        {
        }


        // Fields
        public ScheduleDefinition Definition;
        public string ScheduleID;
    }
}

