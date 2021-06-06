using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutualRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetA(n));
            //Console.WriteLine(GetB(n));

            Console.WriteLine(GetAByForm(n));
            Console.ReadLine();
        }

        static int GetA(int n)
        {
            if (n == 0)
                return 2;
            return 5 * GetA(n - 1) - 3 * GetB(n - 1);
        }
        
        static int GetB(int n)
        {
            if (n == 0)
                return 4;
            return GetA(n - 1) + GetB(n - 1);
        }

        static double GetAByForm(int n)
        {
            return 5 * Math.Pow(2, n) + (-3) * Math.Pow(4, n);
        }
    }
}
