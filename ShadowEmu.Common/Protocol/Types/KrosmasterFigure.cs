


















// Generated on 01/12/2017 03:53:10
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class KrosmasterFigure : NetworkType
{

public const short Id = 397;
public virtual short TypeId
{
    get { return Id; }
}

public string uid;
        public uint figure;
        public uint pedestal;
        public bool bound;
        

public KrosmasterFigure()
{
}

public KrosmasterFigure(string uid, uint figure, uint pedestal, bool bound)
        {
            this.uid = uid;
            this.figure = figure;
            this.pedestal = pedestal;
            this.bound = bound;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteUTF(uid);
            writer.WriteVarShort((int)figure);
            writer.WriteVarShort((int)pedestal);
            writer.WriteBoolean(bound);
            

}

public virtual void Deserialize(IDataReader reader)
{

uid = reader.ReadUTF();
            figure = reader.ReadVarUhShort();
            if (figure < 0)
                throw new System.Exception("Forbidden value on figure = " + figure + ", it doesn't respect the following condition : figure < 0");
            pedestal = reader.ReadVarUhShort();
            if (pedestal < 0)
                throw new System.Exception("Forbidden value on pedestal = " + pedestal + ", it doesn't respect the following condition : pedestal < 0");
            bound = reader.ReadBoolean();
            

}


}


}