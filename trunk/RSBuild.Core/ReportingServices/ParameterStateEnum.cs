namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public enum ParameterStateEnum
    {
        // Fields
        DynamicValuesUnavailable = 3,
        HasOutstandingDependencies = 2,
        HasValidValue = 0,
        MissingValidValue = 1
    }
}

