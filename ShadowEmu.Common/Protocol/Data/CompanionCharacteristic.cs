

















// Generated on 01/12/2017 03:53:13
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("CompanionCharacteristics")]
    
public class CompanionCharacteristic : IDataObject
{

public const String MODULE = "CompanionCharacteristics";
        public int id;
        public int caracId;
        public int companionId;
        public int order;
        public List<List<float>> statPerLevelRange;
        

}

}