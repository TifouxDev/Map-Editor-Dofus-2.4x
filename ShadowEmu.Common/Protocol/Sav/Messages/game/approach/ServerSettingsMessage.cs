


















// Generated on 07/24/2016 18:35:46
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
        

public ServerSettingsMessage()
{
}

public ServerSettingsMessage(string lang, sbyte community, sbyte gameType)
        {
            this.lang = lang;
            this.community = community;
            this.gameType = gameType;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(lang);
            writer.WriteSByte(community);
            writer.WriteSByte(gameType);
            

}

public void Deserialize(IDataReader reader)
{

lang = reader.ReadUTF();
            community = reader.ReadSByte();
            if (community < 0)
                throw new System.Exception("Forbidden value on community = " + community + ", it doesn't respect the following condition : community < 0");
            gameType = reader.ReadSByte();
            

}


}


}