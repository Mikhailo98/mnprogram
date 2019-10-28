using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reclaimed
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NonReclaimed> nonReclaimedList = new List<NonReclaimed>();
            for (int i = 0; i < 10; i++)
            {
                nonReclaimedList.Add(new NonReclaimed(i));
            }
            nonReclaimedList = null;

            while (true)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(2000);
                
                FinalizedObjectCollection.Reset();
            }
        }
    }
}
