using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{
    public class BadTicketInformation : ISCMessage
    {
        public const uint Id = 7;
        public string Ticket;
        public uint MessageId
        {
            get { return 7; }
        }

        public uint RequestId
        {
            get; set;
        }
        public void Serialize(IO.IDataWriter writer)
        {
            writer.WriteUTF(Ticket);
        }

        public void Deserialize(IO.IDataReader reader)
        {
            Ticket = reader.ReadUTF();
        }
    }
}
