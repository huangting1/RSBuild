namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices"), XmlInclude(typeof(DataSourceDefinition)), XmlInclude(typeof(InvalidDataSourceReference)), XmlInclude(typeof(DataSourceReference))]
    public class DataSourceDefinitionOrReference
    {
        // Methods
        public DataSourceDefinitionOrReference()
        {
        }

    }
}

