


















// Generated on 01/12/2017 03:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class SelectedServerRefusedMessage : NetworkMessage
{

public const uint Id = 41;
public uint MessageId
{
    get { return Id; }
}

public uint serverId;
        public sbyte error;
        public sbyte serverStatus;
        

public SelectedServerRefusedMessage()
{
}

public SelectedServerRefusedMessage(uint serverId, sbyte error, sbyte serverStatus)
        {
            this.serverId = serverId;
            this.error = error;
            this.serverStatus = serverStatus;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)serverId);
            writer.WriteSByte(error);
            writer.WriteSByte(serverStatus);
            

}

public void Deserialize(IDataReader reader)
{

serverId = reader.ReadVarUhShort();
            if (serverId < 0)
                throw new System.Exception("Forbidden value on serverId = " + serverId + ", it doesn't respect the following condition : serverId < 0");
            error = reader.ReadSByte();
            if (error < 0)
                throw new System.Exception("Forbidden value on error = " + error + ", it doesn't respect the following condition : error < 0");
            serverStatus = reader.ReadSByte();
            if (serverStatus < 0)
                throw new System.Exception("Forbidden value on serverStatus = " + serverStatus + ", it doesn't respect the following condition : serverStatus < 0");
            

}


}


}