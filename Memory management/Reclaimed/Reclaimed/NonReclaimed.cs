using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reclaimed
{
    public class NonReclaimed
    {
        public int Id;
        private Reclaimed reclaimed;

        public NonReclaimed(int id)
        {
            this.Id = id;
            Console.WriteLine($"NonReclaimed object inizialization #{id}");
            reclaimed = new Reclaimed(id);
        }

        ~NonReclaimed()
        {
            reclaimed = null;
            Console.WriteLine($"Finalizing NonReclaimed class #{Id}");
        }
    }
}
