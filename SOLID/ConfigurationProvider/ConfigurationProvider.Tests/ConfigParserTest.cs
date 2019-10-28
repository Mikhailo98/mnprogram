using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using SolidTask.ConfigurationProvider.Base;
using SolidTask.ConfigurationProvider.Exceptions;
using SolidTask.ConfigurationProvider.Models;
using SolidTask.ConfigurationProvider.Parser;
using Xunit;

namespace SolidTask.ConfigurationProvider.Tests
{
    public class ConfigParserTest
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    @"SolidTask.IT.Tests.ServiceSettingsTest.ConnectionString=sqlserver/dba #It is a comment",
                    new List<Result<ParsedData>>
                    {
                        Result.Ok(new ParsedData
                        {
                            ClassName = "ServiceSettingsTest",
                            Namespace = "SolidTask.IT.Tests",
                            Property = "ConnectionString",
                            Value = "sqlserver/dba"
                        })
                    }
                },

                new object[]
                {
                    @"SolidTask.Model.Tests.ServiceSettingsTest.Port=1
                      ServiceSettingsTest.BatchSize=1",
                    new List<Result<ParsedData>>
                    {
                        Result.Ok(new ParsedData
                        {
                            ClassName = "ServiceSettingsTest",
                            Namespace = "SolidTask.Model.Tests",
                            Property = "Port",
                            Value = "1"
                        }),
                        Result.Ok(new ParsedData
                        {
                            ClassName = "ServiceSettingsTest",
                            Namespace = "",
                            Property = "BatchSize",
                            Value = "1"
                        })
                    }
                }
            };


        [Theory]
        [MemberData(nameof(Data))]
        public void ParseConfig_PassValidValues_ReturnExpectedValidResult(string txt, IEnumerable<Result<ParsedData>> expectedResult)
        {
            //Arrange
            var mock = new Mock<IParsedDataValidator>();
            mock.Setup(a => a.ValidateClass(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => Result.Ok<IEnumerable<Type>>(null));
            mock.Setup(a => a.ValidateProperty(It.IsAny<IEnumerable<Type>>(), It.IsAny<string>()))
                .Returns(Result.Ok);

            var txtConfigParser = new TxtConfigParser(new TxtParserConfiguration(), mock.Object);

            //Act
            var actualResult = txtConfigParser.ParseConfig(txt);

            //Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }


        [Fact]
        public void ParseConfig_PassValueWithoutAssignmentChar_ResultContainsErrors()
        {
            //Arrange
            var mock = new Mock<IParsedDataValidator>();

            var txtConfigParser = new TxtConfigParser(new TxtParserConfiguration(), mock.Object);
            var txtConfig = @"undefinedNameSpace.ClassThatDoesNotExists.ConnectionStringsqlserver/dba";

            //Act
            var act = txtConfigParser.ParseConfig(txtConfig).ToList();

            //Assert
            act.Should().OnlyContain(p => p.Failure);
        }

        [Fact]
        public void ParseConfig_PassValueWithUndefinedClassAndNamespace_ResultContainsErrors()
        {
            //Arrange
            var mock = new Mock<IParsedDataValidator>();
            mock.Setup(a => a.ValidateProperty(It.IsAny<IEnumerable<Type>>(), It.IsAny<string>()))
                .Returns(() => Result.Fail("failed message"));
            mock.Setup(a => a.ValidateClass(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => Result.Ok<IEnumerable<Type>>(null));

            var txtConfigParser = new TxtConfigParser(new TxtParserConfiguration(), mock.Object);
            var txtConfig = @"WrongNamespace.UndefinedClass.ConnectionString=sqlserver/dba";

            //Act
            var act = txtConfigParser.ParseConfig(txtConfig).ToList();

            //Assert
            act.Should().OnlyContain(p => p.Failure);
        }
    }
}