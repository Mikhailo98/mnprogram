using System;
using System.Collections.Generic;
using SolidTask.ConfigurationProvider.Base;
using SolidTask.ConfigurationProvider.Models;

namespace SolidTask.ConfigurationProvider
{
	public class ObjectCreator : IObjectCreator
	{
		public T Create<T>(IEnumerable<ParsedData> parsedDataCollection)
		{
			if (parsedDataCollection == null) throw new ArgumentNullException(nameof(parsedDataCollection));

			var objectInstance = Activator.CreateInstance<T>();

			foreach (var parsedData in parsedDataCollection)
			{
				var value = parsedData.Value;
				var modelProperty = parsedData.Property;

				var property = objectInstance.GetType().GetProperty(modelProperty);
				if (property == null) continue;

				var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

				var safeValue = value != null ? Convert.ChangeType(value, propertyType) : null;

				property.SetValue(objectInstance, safeValue, null);
			}

			return objectInstance;
		}
	}
}