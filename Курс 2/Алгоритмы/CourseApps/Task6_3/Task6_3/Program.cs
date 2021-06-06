using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task6_3
{
    class Program
    {
        static int HashX = 2,
            HashP = 1000000;
        static void Main(string[] args)
        {
            string subStr = "",
                str = "";
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                subStr = reader.ReadLine();
                str = reader.ReadLine();
            }


            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                var res = GetSubPositions(str, subStr);
                writer.WriteLine(res.Item1);
                writer.Write(res.Item2);
            }
        }

        static int Hash(string str)
        {
            int res = 0;
            for(int i=0; i< str.Length; i++)
            {
                res = (res * HashX + (int)str[i]) % HashP;
            }
            return res;
        }

        static int PowXMod(int x, int y, int mod)
        {
            int res = 1;
            for (int i = 0; i < y; i++)
                res = (res * x) % mod;
            return res;
        }

        public static (int,string) GetSubPositions(string str, string subStr)
        {
            if (subStr.Length > str.Length)
                return (0, "");

            StringBuilder res = new StringBuilder();
            var subStrHash = Hash(subStr);
            //var hashs = BuildHashe(str, subStr);
            int n = 0;
            int i = 0;
            int strL = str.Length;
            int subStrL = subStr.Length;
            int m = str.Length - subStr.Length;
            var lastHash = Hash(str.Substring(0, subStr.Length));
            int powXMod = PowXMod(HashX, subStr.Length, HashP);
            bool isSame;

            for (i = 0; i < m; i++)
            {
                if (lastHash == subStrHash) 
                {
                    isSame = true;
                    for (int j = 0, k=subStrL-1; j <= k; j++, k--)
                    {
                        if (str[j + i] != subStr[j]||str[i+k]!=subStr[k])
                        {
                            isSame = false;
                            break;
                        }
                    }
                    if (isSame)
                    {
                        res.Append((i + 1) + " ");
                        n++;
                    }
                }
                lastHash = (lastHash * HashX - str[i] * powXMod + str[i + subStrL]) % HashP;
                if (lastHash < 0)
                    lastHash += HashP;
            }
            if (lastHash == subStrHash)
            {
                isSame = true;
                for (int j = 0; j < subStr.Length; j++)
                {
                    if (str[j + i] != subStr[j])
                    {
                        isSame = false;
                        break;
                    }
                }
                if (isSame)
                {
                    res.Append((i + 1) + " ");
                    n++;
                }
            }
            return (n, res.ToString());
        }

        static int[] BuildHashe(string str, string subStr)
        {
            int[] hashs = new int[str.Length - subStr.Length + 1];
            hashs[0] = Hash(str.Substring(0, subStr.Length));
            int powXMod = PowXMod(HashX, subStr.Length, HashP);
            for (int i = 0; i < str.Length - subStr.Length; i++)
            {
                hashs[i + 1] = (hashs[i] * HashX - ((int)str[i]) * powXMod + (int)str[i + subStr.Length]) % HashP;
                if (hashs[i + 1] < 0)
                    hashs[i + 1] += HashP;
            }
            return hashs;
        }

    }
}
