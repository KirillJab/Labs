using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    class Encryption
    {
        public static byte[] GenerateKey(int length)
        {
            var key = new byte[length];
            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                key[i] = (byte)rand.Next(256);
            }
            return key;
        }
        public static string Encrypt(string input, byte[] key)
        {
            using (Aes encrSt = Aes.Create())
            {
                ICryptoTransform cryptoTransform = encrSt.CreateEncryptor(key, new byte[16]);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(input);
                        }
                        return Convert.ToBase64String(stream.ToArray());
                    }
                }
            }
        }
        public static string Decrypt(string input, byte[] key)
        {
            string output;
            using (Aes encrSt = Aes.Create())
            {
                ICryptoTransform cryptoTransform = encrSt.CreateDecryptor(key, new byte[16]);
                using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(input)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            output = streamReader.ReadToEnd();
                        }
                        return output;
                    }
                }
            }
        }
    }
}
