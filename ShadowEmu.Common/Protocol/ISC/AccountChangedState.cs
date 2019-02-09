using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.ISC
{
    public class AccountChangedState : ISCMessage
    {
        public int AccountId;
        public bool Connected;
        public bool OnTheWorld;
        public const uint Id = 12;
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
            Connected = reader.ReadBoolean();
            OnTheWorld = reader.ReadBoolean();
        }

        public void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteBoolean(Connected);
            writer.WriteBoolean(OnTheWorld);
        }
    }
}
