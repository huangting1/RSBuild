namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class TimeExpiration : ExpirationDefinition
    {
        // Methods
        public TimeExpiration()
        {
        }


        // Fields
        public int Minutes;
    }
}

