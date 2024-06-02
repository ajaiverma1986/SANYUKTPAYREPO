using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SANYUKT.CommonLib.Utility
{
    public class PKCS5Class
    {
        protected RijndaelManaged myRijndael;

        protected static readonly PKCS5Class _instance = new PKCS5Class();
        public static PKCS5Class Instance
        {
            get { return _instance; }
        }

        public PKCS5Class()
        {

        }

        public string symmetrickeygen()
        {
            int len = 16;
            string key = "";

            List<string> alphanumeric = new List<string>();

            char[] allChars = (Enumerable.Range(65, 26).Select(c => (Char)c).Union(Enumerable.Range(97, 26).Select(c => (Char)c))).ToArray();

            for (int j = 0; j < allChars.Length; j++)
                alphanumeric.Add(allChars.GetValue(j).ToString());

            for (int i = 0; i < 10; i++)
                alphanumeric.Add(i.ToString());

            Random rnd = new Random();
            for (int i = 0; i < len; i++)
            {
                string vn = alphanumeric[rnd.Next(0, 61)];
                key += vn;
            }
            return key;
        }


        /// <summary>
        /// To Get Encrypted Token based on RSA-SHA1 Signature Algorithm with FIA private key
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fiaprivatekey"></param>
        /// <returns></returns>
        public string GetToken(string input, string fiaprivatekey)
        {
            ASCIIEncoding ByteConverter = new ASCIIEncoding();
            byte[] inputBytes = ByteConverter.GetBytes(input);

            byte[] inputHash = new SHA1CryptoServiceProvider().ComputeHash(inputBytes);


            var byteArray = Encoding.ASCII.GetBytes(fiaprivatekey);
            var ms = new MemoryStream(byteArray);
            var sr = new StreamReader(ms);
            var pemReader = new Org.BouncyCastle.Utilities.IO.Pem.PemReader(sr);
            var pem = pemReader.ReadPemObject();
            var privateKey = PrivateKeyFactory.CreateKey(pem.Content);
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(privateKey as RsaPrivateCrtKeyParameters);

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(128);
            rsa.ImportParameters(rsaParams);


            byte[] output = rsa.SignHash(inputHash, "SHA1");

            return Convert.ToBase64String(output);
        }

        /// <summary>
        /// To Get Encrypted Key based on RSA-SHA1 Signature Algorithm with Yes Bank public key
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fiaprivatekey"></param>
        /// <returns></returns>
        public string ParterKeyEncryption(string strText, string bankspublickey)
        {
            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(128))
            {
                try
                {
                    PemReader pr = new PemReader(new StringReader(bankspublickey));
                    AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter)pr.ReadObject();

                    RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)publicKey);

                    rsa.ImportParameters(rsaParams);

                    var encryptedData = rsa.Encrypt(testData, RSAEncryptionPadding.Pkcs1);


                    var base64Encrypted = Convert.ToBase64String(encryptedData);

                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }


        /// <summary>
        /// To Get Decrypted Key based on RSA-128 Algorithm with FIA private key
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="fiaprivatekey"></param>
        /// <returns></returns>
        public string GetDecryptKey(string strText, string fiaprivatekey)
        {
            var testData = Convert.FromBase64String(strText);

            using (var rsa = new RSACryptoServiceProvider(128))
            {
                try
                {
                    /*
            string fiaprivatekey = @"-----BEGIN PRIVATE KEY-----
MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCzuBTLHA529tID
mvFJj3W2tJ3CrvvR5Vt/WBEgf5zBjSrP3VDGd1XGVfXsoxuV1BE++dH8azm9qcQ4
NQQlRw7PekZ51Njtpx0SUz2bJbt/1UgOw+XxJ4jrWz3GyGbq1hVt1i7FYdlS+pNK
UaxlSRf3dzyU+5wOMDhJ5Hk8/iCIAAkEqR6DhPLsIuzG0/QjgjFi7cs0fVmAuM44
tHOKordvNkVzVhJL2DY+z4YTHxthaZyplCj6UBUmB2Bog8jnM/LrKnf+FUcVksb3
rZm4vEWWBnaNUtfpoUVCZRijKvsFxNl0ESGCeRX+4oWHYCsy2MqxaBiQMTXT4LTd
U3vJFTy9AgMBAAECggEAO/2sLzqP14U/iIWNmq0BMbpr2QNZOvDxUHpgyTTf6joJ
uvZZEs7d+oVSQKoXuLVgBmIVBsnyLc4AGnUUC6+DEZ3y7ZMv0HDSwv23WFVJl/vl
gExDMvMsAMhlwDfAJw7Me2weE7Q8e7b6OLo3rl2uWuRZ/C9bId9VwtC56bK4wDyW
2kVX9cDXQEFZ+tavy4cMqW1NLO0+H+xbc1y22D/luwNXyJyRpCLqeIiUqrppG+5l
hGuTuaJ4AcQ0FwiP4jMXE95CAtobuqeiZjMokkxiNMX/98NC2basLyazVH6Cc1Mm
sXmiGc0pljnuTiuWvbW1iya0ulSXur3xlFPfDqF4vwKBgQDtHdh6h73WTtU9gonZ
W4B+HB6WUT61FWyR2ay0aSG4h5t0ECg+iBe4yEQ9U3eDXKlAuVh/uWUvlh+bCufV
BUKm3ntBF7PdiVNWAZF1EPxsq5572DeAAdatERr20uU5kj4CClEAZh1VvVn68K1t
uXXF3FVGreyCXDdT5TR6WEbg+wKBgQDCCA7pDEMwSNS6vQeBtEXfzx2IeQguJ/5f
MCffRt8fFh6b3N1TaIQkLs3U14+hQlnYCPVY/5gsWdhiaonGRVEUvAMsGP8ROTet
IqE1vaN8wpfm+wYe0TfFH+hTl4H4IA4F/FyaO9D4xzko/IrcTjruNsDlKx2iDoRD
D7sHzPobpwKBgQDCJgbjxRN2T1Qgqiru0xIxsBqHX/ylTuZ3wbC8g7x9mGN7s+MP
2GT8AtaFFDuuToezHE/PPOESBqzYSSSr8kOx2Ec5dAvtIA0hReVw4jidTiRVKSPA
Z0D8sh3O7b2M1yZ4izPpzLLGSmVLqBeI2SsKmC8m0S/vSUxwICNI7dETUwKBgEew
XoHwi+qNHjwYl2tuxdpZVdoUjdcv46Ybzr+KGeoMbCa+RfAJT7lmqZoYQvMb5sIR
HUVSulC4qWBDaMAe4EQ+6xUh7yvX7iBECTgn5v2zkBhBaxN7zZVBor8v3U9l2IiR
o01BCIbCZPYlyNB4/wEAreh+M6aqomd8qmfJbidFAoGBALyeio0EtAORoSY6+SZ9
Yrqa1jF9j1sBWhsFOJ5iQFfYbUnTvKLlCN31mlq/MT0TflQ3UiTPI+L3bCrRbBP6
0CAb8/Fq2AZ0Zud7sxn0fYlrm/X7ZpTr1MGKKWaW2CCXmFEj/mJMcxe7qBrSVH2n
mZRrLFCuSDoP95aTggl2y/c6
-----END PRIVATE KEY-----";
*/



                    var byteArray = Encoding.ASCII.GetBytes(fiaprivatekey);
                    var ms = new MemoryStream(byteArray);
                    var sr = new StreamReader(ms);
                    var pemReader = new Org.BouncyCastle.Utilities.IO.Pem.PemReader(sr);
                    var pem = pemReader.ReadPemObject();
                    var privateKey = PrivateKeyFactory.CreateKey(pem.Content);
                    RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(privateKey as RsaPrivateCrtKeyParameters);


                    rsa.ImportParameters(rsaParams);

                    var decryptedData = rsa.Decrypt(testData, RSAEncryptionPadding.Pkcs1);


                    var strvalue = Encoding.UTF8.GetString(decryptedData);

                    return strvalue;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        /// <summary>
        /// To Get Encrypted Request based on AES/CBC/PKCS5Padding with symmetric key and IV
        /// </summary>
        /// <param name="key"></param>
        /// <param name="plainText"></param>
        /// <param name="initialisationVector"></param>
        /// <returns></returns>
        public string EncryptRIJText(string key, string plainText, string initialisationVector)
        {

            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 128;
            //rijndaelCipher.BlockSize = 128;

            byte[] encryptedbytes = Encoding.UTF8.GetBytes(plainText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(initialisationVector);

            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = ivBytes;

            ICryptoTransform transform = rijndaelCipher.CreateEncryptor(keyBytes, ivBytes);
            return Convert.ToBase64String(transform.TransformFinalBlock(encryptedbytes, 0, plainText.Length));
        }

        /// <summary>
        /// To Get Decrypted Value from Bank Encrypted Response based on AES/CBC/PKCS5Padding with symmetric key and IV
        /// </summary>
        /// <param name="key"></param>
        /// <param name="toBeDecrypted"></param>
        /// <param name="initialisationVector"></param>
        /// <returns></returns>
        public string DecrptRIJText(string key, string toBeDecrypted, string initialisationVector)
        {

            var keyByte = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(initialisationVector);

            var rijndael = new RijndaelManaged
            {
                BlockSize = 128,
                IV = ivBytes,
                KeySize = 128,
                Key = keyByte,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.Zeros
            };

            var buffer = Convert.FromBase64String(toBeDecrypted);
            var transform = rijndael.CreateDecryptor();

            MemoryStream msDecrypt = new MemoryStream(buffer);

            CryptoStream csDecrypt = new CryptoStream(msDecrypt, transform, CryptoStreamMode.Read);

            string plaintext = "";
            using (StreamReader Decrypt = new StreamReader(csDecrypt))
            {
                plaintext = Decrypt.ReadToEnd();
            }
            return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(plaintext));

        }


        public string AES256Encrypt(string publicKey, string data)
        {
            CspParameters cspParams = new CspParameters { ProviderType = 1 };
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);

            rsaProvider.ImportCspBlob(Convert.FromBase64String(publicKey));

            byte[] plainBytes = Encoding.UTF8.GetBytes(data);
            byte[] encryptedBytes = rsaProvider.Encrypt(plainBytes, false);

            return Convert.ToBase64String(encryptedBytes);
        }


        // using System.Security.Cryptography;
        public static byte[] ComputeHashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }

        public string GetHashKey(string privatekey)
        {
            using (var md5 = MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in md5.ComputeHash(Encoding.UTF8.GetBytes(privatekey)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }
        }

        public string AESEncrypt256StringBySecretKey(string plainText, string secretkey)
        {
            string encryptedstring = string.Empty;

            var keyByte = Encoding.UTF8.GetBytes(secretkey);
            var privatekeybyte = ComputeHashSha256(Encoding.UTF8.GetBytes(secretkey));

            byte[] ivBytes = new byte[16];
            keyByte = new byte[24];
            Array.Copy(privatekeybyte, ivBytes, 16);
            Array.Copy(privatekeybyte, keyByte, 24);

            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (keyByte == null || keyByte.Length <= 0)
                throw new ArgumentNullException("Key");
            if (ivBytes == null || ivBytes.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = keyByte;
                aesAlg.IV = ivBytes;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                        encryptedstring = Convert.ToBase64String(encrypted);
                    }
                }
            }

            // Return the encrypted bytes from the memory stream. 
            return encryptedstring;

        }


        public string AESDecrypt256StringBySecretKey(string encryptedText, string secretkey)
        {
            string decryptedstring = string.Empty;

            var keyByte = Encoding.UTF8.GetBytes(secretkey);
            var privatekeybyte = ComputeHashSha256(Encoding.UTF8.GetBytes(secretkey));

            byte[] ivBytes = new byte[16];
            keyByte = new byte[24];
            Array.Copy(privatekeybyte, ivBytes, 16);
            Array.Copy(privatekeybyte, keyByte, 24);

            // Check arguments. 
            if (encryptedText == null || encryptedText.Length <= 0)
                throw new ArgumentNullException("decryptedText");
            if (keyByte == null || keyByte.Length <= 0)
                throw new ArgumentNullException("Key");
            if (ivBytes == null || ivBytes.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted = Convert.FromBase64String(encryptedText);
            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = keyByte;
                aesAlg.IV = ivBytes;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform decrypter = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encrypted))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypter, CryptoStreamMode.Read))
                    {
                        using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                        {
                            decryptedstring = swDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            // Return the encrypted bytes from the memory stream. 
            return decryptedstring;

        }


        public string AESEncrypt256String(string plainText, string publickey)
        {
            string encryptedstring = string.Empty;

            var keyByte = Encoding.UTF8.GetBytes(publickey);

            byte[] ivBytes = new byte[16];

            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (keyByte == null || keyByte.Length <= 0)
                throw new ArgumentNullException("Key");
            if (ivBytes == null || ivBytes.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = keyByte;
                aesAlg.IV = ivBytes;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                        encryptedstring = Convert.ToBase64String(encrypted);
                    }
                }
            }

            // Return the encrypted bytes from the memory stream. 
            return encryptedstring;

        }



        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static byte[] Base64Decoding(String input)
        {
            return Convert.FromBase64String(input);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
