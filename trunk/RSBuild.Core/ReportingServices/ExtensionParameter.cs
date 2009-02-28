namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ExtensionParameter
    {
        // Methods
        public ExtensionParameter()
        {
        }


        // Fields
        public string DisplayName;
        public bool Encrypted;
        public string Error;
        public bool IsPassword;
        public string Name;
        public bool ReadOnly;
        public bool Required;
        [XmlIgnore]
        public bool RequiredSpecified;
        [XmlArrayItem("Value")]
        public ValidValue[] ValidValues;
        public string Value;
    }
}

