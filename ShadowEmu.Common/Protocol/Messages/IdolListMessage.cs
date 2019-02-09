


















// Generated on 01/12/2017 03:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class IdolListMessage : NetworkMessage
{

public const uint Id = 6585;
public uint MessageId
{
    get { return Id; }
}

public uint[] chosenIdols;
        public uint[] partyChosenIdols;
        public Types.PartyIdol[] partyIdols;
        

public IdolListMessage()
{
}

public IdolListMessage(uint[] chosenIdols, uint[] partyChosenIdols, Types.PartyIdol[] partyIdols)
        {
            this.chosenIdols = chosenIdols;
            this.partyChosenIdols = partyChosenIdols;
            this.partyIdols = partyIdols;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)chosenIdols.Length);
            foreach (var entry in chosenIdols)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteUShort((ushort)partyChosenIdols.Length);
            foreach (var entry in partyChosenIdols)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteUShort((ushort)partyIdols.Length);
            foreach (var entry in partyIdols)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            chosenIdols = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 chosenIdols[i] = reader.ReadVarUhShort();
            }
            limit = reader.ReadUShort();
            partyChosenIdols = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 partyChosenIdols[i] = reader.ReadVarUhShort();
            }
            limit = reader.ReadUShort();
            partyIdols = new Types.PartyIdol[limit];
            for (int i = 0; i < limit; i++)
            {
                 partyIdols[i] = ProtocolTypeManager.GetInstance<Types.PartyIdol>(reader.ReadShort());
                 partyIdols[i].Deserialize(reader);
            }
            

}


}


}