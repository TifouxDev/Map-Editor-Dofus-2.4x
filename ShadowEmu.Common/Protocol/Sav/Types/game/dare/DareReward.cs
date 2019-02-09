


















// Generated on 07/24/2016 18:36:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class DareReward : NetworkType
{

public const short Id = 505;
public virtual short TypeId
{
    get { return Id; }
}

public sbyte type;
        public uint monsterId;
        public uint kamas;
        public double dareId;
        

public DareReward()
{
}

public DareReward(sbyte type, uint monsterId, uint kamas, double dareId)
        {
            this.type = type;
            this.monsterId = monsterId;
            this.kamas = kamas;
            this.dareId = dareId;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteSByte(type);
            writer.WriteVarShort((int)monsterId);
            writer.WriteUInt(kamas);
            writer.WriteDouble(dareId);
            

}

public virtual void Deserialize(IDataReader reader)
{

type = reader.ReadSByte();
            if (type < 0)
                throw new System.Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            monsterId = reader.ReadVarUhShort();
            if (monsterId < 0)
                throw new System.Exception("Forbidden value on monsterId = " + monsterId + ", it doesn't respect the following condition : monsterId < 0");
            kamas = reader.ReadUInt();
            if (kamas < 0 || kamas > 4.294967295E9)
                throw new System.Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0 || kamas > 4.294967295E9");
            dareId = reader.ReadDouble();
            if (dareId < 0 || dareId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on dareId = " + dareId + ", it doesn't respect the following condition : dareId < 0 || dareId > 9.007199254740992E15");
            

}


}


}