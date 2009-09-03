namespace RSBuild.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Text;
    using RSBuild.Entities;

    /// <summary>
	/// Represents a publish task.
	/// </summary>
	public class PublishTask : Task
	{
        private readonly GlobalVariableDictionary _globalVariables;
        private readonly IDictionary<string, ReportServerInfo> _reportServers;
		private readonly IDictionary<string, DataSource> _dataSources;
		private readonly IList<ReportGroup> _reportGroups;
        private readonly IDictionary<string, IWsWrapper> _wsWrappers = new Dictionary<string, IWsWrapper>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishTask"/> class.
        /// </summary>
		public PublishTask(Settings settings)
		{
            _globalVariables = settings.GlobalVariables;
            _reportServers = new Dictionary<string, ReportServerInfo>(settings.ReportServers);
            _dataSources = new Dictionary<string, DataSource>(settings.DataSources);
            _reportGroups = new List<ReportGroup>(settings.ReportGroups);
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
			if (_reportServers.Count == 0)
            {
                Logger.LogException("PublishTask::Validate", "No report server specified.");
                return false;
            }

			foreach(ReportServerInfo reportServer in _reportServers.Values)
			{
                Logger.LogMessage(string.Format("Validating reporting service: {0}", reportServer.ServiceBaseUrl));

                IWsWrapper wrapper;
                Exception exception;
                if (WsWrapper2003.TryCreate(reportServer, out wrapper, out exception)
                    || WsWrapper2005.TryCreate(reportServer, out wrapper, out exception))
                {
                    _wsWrappers.Add(reportServer.Name, wrapper);
                }
                else
                {
                    Logger.LogException("PublishTask::Validate", exception.Message);
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

			foreach(DataSource source in _dataSources.Values)
			{
				if (source.Publish
                    && source.TargetFolder != null
                    && !folders.ContainsKey(source.TargetFolder))
				{
                    folders.Add(source.TargetFolder, source.TargetFolder);
				}
			}

			foreach(ReportGroup reportGroup in _reportGroups)
			{
				if (reportGroup != null 
                    && reportGroup.TargetFolder != null
                    && !folders.ContainsKey(reportGroup.TargetFolder))
				{
                    folders.Add(reportGroup.TargetFolder, reportGroup.TargetFolder);
				}
			}

			foreach(IWsWrapper wsWrapper in _wsWrappers.Values)
			{
				foreach(string folder in folders.Values)
				{
					string[] folderSegments = folder.Split(new[] {'/', '\\'});
					StringBuilder location = new StringBuilder();

					foreach (string folderSegment in folderSegments)
					{
						if (folderSegment.Length > 0)
						{
							try
							{
								wsWrapper.CreateFolder(folderSegment, location.Length == 0 ? "/" : location.ToString());
								Logger.LogMessage(string.Format("Folder created: {0} at {1}", folderSegment, location));
							}
							catch(Exception e)
							{
								Logger.LogException("PublishTask::CreateFolders", e.Message);
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
			if (_dataSources != null && _dataSources.Count > 0)
			{
				foreach(DataSource source in _dataSources.Values)
				{
					if (source.Publish && source.ReportServer != null)
					{
						try
						{
							IWsWrapper wsWrapper = _wsWrappers[source.ReportServer.Name];
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
			foreach(ReportGroup reportGroup in _reportGroups)
			{
				if (reportGroup != null)
				{
					IWsWrapper wsWrapper = _wsWrappers[reportGroup.ReportServer.Name];

                    foreach (Report report in reportGroup.Reports)
                    {
                        if (report != null)
                        {
                            try
                            {
                                byte[] reportDefinition = Encoding.UTF8.GetBytes(report.Definition);
                                wsWrapper.CreateReport(report, report.TargetFolder, reportDefinition);
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
