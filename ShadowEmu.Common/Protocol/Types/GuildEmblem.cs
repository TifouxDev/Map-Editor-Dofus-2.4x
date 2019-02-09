


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class GuildEmblem : NetworkType
{

public const short Id = 87;
public virtual short TypeId
{
    get { return Id; }
}

public uint symbolShape;
        public int symbolColor;
        public sbyte backgroundShape;
        public int backgroundColor;
        

public GuildEmblem()
{
}

public GuildEmblem(uint symbolShape, int symbolColor, sbyte backgroundShape, int backgroundColor)
        {
            this.symbolShape = symbolShape;
            this.symbolColor = symbolColor;
            this.backgroundShape = backgroundShape;
            this.backgroundColor = backgroundColor;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)symbolShape);
            writer.WriteInt(symbolColor);
            writer.WriteSByte(backgroundShape);
            writer.WriteInt(backgroundColor);
            

}

public virtual void Deserialize(IDataReader reader)
{

symbolShape = reader.ReadVarUhShort();
            if (symbolShape < 0)
                throw new System.Exception("Forbidden value on symbolShape = " + symbolShape + ", it doesn't respect the following condition : symbolShape < 0");
            symbolColor = reader.ReadInt();
            backgroundShape = reader.ReadSByte();
            if (backgroundShape < 0)
                throw new System.Exception("Forbidden value on backgroundShape = " + backgroundShape + ", it doesn't respect the following condition : backgroundShape < 0");
            backgroundColor = reader.ReadInt();
            

}


}


}