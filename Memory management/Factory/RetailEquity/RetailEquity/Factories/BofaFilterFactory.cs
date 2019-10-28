using System.Collections.Generic;
using RetailEquity.Filters;

namespace RetailEquity.Factories
{
    public class BofaFilterFactory : IFilterFactory
    {
        private readonly int _greaterThanAmount = 70;

        public List<IFilter> CreateFilter()
        {
            return new List<IFilter> { new AmountGreaterThanFilter(_greaterThanAmount) };
        }
    }
}