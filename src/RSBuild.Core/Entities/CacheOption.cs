using System;

namespace RSBuild.Entities
{
	/// <summary>
	/// Represents cache options.
	/// </summary>
	public class CacheOption
	{
		private readonly bool _cacheReport;
        private readonly int? _expirationMinutes;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheOption"/> class.
        /// </summary>
		public CacheOption() : this(false, null)
		{}

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheOption"/> class.
        /// </summary>
        /// <param name="expirationMinutes">The expiration definition.</param>
		public CacheOption(int expirationMinutes) : this(true, expirationMinutes)
		{}

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheOption"/> class.
        /// </summary>
        /// <param name="cacheReport">If set to <c>true</c> report should be cached.</param>
        /// <param name="expirationMinutes">The expiration definition.</param>
        private CacheOption(bool cacheReport, int? expirationMinutes)
		{
            if (expirationMinutes.HasValue && expirationMinutes.Value < 0)
            {
                throw new ArgumentException("Expiration time must be zero or greater", "expirationMinutes");
            }

			_cacheReport = cacheReport;
            _expirationMinutes = expirationMinutes;
		}

        /// <summary>
        /// Gets a value indicating whether report is cached.
        /// </summary>
        /// <value><c>true</c> if report is cached; otherwise, <c>false</c>.</value>
		public bool CacheReport
		{
			get { return _cacheReport; }
		}

        /// <summary>
        /// Gets the expiration definition.
        /// </summary>
        /// <value>The expiration definition.</value>
		public int? ExpirationMinutes
		{
			get { return _expirationMinutes; }
		}
	}
}
