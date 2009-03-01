namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class Role
    {
        // Methods
        public Role()
        {
        }


        // Fields
        public string Description;
        public string Name;
    }
}

