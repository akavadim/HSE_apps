using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binominalnaya
{
    class Program
    {
        static int RandomArrayMax = 9;
        static int RandomArrayMin = 0;

        static int AmountRaw = 20;
        static int AmountColumn = 20;
        static void Main(string[] args)
        {
            //int k = 50;
            //int n = 100;
            //Console.WriteLine(Bin(k, n));
            //Console.ReadKey();

            int[,] array = new int[AmountColumn, AmountRaw];
            RandomArray(array);
            Console.WriteLine(ArrayToString(array));
            //int res = MaxWayRecurs(array, 0, 0);
            MaxWayCycle(array);
            //Console.WriteLine(res + "\n");
            Console.WriteLine(ArrayToString(array));
            Console.ReadKey();
        }

        static string ArrayToString(int[,] array)
        {
            string res = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    res += array[i, j] + " ";
                res += "\n";
            }
            return res;
        }
        
        static void MaxWayCycle(int[,] array)
        {
            for (int m = 0; m < array.GetLength(0); m++)
            {
                for (int n = 0; n < array.GetLength(1); n++)
                {
                    if (m == 0 && n == 0)
                        continue;
                    if (m == 0 || n == 0)
                    {
                        if (m == 0)
                            array[m, n] += array[m, n - 1];
                        else if (n == 0)
                            array[m, n] += array[m - 1, n];
                    }

                    else if (array[m, n - 1] < array[m - 1, n])
                        array[m, n] += array[m, n - 1];
                    else array[m, n] += array[m - 1, n];
                }
            }
        }

        static int MaxWayRecurs(int[,] array, int m, int n)
        {
            if (m == array.GetLength(0) - 1 && n == array.GetLength(1) - 1)
                return array[m, n];
            if (m == array.GetLength(0) - 1)
                return MaxWayRecurs(array, m, n + 1)+array[m,n];
            else if (n == array.GetLength(1) - 1)
                return MaxWayRecurs(array, m + 1, n)+array[m,n];
            else
            {
                int left = MaxWayRecurs(array, m, n + 1);
                int right = MaxWayRecurs(array, m + 1, n);
                if (left > right)
                    return left + array[m, n];
                else return right + array[m, n];
            }
        }

        static void RandomArray(int[,] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = random.Next(RandomArrayMin, RandomArrayMax);
        }

        static int Bin(int k, int n)
        {
            if (k == 0||k==n)
                return 1;

            return Bin(k, n - 1) + Bin(k - 1, n - 1);
        }
    }
}
