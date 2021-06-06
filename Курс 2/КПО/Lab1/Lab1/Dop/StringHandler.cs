using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IStringHandler
    {
        string Name { get; }

        IdentTypes IdentTypes { get; }

        IdentInfoTypes IdentInfoTypes { get; }

        MyArray<(ParametrTypes parametr, IdentInfoTypes type)> GetParametrs();

        int GetConstValue();
    }

    class StringHandler : IStringHandler
    {
        private int? _constValue;
        private MyArray<(ParametrTypes parametr, IdentInfoTypes type)> _parametrs;

        public StringHandler(string data)
        {
            Process(data);
        }

        public string Name { get; private set; }

        public IdentTypes IdentTypes { get; private set; }

        public IdentInfoTypes IdentInfoTypes { get; private set; }

        public int GetConstValue()
        {
            if (_constValue == null)
                throw new Exception("Эта строка не является константой");
            return _constValue.Value;
        }

        public MyArray<(ParametrTypes parametr, IdentInfoTypes type)> GetParametrs()
        {
            if (_parametrs == null)
                throw new Exception("Эта строка не является методом");
            return _parametrs;
        }

        private void Process(string data)
        {
            string[] dataSplit = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (dataSplit[0] == "const")
            {
                IdentInfoTypes = GetIdentInfoTypes(dataSplit[1]);
                IdentTypes = IdentTypes.Const;
                Name = dataSplit[2];
                _constValue = int.Parse(dataSplit.Last());
                return;
            }

            IdentInfoTypes = GetIdentInfoTypes(dataSplit[0]);
            Name = dataSplit[1].Split('(')[0];
            if (IdentInfoTypes == IdentInfoTypes.ClassType)
                IdentTypes = IdentTypes.Class;
            else IdentTypes = IdentTypes.Var;

            if(data.Contains('(')&&data.Contains(')'))
            {
                IdentTypes = IdentTypes.Method;
                var parametrs = GetParametrs(data);
                _parametrs = parametrs;
            }
        }

        private IdentInfoTypes GetIdentInfoTypes(string data)
        {
            IdentInfoTypes identInfoTypes;
            switch (data)
            {
                case "int": identInfoTypes = IdentInfoTypes.IntType; break;
                case "bool":identInfoTypes = IdentInfoTypes.BoolType; break;
                case "string": identInfoTypes = IdentInfoTypes.StringType; break;
                case "char": identInfoTypes = IdentInfoTypes.CharType; break;
                case "float": identInfoTypes = IdentInfoTypes.FloatType; break;
                case "class": identInfoTypes = IdentInfoTypes.ClassType; break;
                case "void": identInfoTypes = IdentInfoTypes.VoidType; break;
                default: throw new Exception("Невозможно определить тип");
            }
            return identInfoTypes;
        }
        
        private MyArray<(ParametrTypes parametr, IdentInfoTypes type)> GetParametrs(string data)
        {
            MyArray<(ParametrTypes parametr, IdentInfoTypes type)> res = new MyArray<(ParametrTypes parametr, IdentInfoTypes type)>();
            string dataSplit = data.Split('(')[1];
            dataSplit = dataSplit.Replace(")", "");

            if (String.IsNullOrWhiteSpace(dataSplit))
                return res;

            string[] arguments = dataSplit.Split(',');

            foreach(var argument in arguments)
            {
                var parametr = GetParametr(argument);
                res.Add(parametr);
            }

            return res;
        }

        private (ParametrTypes parametr, IdentInfoTypes type) GetParametr(string argument)
        {
            ParametrTypes parametrType;
            IdentInfoTypes identInfoTypes;
            argument = argument.Trim();
            string[] argumentSplit = argument.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (argumentSplit[0] == "ref")
                parametrType = ParametrTypes.Reference;
            else if (argumentSplit[0] == "out")
                parametrType = ParametrTypes.Out;
            else
            {
                parametrType = ParametrTypes.Default;
                identInfoTypes = GetIdentInfoTypes(argumentSplit[0]);
                return (parametrType, IdentInfoTypes);
            }
            identInfoTypes = GetIdentInfoTypes(argumentSplit[1]);
            return (parametrType, IdentInfoTypes);
        }
    }
}
