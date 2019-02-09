using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaCore.Common.Crypto
{
    public static class Cryptography
    {

        #region Methods

        public static sbyte[] Encrypt(sbyte[] key, string salt, string username, string password, byte[] aesKey)
        {
            //Convert SByte To Byte

            List<byte> unsigned = new List<byte>();
            foreach (sbyte signed in key)
            {
                unsigned.Add(unchecked((byte)signed));
            }

            //Set Public Key

            RSACryptoServiceProvider publicKey = SetPublicKey(unsigned);

            //Set Salt

            string validSalt = SetSalt(salt);

            //Get Credentials

            byte[] credentials = SetCredentials(publicKey, validSalt, username, password, aesKey);

            //Convert Byte To SByte

            return (sbyte[])(Array)credentials;
        }

        #region Set
        private static string GetRsaPublicKey()
        {
            return "MIIBUzANBgkqhkiG9w0BAQEFAAOCAUAAMIIBOwKCATIAgucoka9J2PXcNdjcu6CuDmgteIMB+rih2UZJIuSoNT/0J/lEKL/W4UYbDA4U/6TDS0dkMhOpDsSCIDpO1gPG6+6JfhADRfIJItyHZflyXNUjWOBG4zuxc/L6wldgX24jKo+iCvlDTNUedE553lrfSU23Hwwzt3+doEfgkgAf0l4ZBez5Z/ldp9it2NH6/2/7spHm0Hsvt/YPrJ+EK8ly5fdLk9cvB4QIQel9SQ3JE8UQrxOAx2wrivc6P0gXp5Q6bHQoad1aUp81Ox77l5e8KBJXHzYhdeXaM91wnHTZNhuWmFS3snUHRCBpjDBCkZZ+CxPnKMtm2qJIi57RslALQVTykEZoAETKWpLBlSm92X/eXY2DdGf+a7vju9EigYbX0aXxQy2Ln2ZBWmUJyZE8B58CAwEAAQ==";
        }

        private static RSACryptoServiceProvider SetPublicKey(List<byte> key)
        {
            byte[] array = key.ToArray();
            //Decode RSAPublicKey
            string _rsaPublicKey = GetRsaPublicKey();
            RSACryptoServiceProvider rsapublicKey = DecodeX509PublicKey(Convert.FromBase64String(_rsaPublicKey));

            //Verify
            byte[] VerifiedKey = verify(array, rsapublicKey.ExportParameters(false));

            //Return Valid Public Key
            return DecodeX509PublicKey(VerifiedKey);

        }

        private static string SetSalt(string salt)
        {
            if (salt.Length < 32)
            {
                while (salt.Length < 32)
                {
                    salt += " ";
                }
            }

            return salt;
        }

        private static byte[] SetCredentials(RSACryptoServiceProvider publickey, string salt, string username, string password, byte[] aesKey)
        {
            List<byte> Credentials = new List<byte>();

            Credentials.AddRange(Encoding.UTF8.GetBytes(salt));
            Credentials.AddRange(aesKey);
            Credentials.Add(Convert.ToByte(username.Length));
            Credentials.AddRange(Encoding.UTF8.GetBytes(username));
            Credentials.AddRange(Encoding.UTF8.GetBytes(password));

            byte[] result = publickey.Encrypt(Credentials.ToArray(), false);

            return result;
        }
        #endregion

        #region Autre Methode

        private static RSACryptoServiceProvider DecodeX509PublicKey(byte[] x509key)
        {
            // Inspired of http://stackoverflow.com/questions/11506891/how-to-load-the-rsa-public-key-from-file-in-c-sharp

            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] seq = new byte[15];
            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            MemoryStream mem = new MemoryStream(x509key);
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;

            try
            {

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();    //advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();   //advance 2 bytes
                else
                    return null;

                seq = binr.ReadBytes(15);       //read the Sequence OID
                if (!CompareBytearrays(seq, SeqOID))    //make sure Sequence for OID is correct
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                    binr.ReadByte();    //advance 1 byte
                else if (twobytes == 0x8203)
                    binr.ReadInt16();   //advance 2 bytes
                else
                    return null;

                bt = binr.ReadByte();
                if (bt != 0x00)     //expect null byte next
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();    //advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();   //advance 2 bytes
                else
                    return null;

                twobytes = binr.ReadUInt16();
                byte lowbyte = 0x00;
                byte highbyte = 0x00;

                if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                    lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
                else if (twobytes == 0x8202)
                {
                    highbyte = binr.ReadByte(); //advance 2 bytes
                    lowbyte = binr.ReadByte();
                }
                else
                    return null;
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                int modsize = BitConverter.ToInt32(modint, 0);

                byte firstbyte = binr.ReadByte();
                binr.BaseStream.Seek(-1, SeekOrigin.Current);

                if (firstbyte == 0x00)
                {   //if first byte (highest order) of modulus is zero, don't include it
                    binr.ReadByte();    //skip this null byte
                    modsize -= 1;   //reduce modulus buffer size by 1
                }

                byte[] modulus = binr.ReadBytes(modsize);   //read the modulus bytes

                if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data
                    return null;
                int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                byte[] exponent = binr.ReadBytes(expbytes);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAKeyInfo = new RSAParameters();
                RSAKeyInfo.Modulus = modulus;
                RSAKeyInfo.Exponent = exponent;
                RSA.ImportParameters(RSAKeyInfo);
                return RSA;
            }
            catch (System.Exception)
            {
                return null;
            }

            finally { binr.Close(); }

        }

        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            // Inspired of http://stackoverflow.com/questions/11506891/how-to-load-the-rsa-public-key-from-file-in-c-sharp

            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }

        private static byte[] verify(byte[] key, RSAParameters RSAParameters)
        {
            // Thank's to MoonLight Angel

            BigInteger Exponent = new BigInteger(RSAParameters.Exponent.Reverse().Concat(new byte[] { 0 }).ToArray());
            BigInteger Modulus = new BigInteger(RSAParameters.Modulus.Reverse().Concat(new byte[] { 0 }).ToArray());

            BigInteger PreparedData = new BigInteger(key   // Our data block
                .Reverse()  // BigInteger has another byte order
                .Concat(new byte[] { 0 })   // Append 0 so we are always handling positive numbers
                .ToArray()  // Constructor wants an array
            );

            byte[] DecryptedData = BigInteger.ModPow(PreparedData, Exponent, Modulus)   // The RSA operation itself
                .ToByteArray()  // Make bytes from BigInteger
                .Reverse()  // Back to "normal" byte order
                .ToArray(); // Return as byte array

            return DecryptedData.SkipWhile(x => x != 0).Skip(1).ToArray(); // PKCS#1 padding
        }

        #endregion

        #endregion

    }
}
