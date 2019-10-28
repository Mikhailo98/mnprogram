using System;

namespace StockExchangeOnInterfaces
{
	public class Bank : IStockObserver
	{
		private IDisposable _unsubscriber;

		public Bank(string name)
		{
			Name = name;
		}

		public string Name { get; }
		public int NotifiedTimes { get; private set; }

		public void Update()
		{
			Console.WriteLine($"Bank '{Name}' is notified {++NotifiedTimes} times!");
		}

		public void Unsubscribe()
		{
			_unsubscriber?.Dispose();
		}

		public void Subscribe(IStockObservable stock)
		{
			_unsubscriber = stock.Subscribe(this);
		}
	}
}