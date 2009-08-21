using System;

namespace RSBuild
{
	/// <summary>
	/// Application entry.
	/// </summary>
	class AppEntry
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Dispatcher dispatcher = new Dispatcher(args);
			dispatcher.Run();
		}
	}
}
