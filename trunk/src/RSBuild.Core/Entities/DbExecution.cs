namespace RSBuild.Entities
{
    using System;
    using System.Collections.Generic;

	[Serializable]
	public class DbExecution
	{
		private readonly DataSource _dataSource;
        private readonly IList<string> _filePaths;

		public DataSource DataSource
		{
			get { return _dataSource; }
		}

		public IList<string> FilePaths
		{
			get { return _filePaths; }
		}

		public DbExecution(DataSource dataSource, IEnumerable<string> files)
		{
		    _dataSource = dataSource;
		    _filePaths = new List<string>(files);
		}
	}
}
