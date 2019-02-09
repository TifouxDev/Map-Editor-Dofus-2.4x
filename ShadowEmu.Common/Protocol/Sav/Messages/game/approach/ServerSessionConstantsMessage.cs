


















// Generated on 07/24/2016 18:35:46
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ServerSessionConstantsMessage : NetworkMessage
{

public const uint Id = 6434;
public uint MessageId
{
    get { return Id; }
}

public Types.ServerSessionConstant[] variables;
        

public ServerSessionConstantsMessage()
{
}

public ServerSessionConstantsMessage(Types.ServerSessionConstant[] variables)
        {
            this.variables = variables;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)variables.Length);
            foreach (var entry in variables)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            variables = new Types.ServerSessionConstant[limit];
            for (int i = 0; i < limit; i++)
            {
                 variables[i] = ProtocolTypeManager.GetInstance<Types.ServerSessionConstant>(reader.ReadShort());
                 variables[i].Deserialize(reader);
            }
            

}


}


}