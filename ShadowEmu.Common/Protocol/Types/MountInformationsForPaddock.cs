


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class MountInformationsForPaddock : NetworkType
{

public const short Id = 184;
public virtual short TypeId
{
    get { return Id; }
}

public uint modelId;
        public string name;
        public string ownerName;
        

public MountInformationsForPaddock()
{
}

public MountInformationsForPaddock(uint modelId, string name, string ownerName)
        {
            this.modelId = modelId;
            this.name = name;
            this.ownerName = ownerName;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)modelId);
            writer.WriteUTF(name);
            writer.WriteUTF(ownerName);
            

}

public virtual void Deserialize(IDataReader reader)
{

modelId = reader.ReadVarUhShort();
            if (modelId < 0)
                throw new System.Exception("Forbidden value on modelId = " + modelId + ", it doesn't respect the following condition : modelId < 0");
            name = reader.ReadUTF();
            ownerName = reader.ReadUTF();
            

}


}


}