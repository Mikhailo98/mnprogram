using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeakReferenceImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recovered> recoveredList = new List<Recovered>();
            List<WeakReference<Recovered>> weakReferenceList = new List<WeakReference<Recovered>> ();
            Recovered recovered;

            for (int i = 0; i < 100; i++)
            {
                recovered = new Recovered(i);
                recoveredList.Add(recovered);
                weakReferenceList.Add(new WeakReference<Recovered>(target: recovered, trackResurrection: true));
            }

            recoveredList = null;
            Console.WriteLine("\t\t\t List of recovered objects is assigned null");

            Console.WriteLine("\t\t\t Garbage collection processing");
            GC.Collect();
            Console.WriteLine("\t\t\t WaitForPendingFinalizers() processing");
            GC.WaitForPendingFinalizers();

            Recovered retrievedObject;
            foreach (var weakReference in weakReferenceList)
            {
                weakReference.TryGetTarget(out retrievedObject);
                if (retrievedObject != null)
                    Console.WriteLine($"Recovered object #{retrievedObject.Id}");
            }

            Console.ReadKey();
        }
    }
}
