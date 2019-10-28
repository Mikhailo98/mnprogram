using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reclaimed
{
    public class Reclaimed
    {
        public int Id { get; set; }

        public Reclaimed(int id)
        {
            Id = id;
            Console.WriteLine($"Reclaimed object inizialization #{id}");
        }

        ~Reclaimed()
        {
            Console.WriteLine($"Finalizing Reclaimed class #{Id}");
            FinalizedObjectCollection.AddTarget(this);
        }
    }
}
