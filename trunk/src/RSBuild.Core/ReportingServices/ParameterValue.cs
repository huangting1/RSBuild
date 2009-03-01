namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ParameterValue : ParameterValueOrFieldReference
    {
        // Methods
        public ParameterValue()
        {
        }


        // Fields
        public string Label;
        public string Name;
        public string Value;
    }
}

