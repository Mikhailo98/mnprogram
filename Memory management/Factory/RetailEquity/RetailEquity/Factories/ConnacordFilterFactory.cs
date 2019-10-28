using System.Collections.Generic;
using RetailEquity.Filters;

namespace RetailEquity.Factories
{
    public class ConnacordFilterFactory : IFilterFactory
    {
        private readonly int _greaterThanAmount = 10;
        private readonly int _lessThanAmount = 40;
        private readonly TradeType _tradeType = TradeType.Future;

        public List<IFilter> CreateFilter()
        {
            return new List<IFilter>
            {
                new AmountGreaterThanFilter(_greaterThanAmount),
                new AmountLessThanFilter(_lessThanAmount),
                new TradeTypeFilter(_tradeType)
            };
        }
    }
}