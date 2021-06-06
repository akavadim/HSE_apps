using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3_5
{
    class BinaryTree
    {
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public int Key { get; set; }

        public bool IsSearchedTree()
        {
            Int64 max = Int64.MaxValue;
            Int64 min = Int64.MinValue;
            BinaryTree tree = this;
            while (true)
            {
                if (!(tree.Key < max && tree.Key > min))
                    return false;
                if (tree.Left != null && tree.Right != null)
                    break;
                if (tree.Left == null && tree.Right != null)
                {
                    if (tree.Right.Key <= tree.Key)
                        return false;
                    min = tree.Key;
                    tree = tree.Right;
                }
                else if (tree.Right == null && tree.Left != null)
                {
                    if (tree.Left.Key >= tree.Key)
                        return false;
                    max = tree.Key;
                    tree = tree.Left;
                }
                else break;
            }
            return tree.IsSearchedTree(max, min);
        }
        public bool IsSearchedTree(Int64 max, Int64 min)
        {
            if (!(Key < max && Key > min))
                return false;
            if (Left == null && Right == null)
                return true;
            bool l = true,
                r = true;
            if (Left != null)
            {
                if (Left.Key >= Key)
                    return false;
                l=Left.IsSearchedTree(Key, min);
            }
            if (Right != null)
            {
                if (Right.Key <= Key)
                    return false;
                r= Right.IsSearchedTree(max, Key);
            }
            return (r && l);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int n = int.Parse(reader.ReadLine());
            if (n == 0)
            {
                writer.Write("YES");
                writer.Close();
                reader.Close();
                return;
            }
            BinaryTree[] trees = new BinaryTree[n];
            for (int i = 0; i < trees.Length; i++)
                trees[i] = new BinaryTree();
            BinaryTree tree = trees[0];
            for (int i = 0; i < trees.Length; i++)
            {
                string[] inpts = reader.ReadLine().Split(' ');
                trees[i].Key = int.Parse(inpts[0]);
                int left = int.Parse(inpts[1]),
                    right = int.Parse(inpts[2]);
                if (left != 0)
                    trees[i].Left = trees[left - 1];
                if (right != 0)
                    trees[i].Right = trees[right - 1];
            }
            reader.Close();
            bool result = tree.IsSearchedTree();
            if (result)
                writer.WriteLine("YES");
            else writer.WriteLine("NO");
            writer.Close();
        }   
    }
}
