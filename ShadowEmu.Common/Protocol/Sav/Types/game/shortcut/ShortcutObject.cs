


















// Generated on 07/24/2016 18:36:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class ShortcutObject : Shortcut
{

public const short Id = 367;
public override short TypeId
{
    get { return Id; }
}



public ShortcutObject()
{
}

public ShortcutObject(sbyte slot)
         : base(slot)
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