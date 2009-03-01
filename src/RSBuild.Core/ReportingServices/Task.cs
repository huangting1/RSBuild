namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class Task
    {
        // Methods
        public Task()
        {
        }


        // Fields
        public string Description;
        public string Name;
        public string TaskID;
    }
}

