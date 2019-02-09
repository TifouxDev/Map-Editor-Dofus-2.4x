


















// Generated on 07/24/2016 18:36:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class StatisticData : NetworkType
{

public const short Id = 484;
public virtual short TypeId
{
    get { return Id; }
}



public StatisticData()
{
}



public virtual void Serialize(IDataWriter writer)
{



}

public virtual void Deserialize(IDataReader reader)
{



}


}


}