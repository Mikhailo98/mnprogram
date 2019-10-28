using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointIssue
{
    class Program
    {
        public struct Point
        {
            public int X;
            public void IncX()
            {
                ++X;
            }
        }

        static void Main()
        {
            var points = new List<Point>(Enumerable.Range(1, 10).Select(p => new Point())).ToArray();

            for (int i = 0; i < points.Length; i++)
            {
                points[i].IncX();
            }

            foreach (var p in points)
            {
                Console.WriteLine(p.X);
            }
            Console.ReadKey();
        }
    }
}
