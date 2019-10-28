using System;
using System.Text.RegularExpressions;

namespace SolidTask.ConfigurationProvider.Parser
{
	public class TxtParserConfiguration
	{
		public TxtParserConfiguration()
		{
			NewLineString = Environment.NewLine;
			KeyValueAssignmentString = "=";

			KeyRgx = new Regex(@".+?(?==)");
			ValueRgx = new Regex(@"(?<==)[^ ]*");
			CommentsRgx = new Regex(@"(#.*$)|(/\*[^(\*/)]+\*/)", RegexOptions.Compiled | RegexOptions.Multiline);
			KeyValueRgx = new Regex($@".+?(?==){KeyValueAssignmentString}[^ ]*", RegexOptions.Compiled);
		}

		public Regex ValueRgx { get; set; }
		public Regex KeyRgx { get; set; }
		public Regex KeyValueRgx { get; set; }
		public Regex CommentsRgx { get; set; }
		public string KeyValueAssignmentString { get; set; }
		public string NewLineString { get; set; }
	}
}