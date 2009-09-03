namespace RSBuild.Entities
{
    using System;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.XPath;

    /// <summary>
	/// Represents a report.
	/// </summary>
	[Serializable]
	public class Report
	{
        #region Instance fields

		private readonly string _name;
        private readonly string _targetFolder;
        private readonly XmlDocument _definitionDoc = new XmlDocument();
        private readonly XmlNode _bodyHeightNode; 
        private readonly XmlNamespaceManager _xmlNamespaces;
        private CacheOption _cacheOption;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="Report"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="targetFolder">The target folder for the report.</param>
        /// <param name="definition">Report definition.</param>
        public Report(string name, string targetFolder, XmlReader definition)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Report name is required", "name");
            }
            if (string.IsNullOrEmpty(targetFolder))
            {
                throw new ArgumentException("Target folder is required", "targetFolder");
            }

            _name = name;
            _targetFolder = targetFolder;
            _definitionDoc.Load(definition);
            _xmlNamespaces = GetXmlNamespaceManager(_definitionDoc);
            _bodyHeightNode = _definitionDoc.SelectSingleNode("//def:Report/def:Body/def:Height", _xmlNamespaces);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The report name.
        /// </summary>
		public string Name
		{
			get { return _name; }
		}

        /// <summary>
        /// The target folder for this report.
        /// </summary>
		public string TargetFolder
		{
			get { return _targetFolder; }
		}

        /// <summary>
        /// Gets the collapsed height of the report.
        /// </summary>
        /// <value>The collapsed height of the report.</value>
		public string BodyHeight
		{
			get
			{
			    return _bodyHeightNode != null
	                ? _bodyHeightNode.InnerText
	                : null;
			}
            set
            {
                if (value == null || !ValidateDistance(value))
                {
                    throw new ArgumentException("Height must match number format ##0.##in.", "value");
                }
                if (_bodyHeightNode != null)
                {
                    _bodyHeightNode.InnerText = value;
                }
            }
		}

        /// <summary>
        /// Gets the cache option.
        /// </summary>
        /// <value>The cache option.</value>
		public CacheOption CacheOption
		{
			get { return _cacheOption; }
            set { _cacheOption = value; }
        }

        /// <summary>
        /// The report definition
        /// </summary>
        public string Definition
        {
            get { return _definitionDoc.ToString(); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets first data source reference in report definition to the specified data source.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        public void SetDataSourceReference(DataSource dataSource)
        {
            if (dataSource.Publish)
            {
                string newDataSourceNodeContent = string.Format(
                    "<rd:DataSourceID>{0}</rd:DataSourceID><DataSourceReference>{1}{2}</DataSourceReference>",
                    Guid.NewGuid(),
                    PathUtil.GetRelativePath(_targetFolder, dataSource.TargetFolder),
                    dataSource.Name);

                XmlNode firstDataSourceNode = _definitionDoc.SelectSingleNode("//def:Report/def:DataSources/def:DataSource", _xmlNamespaces);
                if (firstDataSourceNode != null)
                {
                    firstDataSourceNode.InnerXml = newDataSourceNodeContent;
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="XmlNamespaceManager"/> instance with all namespaces
        /// used within a XML document.
        /// </summary>
        /// <param name="doc">The Xml document.</param>
        /// <returns>All namespaces used within <paramref name="doc"/>.</returns>
        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument doc)
        {
            if (doc == null)
            {
                throw new ArgumentNullException("doc");
            }
            if (doc.DocumentElement == null)
            {
                throw new ArgumentException("report definition XML document is empty.");
            }

            XmlNamespaceManager xnm = new XmlNamespaceManager(doc.NameTable);

            XPathNavigator xnav = doc.DocumentElement.CreateNavigator();
            foreach (var ns in xnav.GetNamespacesInScope(XmlNamespaceScope.All))
            {
                xnm.AddNamespace(string.IsNullOrEmpty(ns.Key) ? "def" : ns.Key, ns.Value);
            }

            return xnm;
        }

        /// <summary>
        /// Validates the distance.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        private static bool ValidateDistance(string input)
        {
            Regex reg = new Regex(@"^\d+(\.\d*)*in$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(input);
        }

        #endregion
    }
}
