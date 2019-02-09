

















// Generated on 01/12/2017 03:53:13
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("SpeakingItemsTriggers")]
    
public class SpeakingItemsTrigger : IDataObject
{

public const String MODULE = "SpeakingItemsTriggers";
        public int triggersId;
        public List<int> textIds;
        public List<int> states;
        

}

}