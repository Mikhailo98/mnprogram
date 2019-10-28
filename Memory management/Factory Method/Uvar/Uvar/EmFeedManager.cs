namespace Uvar
{
    public class EmFeedManager : FeedManager
    {
        private readonly AccountRepository _accountRepository;
        private EmFeedProcessor _feedProcessor;

        public EmFeedManager(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public override IFeedProcessor FeedProcessor =>
            _feedProcessor ?? (_feedProcessor = new EmFeedProcessor(_accountRepository));
    }
}