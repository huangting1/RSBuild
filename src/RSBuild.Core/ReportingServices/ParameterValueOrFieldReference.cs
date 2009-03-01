namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlInclude(typeof(ParameterFieldReference)), XmlInclude(typeof(ParameterValue)), XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ParameterValueOrFieldReference
    {
        // Methods
        public ParameterValueOrFieldReference()
        {
        }

    }
}

