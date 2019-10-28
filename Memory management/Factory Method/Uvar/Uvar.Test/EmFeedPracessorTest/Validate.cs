using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Uvar.Test
{
	[TestFixture]
	public partial class EmFeedProcessorTest
	{
		public class Validate
		{
			[Test]
			public void SendNull_ReturnArgumentException()
			{
				//Arrange
				var feedProcessor = new EmFeedProcessor(new AccountRepository());

				//Assert
				Assert.Throws<ArgumentNullException>(() =>
				{
					//Act
					feedProcessor.Validate(null);
				});
			}

			[Test]
			public void SendItemWithDefaultStringOfSedol_ReturnArrayWithOneValidationError()
			{
				//Arrange
				var feedProcessor = new EmFeedProcessor(new AccountRepository());

				//Act
				var actualResult = feedProcessor.Validate(new EmFeed() { AssetValue = 123 });

				//Assert
				CollectionAssert.IsNotEmpty(actualResult);
			}

			[Test]
			public void SendItemWithDefaultIntegerOfAssetValue_ReturnArrayWithOneValidationError()
			{
				//Arrange
				var feedProcessor = new EmFeedProcessor(new AccountRepository());

				//Act
				var actualResult = feedProcessor.Validate(new EmFeed() { Sedol = "123" });

				//Assert
				CollectionAssert.IsNotEmpty(actualResult);
			}

			[Test]
			public void SendProperItems_ReturnEmptyValidationErrorArray()
			{
				//Arrange
				var feedProcessor = new EmFeedProcessor(new AccountRepository());
				var list = FeedInitializer.EmFeedInitialize();

				//Act
				var actualResult = feedProcessor.Validate(list[0]);

				//Assert
				CollectionAssert.IsEmpty(actualResult);
			}
		}
	}
}
