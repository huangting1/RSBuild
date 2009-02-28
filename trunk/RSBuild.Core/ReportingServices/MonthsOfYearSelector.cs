namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class MonthsOfYearSelector
    {
        // Methods
        public MonthsOfYearSelector()
        {
        }


        // Fields
        public bool April;
        public bool August;
        public bool December;
        public bool February;
        public bool January;
        public bool July;
        public bool June;
        public bool March;
        public bool May;
        public bool November;
        public bool October;
        public bool September;
    }
}

