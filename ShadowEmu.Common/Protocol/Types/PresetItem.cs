


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class PresetItem : NetworkType
{

public const short Id = 354;
public virtual short TypeId
{
    get { return Id; }
}

public byte position;
        public uint objGid;
        public uint objUid;
        

public PresetItem()
{
}

public PresetItem(byte position, uint objGid, uint objUid)
        {
            this.position = position;
            this.objGid = objGid;
            this.objUid = objUid;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteByte(position);
            writer.WriteVarShort((int)objGid);
            writer.WriteVarInt((int)objUid);
            

}

public virtual void Deserialize(IDataReader reader)
{

position = reader.ReadByte();
            if (position < 0 || position > 255)
                throw new System.Exception("Forbidden value on position = " + position + ", it doesn't respect the following condition : position < 0 || position > 255");
            objGid = reader.ReadVarUhShort();
            if (objGid < 0)
                throw new System.Exception("Forbidden value on objGid = " + objGid + ", it doesn't respect the following condition : objGid < 0");
            objUid = reader.ReadVarUhInt();
            if (objUid < 0)
                throw new System.Exception("Forbidden value on objUid = " + objUid + ", it doesn't respect the following condition : objUid < 0");
            

}


}


}