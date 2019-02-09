using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.ISC
{
    public class AccountAnswerMessage : ISCMessage
    {
        public const uint Id = 6;
        public uint MessageId
        {
            get { return 6; }
        }
        public uint RequestId
        {
            get; set;
        }
        public int AccountId
        {
            get;
            set;
        }
       
        public string Login
        {
            get;
            set;
        }
       
        public string PasswordHash
        {
            get;
            set;
        }
     
        public string Nickname
        {
            get;
            set;
        }
    
        public string Ticket
        {
            get;
            set;
        }
        
        public string SecretQuestion
        {
            get;
            set;
        }
      
        public string SecretAnswer
        {
            get;
            set;
        }

        public string LastConnexion
        {
            get;
            set;
        }

        public string LastIp
        {
            get;
            set;
        }

        public CharacterRoleEnum Role
        {
            get;
            set;
        }

        public DateTime DateLast
        {
            get
            {
                if (LastConnexion.Trim() == "")
                     return DateTime.Now;
                 return DateTime.Parse(LastConnexion);
            }
        }

        public void Serialize(IO.IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteUTF(Login);
            writer.WriteUTF(PasswordHash);
            writer.WriteUTF(Nickname);
            writer.WriteUTF(Ticket);
            writer.WriteUTF(SecretQuestion);
            writer.WriteUTF(SecretAnswer);
            writer.WriteUTF(LastConnexion);
            writer.WriteUTF(LastIp);
            writer.WriteByte((byte)Role);

        }

        public void Deserialize(IO.IDataReader reader)
        {
            AccountId = reader.ReadInt();
            Login = reader.ReadUTF();
            PasswordHash = reader.ReadUTF();
            Nickname = reader.ReadUTF();
            Ticket = reader.ReadUTF();
            SecretQuestion = reader.ReadUTF();
            SecretAnswer = reader.ReadUTF();
            LastConnexion = reader.ReadUTF();
            LastIp = reader.ReadUTF();
            Role = (CharacterRoleEnum)reader.ReadByte();
        }
    }
}
