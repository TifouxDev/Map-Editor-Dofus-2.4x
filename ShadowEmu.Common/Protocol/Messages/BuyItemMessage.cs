using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{
    public class BuyItemMessage : NetworkMessage
    {
        public const uint Id = 2555;
        public uint MessageId
        {
            get { return Id; }
        }

        public int itemId;
        public int count;
        public string key;

        public BuyItemMessage()
        {
        }

        public BuyItemMessage(int itemId, int count, string key)
        {
            this.itemId = itemId;
            this.count = count;
            this.key = key;
        }

        public void Deserialize(IDataReader reader)
        {
            itemId = reader.ReadInt();
            count = reader.ReadInt();
            key = reader.ReadUTF();
        }

        public void Serialize(IDataWriter writer)
        {
            writer.WriteInt(itemId);
            writer.WriteInt(count);
            writer.WriteUTF(key);
        }
    }
}
