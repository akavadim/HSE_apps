using System.Collections.Generic;
using System.IO;

namespace Task1_1_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int amountOfElements = int.Parse(reader.ReadLine());
            for(int i=0; i< amountOfElements; i++)
            {
                string input = reader.ReadLine();
                if (input[0] == '-')
                    writer.WriteLine(stack.Pop());
                else
                {
                    input = input.Remove(0, 1);
                    stack.Push(int.Parse(input));
                }
            }
            reader.Close();
            writer.Close();
        }
    }
}
