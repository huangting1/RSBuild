namespace RSBuild
{
    using System.Text;

    /// <summary>
	/// Utility methods.
	/// </summary>
	public static class PathUtil
	{
        /// <summary>
        /// Formats the path.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
		public static string FormatPath(string input)
		{
            const char DIR_SEPARATOR = '/';

            input = input == null
                ? string.Empty
                : input.Trim();
            if (input.Length == 0) return DIR_SEPARATOR.ToString();

            StringBuilder sb = new StringBuilder(input).Replace('\\', DIR_SEPARATOR);
            if (sb[sb.Length - 1] == DIR_SEPARATOR)
            {
                sb.Length -= 1;
            }
            if (sb[0] != DIR_SEPARATOR)
            {
                sb.Insert(0, DIR_SEPARATOR);
            }
            return sb.ToString();
		}

        /// <summary>
        /// Gets the relative path.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
		public static string GetRelativePath(string source, string target)
		{
			string pathSource = PathUtil.FormatPath(source);
			string pathTarget = PathUtil.FormatPath(target);
			string[] sourceSegments = null;
			string[] targetSegments = null;
            int sourceToCommonRoot = 0;
            int targetToCommonRoot = 0;
			
            if (pathSource != "/")
			{
				sourceSegments = pathSource.Split('/');
				sourceToCommonRoot = sourceSegments.GetUpperBound(0);
			}
			if (pathTarget != "/")
			{
				targetSegments = pathTarget.Split('/');
				targetToCommonRoot = targetSegments.GetUpperBound(0);
			}
			
            StringBuilder relativePath = new StringBuilder();
			int parentSegments = sourceToCommonRoot;
			int i = 1;

			while(sourceToCommonRoot >= i && targetToCommonRoot >= i)
			{
				if (string.Compare(sourceSegments[i], targetSegments[i], true) == 0)
				{
					parentSegments--;
					i++;
				}
				else
				{
					break;
				}
			}

			for(int k=0; k<parentSegments; k++)
			{
				relativePath.Append("../");
			}

			for(int m=i; m<=targetToCommonRoot; m++)
			{
				relativePath.AppendFormat("{0}/", targetSegments[m]);
			}

			return relativePath.ToString();

		}
	}
}
