


















// Generated on 07/24/2016 18:35:45
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class AllianceInsiderInfoMessage : NetworkMessage
{

public const uint Id = 6403;
public uint MessageId
{
    get { return Id; }
}

public Types.AllianceFactSheetInformations allianceInfos;
        public Types.GuildInsiderFactSheetInformations[] guilds;
        public Types.PrismSubareaEmptyInfo[] prisms;
        

public AllianceInsiderInfoMessage()
{
}

public AllianceInsiderInfoMessage(Types.AllianceFactSheetInformations allianceInfos, Types.GuildInsiderFactSheetInformations[] guilds, Types.PrismSubareaEmptyInfo[] prisms)
        {
            this.allianceInfos = allianceInfos;
            this.guilds = guilds;
            this.prisms = prisms;
        }
        

public void Serialize(IDataWriter writer)
{

allianceInfos.Serialize(writer);
            writer.WriteUShort((ushort)guilds.Length);
            foreach (var entry in guilds)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)prisms.Length);
            foreach (var entry in prisms)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

allianceInfos = new Types.AllianceFactSheetInformations();
            allianceInfos.Deserialize(reader);
            var limit = reader.ReadUShort();
            guilds = new Types.GuildInsiderFactSheetInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guilds[i] = new Types.GuildInsiderFactSheetInformations();
                 guilds[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            prisms = new Types.PrismSubareaEmptyInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 prisms[i] = ProtocolTypeManager.GetInstance<Types.PrismSubareaEmptyInfo>(reader.ReadShort());
                 prisms[i].Deserialize(reader);
            }
            

}


}


}