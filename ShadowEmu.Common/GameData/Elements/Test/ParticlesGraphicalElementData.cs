using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.GameData.Elements.Test
{
    public class ParticlesGraphicalElementData : EleGraphicalData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ParticlesGraphicalElementData(EleInstance instance, int id) : base(instance, id)
        {
        }

        public override EleGraphicalElementTypes Type
        {
            get
            {
                return EleGraphicalElementTypes.ANIMATED;
            }
        }

        public int ScriptId
        {
            get;
            set;
        }

        public static ParticlesGraphicalElementData ReadFromStream(EleInstance instance, int id, BigEndianReader reader)
        {
            var data = new ParticlesGraphicalElementData(instance, id);

            data.ScriptId = reader.ReadShort();

            return data;
        }
    }
}
