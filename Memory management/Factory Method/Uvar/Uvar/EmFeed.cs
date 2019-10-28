namespace Uvar
{
    public class EmFeed : FeedItem
    {
        public string Sedol { get; set; }
        public int AssetValue { get; set; }
        public override int FeedId => SourceAccountId;
    }
}