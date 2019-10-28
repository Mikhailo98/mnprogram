using System;

namespace Uvar
{
    public abstract class FeedItem
    {
        public abstract int FeedId { get; }
        public int StagingId { get; set; }
        public string SourceTradeRef { get; set; }
        public int CounterPartyId { get; set; }
        public int PrincipalId { get; set; }
        public DateTime ValuationDate { get; set; }
        public decimal CurrentPrice { get; set; }
        public int SourceAccountId { get; set; }
    }
}