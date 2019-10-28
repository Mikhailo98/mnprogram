using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using SolidTask.ConfigurationProvider.Models;

namespace SolidTask.ConfigurationProvider.Collections
{
	public class KeyedByTypeCollection
	{
		private readonly ConcurrentDictionary<Type, IEnumerable<ParsedData>> _keyedByTypeCollection =
			new ConcurrentDictionary<Type, IEnumerable<ParsedData>>();

		public void AddOrUpdate(Type type, ParsedData parsedData)
		{
			_keyedByTypeCollection.AddOrUpdate(type, new[] {parsedData},
				(t, list) =>
				{
					var data = list.FirstOrDefault(p => p.Property == parsedData.Property);
					if (data == null)
						list = list.Append(parsedData);
					else
						data.Value = parsedData.Value;

					return list;
				});
		}

		public void AddOrUpdate(IEnumerable<ParsedData> parsedDatas)
		{
			foreach (var parsedData in parsedDatas)
			foreach (var type in parsedData.Types)
				AddOrUpdate(type, parsedData);
		}

		public IEnumerable<ParsedData> Get(Type type)
		{
			return _keyedByTypeCollection.GetValueOrDefault(type);
		}
	}
}