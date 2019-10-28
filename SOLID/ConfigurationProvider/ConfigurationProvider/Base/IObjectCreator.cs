using System.Collections.Generic;
using SolidTask.ConfigurationProvider.Models;

namespace SolidTask.ConfigurationProvider.Base
{
	public interface IObjectCreator
	{
		T Create<T>(IEnumerable<ParsedData> parsedDataCollection);
	}
}