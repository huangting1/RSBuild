namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlInclude(typeof(ScheduleExpiration)), XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices"), XmlInclude(typeof(TimeExpiration))]
    public class ExpirationDefinition
    {
        // Methods
        public ExpirationDefinition()
        {
        }

    }
}

