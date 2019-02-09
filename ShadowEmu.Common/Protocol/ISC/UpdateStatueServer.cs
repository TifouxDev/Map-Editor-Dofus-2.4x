using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{
    public class UpdateStatueServer : ISCMessage
    {
        public int ServerId;
        public sbyte Status;
        public const uint Id = 4;
        public uint MessageId
        {
            get { return 4; }
        }
        public uint RequestId
        {
            get; set;
        }
        public UpdateStatueServer() { }
        public UpdateStatueServer(int serverId, sbyte status)
        {
            ServerId = serverId;
            Status = status;
        }
        public void Serialize(IO.IDataWriter writer)
        {
            writer.WriteInt(ServerId);
            writer.WriteSByte(Status);
        }

        public void Deserialize(IO.IDataReader reader)
        {
            ServerId = reader.ReadInt();
            Status = reader.ReadSByte();
        }
    }
}
