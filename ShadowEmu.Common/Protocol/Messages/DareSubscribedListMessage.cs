


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareSubscribedListMessage : NetworkMessage
{

public const uint Id = 6658;
public uint MessageId
{
    get { return Id; }
}

public Types.DareInformations[] daresFixedInfos;
        public Types.DareVersatileInformations[] daresVersatilesInfos;
        

public DareSubscribedListMessage()
{
}

public DareSubscribedListMessage(Types.DareInformations[] daresFixedInfos, Types.DareVersatileInformations[] daresVersatilesInfos)
        {
            this.daresFixedInfos = daresFixedInfos;
            this.daresVersatilesInfos = daresVersatilesInfos;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)daresFixedInfos.Length);
            foreach (var entry in daresFixedInfos)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)daresVersatilesInfos.Length);
            foreach (var entry in daresVersatilesInfos)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            daresFixedInfos = new Types.DareInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 daresFixedInfos[i] = new Types.DareInformations();
                 daresFixedInfos[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            daresVersatilesInfos = new Types.DareVersatileInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 daresVersatilesInfos[i] = new Types.DareVersatileInformations();
                 daresVersatilesInfos[i].Deserialize(reader);
            }
            

}


}


}