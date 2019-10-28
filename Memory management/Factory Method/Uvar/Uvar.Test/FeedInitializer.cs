using System;
using System.Collections.Generic;

namespace Uvar
{
	internal static class FeedInitializer
	{
		internal static List<FeedItem> DeltaOneFeedInitialize()
		{
			return new List<FeedItem>
			{
				new DeltaOneFeed
				{
					CounterPartyId = 1,
					CurrentPrice = 2,
					Isin = 1,
					MaturityDate = DateTime.Now,
					PrincipalId = 4,
					SourceAccountId = 5,
					SourceTradeRef = "7",
					StagingId = 8,
					ValuationDate = new DateTime(1990, 11, 10)
				},
				new DeltaOneFeed
				{
					CounterPartyId = 2,
					CurrentPrice = 10,
					Isin = 2,
					MaturityDate = DateTime.Now,
					PrincipalId = 8,
					SourceAccountId = 3,
					SourceTradeRef = "3",
					StagingId = 6,
					ValuationDate = new DateTime(1993, 9, 10)
				},
				new DeltaOneFeed
				{
					CounterPartyId = 4,
					CurrentPrice = 22,
					Isin = 3,
					MaturityDate = DateTime.Now,
					PrincipalId = 7,
					SourceAccountId = 8,
					SourceTradeRef = "11",
					StagingId = 9,
					ValuationDate = new DateTime(1992, 3, 10)
				},
				new DeltaOneFeed
				{
					CounterPartyId = 9,
					CurrentPrice = 22,
					MaturityDate = DateTime.Now,
					PrincipalId = 7,
					SourceAccountId = 8,
					SourceTradeRef = "11",
					StagingId = 9,
					ValuationDate = new DateTime(1992, 3, 10)
				}
			};
		}

		internal static List<FeedItem> EmFeedInitialize()
		{
			return new List<FeedItem>
			{
				new EmFeed
				{
					CounterPartyId = 1,
					CurrentPrice = 2,
					AssetValue = 3,
					Sedol = "3",
					PrincipalId = 4,
					SourceAccountId = 5,
					SourceTradeRef = "7",
					StagingId = 8,
					ValuationDate = new DateTime(1990, 11, 10)
				},
				new EmFeed
				{
					CounterPartyId = 2,
					CurrentPrice = 10,
					AssetValue = 2,
					Sedol = "7",
					PrincipalId = 8,
					SourceAccountId = 5,
					SourceTradeRef = "3",
					StagingId = 6,
					ValuationDate = new DateTime(1993, 9, 10)
				},
				new EmFeed
				{
					CounterPartyId = 4,
					CurrentPrice = 22,
					AssetValue = 6,
					Sedol = "9",
					PrincipalId = 7,
					SourceAccountId = 8,
					SourceTradeRef = "11",
					StagingId = 9,
					ValuationDate = new DateTime(1992, 3, 10)
				}
			};
		}
	}
}