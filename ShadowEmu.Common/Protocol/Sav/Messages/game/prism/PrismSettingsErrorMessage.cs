


















// Generated on 07/24/2016 18:36:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PrismSettingsErrorMessage : NetworkMessage
{

public const uint Id = 6442;
public uint MessageId
{
    get { return Id; }
}



public PrismSettingsErrorMessage()
{
}



public void Serialize(IDataWriter writer)
{



}

public void Deserialize(IDataReader reader)
{



}


}


}