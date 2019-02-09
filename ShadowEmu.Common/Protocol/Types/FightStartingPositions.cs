using ShadowEmu.Common.IO;
using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.Types
{
    public class FightStartingPositions : NetworkType
    {

        public const short Id = 513;
        public virtual short TypeId
        {
            get { return Id; }
        }

        public List<uint> positionsForChallengers;
        public List<uint> positionsForDefenders;

        public FightStartingPositions()
        {
        }

        public FightStartingPositions(List<uint> positionsForChallengers, List<uint> positionsForDefenders)
        {
            this.positionsForChallengers = positionsForChallengers;
            this.positionsForDefenders = positionsForDefenders;
        }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)positionsForChallengers.Count);
            foreach (var item in positionsForChallengers)
            {
                writer.WriteVarShort((int)item);
            }
            writer.WriteShort((short)positionsForDefenders.Count);
            foreach (var item in positionsForDefenders)
            {
                writer.WriteVarShort((int)item);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {

        }


    }
}