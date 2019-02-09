

















// Generated on 07/24/2016 18:36:12
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