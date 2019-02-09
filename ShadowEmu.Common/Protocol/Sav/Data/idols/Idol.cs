

















// Generated on 07/24/2016 18:36:11
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("Idols")]
    
public class Idol : IDataObject
{

public const String MODULE = "Idols";
        public int id;
        public String description;
        public int categoryId;
        public int itemId;
        public Boolean groupOnly;
        public int spellPairId;
        public int score;
        public int experienceBonus;
        public int dropBonus;
        public List<int> synergyIdolsIds;
        public List<double> synergyIdolsCoeff;
        public List<int> incompatibleMonsters;
        

}

}