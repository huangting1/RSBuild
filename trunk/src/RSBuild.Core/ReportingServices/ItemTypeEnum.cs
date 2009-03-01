namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public enum ItemTypeEnum
    {
        // Fields
        DataSource = 5,
        Folder = 1,
        LinkedReport = 4,
        Report = 2,
        Resource = 3,
        Unknown = 0
    }
}

