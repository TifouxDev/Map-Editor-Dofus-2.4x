

















// Generated on 01/12/2017 03:53:10
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("AmbientSounds")]
    
public class AmbientSound : PlaylistSound
{

public const int AMBIENT_TYPE_ROLEPLAY = 1;
        public const int AMBIENT_TYPE_AMBIENT = 2;
        public const int AMBIENT_TYPE_FIGHT = 3;
        public const int AMBIENT_TYPE_BOSS = 4;
        public const String MODULE = "AmbientSounds";
        public int criterionId;
        public uint silenceMin;
        public uint silenceMax;
        public int type_id;
        

}

}