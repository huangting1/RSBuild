namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public enum ExtensionTypeEnum
    {
        // Fields
        All = 3,
        Data = 2,
        Delivery = 0,
        Render = 1
    }
}

