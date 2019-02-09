using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Random
{
    public static class FlashKeyGenerator
    {

        public static string GetRandomFlashKey(string accountName)
        {
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int seed = 0x2A;
            int num3 = 0;
            int length = accountName.Length;
            while (num3 < length)
            {
                char ch = accountName[num3];
                seed = (seed + (Convert.ToInt32(ch) - 3));
                num3 += 1;
            }
            System.Random random = new System.Random(seed);
            string str3 = "";
            int num2 = 1;
            do
            {
                str3 = (str3 + Convert.ToString(str[random.Next(0, str.Length)]));
                num2 += 1;
            }
            while (num2 <= 0x15);
            return str3;
        }

    }
}
