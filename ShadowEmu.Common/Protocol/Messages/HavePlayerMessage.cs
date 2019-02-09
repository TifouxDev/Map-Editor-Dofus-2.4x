using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{
    public class HavePlayerMessage : NetworkMessage
    {
        public const uint Id = 2554;
        public uint MessageId
        {
            get { return Id; }
        }

        public int accId;
        public string key;

        public HavePlayerMessage()
        {
        }

        public HavePlayerMessage(int accId, string key)
        {
            this.accId = accId;
            this.key = key;
        }

        public void Deserialize(IDataReader reader)
        {
            accId = reader.ReadInt();
            key = reader.ReadUTF();
        }

        public void Serialize(IDataWriter writer)
        {
            writer.WriteInt(accId);
            writer.WriteUTF(key);
        }
    }
}
