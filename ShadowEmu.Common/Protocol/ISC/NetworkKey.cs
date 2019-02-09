using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{
    public class NetworkKey : ISCMessage
    {
        public string Key;

        public const uint Id = 2;
        public uint MessageId
        {
            get { return 2; }
        }
        public uint RequestId
        {
            get; set;
        }
        public NetworkKey() { }
        public NetworkKey(string key)
        {
            Key = key;
        }
        public void Serialize(IO.IDataWriter writer)
        {
            writer.WriteUTF(Key);
        }

        public void Deserialize(IO.IDataReader reader)
        {
            Key = reader.ReadUTF();
        }
    }
}
