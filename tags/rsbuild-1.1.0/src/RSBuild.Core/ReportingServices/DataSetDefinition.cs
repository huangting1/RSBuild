namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class DataSetDefinition
    {
        // Methods
        public DataSetDefinition()
        {
        }


        // Fields
        public SensitivityEnum AccentSensitivity;
        [XmlIgnore]
        public bool AccentSensitivitySpecified;
        public SensitivityEnum CaseSensitivity;
        [XmlIgnore]
        public bool CaseSensitivitySpecified;
        public string Collation;
        public Field[] Fields;
        public SensitivityEnum KanatypeSensitivity;
        [XmlIgnore]
        public bool KanatypeSensitivitySpecified;
        public string Name;
        public QueryDefinition Query;
        public SensitivityEnum WidthSensitivity;
        [XmlIgnore]
        public bool WidthSensitivitySpecified;
    }
}

