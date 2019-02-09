


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class FinishMoveInformations : NetworkType
{

public const short Id = 506;
public virtual short TypeId
{
    get { return Id; }
}

public int finishMoveId;
        public bool finishMoveState;
        

public FinishMoveInformations()
{
}

public FinishMoveInformations(int finishMoveId, bool finishMoveState)
        {
            this.finishMoveId = finishMoveId;
            this.finishMoveState = finishMoveState;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteInt(finishMoveId);
            writer.WriteBoolean(finishMoveState);
            

}

public virtual void Deserialize(IDataReader reader)
{

finishMoveId = reader.ReadInt();
            if (finishMoveId < 0)
                throw new System.Exception("Forbidden value on finishMoveId = " + finishMoveId + ", it doesn't respect the following condition : finishMoveId < 0");
            finishMoveState = reader.ReadBoolean();
            

}


}


}