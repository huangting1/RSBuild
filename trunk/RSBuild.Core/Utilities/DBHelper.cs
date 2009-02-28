using System;
using System.Data;
using System.IO;
using System.Text;
using System.Data.SqlClient;

namespace RSBuild
{
	/// <summary>
	/// Helper methods for data access.
	/// </summary>
	public static class DBHelper
	{
        /// <summary>
        /// Executes the sql file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="connectionString">The connection string.</param>
		public static void ExecuteFile(string filePath, string connectionString) 
		{
			SqlConnection connection = null;

			try 
			{
				StreamReader reader = null;
				string sql	= string.Empty;

				if( false == System.IO.File.Exists( filePath )) 
				{
					throw new Exception(string.Format("File [{0}] does not exists", filePath));
				}
				else
				{
					using( Stream stream = System.IO.File.OpenRead( filePath ) ) 
					{
						reader = new StreamReader( stream );
						connection = new SqlConnection(connectionString);
						SqlCommand	command = new SqlCommand();
						connection.Open();
						command.Connection = connection;
						command.CommandType	= System.Data.CommandType.Text;

						while( null != (sql = ReadNextStatementFromStream( reader ) )) 
						{
							command.CommandText = Settings.ProcessGlobals(sql);
							command.ExecuteNonQuery();
						}

						reader.Close();
					}
				}
			}
			catch(Exception ex) 
			{
				Logger.LogException( "DBHelper::ExecuteFile" , ex.Message);
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
		private static string ReadNextStatementFromStream( StreamReader reader ) 
		{
			try 
			{
				StringBuilder sb = new StringBuilder();
				string lineOfText;
	
				while(true) 
				{
					lineOfText = reader.ReadLine();
					if( lineOfText == null ) 
					{
						if( sb.Length > 0 ) 
						{
							return sb.ToString();
						}
						else 
						{
							return null;
						}
					}

					if( lineOfText.TrimEnd().ToUpper() == "GO" ) 
					{
						break;
					}
				
					sb.Append(lineOfText + Environment.NewLine);
				}

				return sb.ToString();
			}
			catch(Exception) 
			{
				return null;
			}
		}
	}
}
