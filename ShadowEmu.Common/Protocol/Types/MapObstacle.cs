


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class MapObstacle : NetworkType
{

public const short Id = 200;
public virtual short TypeId
{
    get { return Id; }
}

public uint obstacleCellId;
        public sbyte state;
        

public MapObstacle()
{
}

public MapObstacle(uint obstacleCellId, sbyte state)
        {
            this.obstacleCellId = obstacleCellId;
            this.state = state;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)obstacleCellId);
            writer.WriteSByte(state);
            

}

public virtual void Deserialize(IDataReader reader)
{

obstacleCellId = reader.ReadVarUhShort();
            if (obstacleCellId < 0 || obstacleCellId > 559)
                throw new System.Exception("Forbidden value on obstacleCellId = " + obstacleCellId + ", it doesn't respect the following condition : obstacleCellId < 0 || obstacleCellId > 559");
            state = reader.ReadSByte();
            if (state < 0)
                throw new System.Exception("Forbidden value on state = " + state + ", it doesn't respect the following condition : state < 0");
            

}


}


}