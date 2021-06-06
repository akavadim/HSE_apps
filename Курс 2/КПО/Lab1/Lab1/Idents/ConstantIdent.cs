using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class ConstantIdent:Identificator
    {

        object Value { get; }
        Constant Constant { get; }

        public ConstantIdent(ISharpStringHandler stringHandler) : base(stringHandler)
        {
            var constant = stringHandler.GetConstValue();
            Value = constant.Date;
            Constant = constant;
        }

        public ConstantIdent(string Name, IdentTypes IdentTypes, IdentInfoTypes IdentInfoTypes, int ConstValue) : base(Name, IdentTypes, IdentInfoTypes)
        {
            Value = ConstValue;
        }
    }
}
