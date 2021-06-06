using System;
using System.Threading;

namespace Lab3_ThreadWar
{
    class Program
    {
        private object screenlock = new object();

        static void Main(string[] args)
        {
            ThreadWar threadWar = new ThreadWar();
            threadWar.Start();
        }
    }
}
