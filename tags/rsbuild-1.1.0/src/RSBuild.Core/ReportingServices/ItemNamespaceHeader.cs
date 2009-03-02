namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices"), XmlRoot(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices", IsNullable=false)]
    public class ItemNamespaceHeader : SoapHeader
    {
        // Methods
        public ItemNamespaceHeader()
        {
        }


        // Fields
        public ItemNamespaceEnum ItemNamespace;
    }
}

