


















// Generated on 01/12/2017 03:53:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class GameActionMark : NetworkType
{

public const short Id = 351;
public virtual short TypeId
{
    get { return Id; }
}

public double markAuthorId;
        public sbyte markTeamId;
        public int markSpellId;
        public short markSpellLevel;
        public short markId;
        public sbyte markType;
        public short markimpactCell;
        public Types.GameActionMarkedCell[] cells;
        public bool active;
        

public GameActionMark()
{
}

public GameActionMark(double markAuthorId, sbyte markTeamId, int markSpellId, short markSpellLevel, short markId, sbyte markType, short markimpactCell, Types.GameActionMarkedCell[] cells, bool active)
        {
            this.markAuthorId = markAuthorId;
            this.markTeamId = markTeamId;
            this.markSpellId = markSpellId;
            this.markSpellLevel = markSpellLevel;
            this.markId = markId;
            this.markType = markType;
            this.markimpactCell = markimpactCell;
            this.cells = cells;
            this.active = active;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteDouble(markAuthorId);
            writer.WriteSByte(markTeamId);
            writer.WriteInt(markSpellId);
            writer.WriteShort(markSpellLevel);
            writer.WriteShort(markId);
            writer.WriteSByte(markType);
            writer.WriteShort(markimpactCell);
            writer.WriteUShort((ushort)cells.Length);
            foreach (var entry in cells)
            {
                 entry.Serialize(writer);
            }
            writer.WriteBoolean(active);
            

}

public virtual void Deserialize(IDataReader reader)
{

markAuthorId = reader.ReadDouble();
            if (markAuthorId < -9.007199254740992E15 || markAuthorId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on markAuthorId = " + markAuthorId + ", it doesn't respect the following condition : markAuthorId < -9.007199254740992E15 || markAuthorId > 9.007199254740992E15");
            markTeamId = reader.ReadSByte();
            if (markTeamId < 0)
                throw new System.Exception("Forbidden value on markTeamId = " + markTeamId + ", it doesn't respect the following condition : markTeamId < 0");
            markSpellId = reader.ReadInt();
            if (markSpellId < 0)
                throw new System.Exception("Forbidden value on markSpellId = " + markSpellId + ", it doesn't respect the following condition : markSpellId < 0");
            markSpellLevel = reader.ReadShort();
            if (markSpellLevel < 1 || markSpellLevel > 200)
                throw new System.Exception("Forbidden value on markSpellLevel = " + markSpellLevel + ", it doesn't respect the following condition : markSpellLevel < 1 || markSpellLevel > 200");
            markId = reader.ReadShort();
            markType = reader.ReadSByte();
            markimpactCell = reader.ReadShort();
            if (markimpactCell < -1 || markimpactCell > 559)
                throw new System.Exception("Forbidden value on markimpactCell = " + markimpactCell + ", it doesn't respect the following condition : markimpactCell < -1 || markimpactCell > 559");
            var limit = reader.ReadUShort();
            cells = new Types.GameActionMarkedCell[limit];
            for (int i = 0; i < limit; i++)
            {
                 cells[i] = new Types.GameActionMarkedCell();
                 cells[i].Deserialize(reader);
            }
            active = reader.ReadBoolean();
            

}


}


}