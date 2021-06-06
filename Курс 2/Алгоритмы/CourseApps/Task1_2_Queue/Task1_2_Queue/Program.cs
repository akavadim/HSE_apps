using System.Collections.Generic;
using System.IO;

namespace Task1_2_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> stack = new Queue<int>();
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int amountOfElements = int.Parse(reader.ReadLine());
            for (int i = 0; i < amountOfElements; i++)
            {
                string input = reader.ReadLine();
                if (input[0] == '-')
                    writer.WriteLine(stack.Dequeue());
                else
                {
                    input = input.Remove(0, 1);
                    stack.Enqueue(int.Parse(input));
                }
            }
            reader.Close();
            writer.Close();
        }
    }
}
