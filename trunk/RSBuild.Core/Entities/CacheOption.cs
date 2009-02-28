using System;

using Microsoft.SqlServer.ReportingServices;

namespace RSBuild
{
	/// <summary>
	/// Represents cache options.
	/// </summary>
	public class CacheOption
	{
		private bool _CacheReport;
		private ExpirationDefinition _ExpirationDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheOption"/> class.
        /// </summary>
		public CacheOption() : this(false, null)
		{}

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheOption"/> class.
        /// </summary>
        /// <param name="expirationDef">The expiration definition.</param>
		public CacheOption(ExpirationDefinition expirationDef) : this(true, expirationDef)
		{}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CacheOption"/> class.
        /// </summary>
        /// <param name="cacheReport">If set to <c>true</c> report should be cached.</param>
        /// <param name="expirationDef">The expiration definition.</param>
		public CacheOption(bool cacheReport, ExpirationDefinition expirationDef)
		{
			_CacheReport = cacheReport;
			_ExpirationDef = expirationDef;
		}

        /// <summary>
        /// Gets a value indicating whether report is cached.
        /// </summary>
        /// <value><c>true</c> if report is cached; otherwise, <c>false</c>.</value>
		public bool CacheReport
		{
			get
			{
				return _CacheReport;
			}
		}

        /// <summary>
        /// Gets the expiration definition.
        /// </summary>
        /// <value>The expiration definition.</value>
		public ExpirationDefinition ExpirationDefinition
		{
			get
			{
				return _ExpirationDef;
			}
		}
	}
}
