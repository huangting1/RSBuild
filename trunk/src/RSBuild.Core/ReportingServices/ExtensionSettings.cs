namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ExtensionSettings
    {
        // Methods
        public ExtensionSettings()
        {
        }


        // Fields
        public string Extension;
        [XmlArrayItem(typeof(ParameterFieldReference)), XmlArrayItem(typeof(ParameterValue))]
        public ParameterValueOrFieldReference[] ParameterValues;
    }
}

