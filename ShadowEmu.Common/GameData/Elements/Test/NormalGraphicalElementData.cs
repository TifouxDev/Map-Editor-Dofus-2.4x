using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.GameData.Elements.Test
{
    public class NormalGraphicalElementData : EleGraphicalData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public NormalGraphicalElementData(EleInstance instance, int id) : base(instance, id)
        {
        }

        public int Gfx
        {
            get;
            set;
        }

        public uint Height
        {
            get;
            set;
        }

        public bool HorizontalSymmetry
        {
            get;
            set;
        }

        public System.Drawing.Point Origin
        {
            get;
            set;
        }

        public System.Drawing.Point Size
        {
            get;
            set;
        }

        public override EleGraphicalElementTypes Type
        {
            get { return EleGraphicalElementTypes.NORMAL; }
        }

        public static NormalGraphicalElementData ReadFromStream(EleInstance instance, int id, BigEndianReader reader)
        {
            var data = new NormalGraphicalElementData(instance, id);

            data.Gfx = reader.ReadInt();
            data.Height = reader.ReadByte();
            data.HorizontalSymmetry = reader.ReadBoolean();
            data.Origin = new System.Drawing.Point(reader.ReadShort(), reader.ReadShort());
            data.Size = new System.Drawing.Point(reader.ReadShort(), reader.ReadShort());

            return data;
        }
    }
}
