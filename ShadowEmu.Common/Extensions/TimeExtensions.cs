using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Extensions
{
    public static class TimeExtensions
    {
        public static long GetUnixTimeStampLong(this DateTime date)
        {
            return (long)(date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime())).TotalMilliseconds;
        }

        public static int GetUnixTimeStamp(this DateTime date)
        {
            return (int)(date - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime()).TotalSeconds;
        }
    }
}