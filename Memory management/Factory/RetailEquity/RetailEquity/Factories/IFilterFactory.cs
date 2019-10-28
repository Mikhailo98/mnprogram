using System.Collections.Generic;
using RetailEquity.Filters;

namespace RetailEquity.Factories
{
    public interface IFilterFactory
    {
        List<IFilter> CreateFilter();
    }
}