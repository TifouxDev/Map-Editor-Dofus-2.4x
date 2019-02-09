using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowEmu.Common.GameData.Maps
{
    [Serializable()]
    public class ColorMultiplicator
    {
        // Methods
        public ColorMultiplicator(int red, int green, int blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        // Fields
        public double Blue;
        public double Green;
        public double Red;
        public static double clamp(double param1, double param2, double param3)
        {
            if (param1 > param3)
            {
                return param3;
            }
            if (param1 < param2)
            {
                return param2;
            }
            return param1;
        }
    }
}
