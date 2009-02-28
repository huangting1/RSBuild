namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class Subscription
    {
        // Methods
        public Subscription()
        {
        }


        // Fields
        public ActiveState Active;
        public ExtensionSettings DeliverySettings;
        public string Description;
        public string EventType;
        public bool IsDataDriven;
        public DateTime LastExecuted;
        [XmlIgnore]
        public bool LastExecutedSpecified;
        public string ModifiedBy;
        public DateTime ModifiedDate;
        public string Owner;
        public string Path;
        public string Report;
        public string Status;
        public string SubscriptionID;
        public string VirtualPath;
    }
}

