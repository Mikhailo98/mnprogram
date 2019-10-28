using System;
using System.Collections.Generic;
using System.Linq;
using SolidTask.ConfigurationProvider.Base;
using SolidTask.ConfigurationProvider.Models;

namespace SolidTask.ConfigurationProvider.Reader
{
    public class ParsedDataValidator : IParsedDataValidator
    {
        public Result<IEnumerable<Type>> ValidateClass(string className, string Namespace = null)
        {
            var result = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes()).Where(t => t.IsClass && t.Name == className
                                                                    && (string.IsNullOrEmpty(Namespace) ||
                                                                        t.Namespace == Namespace));

            if (!result.Any())
                return Result.Fail<IEnumerable<Type>>($"Assembly does not contain class \'{className}\' in \'{Namespace}\' namespace");

            return Result.Ok(result);
        }

        public Result ValidateProperty(IEnumerable<Type> classes, string property)
        {
            var result = Result.Ok();

            foreach (var classType in classes)
            {
                if (classType.GetProperty(property) == null)
                    result = Result.Fail(string.Format($"Class \'{classType.FullName}\' does not contain \'{property}\' property \n {result.Error}"));
            }

            return result;
        }
    }
}