using System.Collections.Generic;
using RetailEquity.Filters;

namespace RetailEquity.Factories
{
    public class BarclaysFilterFactory : IFilterFactory
    {
        private readonly int _greaterThanAmount = 50;
        private readonly TradeSubType _tradeSubType = TradeSubType.NyOption;
        private readonly TradeType _tradeType = TradeType.Option;

        public List<IFilter> CreateFilter()
        {
            return new List<IFilter>
            {
                new AmountGreaterThanFilter(_greaterThanAmount),
                new TradeTypeFilter(_tradeType),
                new TradeSubTypeFilter(_tradeSubType)
            };
        }
    }
}