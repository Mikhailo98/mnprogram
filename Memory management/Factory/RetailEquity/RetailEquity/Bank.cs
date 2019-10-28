using System;
using System.Collections.Generic;
using System.Linq;
using RetailEquity.Factories;
using RetailEquity.Filters;

namespace RetailEquity
{
	public class Bank
	{
		protected readonly List<IFilter> Filters;

		public Bank(IFilterFactory filterFactory)
		{
			if (filterFactory == null) throw new ArgumentNullException(nameof(filterFactory));

			Filters = filterFactory.CreateFilter();
		}

		public IEnumerable<Trade> Trade(IEnumerable<Trade> trades)
		{
			if (trades == null) throw new ArgumentNullException(nameof(trades));

			foreach (var filter in Filters)
				trades = filter.Match(trades);
			
			return trades.ToList();
		}
	}

	public class BofaBank : Bank
	{
		public BofaBank(BofaFilterFactory filterFactory) : base(filterFactory)
		{
		}
	}

	public class ConnacordBank : Bank
	{
		public ConnacordBank(ConnacordFilterFactory filterFactory) : base(filterFactory)
		{
		}
	}

	public class BarclaysBank : Bank
	{
		public BarclaysBank(BarclaysFilterFactory filterFactory) : base(filterFactory)
		{
		}
	}
}