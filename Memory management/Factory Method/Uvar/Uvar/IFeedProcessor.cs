using System.Collections.Generic;

namespace Uvar
{
    public interface IFeedProcessor
    {
        IEnumerable<ValidationError> Validate(FeedItem feedItem);
        FeedItem Match(FeedItem feedItem);
        void Save(FeedItem matchedAccount);
        void SaveErrors(IEnumerable<ValidationError> errors);
    }
}