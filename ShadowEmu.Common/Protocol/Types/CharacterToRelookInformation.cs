


















// Generated on 01/12/2017 03:53:07
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