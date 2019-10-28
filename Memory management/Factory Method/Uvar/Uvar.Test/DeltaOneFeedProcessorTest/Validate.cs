using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Uvar.Test.DeltaOneFeedProcessorTest
{
	[TestFixture]
	public partial class DeltaOneFeedProcessorTest
	{
		public class Validate
		{
			[Test]
			public void SendNull_ReturnArgumentException()
			{
				//Arrange
				var feedProcessor = new DeltaOneFeedProcessor(new AccountRepository());

				//Assert
				Assert.Throws<ArgumentNullException>(() =>
				{
					//Act
					feedProcessor.Validate(null);
				});
			}

			[Test]
			public void SendFeedItemOfAnotherType_ReturnArgumentException()
			{
				//Arrange
				var feedProcessor = new DeltaOneFeedProcessor(new AccountRepository());

				//Assert
				Assert.Throws<ArgumentException>(() =>
				{
					//Act
					feedProcessor.Validate(new EmFeed());
				});
			}

			[Test]
			public void SendItemWithDefaultDatetimeOfMaturnityDate_ReturnArrayWithOneValidationError()
			{
				//Arrange
				var feedProcessor = new DeltaOneFeedProcessor(new AccountRepository());

				//Act
				var actualResult = feedProcessor.Validate(new DeltaOneFeed() { Isin = 123 });

				//Assert
				CollectionAssert.IsNotEmpty(actualResult);
			}

			[Test]
			public void SendItemWithDefaultIntegerOfIsin_ReturnArrayWithOneValidationError()
			{
				//Arrange
				var feedProcessor = new DeltaOneFeedProcessor(new AccountRepository());

				//Act
				var actualResult = feedProcessor.Validate(new DeltaOneFeed() { MaturityDate = DateTime.Now });

				//Assert
				CollectionAssert.IsNotEmpty(actualResult);
			}

			[Test]
			public void SendProperItems_ReturnEmptyValidationErrorArray()
			{
				//Arrange
				var feedProcessor = new DeltaOneFeedProcessor(new AccountRepository());
				var list = FeedInitializer.DeltaOneFeedInitialize();

				//Act
				var actualResult = feedProcessor.Validate(list[0]);

				//Assert
				CollectionAssert.IsEmpty(actualResult);
			}
		}

	}
}
