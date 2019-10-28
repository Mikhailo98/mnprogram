using System;

namespace StockExchangeOnInterfaces
{
	public interface IStockObservable
	{
		IDisposable Subscribe(IStockObserver observer);
	}
}