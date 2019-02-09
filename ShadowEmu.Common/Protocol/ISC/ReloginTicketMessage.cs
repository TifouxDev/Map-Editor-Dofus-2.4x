using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{
    public class ReloginTicketMessage : ISCMessage
    {
        public const uint Id = 11;

        public sbyte[] Ticket;
        public int AccountId;

        public uint MessageId
        {
            get { return Id; }
        }
        public uint RequestId
        {
            get; set;
        }

        public void Serialize(IO.IDataWriter writer)
        {
            writer.WriteInt(Ticket.Count());
            for (int i = 0; i < Ticket.Count(); i++)
            {
                writer.WriteSByte(Ticket[i]);
            }
            writer.WriteInt(AccountId);
        }

        public void Deserialize(IO.IDataReader reader)
        {
            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                Ticket[i] = reader.ReadSByte();
            }
            AccountId = reader.ReadInt();
        }
    }
}
