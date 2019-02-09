

















// Generated on 01/12/2017 03:53:15
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("Spells")]
    
public class Spell : IDataObject
{

public const String MODULE = "Spells";
        public int id;
        public uint nameId;
        public uint descriptionId;
        public uint typeId;
        public uint order;
        public String scriptParams;
        public String scriptParamsCritical;
        public int scriptId;
        public int scriptIdCritical;
        public int iconId;
        public List<uint> spellLevels;
        public List<int> variants;
        public Boolean useParamCache = true;
        public Boolean verbose_cast;
        public uint obtentionLevel;
        public Boolean useSpellLevelScaling;
        

}

}