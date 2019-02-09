


















// Generated on 07/24/2016 18:36:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class TitlesAndOrnamentsListMessage : NetworkMessage
{

public const uint Id = 6367;
public uint MessageId
{
    get { return Id; }
}

public uint[] titles;
        public uint[] ornaments;
        public uint activeTitle;
        public uint activeOrnament;
        

public TitlesAndOrnamentsListMessage()
{
}

public TitlesAndOrnamentsListMessage(uint[] titles, uint[] ornaments, uint activeTitle, uint activeOrnament)
        {
            this.titles = titles;
            this.ornaments = ornaments;
            this.activeTitle = activeTitle;
            this.activeOrnament = activeOrnament;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)titles.Length);
            foreach (var entry in titles)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteUShort((ushort)ornaments.Length);
            foreach (var entry in ornaments)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteVarShort((int)activeTitle);
            writer.WriteVarShort((int)activeOrnament);
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            titles = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 titles[i] = reader.ReadVarUhShort();
            }
            limit = reader.ReadUShort();
            ornaments = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 ornaments[i] = reader.ReadVarUhShort();
            }
            activeTitle = reader.ReadVarUhShort();
            if (activeTitle < 0)
                throw new System.Exception("Forbidden value on activeTitle = " + activeTitle + ", it doesn't respect the following condition : activeTitle < 0");
            activeOrnament = reader.ReadVarUhShort();
            if (activeOrnament < 0)
                throw new System.Exception("Forbidden value on activeOrnament = " + activeOrnament + ", it doesn't respect the following condition : activeOrnament < 0");
            

}


}


}