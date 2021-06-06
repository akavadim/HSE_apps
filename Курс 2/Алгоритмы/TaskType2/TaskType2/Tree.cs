using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskType2
{
    class Tree
    {
        public int Prioritet;
        public int TaskNumber;
        public string Name;
        public List<Tree> Trees;
        public Tree() { }
        public Tree(int TaskNumber, string name)
        {
            this.TaskNumber = TaskNumber;
            this.Name = name;
        }
        
        public void AddChild(Tree tree)
        {
            if (Trees == null)
                Trees = new List<Tree>();
            else if (Trees.Contains(tree))
                return;
            Trees.Add(tree);
        }
        
        //возвращает максимальный приоритет
        public int SetPrioretets()
        {
            this.Prioritet = 1;
            int maxPrioritet = 1;
            int startPrioritet = 1;
            while (true)
            {
                Tree tree = GetByPrioritet(this, startPrioritet);
                if (tree == null)
                    break;
                if (tree.Trees != null)
                {
                    foreach (var childTree in tree.Trees)
                    {
                        if (childTree.Prioritet != 0)
                            continue;
                        maxPrioritet++;
                        childTree.Prioritet = maxPrioritet;
                    }
                }
                startPrioritet++;
            }
            return maxPrioritet;

        }

        public Tree GetByPrioritet(Tree startTree, int prioritet)
        {
            if (startTree.Prioritet == prioritet)
                return startTree;
            if (startTree.Trees == null)
                return null;
            foreach (var tree in startTree.Trees)
            {
                Tree priorTree = GetByPrioritet(tree, prioritet);
                if (priorTree != null)
                    return priorTree;
            }
            return null;
        }

        public bool ContainsPrioritet(int prioritet)
        {
            return GetByPrioritet(this, prioritet) == null ? false : true;
        }

        public int GetMaxPrioritet(Tree tree)
        {
            int maxPrioritet = tree.Prioritet;
            if (tree.Trees == null)
                return maxPrioritet;

            foreach(var child in tree.Trees)
            {
                int childMaxPrioritet = GetMaxPrioritet(child);
                if (childMaxPrioritet > maxPrioritet)
                    maxPrioritet = childMaxPrioritet;
            }

            return maxPrioritet;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
