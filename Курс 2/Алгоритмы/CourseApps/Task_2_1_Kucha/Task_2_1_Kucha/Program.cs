using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task_2_1_Kucha
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input.txt");
            int amountOfElements = int.Parse(reader.ReadLine());
            int[] array = new int[amountOfElements];
            string[] inps = reader.ReadToEnd().Split(' ');
            for (int i = 0; i < amountOfElements; i++)
                array[i] = int.Parse(inps[i]);
            reader.Close();

            StreamWriter writer = new StreamWriter("output.txt");
            bool ok = true;
            for (int i = 1; 2 * i <= amountOfElements; i++)
            {
                if (!(array[i-1] <= array[2 * i-1]))
                {
                    ok = false;
                    break;
                }
                if ((2 * i + 1 <= amountOfElements) && !(array[i-1] <= array[2 * i]))
                {
                    ok = false;
                    break;
                }
            }
            if (ok)
                writer.WriteLine("YES");
            else writer.WriteLine("NO");

            writer.Close();

        }
    }
}
