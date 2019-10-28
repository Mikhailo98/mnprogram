namespace StockExchangeOnDelegates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var c1 = new Company { Name = "Apple" };
            var c2 = new Company { Name = "Microsoft" };
            var c3 = new Company { Name = "Google" };
            var c4 = new Company { Name = "Alphabet" };
            var c5 = new Company { Name = "Samsung" };

            var stockExchange = new StockExchange();
            stockExchange.AddCompany(c1);

            var bank1 = new Bank("PrivatBank");
            var bank2 = new Bank("UkrSib");
            stockExchange.ObserverHandler += bank1.InternalBankingProcessing;
            stockExchange.ObserverHandler += bank2.InternalBankingProcessing;

            stockExchange.AddCompany(c2);

            var scoundrel = new Scoundrel(stockExchange);

            stockExchange.AddCompany(c3);
            stockExchange.AddCompany(c4);
            stockExchange.AddCompany(c5);
        }
    }
}