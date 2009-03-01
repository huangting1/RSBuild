namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class Warning
    {
        // Methods
        public Warning()
        {
        }


        // Fields
        public string Code;
        public string Message;
        public string ObjectName;
        public string ObjectType;
        public string Severity;
    }
}

