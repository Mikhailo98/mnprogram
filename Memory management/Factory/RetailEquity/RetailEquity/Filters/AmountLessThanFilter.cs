using System.Collections.Generic;
using System.Linq;

namespace RetailEquity.Filters
{
    public class AmountLessThanFilter : IFilter
    {
        private readonly int _count;

        public AmountLessThanFilter(int count)
        {
            _count = count;
        }

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(p => p.Amount < _count);
        }
    }
}