using System;

namespace StockExchangeOnDelegates
{
    public class Bank
    {
        public string Name { get; }
        public int NotifiedTimes { get; private set; }

        public Bank(string name)
        {
            Name = name;
        }


        public void InternalBankingProcessing()
        {
            Console.WriteLine($"Bank '{Name}' is notified {++NotifiedTimes} times!");
        }
    }
}