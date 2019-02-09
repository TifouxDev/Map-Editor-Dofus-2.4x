

















// Generated on 01/12/2017 03:53:15
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("Dungeons")]
    
public class Dungeon : IDataObject
{

public const String MODULE = "Dungeons";
        public int id;
        public uint nameId;
        public int optimalPlayerLevel;
        public List<int> mapIds;
        public int entranceMapId;
        public int exitMapId;
        

}

}