namespace Uvar
{
    public class DeltaOneFeedManager : FeedManager
    {
        private readonly IAccountRepository _accountRepository;
        private DeltaOneFeedProcessor _feedProcessor;

        public DeltaOneFeedManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public override IFeedProcessor FeedProcessor =>
            _feedProcessor ?? (_feedProcessor = new DeltaOneFeedProcessor(_accountRepository));
    }
}