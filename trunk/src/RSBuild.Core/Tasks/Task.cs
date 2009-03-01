using System;

namespace RSBuild
{
	/// <summary>
	/// Represents a task.
	/// </summary>
	public abstract class Task
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
		public Task()
		{}

        /// <summary>
        /// Executes this instance.
        /// </summary>
		public abstract void Execute();

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>true if the task is valid.</returns>
		public abstract bool Validate();
	}
}
