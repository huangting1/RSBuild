namespace Microsoft.SqlServer.ReportingServices
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.microsoft.com/sqlserver/2003/12/reporting/reportingservices")]
    public class CatalogItem
    {
        // Methods
        public CatalogItem()
        {
        }


        // Fields
        public string CreatedBy;
        public DateTime CreationDate;
        [XmlIgnore]
        public bool CreationDateSpecified;
        public string Description;
        public DateTime ExecutionDate;
        [XmlIgnore]
        public bool ExecutionDateSpecified;
        public bool Hidden;
        [XmlIgnore]
        public bool HiddenSpecified;
        public string ID;
        public string MimeType;
        public string ModifiedBy;
        public DateTime ModifiedDate;
        [XmlIgnore]
        public bool ModifiedDateSpecified;
        public string Name;
        public string Path;
        public int Size;
        [XmlIgnore]
        public bool SizeSpecified;
        public ItemTypeEnum Type;
        public string VirtualPath;
    }
}

