using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input.txt");
            int n = int.Parse(reader.ReadLine());
            int[] arrayN = new int[n];
            string[] inps = reader.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
                arrayN[i] = int.Parse(inps[i]);

            int m = int.Parse(reader.ReadLine());
            inps = reader.ReadLine().Split(' ');
            StreamWriter writer = new StreamWriter("output.txt");
            for (int i = 0; i < m; i++)
            {
                int desired = int.Parse(inps[i]);
                int desiredIndex = BinarySearch(arrayN, desired);
                if (desiredIndex == -1)
                    writer.WriteLine("-1 -1");
                else writer.WriteLine((GetBorder(arrayN, desiredIndex, false)+1) + " " + (GetBorder(arrayN, desiredIndex, true)+1));
            }

            reader.Close();
            writer.Close();
        }

        static int BinarySearch(int[] arrayN, int desired)
        {
            int left = 0,
                right = arrayN.Length - 1,
                middle;

            while (true)
            {
                if (left == right)
                {
                    if (arrayN[left] == desired)
                        return left;
                    else return -1;
                }
                else
                {
                    middle = left + (right - left) / 2;
                    if (arrayN[middle] == desired)
                        return middle;
                    else if (arrayN[middle] > desired)
                    {
                        if (left == middle)
                            right = middle;
                        else right = middle - 1;
                    }
                    else left = middle + 1;
                }
            }
        }
        static int GetBorder(int[] arrayN, int index, bool right)
        {
            int elem = arrayN[index];
            if (!right)
            {
                for (int i = index - 1; i >= 0; i--)
                {
                    if (arrayN[i] != elem)
                        return i + 1;
                }
                return 0;
            }
            else
            {
                for (int i = index + 1; i < arrayN.Length; i++)
                {
                    if (arrayN[i] != elem)
                        return i - 1;
                }
                return arrayN.Length - 1;
            }
        } 
    }
}
