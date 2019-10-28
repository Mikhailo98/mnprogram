namespace StockExchangeOnInterfaces
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var c1 = new Company {Name = "Apple"};
			var c2 = new Company {Name = "Microsoft"};
			var c3 = new Company {Name = "Google"};
			var c4 = new Company {Name = "Alphabet"};
			var c5 = new Company {Name = "Samsung"};

			var stockExchange = new StockExchange();
			stockExchange.AddCompany(c1);

			var bank1 = new Bank("PrivatBank");
			var bank2 = new Bank("UkrSib");

			bank1.Subscribe(stockExchange);
			bank2.Subscribe(stockExchange);

			stockExchange.AddCompany(c2);

			bank2.Unsubscribe();

			stockExchange.AddCompany(c3);
			stockExchange.AddCompany(c4);
			stockExchange.AddCompany(c5);
		}
	}
}