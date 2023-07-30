using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserMgr.Domain.Uilities
{
    public static class MD5Helper
    {
        public static string MD5Cryptography(string value)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(value);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2")); // 将每个字节转换为两位的十六进制字符串
            }
            string hashString = builder.ToString();
            return hashString;
        }
    }
}
