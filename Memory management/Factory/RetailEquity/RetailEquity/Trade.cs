using System;

namespace RetailEquity
{
    public class Trade : IEquatable<Trade>
    {
        public Trade(int amount, TradeSubType tradeSubType, TradeType tradeType)
        {
            Amount = amount;
            TradeSubType = tradeSubType;
            TradeType = tradeType;
        }

        public int Amount { get; }
        public TradeSubType TradeSubType { get; }
        public TradeType TradeType { get; }


        public bool Equals(Trade other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return Amount == other.Amount && TradeSubType == other.TradeSubType && TradeType == other.TradeType;
        }
    }

    public enum TradeType
    {
        Option,
        Future
    }

    public enum TradeSubType
    {
        NyOption,
        MyOption
    }
}