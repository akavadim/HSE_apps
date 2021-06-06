using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Task_1_2_BracketSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int amountOfElements = int.Parse(reader.ReadLine());
            for (int i = 0; i < amountOfElements; i++)
            {
                string input = reader.ReadLine();
                if (IsBracketSequence(input))
                    writer.WriteLine("YES");
                else
                    writer.WriteLine("NO");
            }
            reader.Close();
            writer.Close();
        }

        static bool IsBracketSequence(string input)
        {
            if (input.Length % 2 != 0)
                return false;
            Stack<char> stack = new Stack<char>();
            foreach(char ch in input)
            {
                if (ch == '(' || ch == '[')
                    stack.Push(ch);
                else if (stack.Count == 0)
                    return false;
                else
                {
                    char stackCh = stack.Pop();
                    if ((stackCh == '(' && ch != ')')||(stackCh=='['&&ch!=']'))
                        return false;
                }
            }
            return stack.Count == 0 ? true : false;
        } 
    }
}
