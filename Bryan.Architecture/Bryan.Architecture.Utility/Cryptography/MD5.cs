using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.Utility.Cryptography
{
    /// <summary>The md 5.</summary>
    public static class Md5
    {
        /// <summary>The get hash.</summary>
        /// <param name="argument">The argument.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetHash(string argument)
        {
            using (var md5Hash = MD5.Create())
            {
                byte[] datas = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(argument));
                StringBuilder sb = new StringBuilder();
                foreach (var data in datas)
                {
                    sb.Append(data.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}