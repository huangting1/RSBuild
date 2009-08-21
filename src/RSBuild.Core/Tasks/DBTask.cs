using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace RSBuild
{
	/// <summary>
	/// Represents a database task.
	/// </summary>
	public class DBTask : Task
	{
	    private readonly Settings Settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBTask"/> class.
        /// </summary>
		public DBTask(Settings settings)
        {
            this.Settings = settings;
        }

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
								ExecuteFile(filePath, connection);
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

        /// <summary>
        /// Executes the sql file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="connectionString">The connection string.</param>
        private void ExecuteFile(string filePath, string connectionString)
        {
            SqlConnection connection = null;

            try
            {
                StreamReader reader = null;
                string sql = string.Empty;

                if (false == System.IO.File.Exists(filePath))
                {
                    throw new Exception(string.Format("File [{0}] does not exists", filePath));
                }
                else
                {
                    using (Stream stream = System.IO.File.OpenRead(filePath))
                    {
                        reader = new StreamReader(stream);
                        connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand();
                        connection.Open();
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.Text;

                        while (null != (sql = ReadNextStatementFromStream(reader)))
                        {
                            command.CommandText = Settings.ProcessGlobals(sql);
                            command.ExecuteNonQuery();
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("DBHelper::ExecuteFile", ex.Message);
            }

            if (connection != null)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Reads the next statement from stream.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private string ReadNextStatementFromStream(StreamReader reader)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string lineOfText;

                while (true)
                {
                    lineOfText = reader.ReadLine();
                    if (lineOfText == null)
                    {
                        if (sb.Length > 0)
                        {
                            return sb.ToString();
                        }
                        else
                        {
                            return null;
                        }
                    }

                    if (lineOfText.TrimEnd().ToUpper() == "GO")
                    {
                        break;
                    }

                    sb.Append(lineOfText + Environment.NewLine);
                }

                return sb.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
