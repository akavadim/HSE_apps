using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IIdentificator
    {
        string Name { get;}

        int Hash { get; }

        IdentTypes IdentTypes { get;}

        IdentInfoTypes IdentInfoTypes { get;}
    }

    class Identificator : IIdentificator
    {
        public string Name { get; }

        public int Hash { get; }

        public IdentTypes IdentTypes { get; }

        public IdentInfoTypes IdentInfoTypes { get; }

        public Identificator(ISharpStringHandler stringHandler)
        {
            Name = stringHandler.Name;
            Hash = Name.GetHashCode();
            IdentInfoTypes = stringHandler.IdentInfoTypes;
            IdentTypes = stringHandler.IdentTypes;
        }

        public Identificator(string Name, IdentTypes IdentTypes, IdentInfoTypes IdentInfoTypes)
        {
            this.Name = Name;
            this.IdentTypes = IdentTypes;
            this.IdentInfoTypes = IdentInfoTypes;
            this.Hash = this.Name.GetHashCode();
        }
    }
}
