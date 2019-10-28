using System;
using System.Collections.Generic;
using System.IO;
using SolidTask.ConfigurationProvider.Base;
using SolidTask.ConfigurationProvider.Collections;
using SolidTask.ConfigurationProvider.Exceptions;
using SolidTask.ConfigurationProvider.Models;

namespace SolidTask.ConfigurationProvider.Reader
{
	public class TxtConfigReader : IConfigReader
	{
		private readonly IConfigParser _configParser;

		public TxtConfigReader(IConfigParser configParser)
		{
			_configParser = configParser;
		}


		public KeyedByTypeCollection ReadConfigs(IEnumerable<FileInfo> configs)
		{
			if (configs == null) throw new ArgumentNullException(nameof(configs));
            
            var result = Result.Ok();
            var list = new List<ParsedData>();
            var keyedByTypeCollection = new KeyedByTypeCollection();

            foreach (var fileInfo in configs)
            {
                var parsedDataResults = _configParser.ParseConfig(File.ReadAllText(fileInfo.FullName));

                foreach (var parsedData in parsedDataResults)
                {
                    if (parsedData.Failure)
                        result = Result.Fail($"File {fileInfo.Name}: {parsedData.Error} \n\n {result.Error}");

                    list.Add(parsedData.Value);
                }
            }

            if (result.Failure)
                throw new ParsingException(result.Error);

            keyedByTypeCollection.AddOrUpdate(list);

            return keyedByTypeCollection;
        }
    }
}