using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakReferenceImplementation
{
    public class Recovered
    {
        public int Id { get; set; }

        public Recovered(int id)
        {
            Id = id;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Recovered Object #{id} has been created");
            Console.ResetColor();
        }

        ~Recovered()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Recovered Object #{Id} Finalization");
            Console.ResetColor();
            GC.ReRegisterForFinalize(this);
        }
    }
}
