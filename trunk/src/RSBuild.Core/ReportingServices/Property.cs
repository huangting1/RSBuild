namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices"), XmlInclude(typeof(SearchCondition))]
    public class Property
    {
        // Methods
        public Property()
        {
        }


        // Fields
        public string Name;
        public string Value;
    }
}

