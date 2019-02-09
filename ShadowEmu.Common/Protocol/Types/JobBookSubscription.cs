


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class JobBookSubscription : NetworkType
{

public const short Id = 500;
public virtual short TypeId
{
    get { return Id; }
}

public sbyte jobId;
        public bool subscribed;
        

public JobBookSubscription()
{
}

public JobBookSubscription(sbyte jobId, bool subscribed)
        {
            this.jobId = jobId;
            this.subscribed = subscribed;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteSByte(jobId);
            writer.WriteBoolean(subscribed);
            

}

public virtual void Deserialize(IDataReader reader)
{

jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new System.Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            subscribed = reader.ReadBoolean();
            

}


}


}