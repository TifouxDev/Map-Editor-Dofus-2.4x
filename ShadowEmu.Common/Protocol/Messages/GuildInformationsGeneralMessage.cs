


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GuildInformationsGeneralMessage : NetworkMessage
{

public const uint Id = 5557;
public uint MessageId
{
    get { return Id; }
}

public bool abandonnedPaddock;
        public byte level;
        public double expLevelFloor;
        public double experience;
        public double expNextLevelFloor;
        public int creationDate;
        public uint nbTotalMembers;
        public uint nbConnectedMembers;
        

public GuildInformationsGeneralMessage()
{
}

public GuildInformationsGeneralMessage(bool abandonnedPaddock, byte level, double expLevelFloor, double experience, double expNextLevelFloor, int creationDate, uint nbTotalMembers, uint nbConnectedMembers)
        {
            this.abandonnedPaddock = abandonnedPaddock;
            this.level = level;
            this.expLevelFloor = expLevelFloor;
            this.experience = experience;
            this.expNextLevelFloor = expNextLevelFloor;
            this.creationDate = creationDate;
            this.nbTotalMembers = nbTotalMembers;
            this.nbConnectedMembers = nbConnectedMembers;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(abandonnedPaddock);
            writer.WriteByte(level);
            writer.WriteVarLong(expLevelFloor);
            writer.WriteVarLong(experience);
            writer.WriteVarLong(expNextLevelFloor);
            writer.WriteInt(creationDate);
            writer.WriteVarShort((int)nbTotalMembers);
            writer.WriteVarShort((int)nbConnectedMembers);
            

}

public void Deserialize(IDataReader reader)
{

abandonnedPaddock = reader.ReadBoolean();
            level = reader.ReadByte();
            if (level < 0 || level > 255)
                throw new System.Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 255");
            expLevelFloor = reader.ReadVarUhLong();
            if (expLevelFloor < 0 || expLevelFloor > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on expLevelFloor = " + expLevelFloor + ", it doesn't respect the following condition : expLevelFloor < 0 || expLevelFloor > 9.007199254740992E15");
            experience = reader.ReadVarUhLong();
            if (experience < 0 || experience > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on experience = " + experience + ", it doesn't respect the following condition : experience < 0 || experience > 9.007199254740992E15");
            expNextLevelFloor = reader.ReadVarUhLong();
            if (expNextLevelFloor < 0 || expNextLevelFloor > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on expNextLevelFloor = " + expNextLevelFloor + ", it doesn't respect the following condition : expNextLevelFloor < 0 || expNextLevelFloor > 9.007199254740992E15");
            creationDate = reader.ReadInt();
            if (creationDate < 0)
                throw new System.Exception("Forbidden value on creationDate = " + creationDate + ", it doesn't respect the following condition : creationDate < 0");
            nbTotalMembers = reader.ReadVarUhShort();
            if (nbTotalMembers < 0)
                throw new System.Exception("Forbidden value on nbTotalMembers = " + nbTotalMembers + ", it doesn't respect the following condition : nbTotalMembers < 0");
            nbConnectedMembers = reader.ReadVarUhShort();
            if (nbConnectedMembers < 0)
                throw new System.Exception("Forbidden value on nbConnectedMembers = " + nbConnectedMembers + ", it doesn't respect the following condition : nbConnectedMembers < 0");
            

}


}


}