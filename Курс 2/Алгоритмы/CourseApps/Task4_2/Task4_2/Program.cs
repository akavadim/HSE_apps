using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4_2
{
    class BinaryTree
    {
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public int Balance { get; set; }
        public int Key { get; set; }

        public void SetBalance()
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
            int height = tree.SetBalanceRecursion();
            for (int i = oneChildrenTrees.Count - 1; i >= 0; i--)
                if (oneChildrenTrees[i].Left != null)
                    oneChildrenTrees[i].Balance = -height++;
                else oneChildrenTrees[i].Balance = height++;
        }

        public int SetBalanceRecursion()
        {
            int hightLeft = 0,
                hightRight = 0;
            if (Left != null)
                hightLeft = Left.SetBalanceRecursion();
            if (Right != null)
                hightRight = Right.SetBalanceRecursion();
            Balance = hightRight - hightLeft;
            return ((hightLeft > hightRight) ? hightLeft : hightRight) + 1;
        }

        public BinaryTree ToLeft()
        {
            this.SetBalance();
            if (Right.Balance < 0)
            {
                BinaryTree c = Right.Left;
                Right.Left = c.Right;
                c.Right = Right;
                Right = c.Left;
                c.Left = this;
                return c;
            }
            else
            {
                BinaryTree right = Right;
                Right = right.Left;
                right.Left = this;
                return right;
            }

        }

        public string  GetString(ref int startIndex)
        {
            startIndex++;
            string res = Key + " ";
            string leftStr, rightStr;
            if (Left != null)
            {
                res += startIndex + " ";
                leftStr= Left.GetString(ref startIndex);
            }
            else
            {
                res += "0 ";
                leftStr = "";
            }

            if (Right != null)
            {
                res += startIndex;
                rightStr = Right.GetString(ref startIndex);
            }
            else
            {
                res += "0";
                rightStr = "";
            }
            return res + "\n" + leftStr + rightStr;

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
                trees[i].Key = int.Parse(inpts[0]);
                int left = int.Parse(inpts[1]),
                    right = int.Parse(inpts[2]);
                if (left != 0)
                    trees[i].Left = trees[left - 1];
                if (right != 0)
                    trees[i].Right = trees[right - 1];
            }
            reader.Close();
            tree = tree.ToLeft();
            writer.WriteLine(n);
            int z = 1;
            writer.Write(tree.GetString(ref z));
            writer.Close();
        }

    }
}
