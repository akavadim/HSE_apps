using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader=new StreamReader("input.txt"))
            {
                using(StreamWriter writer=new StreamWriter("output.txt"))
                {
                    int n = int.Parse(reader.ReadLine());
                    HashSet<string> keys = new HashSet<string>(n);
                    for (int i=0; i<n; i++)
                    {
                        string[] input = reader.ReadLine().Split(' ');
                        string key = input[1];
                        if (input[0] == "A")
                                keys.Add(key);
                        else if (input[0] == "D")
                            keys.Remove(key);
                        else if (input[0] == "?")
                            if (keys.Contains(key))
                                writer.WriteLine("Y");
                            else writer.WriteLine("N");
                    }
                }
            }
        }
    }
}
