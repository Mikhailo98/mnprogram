using System;
using System.Collections.Generic;

namespace Uvar
{
    public class EmFeedProcessor : IFeedProcessor
    {
        private readonly AccountRepository _accountRepository;

        public EmFeedProcessor(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<ValidationError> Validate(FeedItem feedItem)
        {
            if (feedItem == null) throw new ArgumentNullException(nameof(feedItem));

            if (!(feedItem is EmFeed emItem))
                throw new ArgumentException($"Item is not of Em type, real type is: {feedItem.GetType()}");

            var validationErrors = new List<ValidationError>();

            if (emItem.Sedol == default(string))
                validationErrors.Add(new ValidationError(emItem.SourceAccountId, $"{nameof(emItem.Sedol)} is empty!"));

            if (emItem.AssetValue == default(int))
                validationErrors.Add(new ValidationError(emItem.SourceAccountId, $"{nameof(emItem.AssetValue)} is empty!"));

            return validationErrors;
        }

        public FeedItem Match(FeedItem feedItem)
        {
            return _accountRepository.GetOrAddAccount(feedItem).FeedItem;
        }

        public void Save(FeedItem matchedAccount)
        {
            Console.WriteLine($"Saved account for Em Feed {matchedAccount.FeedId}");
        }

        public void SaveErrors(IEnumerable<ValidationError> errors)
        {
            _accountRepository.SaveErrors(errors);
        }
    }
}