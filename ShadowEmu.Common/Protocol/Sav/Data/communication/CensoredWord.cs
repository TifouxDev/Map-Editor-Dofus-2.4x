

















// Generated on 07/24/2016 18:36:10
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("CensoredWords")]
    
public class CensoredWord : IDataObject
{

public const String MODULE = "CensoredWords";
        public uint id;
        public uint listId;
        public String language;
        public String word;
        public Boolean deepLooking;
        

}

}