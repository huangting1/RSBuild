namespace RSBuild
{
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Text;

    /// <summary>
	/// Represents a publish task.
	/// </summary>
	public class PublishTask : Task
	{
		private Hashtable _ReportServers;
		private Hashtable _WSWrappers;
		private Hashtable _DataSources;
		private ReportGroup[] _ReportGroups;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishTask"/> class.
        /// </summary>
		public PublishTask()
		{
			_ReportServers = Settings.ReportServers ?? new Hashtable();
            _DataSources = Settings.DataSources ?? new Hashtable();
            _ReportGroups = Settings.ReportGroups ?? new ReportGroup[0];
            _WSWrappers = new Hashtable();
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
		public override void Execute()
		{
			CreateFolders();
			CreateDataSources();
			PublishReports();
		}

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>true if the task is valid.</returns>
		public override bool Validate()
		{
			if (_ReportServers.Count == 0)
            {
                Logger.LogException("PublishTask::Validate", "No report server specified.");
                return false;
            }

			foreach(ReportServerInfo reportServer in _ReportServers.Values)
			{
                Logger.LogMessage(string.Format("Validating reporting service: {0}", reportServer.ServiceBaseUrl));

                IWSWrapper wrapper;
                Exception exception;
                if (WSWrapper2003.TryCreate(reportServer, out wrapper, out exception)
                    || WSWrapper2005.TryCreate(reportServer, out wrapper, out exception))
                {
                    _WSWrappers.Add(reportServer.Name, wrapper);
                }
                else
                {
                    Logger.LogMessage(string.Format("PublishTask::Validate", exception.Message));
                    return false;
                }
			}
			return true;
		}

        /// <summary>
        /// Creates the report and datasource folders.
        /// </summary>
		private void CreateFolders()
		{
			StringDictionary folders = new StringDictionary();

			if (_DataSources.Count > 0)
			{
				foreach(DataSource source in _DataSources.Values)
				{
					if (source.Publish
                        && source.TargetFolder != null
                        && !folders.ContainsKey(source.TargetFolder))
					{
                        folders.Add(source.TargetFolder, source.TargetFolder);
					}
				}
			}

            if (_ReportGroups.Length > 0)
			{
				foreach(ReportGroup reportGroup in _ReportGroups)
				{
					if (reportGroup != null 
                        && reportGroup.TargetFolder != null
                        && !folders.ContainsKey(reportGroup.TargetFolder))
					{
                        folders.Add(reportGroup.TargetFolder, reportGroup.TargetFolder);
					}
				}
			}

			foreach(IWSWrapper wsWrapper in _WSWrappers.Values)
			{
				foreach(string folder in folders.Values)
				{
					string[] folderSegments = folder.Split(new char[]{'/', '\\'});
					StringBuilder location = new StringBuilder();

					foreach (string folderSegment in folderSegments)
					{
						if (folderSegment.Length > 0)
						{
							try
							{
								wsWrapper.CreateFolder(folderSegment, location.Length == 0 ? "/" : location.ToString());
								Logger.LogMessage(string.Format("Folder created: {0} at {1}", folderSegment, location.ToString()));
							}
							catch(Exception)
							{
								//Logger.LogException("PublishTask::CreateFolders", e.Message);
							}
							location.AppendFormat("/{0}", folderSegment);
						}
					}
				}
			}
		}

        /// <summary>
        /// Creates the data sources.
        /// </summary>
		private void CreateDataSources()
		{
			if (_DataSources != null && _DataSources.Count > 0)
			{
				foreach(DataSource source in _DataSources.Values)
				{
					if (source.Publish && source.ReportServer != null)
					{
						try
						{
							IWSWrapper wsWrapper = (IWSWrapper)_WSWrappers[source.ReportServer.Name];
							wsWrapper.CreateDataSource(source);
							Logger.LogMessage(string.Format("DataSource: [{0}] published successfully", source.Name));
						}
						catch (Exception e)
						{
							Logger.LogException("PublishTask::CreateDataSource", e.Message);
						}
					}
				}
			}
		}

        /// <summary>
        /// Publishes the reports.
        /// </summary>
		private void PublishReports()
		{
			if (_ReportGroups.Length > 0)
			{
				foreach(ReportGroup reportGroup in _ReportGroups)
				{
					if (reportGroup != null)
					{
						IWSWrapper wsWrapper = (IWSWrapper)_WSWrappers[reportGroup.ReportServer.Name];
						Report[] reports = reportGroup.Reports;
						if (reports != null && reports.Length > 0)
						{
                            foreach (Report report in reports)
                            {
                                if (report != null)
                                {
                                    try
                                    {
                                        wsWrapper.CreateReport(reportGroup, report);
                                    }
                                    catch (Exception e)
                                    {
                                        Logger.LogException("PublishTask::PublishReport", e.Message);
                                    }
                                }
                            }
						}
					}
				}
			}
		}
	}
}
