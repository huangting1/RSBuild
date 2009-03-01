namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class InvalidDataSourceReference : DataSourceDefinitionOrReference
    {
        // Methods
        public InvalidDataSourceReference()
        {
        }

    }
}

