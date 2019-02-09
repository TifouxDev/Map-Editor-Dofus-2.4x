


















// Generated on 01/12/2017 03:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class IdolFightPreparationUpdateMessage : NetworkMessage
{

public const uint Id = 6586;
public uint MessageId
{
    get { return Id; }
}

public sbyte idolSource;
        public Types.Idol[] idols;
        

public IdolFightPreparationUpdateMessage()
{
}

public IdolFightPreparationUpdateMessage(sbyte idolSource, Types.Idol[] idols)
        {
            this.idolSource = idolSource;
            this.idols = idols;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(idolSource);
            writer.WriteUShort((ushort)idols.Length);
            foreach (var entry in idols)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

idolSource = reader.ReadSByte();
            if (idolSource < 0)
                throw new System.Exception("Forbidden value on idolSource = " + idolSource + ", it doesn't respect the following condition : idolSource < 0");
            var limit = reader.ReadUShort();
            idols = new Types.Idol[limit];
            for (int i = 0; i < limit; i++)
            {
                 idols[i] = ProtocolTypeManager.GetInstance<Types.Idol>(reader.ReadShort());
                 idols[i].Deserialize(reader);
            }
            

}


}


}