

















// Generated on 07/24/2016 18:36:10
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("Challenge")]
    
public class Challenge : IDataObject
{

public const String MODULE = "Challenge";
        public int id;
        public uint nameId;
        public uint descriptionId;
        public Boolean dareAvailable;
        public List<uint> incompatibleChallenges;
        

}

}