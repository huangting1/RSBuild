namespace RSBuild
{
    using System;
    using System.IO;
    using System.Xml;

    /// <summary>
	/// Represents a report.
	/// </summary>
	[Serializable]
	public class Report
	{
		private string _Name;
		private string _FilePath;
		private string _CollapsedHeight;
		private CacheOption _CacheOption;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
		public string Name
		{
			get
			{
				return _Name;
			}
		}

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>The file path.</value>
		public string FilePath
		{
			get
			{
				return _FilePath;
			}
		}

        /// <summary>
        /// Gets the collapsed height of the report.
        /// </summary>
        /// <value>The collapsed height of the report.</value>
		public string CollapsedHeight
		{
			get
			{
				return _CollapsedHeight;
			}
		}

        /// <summary>
        /// Gets the cache option.
        /// </summary>
        /// <value>The cache option.</value>
		public CacheOption CacheOption
		{
			get
			{
				return _CacheOption;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Report"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="collapsedHeight">The height.</param>
        /// <param name="cacheTime">The cache time.</param>
		public Report(string name, string filePath, string collapsedHeight, int cacheTime)
		{
			_Name = name;
			_FilePath = filePath;
			if (collapsedHeight != null && Util.ValidateDistance(collapsedHeight))
			{
				_CollapsedHeight = collapsedHeight;
			}

			if (cacheTime > 0)
			{
				_CacheOption = new CacheOption(cacheTime);
			}
		}

        /// <summary>
        /// Processes the report.
        /// </summary>
        /// <param name="targetFolder">The target folder.</param>
        /// <param name="dataSource">The data source.</param>
        /// <returns>The report definition.</returns>
		public byte[] Process(string targetFolder, DataSource dataSource)
		{
			FileStream stream = null;
			byte[] definition = null;

			try
			{
				stream = File.OpenRead(_FilePath);
				XmlDocument d = new XmlDocument();
				d.Load(stream);
				XmlNamespaceManager xnm = Util.GetXmlNamespaceManager(d);
				XmlDocument e = d;

				if (_CollapsedHeight != null)
				{
					e = CollapseHeight(d, xnm, _CollapsedHeight);
				}

				if (dataSource != null)
				{
					e = ConfigDataSource(e, xnm, dataSource, targetFolder);
				}

				using (StringWriter sw = new StringWriter())
				{
					XmlTextWriter xtw = new XmlTextWriter(sw);
					e.WriteTo(xtw);
					definition = Util.StringToByteArray(Settings.ProcessGlobals(sw.ToString()));
					xtw.Close();
				}
			}
			catch(Exception e)
			{
				Logger.LogException("Report::Process", e.Message);
			}
			finally
			{
				if (stream != null)
				{
					stream.Close();
				}
			}

			return definition;
		}

        /// <summary>
        /// Collapses the height.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="xnm">The namespace.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
		private XmlDocument CollapseHeight(XmlDocument input, XmlNamespaceManager xnm, string height)
		{
			XmlDocument output = input;

			try
			{
				XmlNode n1 = output.SelectSingleNode("//def:Report/def:Body/def:Height", xnm);
				if (n1 != null)
				{
					n1.InnerText = height;
				}

			}
			catch(Exception)
			{}

			return output;
		}

        /// <summary>
        /// Configs the data source.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="xnm">The namespace.</param>
        /// <param name="dataSource">The data source.</param>
        /// <param name="targetFolder">The target folder.</param>
        /// <returns></returns>
		private XmlDocument ConfigDataSource(XmlDocument input, XmlNamespaceManager xnm, DataSource dataSource, string targetFolder)
		{
			XmlDocument output = input;

				if (dataSource.Publish)
				{
					string nodeXml = string.Format(
                        "<rd:DataSourceID>{0}</rd:DataSourceID><DataSourceReference>{1}{2}</DataSourceReference>",
						Guid.NewGuid(),
						Util.GetRelativePath(targetFolder, dataSource.TargetFolder), 
                        dataSource.Name);

					try
					{
						XmlNode n1 = output.SelectSingleNode("//def:Report/def:DataSources/def:DataSource", xnm);
						if (n1 != null)
						{
							n1.InnerXml = nodeXml;
						}

					}
					catch(Exception)
					{}
				}

			return output;
		}
	}
}
