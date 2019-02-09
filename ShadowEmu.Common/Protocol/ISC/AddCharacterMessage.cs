using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{
   public class AddCharacterMessage : ISCMessage
    {
       public int AccountId;
       public int ServerId;
       public const uint Id = 8;
        public uint MessageId
        {
            get { return 8; }
        }
        public uint RequestId
        {
            get; set;
        }
        public void Serialize(IO.IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteInt(ServerId);
        }

        public void Deserialize(IO.IDataReader reader)
        {
            AccountId = reader.ReadInt();
            ServerId = reader.ReadInt();
        }
    }
}
