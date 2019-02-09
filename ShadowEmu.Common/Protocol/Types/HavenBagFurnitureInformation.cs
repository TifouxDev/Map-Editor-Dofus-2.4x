


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class HavenBagFurnitureInformation : NetworkType
{

public const short Id = 498;
public virtual short TypeId
{
    get { return Id; }
}

public uint cellId;
        public int funitureId;
        public sbyte orientation;
        

public HavenBagFurnitureInformation()
{
}

public HavenBagFurnitureInformation(uint cellId, int funitureId, sbyte orientation)
        {
            this.cellId = cellId;
            this.funitureId = funitureId;
            this.orientation = orientation;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)cellId);
            writer.WriteInt(funitureId);
            writer.WriteSByte(orientation);
            

}

public virtual void Deserialize(IDataReader reader)
{

cellId = reader.ReadVarUhShort();
            if (cellId < 0)
                throw new System.Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < 0");
            funitureId = reader.ReadInt();
            orientation = reader.ReadSByte();
            if (orientation < 0)
                throw new System.Exception("Forbidden value on orientation = " + orientation + ", it doesn't respect the following condition : orientation < 0");
            

}


}


}