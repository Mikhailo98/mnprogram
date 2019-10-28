using System.Collections.Generic;
using Epam.NetMentoring.IT;
using FluentAssertions;
using SolidTask.ConfigurationProvider.Models;
using Xunit;

namespace SolidTask.ConfigurationProvider.Tests
{
	public class ObjectCreatorTest
	{
		public static IEnumerable<object[]> Data =>
			new List<object[]>
			{
				new object[]
				{
					new List<ParsedData>
					{
						new ParsedData
						{
							ClassName = "ServiceSettings",
							Namespace = "Epam.NetMentoring",
							Property = "Port",
							Value = "1"
						},
						new ParsedData
						{
							ClassName = "ServiceSettings",
							Namespace = "",
							Property = "BatchSize",
							Value = "1"
						}
					},
					new ServiceSettings
					{
						BatchSize = 1,
						Port = 1
					}
				}
			};

		[Theory]
		[MemberData(nameof(Data))]
		public void Create(List<ParsedData> parsedData, object instance)
		{
			var creator = new ObjectCreator();

			var actualInstance = creator.Create<ServiceSettings>(parsedData);

			actualInstance.Should().BeEquivalentTo(instance);
		}
	}
}