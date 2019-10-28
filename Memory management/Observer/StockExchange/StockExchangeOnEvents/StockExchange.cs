using System;
using System.Collections.Generic;

namespace StockExchangeOnDelegates
{
    public class StockExchange
    {
        public event Action ObserverHandler;
        public List<Company> Companies { get; } = new List<Company>();

        public void AddCompany(Company newCompany)
        {
            Companies.Add(newCompany);
            NotifyObserver();
        }

        private void NotifyObserver()
        {
            ObserverHandler?.Invoke();
        }
    }
}