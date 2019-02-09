using ShadowEmu.Common.IO;
using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.Messages
{
    public class HaveConnectedMessage : NetworkMessage
    {
        public const uint Id = 2561;
        public uint MessageId
        {
            get { return Id; }
        }

        public int count;

        public HaveConnectedMessage(int count)
        {
            this.count = count;
        }

        public void Deserialize(IDataReader reader)
        {
            count = reader.ReadInt();
        }

        public void Serialize(IDataWriter writer)
        {
            writer.WriteInt(count);
        }
    }
}
