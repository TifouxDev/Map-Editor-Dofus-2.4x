using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowEmu.Common.GameData.Maps
{
    [Serializable()]
    public class Fixture
    {
        // Methods
        internal void Init(BigEndianReader Reader)
        {
            this.FixtureId = Reader.ReadInt();
            this.OffsetX = Reader.ReadShort();
            this.OffsetY = Reader.ReadShort();
            this.Rotation = Reader.ReadShort();
            this.xScale = Reader.ReadShort();
            this.yScale = Reader.ReadShort();
            this.RedMultiplier = Reader.ReadSByte();
            this.GreenMultiplier = Reader.ReadSByte();
            this.BlueMultiplier = Reader.ReadSByte();
            this.Hue = ((this.RedMultiplier | this.GreenMultiplier) | this.BlueMultiplier);
            this.Alpha = Reader.ReadByte();
        }

    


        // Fields
        public int Alpha;
        public int BlueMultiplier;
        public int FixtureId;
        public int GreenMultiplier;
        public int Hue;
        public int OffsetX;
        public int OffsetY;
        public int RedMultiplier;
        public int Rotation;
        public int xScale;
        public int yScale;
    }
}
