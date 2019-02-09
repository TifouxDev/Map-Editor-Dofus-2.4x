


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class PartyIdol : Idol
{

public const short Id = 490;
public override short TypeId
{
    get { return Id; }
}

public double[] ownersIds;
        

public PartyIdol()
{
}

public PartyIdol(uint id, uint xpBonusPercent, uint dropBonusPercent, double[] ownersIds)
         : base(id, xpBonusPercent, dropBonusPercent)
        {
            this.ownersIds = ownersIds;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUShort((ushort)ownersIds.Length);
            foreach (var entry in ownersIds)
            {
                 writer.WriteVarLong(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            var limit = reader.ReadUShort();
            ownersIds = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 ownersIds[i] = reader.ReadVarUhLong();
            }
            

}


}


}