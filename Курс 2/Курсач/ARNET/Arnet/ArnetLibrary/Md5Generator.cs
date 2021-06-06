using System;
using System.Collections.Generic;
using System.Text;

namespace  Arnet.Library
{
    public class Md5Generator
    {
        public string RandomMd5String()
        {
            var bytes = new byte[16];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
