using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskType4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConveyorTask.GetPlan(FileLoader.Getinput2()).ToString());

            Console.ReadKey();
        }
    }
}
