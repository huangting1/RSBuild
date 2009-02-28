namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class Policy
    {
        // Methods
        public Policy()
        {
        }


        // Fields
        public string GroupUserName;
        public Role[] Roles;
    }
}

