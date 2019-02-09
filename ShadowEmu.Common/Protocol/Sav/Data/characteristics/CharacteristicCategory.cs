

















// Generated on 07/24/2016 18:36:10
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("CharacteristicCategories")]
    
public class CharacteristicCategory : IDataObject
{

public const String MODULE = "CharacteristicCategories";
        public int id;
        public uint nameId;
        public int order;
        public List<uint> characteristicIds;
        

}

}