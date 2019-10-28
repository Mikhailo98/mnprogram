using System;

namespace Uvar
{
    public class DeltaOneFeed : FeedItem
    {
        public int Isin { get; set; }
        public DateTime MaturityDate { get; set; }
        public override int FeedId => CounterPartyId + PrincipalId;
    }
}