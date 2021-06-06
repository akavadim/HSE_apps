using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Несортированный массив");
            List<int> list1 = CreateRandomArray(6000);
            List<int> list2 = list1.ToList();
            printArray(list1);
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            list1 = Iter(list1);
            sw.Stop();
            var time1 = sw.ElapsedMilliseconds;
            sw.Reset();
            //Console.WriteLine("Сортировка итерацией:");
            //printArray(list1);

            sw.Start();
            list2 = Recurse(list2);
            sw.Stop();
            var time2 = sw.ElapsedMilliseconds;
            Console.WriteLine("Сортировка рекурсией:");
            printArray(list2);

            Console.WriteLine("\nСоортировка итерацией: " + time1.ToString() + "\n Сортировка рекурсией: " + time2.ToString());
            Console.ReadKey();
        }

        static void printArray(List<int> array)
        {
            foreach(var elem in array)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }

        static List<int> CreateRandomArray(int size)
        {
            List<int> res = new List<int>();
            Random rand = new Random();
            for(int i=0; i<size; i++)
            {
                res.Add(rand.Next(-10000, 10000));
            }
            return res;
        }

        static List<int> Recurse(List<int> array)
        {
            if (array.Count <= 1)
                return array;

            int lastElem = array[array.Count - 1];
            array.RemoveAt(array.Count - 1);
            array = Recurse(array);

            int indexMin = 0;
            foreach (var elem in array)
            {
                if (elem >= lastElem)
                    break;
                indexMin++;
            }
            array.Insert(indexMin, lastElem);

            return array;
        }

        static List<int> Iter(List<int> array)
        {
            if (array.Count <= 1)
                return array;
            List<int> res = new List<int>();
            res.Add(array[0]);
            array.RemoveAt(0);

            while(array.Count!=0)
            {
                int minPosition = 0;
                foreach(var element in res)
                {
                    if (element >= array[0])
                        break;
                    minPosition++;
                }

                res.Insert(minPosition, array[0]);
                array.RemoveAt(0);
            }

            return res;
        }
    }
}
