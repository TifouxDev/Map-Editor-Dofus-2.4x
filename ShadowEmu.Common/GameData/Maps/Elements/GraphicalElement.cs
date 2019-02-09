using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowEmu.Common.GameData.Maps.Elements
{
    [Serializable()]
    public class GraphicalElement : BasicElement
    {
        // Methods
        internal override void Init(BigEndianReader Reader, int MapVersion)
        {
            this.ElementId = Convert.ToInt32(Reader.ReadUInt());
            this.Hue = new ColorMultiplicator(Reader.ReadSByte(), Reader.ReadSByte(), Reader.ReadSByte());
            this.Shadow = new ColorMultiplicator(Reader.ReadSByte(), Reader.ReadSByte(), Reader.ReadSByte());
            if ((MapVersion <= 4))
            {
                this.OffsetX = Reader.ReadSByte();
                this.OffsetY = Reader.ReadSByte();
                this.PixelOffsetX = (this.OffsetX * 43);
                this.PixelOffsetY = (this.OffsetY * 21.5);
            }
            else
            {
                this.PixelOffsetX = Reader.ReadShort();
                this.PixelOffsetY = Reader.ReadShort();
                this.OffsetX = (this.PixelOffsetX / 43);
                this.OffsetY = (this.PixelOffsetY / 21.5);
            }
            this.Altitude = Reader.ReadSByte();
            this.Identifier = (int)Reader.ReadUInt();
            this.calculateFinalTeint();
        }

        public override void Write(BigEndianWriter writer, int mapVersion)
        {
            writer.WriteByte(2);
            writer.WriteUInt((uint)ElementId);
            writer.WriteSByte((sbyte)Hue.Red);
            writer.WriteSByte((sbyte)Hue.Green);
            writer.WriteSByte((sbyte)Hue.Blue);
            writer.WriteSByte((sbyte)Shadow.Red);
            writer.WriteSByte((sbyte)Shadow.Green);
            writer.WriteSByte((sbyte)Shadow.Blue);
            if (mapVersion <= 4)
            {
                writer.WriteSByte((sbyte)OffsetX);
                writer.WriteSByte((sbyte)OffsetY);
            }
            else
            {
                writer.WriteShort((short)(PixelOffsetX));
                writer.WriteShort((short)(PixelOffsetY));
            }
            writer.WriteSByte((sbyte)Altitude);
            writer.WriteUInt((uint)Identifier);
        }

        private void calculateFinalTeint()
        {
            var _loc1_ = this.Hue.Red + this.Shadow.Red;
            var _loc2_ = this.Hue.Green + this.Shadow.Green;
            var _loc3_ = this.Hue.Blue + this.Shadow.Blue;
            _loc1_ = ColorMultiplicator.clamp((_loc1_ + 128) * 2, 0,512);
            _loc2_ = ColorMultiplicator.clamp((_loc2_ + 128) * 2, 0, 512);
            _loc3_ = ColorMultiplicator.clamp((_loc3_ + 128) * 2, 0, 512);
            this.FinalTeint = new ColorMultiplicator((int)_loc1_, (int)_loc2_, (int)_loc3_);
        }
        // Fields
        public int Altitude;
        public int ElementId;
        public ColorMultiplicator FinalTeint;
        public ColorMultiplicator Hue;
        public int Identifier;
        public double OffsetX;
        public double OffsetY;
        public double PixelOffsetX;
        public double PixelOffsetY;
        public ColorMultiplicator Shadow;
    }
}
