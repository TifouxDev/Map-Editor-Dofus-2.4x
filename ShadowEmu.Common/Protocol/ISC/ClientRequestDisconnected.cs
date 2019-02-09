using ShadowEmu.Common.IO;
using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{
    public class ClientRequestDisconnected : ISCMessage
    {
        public int AccountId;
     
        public const uint Id = 13;
        public uint MessageId
        {
            get
            {
                return Id;
            }
        }
        public uint RequestId
        {
            get; set;
        }
        public void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();        
        }

        public void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
        }
    }
}
