using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TreeGenerator
{
    class Program
    {
        static int treeSize = 34112;
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("input.txt");
            writer.WriteLine(treeSize);
            for(int i=0; i<treeSize; i++)
            {
                writer.WriteLine((treeSize - i) + " " + (i+2) + " 0");
            }
        }
    }
}
