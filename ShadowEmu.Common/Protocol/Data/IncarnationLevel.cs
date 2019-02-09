

















// Generated on 01/12/2017 03:53:12
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("IncarnationLevels")]
    
public class IncarnationLevel : IDataObject
{

public const String MODULE = "IncarnationLevels";
        public int id;
        public int incarnationId;
        public int level;
        public uint requiredXp;
        

}

}