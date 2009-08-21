namespace RSBuild
{
	/// <summary>
	/// Program dispatcher.
	/// </summary>
	public class Dispatcher
	{
	    private readonly string _settingsFileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dispatcher"/> class.
        /// </summary>
        /// <param name="args">The arguments.</param>
		public Dispatcher(string[] args)
		{
            _settingsFileName = args != null && args.Length > 0
                ? args[0]
                : null;
		}

        /// <summary>
        /// Runs this instance.
        /// </summary>
		public void Run()
		{
            Settings settings = Settings.Load(_settingsFileName);
			LogBanner();
			RunTasks(settings);
		}

        /// <summary>
        /// Runs the tasks.
        /// </summary>
		private void RunTasks(Settings settings)
		{
			// need refactoring
			
			LogSectionHeader("Database Installation");
			DBTask dbTask = new DBTask(settings);
			if (dbTask.Validate())
			{
				dbTask.Execute();
			}

			LogSectionHeader("Reports Installation");
            PublishTask publishTask = new PublishTask(settings);
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
