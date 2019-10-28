namespace Uvar
{
    public class ValidationError
    {
        public ValidationError(int feedItemId, string message)
        {
            FeedItemId = feedItemId;
            ErrorMessage = message;
        }

        public int FeedItemId { get; }
        public string ErrorMessage { get; }
    }
}