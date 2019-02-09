


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ServerSettingsMessage : NetworkMessage
{

public const uint Id = 6340;
public uint MessageId
{
    get { return Id; }
}

public string lang;
        public sbyte community;
        public sbyte gameType;
        public uint arenaLeaveBanTime;
        

public ServerSettingsMessage()
{
}

public ServerSettingsMessage(string lang, sbyte community, sbyte gameType, uint arenaLeaveBanTime)
        {
            this.lang = lang;
            this.community = community;
            this.gameType = gameType;
            this.arenaLeaveBanTime = arenaLeaveBanTime;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(lang);
            writer.WriteSByte(community);
            writer.WriteSByte(gameType);
            writer.WriteVarShort((int)arenaLeaveBanTime);
            

}

public void Deserialize(IDataReader reader)
{

lang = reader.ReadUTF();
            community = reader.ReadSByte();
            if (community < 0)
                throw new System.Exception("Forbidden value on community = " + community + ", it doesn't respect the following condition : community < 0");
            gameType = reader.ReadSByte();
            arenaLeaveBanTime = reader.ReadVarUhShort();
            if (arenaLeaveBanTime < 0)
                throw new System.Exception("Forbidden value on arenaLeaveBanTime = " + arenaLeaveBanTime + ", it doesn't respect the following condition : arenaLeaveBanTime < 0");
            

}


}


}