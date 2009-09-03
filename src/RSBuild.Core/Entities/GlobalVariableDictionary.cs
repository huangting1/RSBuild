namespace RSBuild.Entities
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class GlobalVariableDictionary : Dictionary<string, string>
    {
        private static readonly Regex GlobalsRegex = new Regex(@"(?<g>\${(?<k>[^}]+)})", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Processes the globals.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public string ReplaceVariables(string input)
        {
            return GlobalsRegex.Replace(input, new MatchEvaluator(ReplaceMatches));
        }

        private string ReplaceMatches(Match match)
        {
            string key = match.Groups["k"].ToString();
            string toReplace = match.Groups["g"].ToString();
            string output = toReplace;
            if (ContainsKey(key))
            {
                output = this[key];
            }

            return output;
        }
    }
}
