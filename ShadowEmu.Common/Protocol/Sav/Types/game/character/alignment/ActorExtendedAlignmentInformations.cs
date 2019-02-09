


















// Generated on 07/24/2016 18:36:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
{

public const short Id = 202;
public override short TypeId
{
    get { return Id; }
}

public uint honor;
        public uint honorGradeFloor;
        public uint honorNextGradeFloor;
        public sbyte aggressable;
        

public ActorExtendedAlignmentInformations()
{
}

public ActorExtendedAlignmentInformations(sbyte alignmentSide, sbyte alignmentValue, sbyte alignmentGrade, double characterPower, uint honor, uint honorGradeFloor, uint honorNextGradeFloor, sbyte aggressable)
         : base(alignmentSide, alignmentValue, alignmentGrade, characterPower)
        {
            this.honor = honor;
            this.honorGradeFloor = honorGradeFloor;
            this.honorNextGradeFloor = honorNextGradeFloor;
            this.aggressable = aggressable;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarShort((int)honor);
            writer.WriteVarShort((int)honorGradeFloor);
            writer.WriteVarShort((int)honorNextGradeFloor);
            writer.WriteSByte(aggressable);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            honor = reader.ReadVarUhShort();
            if (honor < 0 || honor > 20000)
                throw new System.Exception("Forbidden value on honor = " + honor + ", it doesn't respect the following condition : honor < 0 || honor > 20000");
            honorGradeFloor = reader.ReadVarUhShort();
            if (honorGradeFloor < 0 || honorGradeFloor > 20000)
                throw new System.Exception("Forbidden value on honorGradeFloor = " + honorGradeFloor + ", it doesn't respect the following condition : honorGradeFloor < 0 || honorGradeFloor > 20000");
            honorNextGradeFloor = reader.ReadVarUhShort();
            if (honorNextGradeFloor < 0 || honorNextGradeFloor > 20000)
                throw new System.Exception("Forbidden value on honorNextGradeFloor = " + honorNextGradeFloor + ", it doesn't respect the following condition : honorNextGradeFloor < 0 || honorNextGradeFloor > 20000");
            aggressable = reader.ReadSByte();
            if (aggressable < 0)
                throw new System.Exception("Forbidden value on aggressable = " + aggressable + ", it doesn't respect the following condition : aggressable < 0");
            

}


}


}