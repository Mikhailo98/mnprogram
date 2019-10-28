using System.Collections.Generic;
using System.IO;
using SolidTask.ConfigurationProvider.Collections;

namespace SolidTask.ConfigurationProvider.Base
{
	public interface IConfigReader
	{
		KeyedByTypeCollection ReadConfigs(IEnumerable<FileInfo> configs);
	}
}