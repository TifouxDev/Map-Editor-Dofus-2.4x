

















// Generated on 07/24/2016 18:36:12
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("ActionDescriptions")]
    
public class ActionDescription : IDataObject
{

public const String MODULE = "ActionDescriptions";
        public uint id;
        public uint typeId;
        public String name;
        public uint descriptionId;
        public Boolean trusted;
        public Boolean needInteraction;
        public uint maxUsePerFrame;
        public uint minimalUseInterval;
        public Boolean needConfirmation;
        

}

}