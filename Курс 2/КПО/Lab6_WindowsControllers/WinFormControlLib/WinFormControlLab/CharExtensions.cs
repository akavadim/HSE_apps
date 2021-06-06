using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinControllers
{
    static class CharExtensions
    {

        public static bool IsHex(char c)
        {
            if (char.IsDigit(c))
                return true;
            if ((c >= 65 && c <= 70) || (c >= 97 && c <= 102))
                return true;
            return false;
        }
    }
}
