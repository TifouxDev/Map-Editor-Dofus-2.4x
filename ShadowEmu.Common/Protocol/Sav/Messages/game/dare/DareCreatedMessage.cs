


















// Generated on 07/24/2016 18:35:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareCreatedMessage : NetworkMessage
{

public const uint Id = 6668;
public uint MessageId
{
    get { return Id; }
}

public Types.DareInformations dareInfos;
        public bool needNotifications;
        

public DareCreatedMessage()
{
}

public DareCreatedMessage(Types.DareInformations dareInfos, bool needNotifications)
        {
            this.dareInfos = dareInfos;
            this.needNotifications = needNotifications;
        }
        

public void Serialize(IDataWriter writer)
{

dareInfos.Serialize(writer);
            writer.WriteBoolean(needNotifications);
            

}

public void Deserialize(IDataReader reader)
{

dareInfos = new Types.DareInformations();
            dareInfos.Deserialize(reader);
            needNotifications = reader.ReadBoolean();
            

}


}


}