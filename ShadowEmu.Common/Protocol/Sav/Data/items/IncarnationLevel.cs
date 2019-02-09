

















// Generated on 07/24/2016 18:36:11
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