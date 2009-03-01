using System;
using System.Collections.Specialized;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;

namespace RSBuild
{
	/// <summary>
	/// Utility methods.
	/// </summary>
	public static class Util
	{
        /// <summary>
        /// Replaces the specified string to replace.
        /// </summary>
        /// <param name="stringToReplace">The string to replace.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <returns></returns>
		public static string Replace(string stringToReplace, string oldValue, string newValue)
		{
			return Regex.Replace(stringToReplace, oldValue, newValue, RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}

        /// <summary>
        /// Validates the distance.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
		public static bool ValidateDistance(string input)
		{
			Regex reg = new Regex(@"^\d+(\.\d*)*in$", RegexOptions.Compiled|RegexOptions.IgnoreCase); 
			return reg.IsMatch(input);
		}

        /// <summary>
        /// Gets the XML namespace manager.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The XML namespace manager</returns>
		public static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument input)
		{
			StringCollection namespaces = DetectXmlNamespace(input);
			XmlNamespaceManager xnm = null;
			
			if (namespaces != null && namespaces.Count > 0)
			{
				xnm = new XmlNamespaceManager(input.NameTable);
				foreach(string ns in namespaces) 
				{
					string[] arr = ns.Split('|');
					xnm.AddNamespace(arr[0].Trim(), arr[1].Trim());
				}
			}

			return xnm;
		}

        /// <summary>
        /// Detects the XML namespace.
        /// </summary>
        /// <param name="doc">The doc.</param>
        /// <returns></returns>
		private static StringCollection DetectXmlNamespace(XmlDocument doc) 
		{
			StringCollection detectedNamespaces = null;

			if (doc != null)
			{
				XmlNode xmlNode = doc.DocumentElement;
				detectedNamespaces = new StringCollection();
				DiscoverNamespace(xmlNode, detectedNamespaces);
			}

			return detectedNamespaces;
		}

        /// <summary>
        /// Discovers the namespace.
        /// </summary>
        /// <param name="xmlNode">The XML node.</param>
        /// <param name="discovered">The discovered.</param>
		private static void DiscoverNamespace(XmlNode xmlNode, StringCollection discovered)
		{
			string nsPrefix;
			string nsUri;

			if (xmlNode.NodeType == XmlNodeType.Element) 
			{
				if (xmlNode.Attributes.Count > 0) 
				{
					foreach(XmlAttribute attr in xmlNode.Attributes)
					{
						if (attr.Name.StartsWith("xmlns")) 
						{
							string nsDef = attr.Name.Split('=')[0];
							if (string.Compare(nsDef, "xmlns", true) != 0) 
							{
								nsPrefix = nsDef.Split(':')[1];
							}
							else 
							{
								nsPrefix = "def";
							}
							nsUri = attr.Value;

							discovered.Add(string.Format("{0}|{1}", nsPrefix, nsUri));
						}
					}
				}
				if (xmlNode.HasChildNodes) 
				{
					foreach(XmlNode node in xmlNode.ChildNodes)
					{
						DiscoverNamespace(node, discovered);
					}
				}
			}
		}

        /// <summary>
        /// Strings to byte array.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
		public static byte[] StringToByteArray(string input)
		{
			return Encoding.UTF8.GetBytes(input);
		}

        /// <summary>
        /// Formats the path.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
		public static string FormatPath(string input)
		{
			if (input != null && input.Trim().Length > 0)
			{
				string output = input.Replace("\\", "/");
				if (!output.StartsWith("/"))
				{
					output = string.Format("/{0}", output);
				}
				if (output.EndsWith("/"))
				{
					output = output.Substring(0, output.Length-1);
				}
				return output;
			}
			else
			{
				return "/";
			}
		}

        /// <summary>
        /// Gets the relative path.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
		public static string GetRelativePath(string source, string target)
		{
			string pathSource = Util.FormatPath(source);
			string pathTarget = Util.FormatPath(target);
			string[] sourceSegments = null;
			string[] targetSegments = null;
			int sourceToCommonRoot = 0, targetToCommonRoot = 0;
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
