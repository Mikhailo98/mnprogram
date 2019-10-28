using System;

namespace StockExchangeOnDelegates
{
    internal class Scoundrel
    {
        private readonly StockExchange _stockExchange;
        public int NotifiedTimes { get; private set; }

        public Scoundrel(StockExchange stockExchange)
        {
            _stockExchange = stockExchange;
            _stockExchange.ObserverHandler += BreakDownStockExchangeSystem;
        }

        public void BreakDownStockExchangeSystem()
        {
            Console.WriteLine($"Scoundrel is notified {++NotifiedTimes} times!");

            if (_stockExchange.Companies.Count <= 2)
                return;

            //cannot assign null as in StockExchangeOnDelegates version 
            //_stockExchange.ObserverHandler = null;
            _stockExchange.ObserverHandler += BreakDownStockExchangeSystem;
        }
    }
}