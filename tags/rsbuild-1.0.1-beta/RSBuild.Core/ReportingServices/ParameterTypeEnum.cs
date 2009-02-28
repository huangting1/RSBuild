namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public enum ParameterTypeEnum
    {
        // Fields
        Boolean = 0,
        DateTime = 1,
        Float = 3,
        Integer = 2,
        String = 4
    }
}

