using ShadowEmu.Common.GameData.D2O;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.GameData.D2O
{
    public class TransformData : IDataObject
    {
        public string overrideClip;
        public string originalClip;
        public double x = 0.0;
        public double y = 0.0;
        public double scaleX = 1.0;
        public double scaleY = 1.0;
        public double rotation = 0.0;
    }
}
