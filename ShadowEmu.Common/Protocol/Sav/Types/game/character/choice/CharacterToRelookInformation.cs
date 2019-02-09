


















// Generated on 07/24/2016 18:36:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class CharacterToRelookInformation : AbstractCharacterToRefurbishInformation
{

public const short Id = 399;
public override short TypeId
{
    get { return Id; }
}



public CharacterToRelookInformation()
{
}

public CharacterToRelookInformation(double id, int[] colors, uint cosmeticId)
         : base(id, colors, cosmeticId)
        {
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            

}


}


}