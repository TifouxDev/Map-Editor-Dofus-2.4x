using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Random
{
    public class SimpleAES
    {

        #region Variables

        private static byte[] Key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 146, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 146, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
        private static byte[] Vector = { 146, 64, 191, 111, 37, 3, 113, 119, 231, 45, 112, 112, 45, 19, 114, 156 };

        private static ICryptoTransform EncryptorTransform, DecryptorTransform;
        private static System.Text.UTF8Encoding UTFEncoder;

        #endregion

        #region Builder

        static SimpleAES()
        {
            RijndaelManaged rm = new RijndaelManaged();

            EncryptorTransform = rm.CreateEncryptor(Key, Vector);
            DecryptorTransform = rm.CreateDecryptor(Key, Vector);

            UTFEncoder = new System.Text.UTF8Encoding();
        }

        #endregion

        #region Methods

        public static byte[] Encrypt(string TextValue)
        {
            Byte[] bytes = UTFEncoder.GetBytes(TextValue);

            MemoryStream memoryStream = new MemoryStream();

            #region Write the decrypted value to the encryption stream
            CryptoStream cs = new CryptoStream(memoryStream, EncryptorTransform, CryptoStreamMode.Write);
            cs.Write(bytes, 0, bytes.Length);
            cs.FlushFinalBlock();
            #endregion

            #region Read encrypted value back out of the stream
            memoryStream.Position = 0;
            byte[] encrypted = new byte[memoryStream.Length];
            memoryStream.Read(encrypted, 0, encrypted.Length);
            #endregion

            cs.Close();
            memoryStream.Close();

            return encrypted;
        }

        public static string Decrypt(byte[] EncryptedValue)
        {
            #region Write the encrypted value to the decryption stream
            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream decryptStream = new CryptoStream(encryptedStream, DecryptorTransform, CryptoStreamMode.Write);
            decryptStream.Write(EncryptedValue, 0, EncryptedValue.Length);
            decryptStream.FlushFinalBlock();
            #endregion

            #region Read the decrypted value from the stream.
            encryptedStream.Position = 0;
            Byte[] decryptedBytes = new Byte[encryptedStream.Length];
            encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);
            encryptedStream.Close();
            #endregion
            return UTFEncoder.GetString(decryptedBytes);
        }

        public static byte[] EncryptAES(byte[] data, byte[] key)
        {
            var iv = key.Take(16).ToArray();
            try
            {
                using (var rijndaelManaged = new RijndaelManaged { Key = key, IV = iv, Mode = CipherMode.CBC })
                {
                    ICryptoTransform crypto = rijndaelManaged.CreateEncryptor();
                    return crypto.TransformFinalBlock(data, 0, data.Length);
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        public static string DecodeWithAES(byte[] ticket, byte[] aes)
        {
            var iv = aes.Take(32).ToArray();

            string text;

            var aesAlg = NewRijndaelManaged(aes);
            var decryptor = aesAlg.CreateDecryptor(aes, iv);
         
            using (var msDecrypt = new MemoryStream(ticket))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        text = srDecrypt.ReadToEnd();
                    }
                }
            }
            return text;
        }
        private static RijndaelManaged NewRijndaelManaged(byte[] key)
        {
           
            var aesAlg = new RijndaelManaged();
            aesAlg.Key = key;
            aesAlg.IV = key.Take(16).ToArray();

            return aesAlg;
        }
        public static string decodeWithAES(byte[] AESKey, byte[] ticket)
        {

            using (AesManaged _AesManaged = new AesManaged())
            {
                _AesManaged.Key = AESKey;
                _AesManaged.Padding = PaddingMode.None;
                _AesManaged.Mode = CipherMode.CBC;

                byte[] cipherText = new byte[16 + ticket.Length];

                BigEndianWriter writer = new BigEndianWriter(cipherText);
                writer.WriteBytes(AESKey, 0, 16);
                writer.WriteBytes(ticket);

                ICryptoTransform decryptor = _AesManaged.CreateDecryptor(_AesManaged.Key, _AesManaged.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

        }
        #endregion

    }
}
