namespace RSBuild
{
    using System;

    /// <summary>
	/// Represents a report group.
	/// </summary>
	[Serializable]
	public class ReportGroup
	{
		private string _Name;
		private string _TargetFolder;
		private DataSource _DataSource;
		private ReportServerInfo _ReportServer;
		private Report[] _Reports;

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
        /// Gets the target folder.
        /// </summary>
        /// <value>The target folder.</value>
		public string TargetFolder
		{
			get
			{
				return _TargetFolder;
			}
		}

        /// <summary>
        /// Gets the data source.
        /// </summary>
        /// <value>The data source.</value>
		public DataSource DataSource
		{
			get
			{
				return _DataSource;
			}
		}

        /// <summary>
        /// Gets the report server.
        /// </summary>
        /// <value>The report server.</value>
		public ReportServerInfo ReportServer
		{
			get
			{
				return _ReportServer;
			}
		}

        /// <summary>
        /// Gets the reports.
        /// </summary>
        /// <value>The reports.</value>
		public Report[] Reports
		{
			get
			{
				return _Reports;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportGroup"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="targetFolder">The target folder.</param>
        /// <param name="dataSource">The data source.</param>
        /// <param name="reportServer">The report server.</param>
        /// <param name="reports">The reports.</param>
		public ReportGroup(string name, string targetFolder, DataSource dataSource, ReportServerInfo reportServer, Report[] reports)
		{
			_Name = name;
			_TargetFolder = targetFolder;
            _DataSource = dataSource;
            _ReportServer = reportServer;

			if (targetFolder != null && targetFolder.Length > 0)
			{
				_TargetFolder = targetFolder.Trim();
			}
			if (reports != null && reports.Length > 0)
			{
				_Reports = reports;
			}

		}
	}
}
