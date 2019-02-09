

















// Generated on 07/24/2016 18:36:12
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

[D2oClass("MonsterDrop")]
    
public class MonsterDrop : IDataObject
{

public uint dropId;
        public int monsterId;
        public int objectId;
        public float percentDropForGrade1;
        public float percentDropForGrade2;
        public float percentDropForGrade3;
        public float percentDropForGrade4;
        public float percentDropForGrade5;
        public int count;
        public Boolean hasCriteria;
        

}

}