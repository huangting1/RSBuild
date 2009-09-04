namespace RSBuild.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
	/// Represents a report group.
	/// </summary>
	[Serializable]
	public class ReportGroup
	{
        private readonly string _name;
        private readonly string _targetFolder;
        private readonly DataSource _dataSource;
        private readonly ReportServerInfo _reportServer;
        private readonly IList<Report> _reports;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
		public string Name
		{
			get { return _name; }
		}

        /// <summary>
        /// Gets the target folder.
        /// </summary>
        /// <value>The target folder.</value>
		public string TargetFolder
		{
			get { return _targetFolder; }
		}

        /// <summary>
        /// Gets the data source.
        /// </summary>
        /// <value>The data source.</value>
		public DataSource DataSource
		{
			get { return _dataSource; }
		}

        /// <summary>
        /// Gets the report server.
        /// </summary>
        /// <value>The report server.</value>
		public ReportServerInfo ReportServer
		{
			get { return _reportServer; }
		}

        /// <summary>
        /// Gets the reports.
        /// </summary>
        /// <value>The reports.</value>
		public IList<Report> Reports
		{
			get { return _reports; }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportGroup"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="targetFolder">The target folder.</param>
        /// <param name="dataSource">The data source.</param>
        /// <param name="reportServer">The report server.</param>
        /// <param name="reports">The reports.</param>
		public ReportGroup(string name, string targetFolder, DataSource dataSource, ReportServerInfo reportServer, IEnumerable<Report> reports)
		{
			_name = name;
			_targetFolder = targetFolder;
            _dataSource = dataSource;
            _reportServer = reportServer;

			if (!string.IsNullOrEmpty(targetFolder))
			{
				_targetFolder = targetFolder.Trim();
			}
			
            _reports = new List<Report>(reports).AsReadOnly();
            if (dataSource.Publish)
            {
                foreach (Report report in _reports)
                {
                    if (report.DataSources.Count > 0)
                    {
                        report.DataSources[0].SetDataSourceReference(dataSource);
                    }
                }
            }
		}
	}
}
