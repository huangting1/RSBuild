namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ValidValue
    {
        // Methods
        public ValidValue()
        {
        }


        // Fields
        public string Label;
        public string Value;
    }
}

