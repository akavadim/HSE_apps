using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IIdentCreator
    {
        IEnumerable<IIdentificator> GetIdentificators(string code);
    }

    class IdentCreator : IIdentCreator
    {
        public IdentCreator(ISharpStringHandler stringHandler) => StringHandler = stringHandler ?? throw new ArgumentNullException();

        public ISharpStringHandler StringHandler { get; }

        public IEnumerable<IIdentificator> GetIdentificators(string code)
        {
            List<IIdentificator> identificators = new List<IIdentificator>();
            string[] commands = code.Split(';');

            foreach(var command in commands)
            {
                if (string.IsNullOrWhiteSpace(command))
                    continue;
                IIdentificator identificator = GetIdentificator(command);
                identificators.Add(identificator);
            }

            return identificators;
        }

        public IIdentificator GetIdentificator(string command)
        {
            IIdentificator identificator;
            StringHandler.SetDate(command);

            switch (StringHandler.IdentTypes)
            {
                case IdentTypes.Class: identificator = new Identificator(StringHandler);  break;
                case IdentTypes.Const: identificator = new ConstantIdent(StringHandler); break;
                case IdentTypes.Method: identificator = new MethodIdent(StringHandler); break;
                case IdentTypes.Var: identificator = new Identificator(StringHandler); break;
                default: throw new Exception("Элемент не содержит обрабатываемый IdentTypes");
            }

            return identificator;
        }
    }
}
