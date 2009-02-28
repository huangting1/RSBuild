namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class QueryDefinition
    {
        // Methods
        public QueryDefinition()
        {
        }


        // Fields
        public string CommandText;
        public string CommandType;
        public int Timeout;
        [XmlIgnore]
        public bool TimeoutSpecified;
    }
}

