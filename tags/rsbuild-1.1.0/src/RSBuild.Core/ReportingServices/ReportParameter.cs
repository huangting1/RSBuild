namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ReportParameter
    {
        // Methods
        public ReportParameter()
        {
        }


        // Fields
        public bool AllowBlank;
        [XmlIgnore]
        public bool AllowBlankSpecified;
        [XmlArrayItem("Value")]
        public string[] DefaultValues;
        public bool DefaultValuesQueryBased;
        [XmlIgnore]
        public bool DefaultValuesQueryBasedSpecified;
        [XmlArrayItem("Dependency")]
        public string[] Dependencies;
        public string ErrorMessage;
        public bool MultiValue;
        [XmlIgnore]
        public bool MultiValueSpecified;
        public string Name;
        public bool Nullable;
        [XmlIgnore]
        public bool NullableSpecified;
        public string Prompt;
        public bool PromptUser;
        [XmlIgnore]
        public bool PromptUserSpecified;
        public bool QueryParameter;
        [XmlIgnore]
        public bool QueryParameterSpecified;
        public ParameterStateEnum State;
        [XmlIgnore]
        public bool StateSpecified;
        public ParameterTypeEnum Type;
        [XmlIgnore]
        public bool TypeSpecified;
        public ValidValue[] ValidValues;
        public bool ValidValuesQueryBased;
        [XmlIgnore]
        public bool ValidValuesQueryBasedSpecified;
    }
}

