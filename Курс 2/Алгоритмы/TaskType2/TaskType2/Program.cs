using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskType2
{
    class Program
    {
        static string InputPath = "input.txt";
        static void Main(string[] args)
        {
            var inp = GetTreeByPath(InputPath);
            Tree tree = inp.Item1;
            bool isForest = inp.Item2;
            int lastPrioritet = tree.SetPrioretets();
            Console.WriteLine("Дерево загружено из файла.\nВведите количество исполнителей");
            int workers = int.Parse(Console.ReadLine());
            var res = GetPlan(tree, workers, lastPrioritet);
            int delta = 0;
            if (isForest)
                delta = 1;
            int index = 1;
            foreach(var perfomer in res)
            {
                Console.Write($"{index}: ");
                index++;
                foreach (var tsk in perfomer)
                    Console.Write(((tsk == 0 || tsk - delta == 0) ? " " : tree.GetByPrioritet(tree, tsk).Name) + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
            index = 1;
            foreach (var perfomer in res)
            {
                Console.Write($"{index}: ");
                index++;
                foreach (var tsk in perfomer)
                    Console.Write(((tsk == 0 || tsk - delta == 0) ? " " : tree.GetByPrioritet(tree, tsk).Prioritet.ToString()) + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static List<int>[] GetPlan(Tree tree, int numberOfPerfomers, int highestPriority)
        {
            List<int>[] plan = new List<int>[numberOfPerfomers];
            List<int> deferred = new List<int>();
            for (int i = 0; i < plan.Length; i++)
                plan[i] = new List<int>();

            while (highestPriority>0||deferred.Count!=0)
            {
                List<int> currentPlan = new List<int>();
                int startPerfomer = 0;
                for(int i=deferred.Count-1; i>=0&&currentPlan.Count<numberOfPerfomers; i--)
                {
                    Tree currentTree = tree.GetByPrioritet(tree, deferred[i]);
                    bool canUseCurrentTree = true;
                    foreach(var prior in deferred)
                    {
                        if (prior != deferred[i] && currentTree.ContainsPrioritet(prior))
                        {
                            canUseCurrentTree = false;
                            break;
                        }
                    }
                    if (!canUseCurrentTree)
                        continue;
                    currentPlan.Add(deferred[i]);
                    deferred.Remove(deferred[i]);
                    startPerfomer++;
                }

                for (int i = startPerfomer; i < numberOfPerfomers; i++)
                {
                    if (highestPriority == 0)
                    {
                        currentPlan.Add(0);
                        continue;
                    }
                    Tree currentTree = tree.GetByPrioritet(tree, highestPriority);
                    bool canUseCurrentTree = true;
                    foreach (var perfomersTask in currentPlan)
                    {
                        if (currentTree.ContainsPrioritet(perfomersTask))
                        {
                            canUseCurrentTree = false;
                            break;
                        }
                    }
                    if (!canUseCurrentTree)
                    {
                        deferred.Add(highestPriority);
                        i--;
                    }
                    else currentPlan.Add(highestPriority);
                    highestPriority--;
                }

                for(int i=0; i<currentPlan.Count; i++)
                {
                    plan[i].Add(currentPlan[i]);
                }
            }
            return plan;
        }

        //Строит дерево по матрице инцидентности с направлениями(+1, -1)
        static (Tree, bool) GetTreeByPath(string path)
        {
            string input;
            using (StreamReader reader = new StreamReader(path))
                input = reader.ReadToEnd();

            int[,] matrix = new int[input.Split('\n').Length, input.Split('\n')[0].Split(' ').Length-1];
            input = input.Replace('\n', ' ');
            string[] splitInput = input.Split(' ');

            int splitInputIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                splitInputIndex++;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(splitInput[splitInputIndex]);
                    splitInputIndex++;
                }
            }

            Tree[] trees = new Tree[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                trees[i] = new Tree(i+1, splitInput[i*(matrix.GetLength(1)+1)]);

            for (int i=0; i<matrix.GetLength(1); i++)
            {
                int elemOne=0, elemMinusOne=0;
                for(int j=0; j<matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] == 1)
                        elemOne = j;
                    else if (matrix[j, i] == 2)
                        elemMinusOne = j;
                }
                trees[elemOne].AddChild(trees[elemMinusOne]);
            }

            List<Tree> startTrees = new List<Tree>();
            for(int i=0; i < matrix.GetLength(0); i++)
            {
                bool isStartTree = true;
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] == 2)
                    {
                        isStartTree = false;
                        break;
                    }
                }
                if (isStartTree)
                    startTrees.Add(trees[i]);
            }
            if (startTrees.Count == 1)
                return (startTrees[0], false);

            Tree res = new Tree();
            foreach (var t in startTrees)
                res.AddChild(t);
            return (res, true);
        }
    }
}
