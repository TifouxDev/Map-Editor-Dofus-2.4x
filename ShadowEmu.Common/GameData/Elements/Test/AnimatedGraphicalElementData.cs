using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.GameData.Elements.Test
{
    public class AnimatedGraphicalElementData : NormalGraphicalElementData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AnimatedGraphicalElementData(EleInstance instance, int id) : base(instance, id)
        {
        }

        public override EleGraphicalElementTypes Type
        {
            get
            {
                return EleGraphicalElementTypes.ANIMATED;
            }
        }

        public int MinDelay
        {
            get;
            set;
        }

        public int MaxDelay
        {
            get;
            set;
        }

        public static new AnimatedGraphicalElementData ReadFromStream(EleInstance instance, int id, BigEndianReader reader)
        {
            var data = new AnimatedGraphicalElementData(instance, id);

            data.Gfx = reader.ReadInt();
            data.Height = reader.ReadByte();
            data.HorizontalSymmetry = reader.ReadBoolean();
            data.Origin = new System.Drawing.Point(reader.ReadShort(), reader.ReadShort());
            data.Size = new System.Drawing.Point(reader.ReadShort(), reader.ReadShort());

            if (instance.Version == 4)
            {
                data.MinDelay = reader.ReadInt();
                data.MaxDelay = reader.ReadInt();
            }

            return data;
        }
    }
}
