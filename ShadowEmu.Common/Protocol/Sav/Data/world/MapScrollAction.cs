

















// Generated on 07/24/2016 18:36:13
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("MapScrollActions")]
    
public class MapScrollAction : IDataObject
{

public const String MODULE = "MapScrollActions";
        public int id;
        public Boolean rightExists;
        public Boolean bottomExists;
        public Boolean leftExists;
        public Boolean topExists;
        public int rightMapId;
        public int bottomMapId;
        public int leftMapId;
        public int topMapId;
        

}

}