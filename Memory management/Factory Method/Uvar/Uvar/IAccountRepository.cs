using System.Collections.Generic;

namespace Uvar
{
    public interface IAccountRepository
    {
        Account GetOrAddAccount(FeedItem feedItem);
        void SaveErrors(IEnumerable<ValidationError> validationErrors);
    }
}