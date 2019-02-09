


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class StatedElement : NetworkType
{

public const short Id = 108;
public virtual short TypeId
{
    get { return Id; }
}

public int elementId;
        public uint elementCellId;
        public uint elementState;
        public bool onCurrentMap;
        

public StatedElement()
{
}

public StatedElement(int elementId, uint elementCellId, uint elementState, bool onCurrentMap)
        {
            this.elementId = elementId;
            this.elementCellId = elementCellId;
            this.elementState = elementState;
            this.onCurrentMap = onCurrentMap;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteInt(elementId);
            writer.WriteVarShort((int)elementCellId);
            writer.WriteVarInt((int)elementState);
            writer.WriteBoolean(onCurrentMap);
            

}

public virtual void Deserialize(IDataReader reader)
{

elementId = reader.ReadInt();
            if (elementId < 0)
                throw new System.Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
            elementCellId = reader.ReadVarUhShort();
            if (elementCellId < 0 || elementCellId > 559)
                throw new System.Exception("Forbidden value on elementCellId = " + elementCellId + ", it doesn't respect the following condition : elementCellId < 0 || elementCellId > 559");
            elementState = reader.ReadVarUhInt();
            if (elementState < 0)
                throw new System.Exception("Forbidden value on elementState = " + elementState + ", it doesn't respect the following condition : elementState < 0");
            onCurrentMap = reader.ReadBoolean();
            

}


}


}