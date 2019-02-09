using ShadowEmu.Common.IO;
using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.Messages
{

    public class GuildShopUpdateMessage : NetworkMessage
    {

        public const uint Id = 5500;
        public uint MessageId
        {
            get { return Id; }
        }

        public byte[] guilds;
        public byte[] GuildVersatileInfoListMessage;
        public byte[] Alliances;
        public byte[] AlliancesVersatil;
 
        public GuildShopUpdateMessage()
        {
        }

        public GuildShopUpdateMessage(byte[] msg, byte[] GuildVersatileInfoListMessage, byte[] alliances, byte[] allianceVersa)
        {
            this.guilds = msg;
            this.GuildVersatileInfoListMessage = GuildVersatileInfoListMessage;
            this.Alliances = alliances;
            this.AlliancesVersatil = allianceVersa;
        }


        public void Serialize(IDataWriter writer)
        {
            writer.WriteInt(guilds.Length);
            writer.WriteBytes(guilds);

            writer.WriteInt(GuildVersatileInfoListMessage.Length);
            writer.WriteBytes(GuildVersatileInfoListMessage);

            writer.WriteInt(Alliances.Length);
            writer.WriteBytes(Alliances);

            writer.WriteInt(AlliancesVersatil.Length);
            writer.WriteBytes(AlliancesVersatil);
        }

        public void Deserialize(IDataReader reader)
        {
            var lenght = reader.ReadInt();
            guilds = reader.ReadBytes(lenght);

            lenght = reader.ReadInt();
            GuildVersatileInfoListMessage = reader.ReadBytes(lenght);

            lenght = reader.ReadInt();
            Alliances = reader.ReadBytes(lenght);

            lenght = reader.ReadInt();
            AlliancesVersatil = reader.ReadBytes(lenght);
        }


    }


}
