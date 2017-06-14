using System;
using System.Security.Cryptography;
using System.Text;

namespace WebProject.Common
{
    public class SecurityHelper
    {
        /// <summary>
        /// md5混淆加密
        /// </summary>
        /// <param name="decrytstr"></param>
        /// <returns></returns>
        public static string Encrypt(string decrytstr)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(Encoding.UTF8.GetBytes(decrytstr));
            return BitConverter.ToString(s).Replace("-", string.Empty).ToLower();
        }
    }
}
