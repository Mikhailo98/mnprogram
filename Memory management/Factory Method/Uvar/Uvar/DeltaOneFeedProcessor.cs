using System;
using System.Collections.Generic;

namespace Uvar
{
    public class DeltaOneFeedProcessor : IFeedProcessor
    {
        private readonly IAccountRepository _accountRepository;

        public DeltaOneFeedProcessor(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<ValidationError> Validate(FeedItem feedItem)
        {
            if (feedItem == null) throw new ArgumentNullException(nameof(feedItem));

            if (!(feedItem is DeltaOneFeed emItem))
                throw new ArgumentException($"Item is not of Em type, real type is: {feedItem.GetType()}");

            var validationErrors = new List<ValidationError>();

            if (emItem.Isin == default(int))
                validationErrors.Add(new ValidationError(emItem.SourceAccountId, $"{nameof(emItem.Isin)} is empty!"));

            if (emItem.MaturityDate == default(DateTime))
                validationErrors.Add(new ValidationError(emItem.SourceAccountId, $"{nameof(emItem.MaturityDate)} is empty!"));

            return validationErrors;
        }

        public FeedItem Match(FeedItem feedItem)
        {
            return _accountRepository.GetOrAddAccount(feedItem).FeedItem;
        }

        public void Save(FeedItem matchedAccount)
        {
            Console.WriteLine($"Saved account for DeltaOne Feed {matchedAccount.FeedId}");
        }

        public void SaveErrors(IEnumerable<ValidationError> errors)
        {
            _accountRepository.SaveErrors(errors);
        }
    }
}