

















// Generated on 07/24/2016 18:36:10
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

    [D2oClass("Bonuses")]
    public class Bonus : IDataObject
    {

        public const String MODULE = "Bonuses";
        public int id;
        public uint type;
        public int amount;
        public List<int> criterionsIds;


    }

}