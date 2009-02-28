using System;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Collections;
using System.Collections.Specialized;

using Microsoft.SqlServer.ReportingServices;

namespace RSBuild
{
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
			_ReportServers = Settings.ReportServers;
			_DataSources = Settings.DataSources;
			_ReportGroups = Settings.ReportGroups;
		}

        /// <summary>
        /// Executes this instance.
        /// </summary>
		public override void Execute()
		{
			_WSWrappers = new Hashtable();
			foreach(ReportServerInfo rs in _ReportServers.Values)
			{
				_WSWrappers.Add(rs.Name, new WSWrapper(rs));
			}

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
			if (_ReportServers != null && _ReportServers.Count > 0)
			{
				foreach(ReportServerInfo reportServer in _ReportServers.Values)
				{
					try
					{
						Logger.LogMessage(string.Format("Validating reporting service: {0}", reportServer.ServiceUrl));
						WSWrapper wsWrapper = new WSWrapper(reportServer);
						wsWrapper.ListSecureMethods();
						wsWrapper.Dispose();
					}
					catch (Exception e)
					{
						Logger.LogException("PublishTask::Validate", e.Message);
						return false;
					}
				}
				return true;
			}
			else
			{
				Logger.LogException("PublishTask::Validate", "No report server specified.");
				return false;
			}
		}

        /// <summary>
        /// Creates the report and datasource folders.
        /// </summary>
		private void CreateFolders()
		{
			StringDictionary folders = new StringDictionary();

			if (_DataSources != null && _DataSources.Count > 0)
			{
				foreach(DataSource source in _DataSources.Values)
				{
					if (source.Publish)
					{
						if (source.TargetFolder != null)
						{
							if (!folders.ContainsKey(source.TargetFolder))
							{
								folders.Add(source.TargetFolder, null);
							}
						}
					}
				}
			}
			if (_ReportGroups != null && _ReportGroups.Length > 0)
			{
				foreach(ReportGroup reportGroup in _ReportGroups)
				{
					if (reportGroup != null && reportGroup.TargetFolder != null)
					{
						if (!folders.ContainsKey(reportGroup.TargetFolder))
						{
							folders.Add(reportGroup.TargetFolder, null);
						}
					}
				}
			}

			foreach(WSWrapper wsWrapper in _WSWrappers.Values)
			{
				foreach(string key in folders.Keys)
				{
					string[] arr = key.Split(new char[]{'/', '\\'});
					StringBuilder location = new StringBuilder();

					foreach (string folder in arr)
					{
						if (folder.Length > 0)
						{
							try
							{
								wsWrapper.CreateFolder(folder, (location.Length==0)? "/":location.ToString(), null);
								Logger.LogMessage(string.Format("Folder created: {0} at {1}", folder, location.ToString()));
							}
							catch(Exception)
							{
								//Logger.LogException("PublishTask::CreateFolders", e.Message);
							}
							location.AppendFormat("/{0}", folder);
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
						DataSourceDefinition definition = new DataSourceDefinition();
						definition.ConnectString = source.RSConnectionString;
						definition.CredentialRetrieval = source.CredentialRetrieval;
						if (source.UserName != null)
						{
							definition.UserName = source.UserName;
							definition.Password = source.Password;
						}
						definition.Enabled = true;
						definition.EnabledSpecified = true;
						definition.Extension = "SQL";
						definition.ImpersonateUser = false;
						definition.ImpersonateUserSpecified = true;
						definition.Prompt = null;
						definition.WindowsCredentials = source.WindowsCredentials;

						try
						{
							WSWrapper wsWrapper = (WSWrapper)_WSWrappers[source.ReportServer.Name];
							wsWrapper.CreateDataSource(
								source.Name, 
								Util.FormatPath(source.TargetFolder), 
								source.Overwrite, 
								definition, 
								null
								);
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
			if (_ReportGroups != null && _ReportGroups.Length > 0)
			{
				foreach(ReportGroup reportGroup in _ReportGroups)
				{
					if (reportGroup != null)
					{
						WSWrapper wsWrapper = (WSWrapper)_WSWrappers[reportGroup.ReportServer.Name];
						Report[] reports = reportGroup.Reports;
						if (reports != null && reports.Length > 0)
						{
							foreach(Report report in reports)
							{
								if (report != null)
								{
									byte[] definition = report.Process(reportGroup.TargetFolder, reportGroup.DataSource);

									if (definition != null)
									{	
										try
										{
											Warning[] warnings = wsWrapper.CreateReport(
												report.Name,
												Util.FormatPath(reportGroup.TargetFolder), 
												true,
												definition,
												null
												);

											if (warnings != null)
											{
												Logger.LogMessage(string.Format("Report: [{0}] published successfully with some warnings", report.Name));
												//foreach(Warning warning in warnings)
												//{
												//	Logger.LogMessage(warning.Message);
												//}
											}
											else
											{
												Logger.LogMessage(string.Format("Report: [{0}] published successfully with no warnings", report.Name));
											}

											if (report.CacheOption != null)
											{
												if (report.CacheOption.CacheReport && report.CacheOption.ExpirationDefinition != null)
												{
													wsWrapper.SetCacheOptions(
														string.Format("{0}/{1}", Util.FormatPath(reportGroup.TargetFolder), report.Name), 
														true, 
														report.CacheOption.ExpirationDefinition
														);
												}
											}
										}
										catch(Exception e)
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
}
