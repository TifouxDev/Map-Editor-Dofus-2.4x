using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{

    public class AccountRemoveTicketMessage : ISCMessage
    {
        public const uint Id = 14;
        public uint MessageId
        {
            get { return 14; }
        }
        public int AccountId
        {
            get;
            set;
        }
        public uint RequestId
        {
            get; set;
        }
        public string Ticket
        {
            get;
            set;
        }

    

        public void Serialize(IO.IDataWriter writer)
        {
            writer.WriteInt(AccountId);
          
            writer.WriteUTF(Ticket);
          
        }

        public void Deserialize(IO.IDataReader reader)
        {
            AccountId = reader.ReadInt();
         
            Ticket = reader.ReadUTF();       
        }
    }
}
