using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Extensions
{
    public static class DateExtensions
    {
        public static double DateTimeToUnixTimestamp(this DateTime dateTime)
        {
            var time = (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
            return time;
        }

        public static int DateTimeToUnixTimestampSeconds(this DateTime dateTime)
        {
            var time = (int)(dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
            return time;
        }

        public static DateTime UnixTimestampToDateTime(this double unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static DateTime UnixTimestampToDateTime(this int unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
