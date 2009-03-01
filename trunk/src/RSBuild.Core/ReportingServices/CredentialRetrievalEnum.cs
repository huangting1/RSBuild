namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public enum CredentialRetrievalEnum
    {
        // Fields
        Integrated = 2,
        None = 3,
        Prompt = 0,
        Store = 1
    }
}

