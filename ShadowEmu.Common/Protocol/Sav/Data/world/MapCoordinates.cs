

















// Generated on 07/24/2016 18:36:13
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("MapCoordinates")]
    
public class MapCoordinates : IDataObject
{

public const String MODULE = "MapCoordinates";
        public uint compressedCoords;
        public List<int> mapIds;
        

}

}