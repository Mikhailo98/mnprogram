using System;
using System.Collections.Generic;

namespace Uvar
{
    public abstract class FeedManager
    {
        public abstract IFeedProcessor FeedProcessor { get; }

        public void Process(IEnumerable<FeedItem> feedItems)
        {
            if (feedItems == null) throw new ArgumentNullException(nameof(feedItems));

            var errors = new List<ValidationError>();

            foreach (var item in feedItems)
            {
                errors.AddRange(FeedProcessor.Validate(item));
                FeedProcessor.Save(FeedProcessor.Match(item));
            }

            FeedProcessor.SaveErrors(errors);
        }
    }
}