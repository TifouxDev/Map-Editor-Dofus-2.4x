using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{
    public class HavePlayerRequestMessage : NetworkMessage
    {
        public const uint Id = 2553;
        public uint MessageId
        {
            get { return Id; }
        }

        public string key = "";

        public HavePlayerRequestMessage(string key)
        {
            this.key = key;
        }

        public void Deserialize(IDataReader reader)
        {
            key = reader.ReadUTF();
        }

        public void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(key);
        }
    }
}
