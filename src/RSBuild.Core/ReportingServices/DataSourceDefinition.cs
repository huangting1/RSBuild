namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class DataSourceDefinition : DataSourceDefinitionOrReference
    {
        // Methods
        public DataSourceDefinition()
        {
        }


        // Fields
        public string ConnectString;
        public CredentialRetrievalEnum CredentialRetrieval;
        public bool Enabled;
        [XmlIgnore]
        public bool EnabledSpecified;
        public string Extension;
        public bool ImpersonateUser;
        [XmlIgnore]
        public bool ImpersonateUserSpecified;
        public string Password;
        public string Prompt;
        public string UserName;
        public bool WindowsCredentials;
    }
}

