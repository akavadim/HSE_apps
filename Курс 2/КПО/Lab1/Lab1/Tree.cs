using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface ITree
    {
        IIdentificator Info { get; set; }
        ITree Left { get; set; }
        ITree Right { get; set; }
        void Add(ITree tree);
        void Add(IIdentificator identificator);
        void AddRange(IEnumerable<IIdentificator> identificator);
    }

    class Tree : ITree
    {
        public IIdentificator Info { get; set; }
        public ITree Left { get; set; }
        public ITree Right { get; set; }

        /// <summary>
        /// Добавление дерева в это дерево
        /// </summary>
        /// <param name="tree">Дере</param>
        public void Add(ITree tree)
        {
            ITree newNode = AddIdentificator(tree.Info, this);
            newNode.Left = tree.Left;
            newNode.Right = tree.Right;
        }

        public void Add(IIdentificator identificator)
        {
            AddIdentificator(identificator, this);
        }

        public void AddRange(IEnumerable<IIdentificator> identificators)
        {
            foreach (var ident in identificators)
                Add(ident);
        }

        //Создает новый элемент в индексе и добавляет туда идентификатор
        private ITree AddIdentificator(IIdentificator identificator, ITree tree)
        {
            if (tree.Info == null)
            {
                tree.Info = identificator;
                return tree;
            }
            while (true)
            {
                if (identificator.Hash >= tree.Info.Hash)
                {
                    if (tree.Right == null)
                    {
                        tree.Right = new Tree();
                        tree.Right.Add(identificator);
                        return tree;
                    }
                    tree = tree.Right;
                }
                else
                {
                    if (tree.Left == null)
                    {
                        tree.Left = new Tree();
                        tree.Left.Add(identificator);
                        return tree;
                    }
                    tree = tree.Left;
                }
            }
        }
    }
}
