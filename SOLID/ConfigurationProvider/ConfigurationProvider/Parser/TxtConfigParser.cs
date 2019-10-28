using System;
using System.Collections.Generic;
using SolidTask.ConfigurationProvider.Base;
using SolidTask.ConfigurationProvider.Models;
using SolidTask.ConfigurationProvider.Reader;

namespace SolidTask.ConfigurationProvider.Parser
{
    public class TxtConfigParser : IConfigParser
    {
        private readonly IParsedDataValidator _parsedDataValidator;
        private readonly TxtParserConfiguration _parserConfiguration;

        public TxtConfigParser(TxtParserConfiguration txtParserConfiguration, IParsedDataValidator parsedDataValidator)
        {
            _parsedDataValidator = parsedDataValidator ?? throw new ArgumentNullException(nameof(parsedDataValidator));
            _parserConfiguration = txtParserConfiguration ?? throw new ArgumentNullException(nameof(txtParserConfiguration));
        }

        public TxtConfigParser() : this(new TxtParserConfiguration(), new ParsedDataValidator())
        {
        }

        public IEnumerable<Result<ParsedData>> ParseConfig(string txtData)
        {
            if (txtData == null) throw new ArgumentNullException(nameof(txtData));

            var spittedConfiguration = txtData.Split(_parserConfiguration.NewLineString);

            for (var lineNumber = 0; lineNumber < spittedConfiguration.Length; lineNumber++)
            {
                var line = _parserConfiguration.CommentsRgx
                    .Replace(spittedConfiguration[lineNumber], string.Empty)
                    .Trim();

                if (line == string.Empty) continue;

                var parsedDataResult = ProcessLine(line);
                if (parsedDataResult.Failure)
                {
                    yield return Result.Fail<ParsedData>(
                        $"value \'{spittedConfiguration[lineNumber]}\' on {lineNumber + 1} line has [{parsedDataResult.Error}] error");
                    continue;
                }

                yield return parsedDataResult;
            }
        }


        private Result<ParsedData> ProcessLine(string currentLine)
        {
            if (currentLine == null) throw new ArgumentNullException(nameof(currentLine));

            var assignmentPosition = currentLine.IndexOf(_parserConfiguration.KeyValueAssignmentString, StringComparison.Ordinal);
            if (assignmentPosition == -1) return Result.Fail<ParsedData>("Key-Value assignment sign was not found");

            var leftOperandResult = ExtractLeftPart(currentLine);
            if (leftOperandResult.Failure)
                return Result.Fail<ParsedData>(leftOperandResult.Error);

            var rightOperandResult = ExtractRightPart(currentLine);
            if (rightOperandResult.Failure)
                return Result.Fail<ParsedData>(rightOperandResult.Error);

            var leftOperand = leftOperandResult.Value;
            var rightOperand = rightOperandResult.Value;

            var propertyResult = ExtractProperty(leftOperand);
            if (propertyResult.Failure)
                return Result.Fail<ParsedData>(propertyResult.Error);

            var namespaceWithClassResult = ExtractClassWithNameSpace(leftOperand);
            if (namespaceWithClassResult.Failure)
                return Result.Fail<ParsedData>(namespaceWithClassResult.Error);

            var namespaceWithClass = namespaceWithClassResult.Value;

            var @class = namespaceWithClass.Substring(namespaceWithClass.LastIndexOf('.') + 1);
            var Namespace = namespaceWithClass != @class
                ? namespaceWithClass.Substring(0, namespaceWithClass.LastIndexOf('.'))
                : string.Empty;

            var types = _parsedDataValidator.ValidateClass(@class, Namespace);

            return types.OnSuccess(p => _parsedDataValidator.ValidateProperty(p, propertyResult.Value))
                .OnSuccess(() => Result.Ok(new ParsedData
                {
                    Namespace = Namespace,
                    ClassName = @class,
                    Property = propertyResult.Value,
                    Value = rightOperand,
                    Types = types.Value
                }));
        }


        private Result<string> ExtractLeftPart(string currentLine)
        {
            var leftOperand = _parserConfiguration.KeyRgx.Match(currentLine).Value;

            return string.IsNullOrWhiteSpace(leftOperand) 
                ? Result.Fail<string>("Left part is missing") 
                : Result.Ok(leftOperand);
        }

        private Result<string> ExtractRightPart(string currentLine)
        {
            var rightOperand = _parserConfiguration.ValueRgx.Match(currentLine).Value;

            return string.IsNullOrWhiteSpace(rightOperand) 
                ? Result.Fail<string>("Value is missing") 
                : Result.Ok(rightOperand);
        }

        private Result<string> ExtractClassWithNameSpace(string leftOperand)
        {
            var lastIndex = leftOperand.LastIndexOf('.');

            return lastIndex == -1
                    ? Result.Fail<string>("Error line processing: class or property does not specified")
                    : Result.Ok(leftOperand.Substring(0, lastIndex));
        }

        private Result<string> ExtractProperty(string leftOperand)
        {
            var property = leftOperand.Substring(leftOperand.LastIndexOf('.') + 1);

            return string.IsNullOrWhiteSpace(property)
                ? Result.Fail<string>("Property is missing")
                : Result.Ok(property);
        }
    }
}