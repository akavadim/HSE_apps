using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    enum IdentInfoTypes
    {
        IntType,
        FloatType,
        BoolType,
        CharType,
        StringType,
        ClassType,
        VoidType
    }

    enum IdentTypes
    {
        Class,
        Const,
        Var,
        Method
    }

    enum ParametrTypes
    {
        Default,
        Reference,
        Out
    }
}
