namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class DataSourcePrompt
    {
        // Methods
        public DataSourcePrompt()
        {
        }


        // Fields
        public string DataSourceID;
        public string Name;
        public string Prompt;
    }
}

