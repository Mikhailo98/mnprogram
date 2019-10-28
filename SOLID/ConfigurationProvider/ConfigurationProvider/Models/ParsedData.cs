using System;
using System.Collections.Generic;

namespace SolidTask.ConfigurationProvider.Models
{
	public class ParsedData
	{
		public string Namespace { get; set; }

		public string ClassName { get; set; }

		public string Property { get; set; }

		public string Value { get; set; }

		public IEnumerable<Type> Types { get; set; }
	}
}