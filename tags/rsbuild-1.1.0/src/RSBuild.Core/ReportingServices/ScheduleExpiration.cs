namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ScheduleExpiration : ExpirationDefinition
    {
        // Methods
        public ScheduleExpiration()
        {
        }


        // Fields
        [XmlElement("ScheduleDefinition", typeof(ScheduleDefinition)), XmlElement("ScheduleReference", typeof(ScheduleReference))]
        public ScheduleDefinitionOrReference Item;
    }
}

