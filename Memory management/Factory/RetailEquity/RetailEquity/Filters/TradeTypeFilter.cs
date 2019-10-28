using System.Collections.Generic;
using System.Linq;

namespace RetailEquity.Filters
{
    public class TradeTypeFilter : IFilter
    {
        private readonly TradeType _tradeType;

        public TradeTypeFilter(TradeType tradeType)
        {
            _tradeType = tradeType;
        }

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(p => p.TradeType == _tradeType);
        }
    }
}