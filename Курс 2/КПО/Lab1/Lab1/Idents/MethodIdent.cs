using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class MethodIdent:Identificator
    {
        MyArray<Parametr> Parameters { get; }

        public MethodIdent(ISharpStringHandler stringHandler):base(stringHandler)
        {
            Parameters = new MyArray<Parametr>(stringHandler.GetParametrs());
        }

        public MethodIdent(string Name, IdentTypes IdentTypes, IdentInfoTypes IdentInfoTypes, IEnumerable<Parametr> Parameters):base(Name, IdentTypes, IdentInfoTypes)
        {
            this.Parameters = new MyArray<Parametr>(Parameters);
        }
    }
}
