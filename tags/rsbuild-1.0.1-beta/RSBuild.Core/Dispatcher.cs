using System;

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
			DBTask task2 = new DBTask();
			if (task2.Validate())
			{
				task2.Execute();
			}

			LogSectionHeader("Reports Installation");
			PublishTask task1 = new PublishTask();
			if (task1.Validate())
			{
				task1.Execute();
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
