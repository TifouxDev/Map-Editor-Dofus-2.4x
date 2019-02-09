
// Generated on 07/24/2016 18:36:12
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Data
{

    [D2oClass("Skills")]

    public class Skill : IDataObject
    {

        public const String MODULE = "Skills";
        public int id;
        public uint nameId;
        public int parentJobId;
        public Boolean isForgemagus;
        public List<int> modifiableItemTypeIds;
        public int gatheredRessourceItem;
        public List<int> craftableItemIds;
        public int interactiveId;
        public String useAnimation;
        public int cursor;
        public int elementActionId;
        public Boolean availableInHouse;
        public uint levelMin;
        public Boolean clientDisplay;

    }

}