using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowEmu.Common.GameData.Maps
{
    public class CustomHex
    {
        // Methods
        public static string FromArray(byte[] ByteArray, bool Flag = false)
        {
            string str = "";
            int num = (ByteArray.Length - 1);
            int i = 0;
            while ((i <= num))
            {
                string str2 = ByteArray[i].ToString("x");
                if ((str2.Length == 1))
                {
                    str2 = ("0" + str2);
                }
                str = (str + str2);
                if ((Flag && (i < (ByteArray.Length - 1))))
                {
                    str = (str + ":");
                }
                i += 1;
            }
            return str;
        }

        public static string FromString(string Str, bool Flag = false)
        {
            return CustomHex.FromArray(Encoding.ASCII.GetBytes(Str), false);
        }

        public static byte[] ToArray(string Str)
        {
            Str = Str.Replace(" ", "").Replace(":", "").Trim();
            if (((Str.Length & 1) == 1))
            {
                Str = ("0" + Str);
            }
            byte[] buffer = new byte[(Convert.ToInt32(Math.Round(Convert.ToDouble(((Convert.ToDouble(Str.Length) / 2) - 1)))) + 1)];
            int num = (Str.Length - 1);
            int i = 0;
            while ((i <= num))
            {
                buffer[Convert.ToInt32(Math.Round(Convert.ToDouble((Convert.ToDouble(i) / 2))))] = Convert.ToByte(Convert.ToInt32(Str.Substring(i, 2), 0x10));
                i = (i + 2);
            }
            return buffer;
        }

        public string ToString(string str)
        {
            return Encoding.ASCII.GetString(CustomHex.ToArray(str));
        }

        
    }
}
