namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class DataSourceReference : DataSourceDefinitionOrReference
    {
        // Methods
        public DataSourceReference()
        {
        }


        // Fields
        public string Reference;
    }
}

