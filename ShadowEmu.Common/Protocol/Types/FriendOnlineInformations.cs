


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class FriendOnlineInformations : FriendInformations
{

public const short Id = 92;
public override short TypeId
{
    get { return Id; }
}

public double playerId;
        public string playerName;
        public byte level;
        public sbyte alignmentSide;
        public sbyte breed;
        public bool sex;
        public Types.GuildInformations guildInfo;
        public uint moodSmileyId;
        public Types.PlayerStatus status;
        

public FriendOnlineInformations()
{
}

public FriendOnlineInformations(int accountId, string accountName, sbyte playerState, uint lastConnection, int achievementPoints, double playerId, string playerName, byte level, sbyte alignmentSide, sbyte breed, bool sex, Types.GuildInformations guildInfo, uint moodSmileyId, Types.PlayerStatus status)
         : base(accountId, accountName, playerState, lastConnection, achievementPoints)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.level = level;
            this.alignmentSide = alignmentSide;
            this.breed = breed;
            this.sex = sex;
            this.guildInfo = guildInfo;
            this.moodSmileyId = moodSmileyId;
            this.status = status;
        }
        

public override void Serialize(IDataWriter writer)
{

            base.Serialize(writer);
            byte byteWrapper = 0;
            BooleanByteWrapper.SetFlag(byteWrapper, 0, sex);
            BooleanByteWrapper.SetFlag(byteWrapper, 1, false);
            writer.WriteByte(byteWrapper);
            writer.WriteVarLong(playerId);
            writer.WriteUTF(playerName);
            writer.WriteByte(level);
            writer.WriteSByte(alignmentSide);
            writer.WriteSByte(breed);
            guildInfo.Serialize(writer);
            writer.WriteVarShort((int)moodSmileyId);
            writer.WriteShort(status.TypeId);
            status.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            playerId = reader.ReadVarUhLong();
            if (playerId < 0 || playerId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0 || playerId > 9.007199254740992E15");
            playerName = reader.ReadUTF();
            level = reader.ReadByte();
            if (level < 0 || level > 206)
                throw new System.Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 206");
            alignmentSide = reader.ReadSByte();
            breed = reader.ReadSByte();
            if (breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Huppermage)
                throw new System.Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Huppermage");
            sex = reader.ReadBoolean();
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
            moodSmileyId = reader.ReadVarUhShort();
            if (moodSmileyId < 0)
                throw new System.Exception("Forbidden value on moodSmileyId = " + moodSmileyId + ", it doesn't respect the following condition : moodSmileyId < 0");
            status = ProtocolTypeManager.GetInstance<Types.PlayerStatus>(reader.ReadShort());
            status.Deserialize(reader);
            

}


}


}