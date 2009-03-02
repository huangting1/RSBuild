namespace RSBuild
{
	/// <summary>
	/// Program dispatcher.
	/// </summary>
	public class Dispatcher
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="Dispatcher"/> class.
        /// </summary>
        /// <param name="args">The arguments.</param>
		public Dispatcher(string[] args)
		{
			if (args != null && args.Length > 0)
			{
				Settings.ConfigFilePath = args[0];
			}
		}

        /// <summary>
        /// Runs this instance.
        /// </summary>
		public void Run()
		{
			if (Settings.Init())
			{
				LogBanner();
				RunTasks();
			}
		}

        /// <summary>
        /// Runs the tasks.
        /// </summary>
		private void RunTasks()
		{
			// need refactoring
			
			LogSectionHeader("Database Installation");
			DBTask dbTask = new DBTask();
			if (dbTask.Validate())
			{
				dbTask.Execute();
			}

			LogSectionHeader("Reports Installation");
            PublishTask publishTask = new PublishTask();
            if (publishTask.Validate())
            {
                publishTask.Execute();
            }
        }

        /// <summary>
        /// Logs the banner.
        /// </summary>
		private void LogBanner()
		{
			Logger.LogMessage(Settings.LogoBanner);
		}

        /// <summary>
        /// Logs the section header.
        /// </summary>
        /// <param name="title">The title.</param>
		private void LogSectionHeader(string title)
		{
			Logger.LogMessage(string.Format("\n--------------------------------\n{0}\n--------------------------------", title));
		}
	}
}
