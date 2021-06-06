using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_1_4_QueueWithMin
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> stack = new Queue<int>();
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int amountOfElements = int.Parse(reader.ReadLine());
            string input;
            char firstCh;
            for (int i = 0; i < amountOfElements; i++)
            {
                input = reader.ReadLine();
                firstCh = input[0];
                if (firstCh == '?')
                       writer.WriteLine(stack.Min());
                else if (firstCh == '-')
                    stack.Dequeue();
                else
                    stack.Enqueue(int.Parse(input.Remove(0, 1)));
            }
            reader.Close();
            writer.Close();
        }
    }
}
