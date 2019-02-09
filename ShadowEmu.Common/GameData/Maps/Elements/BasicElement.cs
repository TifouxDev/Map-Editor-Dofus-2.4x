using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.GameData.Maps.Elements
{
    [Serializable()]
    public abstract class BasicElement : ICloneable
    {
        // Methods
        protected BasicElement()
        {
        }

        public static BasicElement GetElementFromType(int typeId)
        {
            switch (typeId)
            {
                case 2:
                    return new GraphicalElement();
                case 33:
                    return new SoundElement();
            }
            return null;
        }

        internal abstract void Init(BigEndianReader reader, int mapVersion);
        public abstract void Write(BigEndianWriter writer, int mapVersion);
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
