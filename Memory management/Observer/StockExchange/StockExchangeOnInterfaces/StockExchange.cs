using System;
using System.Collections.Generic;

namespace StockExchangeOnInterfaces
{
	public class StockExchange : IStockObservable
	{
		private readonly List<IStockObserver> _observers = new List<IStockObserver>();
		public List<Company> Companies { get; } = new List<Company>();

		public IDisposable Subscribe(IStockObserver observer)
		{
			if (!_observers.Contains(observer))
				_observers.Add(observer);
			return new Unsubscriber(_observers, observer);
		}

		public void AddCompany(Company newCompany)
		{
			Companies.Add(newCompany);
			Notify();
		}

		private void Notify()
		{
			foreach (var item in _observers)
				item.Update();
		}

		private class Unsubscriber : IDisposable
		{
			private readonly IStockObserver _observer;
			private readonly List<IStockObserver> _observers;

			public Unsubscriber(List<IStockObserver> observers, IStockObserver observer)
			{
				_observers = observers;
				_observer = observer;
			}

			public void Dispose()
			{
				if (_observer != null && _observers.Contains(_observer))
					_observers.Remove(_observer);
			}
		}
	}
}