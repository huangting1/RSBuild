namespace RSBuild
{
    using System;
    using System.Collections.Specialized;

    /// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class DBExecution
	{
		private DataSource _dataSource;
		private StringCollection _filePaths;

		public DataSource DataSource
		{
			get
			{
				return _dataSource;
			}
		}

		public StringCollection FilePaths
		{
			get
			{
				return _filePaths;
			}
		}

		public DBExecution(DataSource dataSource, StringCollection files)
		{
		    _dataSource = dataSource;
		    _filePaths = files;
		}
	}
}
