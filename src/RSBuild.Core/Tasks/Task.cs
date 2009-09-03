namespace RSBuild.Tasks
{
	/// <summary>
	/// Represents a task.
	/// </summary>
	public abstract class Task
	{
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
