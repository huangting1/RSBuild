namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class DataRetrievalPlan
    {
        // Methods
        public DataRetrievalPlan()
        {
        }


        // Fields
        public DataSetDefinition DataSet;
        [XmlElement("DataSourceDefinition", typeof(DataSourceDefinition)), XmlElement("InvalidDataSourceReference", typeof(InvalidDataSourceReference)), XmlElement("DataSourceReference", typeof(DataSourceReference))]
        public DataSourceDefinitionOrReference Item;
    }
}

