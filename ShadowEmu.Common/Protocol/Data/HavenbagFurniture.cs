

















// Generated on 01/12/2017 03:53:11
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("HavenbagFurnitures")]
    
public class HavenbagFurniture : IDataObject
{

public const String MODULE = "HavenbagFurnitures";
        public int typeId;
        public int themeId;
        public int elementId;
        public int color;
        public int skillId;
        public int layerId;
        public Boolean blocksMovement;
        public Boolean isStackable;
        public uint cellsWidth;
        public uint cellsHeight;
        public uint order;
        

}

}