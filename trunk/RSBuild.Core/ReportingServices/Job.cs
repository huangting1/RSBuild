namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class Job
    {
        // Methods
        public Job()
        {
        }


        // Fields
        public JobActionEnum Action;
        public string Description;
        public string JobID;
        public string Machine;
        public string Name;
        public string Path;
        public DateTime StartDateTime;
        public JobStatusEnum Status;
        public JobTypeEnum Type;
        public string User;
    }
}

