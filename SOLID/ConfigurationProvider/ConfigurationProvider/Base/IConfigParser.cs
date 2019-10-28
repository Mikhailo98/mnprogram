using System.Collections.Generic;
using SolidTask.ConfigurationProvider.Models;

namespace SolidTask.ConfigurationProvider.Base
{
	public interface IConfigParser
	{
		IEnumerable<Result<ParsedData>> ParseConfig(string configData);
	}
}