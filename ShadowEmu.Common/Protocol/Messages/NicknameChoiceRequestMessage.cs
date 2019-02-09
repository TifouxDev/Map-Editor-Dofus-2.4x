


















// Generated on 01/12/2017 03:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class NicknameChoiceRequestMessage : NetworkMessage
{

public const uint Id = 5639;
public uint MessageId
{
    get { return Id; }
}

public string nickname;
        

public NicknameChoiceRequestMessage()
{
}

public NicknameChoiceRequestMessage(string nickname)
        {
            this.nickname = nickname;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(nickname);
            

}

public void Deserialize(IDataReader reader)
{

nickname = reader.ReadUTF();
            

}


}


}