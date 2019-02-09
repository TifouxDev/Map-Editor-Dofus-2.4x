using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.GameData.Maps.Elements
{
    [Serializable()]
    public class SoundElement : BasicElement
    {
        // Methods
        internal override void Init(BigEndianReader Reader, int MapVersion)
        {
            this.SoundId = Reader.ReadInt();
            this.BaseVolume = Reader.ReadShort();
            this.FullVolumeDistance = Reader.ReadInt();
            this.NullVolumeDistance = Reader.ReadInt();
            this.MinDelayBetweenLoops = Reader.ReadShort();
            this.MaxDelayBetweenLoops = Reader.ReadShort();
        }

        public override void Write(BigEndianWriter writer, int mapVersion)
        {
            writer.WriteByte(33);
            writer.WriteInt(SoundId);
            writer.WriteShort((short)BaseVolume);
            writer.WriteInt(FullVolumeDistance);
            writer.WriteInt(NullVolumeDistance);
            writer.WriteShort((short)MinDelayBetweenLoops);
            writer.WriteShort((short)MaxDelayBetweenLoops);
        }

        // Fields
        public int BaseVolume;
        public int FullVolumeDistance;
        public int MaxDelayBetweenLoops;
        public int MinDelayBetweenLoops;
        public int NullVolumeDistance;
        public int SoundId;
    }
}
