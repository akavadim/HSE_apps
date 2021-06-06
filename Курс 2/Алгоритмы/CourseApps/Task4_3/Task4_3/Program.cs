using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4_3
{
    class Program
    {
        class BinaryTree
        {
            private BinaryTree left;
            private BinaryTree right;
            private BinaryTree parent;
            public BinaryTree Left
            {
                get => left; set
                {
                    if (value != null)
                        value.Parent = this;
                    if (left != null)
                        left.Parent = null;
                    left = value;
                }
            }
            public BinaryTree Right
            {
                get => right; set
                {
                    if (value != null)
                        value.Parent = this;
                    if (right != null)
                        right.Parent = null;
                    right = value;
                }
            }
            public BinaryTree Parent { get => parent;
                private set
                {
                    if (parent != null)
                    {
                        if (parent.Left == this)
                            parent.left = null;
                        if (parent.Right == this)
                            parent.right = null;
                    }
                    parent = value;
                }
            }
            public int Balance
            {
                get
                {
                    int leftH = 0,
                        rightH = 0;
                    if (Left != null)
                        leftH = Left.Height;
                    if (Right != null)
                        rightH = Right.Height;
                    return rightH - leftH;
                }
            }
            public int Height { get; set; }
            public int Key { get; set; }

            public BinaryTree Add(int key)
            {
                BinaryTree tree = this;
                while (true)
                {
                    if(key<tree.Key)
                    {
                        if (tree.Left == null)
                        {
                            tree.Left = new BinaryTree()
                            {
                                Key = key,
                                Height=1
                            };
                            tree = tree.Left;
                            break;
                        }
                        else tree = tree.Left;
                    }
                    else
                    {
                        if (tree.Right == null)
                        {
                            tree.Right = new BinaryTree()
                            {
                                Key = key,
                                Height = 1
                            };
                            tree = tree.Right;
                            break;
                        }
                        else tree = tree.Right;
                    }
                }
                //в tree - свежевсттавленная вершина
                while (tree.Parent!=null)
                {
                    if (tree.Parent.Left == tree)
                    {
                        int rightH = 0;
                        if (tree.Parent.Right != null)
                            rightH = tree.Parent.Right.Height;
                        tree.Parent.Height = ((rightH > tree.Height) ? rightH : tree.Height) + 1;
                    }
                    else
                    {
                        int leftH = 0;
                        if (tree.Parent.Left != null)
                            leftH = tree.Parent.Left.Height;
                        tree.Parent.Height = ((leftH > tree.Height) ? leftH : tree.Height) + 1;
                    }
                    tree = tree.Parent;
                    if (tree.Balance == 2)
                        tree = tree.RotateLeft();
                    else if (tree.Balance == -2)
                        tree = tree.RotateRight();
                    else if (tree.Balance == 0)
                        break;
                }
                while (tree.Parent != null)
                    tree = tree.Parent;
                return tree;
            }

            public BinaryTree RotateLeft()
            {
                BinaryTree treeRes;
                BinaryTree parent = Parent;
                bool left=false;
                if(Parent!=null)
                    left=(parent.Left == this);
                if (Right.Balance < 0)
                {
                    BinaryTree c = Right.Left;
                    Right.Left = c.Right;
                    c.Right = Right;
                    Right = c.Left;
                    c.Left = this;
                    treeRes = c;
                    treeRes.Height++;
                    treeRes.Left.Height--;
                }
                else
                {
                    BinaryTree right = Right;
                    Right = right.Left;
                    right.Left = this;
                    treeRes = right;
                    treeRes.Left.Height--;
                }

                if(parent!=null)
                {
                    if (left)
                        parent.Left = treeRes;
                    else
                        parent.Right = treeRes;
                }
                return treeRes;
            }
            public BinaryTree RotateRight()
            {
                BinaryTree treeRes;
                BinaryTree parent = Parent;
                bool leftB = false;
                if (Parent != null)
                    leftB = (parent.Left == this);
                if (Left.Balance > 0)
                {
                    BinaryTree c = Left.Right;
                    Left.Right = c.Left;
                    c.Left = Left;
                    Left = c.Right;
                    c.Right = this;
                    treeRes = c;
                    treeRes.Height++;
                    treeRes.Right.Height--;
                }
                else
                {
                    BinaryTree left = Left;
                    Left = left.Right;
                    left.Right = this;
                    treeRes = left;
                    treeRes.Right.Height--;
                }
                if (parent != null)
                {
                    if (leftB)
                        parent.Left = treeRes;
                    else
                        parent.Right = treeRes;
                }
                return treeRes;
            }

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
                Height = (hightLeft > hightRight ? hightLeft : hightRight) + 1;
            }

            public string GetString(ref int startIndex)
            {
                startIndex++;
                string res = Key + " ";
                string leftStr, rightStr;
                if (Left != null)
                {
                    res += startIndex + " ";
                    leftStr = Left.GetString(ref startIndex);
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
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int n = int.Parse(reader.ReadLine());
            if (n != 0) {
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
                int key = int.Parse(reader.ReadLine());
                tree.SetHeight();
                tree=tree.Add(key);
                writer.WriteLine(n + 1);
                int z = 1;
                writer.Write(tree.GetString(ref z));
            }
            else
            {
                BinaryTree binaryTree = new BinaryTree();
                binaryTree.Key= int.Parse(reader.ReadLine());
                int startIndex = 1;
                writer.WriteLine(n+1);
                writer.Write(binaryTree.GetString(ref startIndex));
            }
            reader.Close();
            writer.Close();
        }

    }
}
