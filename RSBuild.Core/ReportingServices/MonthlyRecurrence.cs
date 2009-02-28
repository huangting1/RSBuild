namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class MonthlyRecurrence : RecurrencePattern
    {
        // Methods
        public MonthlyRecurrence()
        {
        }


        // Fields
        public string Days;
        public MonthsOfYearSelector MonthsOfYear;
    }
}

