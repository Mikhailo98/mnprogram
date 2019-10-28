namespace Uvar
{
    public class Account
    {
        public Account(FeedItem feedItem)
        {
            FeedItem = feedItem;
        }

        public FeedItem FeedItem { get; }
    }
}