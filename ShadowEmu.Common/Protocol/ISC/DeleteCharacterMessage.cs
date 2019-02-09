using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{
    public class DeleteCharacterMessage : ISCMessage
    {
        public int characterId;
        public int serverId;
        public const uint Id = 10;
        public uint MessageId
        {
            get { return Id; }
        }
        public uint RequestId
        {
            get; set;
        }
        public void Serialize(IO.IDataWriter writer)
        {
            writer.WriteInt(characterId);
            writer.WriteInt(serverId);
        }

        public void Deserialize(IO.IDataReader reader)
        {
            characterId = reader.ReadInt();
            serverId = reader.ReadInt();
        }
    }
}
