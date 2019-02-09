


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class PaddockInformations : NetworkType
{

public const short Id = 132;
public virtual short TypeId
{
    get { return Id; }
}

public uint maxOutdoorMount;
        public uint maxItems;
        

public PaddockInformations()
{
}

public PaddockInformations(uint maxOutdoorMount, uint maxItems)
        {
            this.maxOutdoorMount = maxOutdoorMount;
            this.maxItems = maxItems;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)maxOutdoorMount);
            writer.WriteVarShort((int)maxItems);
            

}

public virtual void Deserialize(IDataReader reader)
{

maxOutdoorMount = reader.ReadVarUhShort();
            if (maxOutdoorMount < 0)
                throw new System.Exception("Forbidden value on maxOutdoorMount = " + maxOutdoorMount + ", it doesn't respect the following condition : maxOutdoorMount < 0");
            maxItems = reader.ReadVarUhShort();
            if (maxItems < 0)
                throw new System.Exception("Forbidden value on maxItems = " + maxItems + ", it doesn't respect the following condition : maxItems < 0");
            

}


}


}