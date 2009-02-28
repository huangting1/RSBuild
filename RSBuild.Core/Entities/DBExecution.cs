using System;
using System.Collections.Specialized;

namespace RSBuild
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class DBExecution
	{
		private DataSource _DataSource;
		private StringCollection _Files;

		public DataSource DataSource
		{
			get
			{
				return _DataSource;
			}
		}

		public StringCollection FilePaths
		{
			get
			{
				return _Files;
			}
		}

		public DBExecution(string dataSourceName, StringCollection files)
		{
			if (dataSourceName != null)
			{
				if (Settings.DataSources.ContainsKey(dataSourceName))
				{
					_DataSource = (DataSource)Settings.DataSources[dataSourceName];
				}
			}
			if (files != null)
			{
				_Files = new StringCollection();
				foreach (string file in files)
				{
					_Files.Add(string.Format("{0}{1}", Settings.CurrentDiretory, file.Trim()));
				}
			}
		}
	}
}
