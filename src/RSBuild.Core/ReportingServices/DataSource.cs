namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class DataSource
    {
        // Methods
        public DataSource()
        {
        }


        // Fields
        [XmlElement("DataSourceReference", typeof(DataSourceReference)), XmlElement("InvalidDataSourceReference", typeof(InvalidDataSourceReference)), XmlElement("DataSourceDefinition", typeof(DataSourceDefinition))]
        public DataSourceDefinitionOrReference Item;
        public string Name;
    }
}

