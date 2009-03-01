using System;
using System.IO;
using System.Collections.Specialized;

namespace RSBuild
{
	/// <summary>
	/// Represents a database task.
	/// </summary>
	public class DBTask : Task
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="DBTask"/> class.
        /// </summary>
		public DBTask()
		{}

        /// <summary>
        /// Executes this instance.
        /// </summary>
		public override void Execute()
		{
			DBExecution[] executions = Settings.DBExecutions;
			StringDictionary connections = Settings.DBConnections;
			if (executions != null && executions.Length > 0)
			{
				foreach(DBExecution execution in executions)
				{
					if (execution != null && execution.DataSource != null)
					{
						string connection = connections[execution.DataSource.Name];
						if (connection != null)
						{
							Logger.LogMessage(string.Format("\nConnecting to data source: {0}", execution.DataSource.Name));

							foreach(string filePath in execution.FilePaths)
							{
								Logger.LogMessage(string.Format("Executing file: {0}", Path.GetFileName(filePath)));
								DBHelper.ExecuteFile(filePath, connection);
							}
						}
					}
				}
			}
		}

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>true if the task is valid.</returns>
		public override bool Validate()
		{
			return true;
		}
	}
}
