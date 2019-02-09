

















// Generated on 01/12/2017 03:53:15
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("FinishMoves")]
    
public class FinishMove : IDataObject
{

public const String MODULE = "FinishMoves";
        public int id;
        public int duration;
        public Boolean free;
        public uint nameId;
        public int category;
        public int spellLevel;
        

}

}