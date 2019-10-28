using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Uvar
{
    public class AccountRepository : IAccountRepository
    {
        private static readonly ConcurrentDictionary<int, Account> Accounts = new ConcurrentDictionary<int, Account>();
        private static readonly List<ValidationError> Errors = new List<ValidationError>();

        public Account GetOrAddAccount(FeedItem feedItem)
        {
            return Accounts.GetOrAdd(feedItem.FeedId, new Account(feedItem));
        }

        public void SaveErrors(IEnumerable<ValidationError> validationErrors)
        {
            Errors.AddRange(validationErrors);
        }
    }
}