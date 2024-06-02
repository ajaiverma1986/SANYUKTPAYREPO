using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SANYUKT.CommonLib.Utility
{
    public  class AESEncDec256
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("7F96I034A2515829"); // replace with your own secret key
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("2468912340583923"); // replace with your own initial vector

        public static string Encrypt(string plainText)
        {
            Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            System.IO.MemoryStream msEncrypt = new System.IO.MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            System.IO.StreamWriter swEncrypt = new System.IO.StreamWriter(csEncrypt);

            swEncrypt.Write(plainText);
            swEncrypt.Close();
            csEncrypt.Close();
            msEncrypt.Close();

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            System.IO.MemoryStream msDecrypt = new System.IO.MemoryStream(cipherBytes);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            System.IO.StreamReader srDecrypt = new System.IO.StreamReader(csDecrypt);

            string plainText = srDecrypt.ReadToEnd();
            srDecrypt.Close();
            csDecrypt.Close();
            msDecrypt.Close();

            return plainText;
        }
    }
}
