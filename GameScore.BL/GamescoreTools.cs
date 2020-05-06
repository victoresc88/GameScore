using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GameScore.BL
{
    public static class GamescoreTools
    {
        public static string Hash(this string input)
        {
            try
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hash = SHA256.Create().ComputeHash(inputBytes);
                var ret = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                    ret.Append(hash[i].ToString("x2"));

                return ret.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
