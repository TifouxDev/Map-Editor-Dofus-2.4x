


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class ObjectEffectDice : ObjectEffect
{

public const short Id = 73;
public override short TypeId
{
    get { return Id; }
}

public uint diceNum;
        public uint diceSide;
        public uint diceConst;
        

public ObjectEffectDice()
{
}

public ObjectEffectDice(uint actionId, uint diceNum, uint diceSide, uint diceConst)
         : base(actionId)
        {
            this.diceNum = diceNum;
            this.diceSide = diceSide;
            this.diceConst = diceConst;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarShort((int)diceNum);
            writer.WriteVarShort((int)diceSide);
            writer.WriteVarShort((int)diceConst);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            diceNum = reader.ReadVarUhShort();
            if (diceNum < 0)
                throw new System.Exception("Forbidden value on diceNum = " + diceNum + ", it doesn't respect the following condition : diceNum < 0");
            diceSide = reader.ReadVarUhShort();
            if (diceSide < 0)
                throw new System.Exception("Forbidden value on diceSide = " + diceSide + ", it doesn't respect the following condition : diceSide < 0");
            diceConst = reader.ReadVarUhShort();
            if (diceConst < 0)
                throw new System.Exception("Forbidden value on diceConst = " + diceConst + ", it doesn't respect the following condition : diceConst < 0");
            

}


}


}