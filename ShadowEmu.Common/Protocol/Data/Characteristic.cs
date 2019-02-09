

















// Generated on 01/12/2017 03:53:11
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("Characteristics")]
    
public class Characteristic : IDataObject
{

public const String MODULE = "Characteristics";
        public int id;
        public String keyword;
        public uint nameId;
        public String asset;
        public int categoryId;
        public Boolean visible;
        public int order;
        public Boolean upgradable;
        

}

}