using System.Collections.Generic;
using System.Linq;

namespace RetailEquity.Filters
{
    public class TradeSubTypeFilter : IFilter
    {
        private readonly TradeSubType _tradeSubType;

        public TradeSubTypeFilter(TradeSubType tradeSubType)
        {
            _tradeSubType = tradeSubType;
        }

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(p => p.TradeSubType == _tradeSubType);
        }
    }
}