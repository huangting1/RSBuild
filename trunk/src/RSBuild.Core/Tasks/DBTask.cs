namespace RSBuild.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using RSBuild.Entities;

    /// <summary>
	/// Represents a database task.
	/// </summary>
	public class DbTask : Task
	{
        private readonly GlobalVariableDictionary _globalVariables;
        private readonly IList<DbExecution> _dbExecutions;
        private readonly IDictionary<string, string> _dbConnections;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbTask"/> class.
        /// </summary>
		public DbTask(Settings settings)
        {
            _globalVariables = settings.GlobalVariables;
            _dbExecutions = new List<DbExecution>(settings.DbExecutions);
            _dbConnections = new Dictionary<string, string>(settings.DbConnections);
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
		public override void Execute()
		{
			foreach(DbExecution execution in _dbExecutions)
			{
				if (execution != null && execution.DataSource != null)
				{
					string connection = _dbConnections[execution.DataSource.Name];
					if (connection != null)
					{
						Logger.LogMessage(string.Format("\nConnecting to data source: {0}", execution.DataSource.Name));

						foreach(string filePath in execution.FilePaths)
						{
							Logger.LogMessage(string.Format("Executing file: {0}", Path.GetFileName(filePath)));
							ExecuteFile(filePath, connection);
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

        /// <summary>
        /// Executes the sql file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="connectionString">The connection string.</param>
        private void ExecuteFile(string filePath, string connectionString)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception(string.Format("File [{0}] does not exists", filePath));
            }

            try
            {
                using (Stream stream = File.OpenRead(filePath))
                using (StreamReader reader = new StreamReader(stream))
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    string sql = ReadNextStatementFromStream(reader);
                    while (sql != null)
                    {
                        command.CommandText = _globalVariables.ReplaceVariables(sql);
                        command.ExecuteNonQuery();
                        sql = ReadNextStatementFromStream(reader);
                    }

                    connection.Close();
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("DBHelper::ExecuteFile", ex.Message);
            }
        }

        /// <summary>
        /// Reads the next statement from stream.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private static string ReadNextStatementFromStream(StreamReader reader)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                string lineOfText = reader.ReadLine();
                if (lineOfText == null)
                {
                    return sb.Length > 0
                        ? sb.ToString()
                        : null;
                }

                if (lineOfText.Trim().Equals("GO", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                sb.AppendLine(lineOfText);
            }

            return sb.ToString();
        }
    }
}
