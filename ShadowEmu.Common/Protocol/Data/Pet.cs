

















// Generated on 01/12/2017 03:53:13
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("Pets")]
    
public class Pet : IDataObject
{

public const String MODULE = "Pets";
        public int id;
        public List<int> foodItems;
        public List<int> foodTypes;
        public int minDurationBeforeMeal;
        public int maxDurationBeforeMeal;
        public List<EffectInstance> possibleEffects;
        

}

}