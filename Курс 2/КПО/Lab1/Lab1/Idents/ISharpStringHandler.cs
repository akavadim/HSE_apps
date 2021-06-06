using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab1
{
    struct Constant
    {
        public Constant(IdentInfoTypes type, object date)
        {
            Type = type;
            Date = date;
        }

        public IdentInfoTypes Type;
        public object Date;
    }

    struct Parametr
    {
        public Parametr(ParametrTypes parametrType, IdentInfoTypes type)
        {
            ParametrType = parametrType;
            Type = type;
        }

        public ParametrTypes ParametrType;
        public IdentInfoTypes Type;
    }

    interface ISharpStringHandler
    {
        string Name { get; }

        IdentTypes IdentTypes { get; }

        IdentInfoTypes IdentInfoTypes { get; }

        IEnumerable<Parametr> GetParametrs();

        Constant GetConstValue();

        /// <summary>
        /// Устанавливает новые значения по строке
        /// </summary>
        /// <param name="command"></param>
        void SetDate(string command);
    }

    class SharpStringHandler : ISharpStringHandler
    {
        private IEnumerable<Parametr> _paramters;
        private Constant? _constant;

        public SharpStringHandler() { }
        public SharpStringHandler(string command)=>SetDate(command);

        public string Name { get; private set; }
        public IdentTypes IdentTypes { get; private set; }
        public IdentInfoTypes IdentInfoTypes { get; private set; }
        public Constant GetConstValue()
        {
            if (IdentTypes != IdentTypes.Const)
                throw new Exception("Этот элемент не является константой");

            return _constant.Value;
        }
        public IEnumerable<Parametr> GetParametrs()
        {
            if (IdentTypes != IdentTypes.Method)
                throw new Exception("Этот тип не содержит параметры");
            return _paramters;
        }
        public void SetDate(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new ArgumentException("На вход была подана пустая команда");

            _constant = null;
            _paramters = null;

            Regex constRegex = new Regex(@"^\s*const\s*(?<Type>(int|string|float|bool|char))\s+(?<Name>\w+)\s*\=\s*(?<Value>(\w+\,?\w*|""[\w\W]*""|'.'))\s*\z");
            Regex valueClassRegex = new Regex(@"^\s*(?<Type>(class|int|string|float|bool|char))\s+(?<Name>\w+)\s*\z");
            Regex methodRegex = new Regex(@"^\s*(?<Type>(int|string|float|bool|char|void))\s+(?<Name>\w+)\s*\((?<ParametrType>((\s*((out|ref)\s+)?(int|string|float|bool|char)\s+\w+\,\s*)+(\s*((out|ref)\s+)?(int|string|float|bool|char)\s+\w+\s*))|(\s*((out|ref)\s+)?(int|string|float|bool|char)\s+\w+\s*)?)\s*\)\s*\z");

            var constMatch = constRegex.Match(command);
            var valueClassMatch = valueClassRegex.Match(command);
            var methodMatch = methodRegex.Match(command);

            if (constMatch.Success)
                CreateConst(constMatch);
            else if (valueClassMatch.Success)
                CreateValueOrClass(valueClassMatch);
            else if (methodMatch.Success)
                CreateMethod(methodMatch);
            else throw new ArgumentException("Эта строка не является командой c#");
        }

        private void CreateConst(Match constMatch)
        {
            IdentInfoTypes = GetType(constMatch);
            Name = constMatch.Groups["Name"].Value;
            IdentTypes = IdentTypes.Const;
            string constValue = constMatch.Groups["Value"].Value;
            object constObj = ToObjectType(IdentInfoTypes, constValue);
            _constant = new Constant(IdentInfoTypes, constObj);
        }

        private void CreateValueOrClass(Match valueClassMatch)
        {
            IdentInfoTypes = GetType(valueClassMatch);
            Name = valueClassMatch.Groups["Name"].Value;
            if (IdentInfoTypes == IdentInfoTypes.ClassType)
                IdentTypes = IdentTypes.Class;
            else IdentTypes = IdentTypes.Var;
        }

        private void CreateMethod(Match methodMatch)
        {
            IdentInfoTypes = GetType(methodMatch);
            Name = methodMatch.Groups["Name"].Value;
            IdentTypes = IdentTypes.Method;
            string parameters = methodMatch.Groups["Params"].Value;
            _paramters = GetParametrs(parameters);
        }

        private IEnumerable<Parametr> GetParametrs(string parametrs)
        {
            string[] parametrsSplit = parametrs.Split(',');
            List<Parametr> lParams = new List<Parametr>();
            Regex regex = new Regex(@"^\s*(?<ParametrType>(out|ref)?)\s+(?<Type>(int|string|float|bool|char))\s+\w+\s*\z");
            foreach(var param in parametrsSplit)
            {
                if (param == "")
                    continue;
                Match match = regex.Match(param);
                if (!match.Success)
                    throw new Exception("Строка не содержит параметров");
                Parametr parametr = new Parametr();
                parametr.Type = GetType(match);
                parametr.ParametrType = GetParametrType(match.Groups["ParametrType"].Value);
                lParams.Add(parametr);
            }
            return lParams;
        }

        //регулярное выражение с группой Type
        private IdentInfoTypes GetType(Match match)
        {
            string type = match.Groups["Type"].Value;
            switch (type)
            {
                case "int": return IdentInfoTypes.IntType;
                case "float": return IdentInfoTypes.FloatType;
                case "bool": return IdentInfoTypes.BoolType;
                case "char": return IdentInfoTypes.CharType;
                case "string": return IdentInfoTypes.StringType;
                case "void": return IdentInfoTypes.VoidType;
                case "class": return IdentInfoTypes.ClassType;
                default: throw new ArgumentException("Данного типа нет в списке");
            }
        }

        private ParametrTypes GetParametrType(string textType)
        {
            switch (textType)
            {
                case "out": return ParametrTypes.Out;
                case "ref": return ParametrTypes.Reference;
                case "":return ParametrTypes.Default;
                default: throw new Exception("Строка не является типом параметра");
            }
        }

        private object ToObjectType(IdentInfoTypes type, string obj)
        {
            if (type == IdentInfoTypes.CharType && (obj.Length != 3 || obj[obj.Length - 1] != '\'' || obj[0] != '\''))
                throw new Exception("Такая строка не может быть char");
            if (type == IdentInfoTypes.StringType && (obj[obj.Length - 1] != '\"' || obj[0] != '\"'))
                throw new Exception("Такая строка не может быть string");
            if (type == IdentInfoTypes.CharType || type == IdentInfoTypes.StringType)
                obj = obj.Remove(obj.Length - 1).Remove(0, 1);
            try
            {
                switch (type)
                {
                    case IdentInfoTypes.BoolType: return bool.Parse(obj);
                    case IdentInfoTypes.CharType: return char.Parse(obj);
                    case IdentInfoTypes.FloatType: return float.Parse(obj);
                    case IdentInfoTypes.IntType: return int.Parse(obj);
                    case IdentInfoTypes.StringType: return obj;
                    default: throw new Exception("Такого формата быть не может");
                }
            }
            catch { throw new Exception("Несоответствие формата константы"); }
        }
    }
}
