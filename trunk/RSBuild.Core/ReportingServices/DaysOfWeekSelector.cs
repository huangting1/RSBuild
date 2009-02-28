namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class DaysOfWeekSelector
    {
        // Methods
        public DaysOfWeekSelector()
        {
        }


        // Fields
        public bool Friday;
        public bool Monday;
        public bool Saturday;
        public bool Sunday;
        public bool Thursday;
        public bool Tuesday;
        public bool Wednesday;
    }
}

