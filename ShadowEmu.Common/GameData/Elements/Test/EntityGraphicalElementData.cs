using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.GameData.Elements.Test
{
    public class EntityGraphicalElementData : EleGraphicalData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public EntityGraphicalElementData(EleInstance instance, int id)
            : base(instance, id)
        {
        }

        public string EntityLook
        {
            get;
            set;
        }

        public bool HorizontalSymmetry
        {
            get;
            set;
        }

        public bool PlayAnimation
        {
            get;
            set;
        }

        public bool PlayAnimStatic
        {
            get;
            set;
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

        public override EleGraphicalElementTypes Type
        {
            get { return EleGraphicalElementTypes.ENTITY; }
        }

        public static EntityGraphicalElementData ReadFromStream(EleInstance instance, int id, BigEndianReader reader)
        {
            var data = new EntityGraphicalElementData(instance, id);

            data.EntityLook = reader.ReadUTF7BitLength();
            data.HorizontalSymmetry = reader.ReadBoolean();

            if (instance.Version >= 7)
            {
                data.PlayAnimation = reader.ReadBoolean();
            }

            if (instance.Version >= 6)
            {
                data.PlayAnimStatic = reader.ReadBoolean();
            }

            if (instance.Version >= 5)
            {
                data.MinDelay = reader.ReadInt();
                data.MaxDelay = reader.ReadInt();
            }

            return data;
        }
    }
}
