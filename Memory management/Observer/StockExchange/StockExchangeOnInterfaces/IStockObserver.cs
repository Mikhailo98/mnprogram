namespace StockExchangeOnInterfaces
{
	public interface IStockObserver
	{
		void Update();
		void Unsubscribe();
		void Subscribe(IStockObservable stock);
	}
}