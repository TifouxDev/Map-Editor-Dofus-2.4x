using ShadowEmu.Common.IO;
using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{
    public class AccountBanMessage : ISCMessage
    {
        public string AccountId;
        public bool Banned;
        public string BanReason;
        public const uint Id = 20;
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
            AccountId = reader.ReadUTF();
            Banned = reader.ReadBoolean();
            BanReason = reader.ReadUTF();
        }

        public void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(AccountId);
            writer.WriteBoolean(Banned);
            writer.WriteUTF(BanReason);
        }
    }
}
