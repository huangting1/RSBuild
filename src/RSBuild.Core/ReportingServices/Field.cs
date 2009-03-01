namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class Field
    {
        // Methods
        public Field()
        {
        }


        // Fields
        public string Alias;
        public string Name;
    }
}

