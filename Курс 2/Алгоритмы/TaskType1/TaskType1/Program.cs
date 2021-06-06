using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskType1
{
    class Program
    {
        static void Main(string[] args)
        {
            int workers, chalendgeAmount;
            Dictionary<int,int> timeOfWorks = new Dictionary<int, int>();

            Console.WriteLine("Введите количество исполнителей");
            workers = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество работ");
            chalendgeAmount = int.Parse(Console.ReadLine());
            for (int i = 0; i < chalendgeAmount; i++)
            {
                Console.Write($"Работа {i + 1}: ");
                timeOfWorks.Add(i, int.Parse(Console.ReadLine()));
            }

            ResultForFirstTypeTask(workers, timeOfWorks);
            Console.ReadLine();
        }

        public static void ResultForFirstTypeTask(int workers, Dictionary<int, int> timeOfWorks)
        {
            int part = 0;
            Dictionary<int,int> overWorks = new Dictionary<int, int>();
            while (true)
            {
                int sumTimes = timeOfWorks.Values.Sum();
                part = sumTimes / workers;
                if (sumTimes % workers != 0)
                    part++;
                int maxValue = timeOfWorks.Values.Max();
                if (maxValue <= part)
                    break;
                workers--;
                int keyMaxValue = (from t in timeOfWorks
                                   where t.Value == maxValue
                                   select t.Key).ToArray()[0];
                overWorks.Add(keyMaxValue, maxValue);
                timeOfWorks.Remove(keyMaxValue);
            }

            int elemNumber = 0;

            for(int i=0; i<workers; i++)
            {
                int partSize = part;
                int timeStart = 0;
                Console.WriteLine($"Исполнитель {i+1}:");
                while (partSize>0&&elemNumber<timeOfWorks.Count)
                {
                    int currentKey = timeOfWorks.ToArray()[elemNumber].Key;
                    int timeEnd = timeStart;
                    int numberOfWork = elemNumber;
                    if (partSize>=timeOfWorks[currentKey])
                    {
                        timeEnd += timeOfWorks[currentKey];
                        partSize -= timeOfWorks[currentKey];
                        elemNumber++;
                    }
                    else
                    {
                        timeEnd += partSize;
                        timeOfWorks[currentKey] -= partSize;
                        partSize = 0;
                    }
                    Console.WriteLine($"Работу {currentKey + 1} начал в {timeStart}, закончил в {timeEnd}");
                    timeStart = timeEnd;
                }
            }

            for(int i=0; i<overWorks.Count; i++)
            {
                Console.WriteLine($"Исполнитель {timeOfWorks.Count + i }:");
                Console.WriteLine($"Работу {overWorks.ToArray()[i].Key + 1} начал в {0}, закончил в {overWorks.ToArray()[i].Value}");
                elemNumber++;
            }
        }
    }
}
