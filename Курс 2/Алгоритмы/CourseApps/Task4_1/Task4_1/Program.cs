using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4_1
{
    class BinaryTree
    {
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public int Balance { get
            {
                int leftH = 0,
                    rightH = 0;
                if (Left != null)
                    leftH = Left.Height;
                if (Right != null)
                    rightH = Right.Height;
                return rightH - leftH;
            } }

        public int Height { get; set; }

        public void SetHeight()
        {
            List<BinaryTree> oneChildrenTrees = new List<BinaryTree>();
            BinaryTree tree = this;
            while (true)
            {
                if (tree.Left != null && tree.Right == null)
                {
                    oneChildrenTrees.Add(tree);
                    tree = tree.Left;
                }
                else if (tree.Right != null && tree.Left == null)
                {
                    oneChildrenTrees.Add(tree);
                    tree = tree.Right;
                }
                else break;
            }
            tree.SetHeightsRecursion();
            int height = tree.Height;
            for (int i = oneChildrenTrees.Count - 1; i >= 0; i--)
                oneChildrenTrees[i].Height = ++height;
        }
        private void SetHeightsRecursion()
        {
            if (Left == null && Right == null)
            {
                Height = 1;
                return;
            }
            int hightLeft = 0,
                hightRight = 0;
            if (Left != null)
            {
                Left.SetHeightsRecursion();
                hightLeft = Left.Height;
            }
            if (Right != null)
            {
                Right.SetHeightsRecursion();
                hightRight = Right.Height;
            }
            Height = (hightLeft > hightRight ? hightLeft : hightRight)+1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int n = int.Parse(reader.ReadLine());
            BinaryTree[] trees = new BinaryTree[n];
            for (int i = 0; i < trees.Length; i++)
                trees[i] = new BinaryTree();
            BinaryTree tree = trees[0];
            for (int i = 0; i < trees.Length; i++)
            {
                string[] inpts = reader.ReadLine().Split(' ');
                int left = int.Parse(inpts[1]),
                    right = int.Parse(inpts[2]);
                if (left != 0)
                    trees[i].Left = trees[left - 1];
                if (right != 0)
                    trees[i].Right = trees[right - 1];
            }
            reader.Close();
            tree.SetHeight();
            foreach (var tr in trees)
                writer.WriteLine(tr.Balance);
            writer.Close();
        }
    }
}
