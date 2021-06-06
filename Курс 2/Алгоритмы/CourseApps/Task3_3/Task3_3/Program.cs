using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3_3
{
    class BinaryTree
    {
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public int Key { get; set; }

        public int GetHeight()
        {
            return 1 + Math.Max((Left == null) ? 0 : Left.GetHeight(), (Right == null) ? 0 : Right.GetHeight());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int n = int.Parse(reader.ReadLine());
            if (n != 0)
            {
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
                int result = 0;
                while (true)
                {
                    if (tree.Left == null && tree.Right != null)
                    {
                        tree = tree.Right;
                        result++;
                    }
                    else if (tree.Right == null && tree.Left != null)
                    {
                        tree = tree.Left;
                        result++;
                    }
                    else break;
                }
                writer.Write((result + tree.GetHeight()));
            }
            else writer.WriteLine("0");
            writer.Close();
        }
    }
}
