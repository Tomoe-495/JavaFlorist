using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace JavaFlorist.Models
{
    public class Encrypt
    {
        private string key;

        public Encrypt()
        {
            key = "aa";
        }
        public Encrypt(string key)
        {
            this.key = key;
        }

        public string EnCrypt(string plainText)
        {
            byte[] data;
            byte[] keys;
            byte[] results;

            data = UTF8Encoding.UTF8.GetBytes(plainText);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.key));

            TripleDESCryptoServiceProvider tp = new TripleDESCryptoServiceProvider() {Key=keys, Mode =CipherMode.ECB,Padding=PaddingMode.PKCS7 };
            ICryptoTransform transform = tp.CreateEncryptor();

            results = transform.TransformFinalBlock(data, 0, data.Length);

            return System.Convert.ToBase64String(results);

        }
    }
}