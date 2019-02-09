

















// Generated on 01/12/2017 03:53:14
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("MonsterRaces")]
    
public class MonsterRace : IDataObject
{

public const String MODULE = "MonsterRaces";
        public int id;
        public int superRaceId;
        public uint nameId;
        public List<uint> monsters;
        

}

}