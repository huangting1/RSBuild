namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class ActiveState
    {
        // Methods
        public ActiveState()
        {
        }


        // Fields
        public bool DeliveryExtensionRemoved;
        [XmlIgnore]
        public bool DeliveryExtensionRemovedSpecified;
        public bool InvalidParameterValue;
        [XmlIgnore]
        public bool InvalidParameterValueSpecified;
        public bool MissingParameterValue;
        [XmlIgnore]
        public bool MissingParameterValueSpecified;
        public bool SharedDataSourceRemoved;
        [XmlIgnore]
        public bool SharedDataSourceRemovedSpecified;
        public bool UnknownReportParameter;
        [XmlIgnore]
        public bool UnknownReportParameterSpecified;
    }
}

