using System;

namespace RSBuild
{
	/// <summary>
	/// Helper methods for logging.
	/// </summary>
	public static class Logger
	{
        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="e">The exception.</param>
		public static void LogException( string module, Exception e ) 
		{
			LogException( module, e.Message );
		}

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="message">The message.</param>
		public static void LogException( string module, string message ) 
		{
			Console.WriteLine(string.Format("[{0}]: {1}", module, message));
		}

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">The message.</param>
		public static void LogMessage( string message ) 
		{
			Console.WriteLine(message);
		}
	}
}
