using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reclaimed
{
    public class FinalizedObjectCollection
    {
        private static ConcurrentDictionary<int, Reclaimed> reclaimedCollection = new ConcurrentDictionary<int, Reclaimed>();

        public static void AddTarget(Reclaimed reclaimed)
        {
            if (reclaimed == null)
                throw new ArgumentNullException(nameof(reclaimed));

             if (!reclaimedCollection.ContainsKey(reclaimed.Id))
                reclaimedCollection.TryAdd(reclaimed.Id, reclaimed);

            GC.ReRegisterForFinalize(reclaimed);
            Console.WriteLine($"\t\t Object #{reclaimed.Id} was recovered");
        }

        public static void Reset()
        {
            reclaimedCollection.Clear();
        }
    }
}
