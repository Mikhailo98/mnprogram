using System;
using System.Collections.Generic;
using SolidTask.ConfigurationProvider.Models;

namespace SolidTask.ConfigurationProvider.Base
{
	public interface IParsedDataValidator
	{
        Result<IEnumerable<Type>> ValidateClass(string className, string Namespace = null);
        Result ValidateProperty(IEnumerable<Type> classes, string property);
    }
}