namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlInclude(typeof(ScheduleDefinition)), XmlInclude(typeof(ScheduleReference)), XmlInclude(typeof(NoSchedule)), XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ScheduleDefinitionOrReference
    {
        // Methods
        public ScheduleDefinitionOrReference()
        {
        }

    }
}

