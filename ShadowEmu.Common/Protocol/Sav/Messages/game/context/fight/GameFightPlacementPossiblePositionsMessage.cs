


















// Generated on 07/24/2016 18:35:49
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

    public class GameFightPlacementPossiblePositionsMessage : NetworkMessage
    {

        public const uint Id = 703;
        public uint MessageId
        {
            get { return Id; }
        }

        public uint[] positionsForChallengers;
        public uint[] positionsForDefenders;
        public sbyte teamNumber;


        public GameFightPlacementPossiblePositionsMessage()
        {
        }

        public GameFightPlacementPossiblePositionsMessage(uint[] positionsForChallengers, uint[] positionsForDefenders, sbyte teamNumber)
        {
            this.positionsForChallengers = positionsForChallengers;
            this.positionsForDefenders = positionsForDefenders;
            this.teamNumber = teamNumber;
        }


        public void Serialize(IDataWriter writer)
        {

            writer.WriteShort((short)positionsForChallengers.Length);
            foreach (var entry in positionsForChallengers)
            {
                writer.WriteVarShort((int)entry);
            }
            writer.WriteShort((short)positionsForDefenders.Length);
            foreach (var entry in positionsForDefenders)
            {
                writer.WriteVarShort((int)entry);
            }
            writer.WriteSByte(teamNumber);


        }

        public void Deserialize(IDataReader reader)
        {

            var limit = reader.ReadUShort();
            positionsForChallengers = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                positionsForChallengers[i] = reader.ReadVarUhShort();
            }
            limit = reader.ReadUShort();
            positionsForDefenders = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                positionsForDefenders[i] = reader.ReadVarUhShort();
            }
            teamNumber = reader.ReadSByte();
            if (teamNumber < 0)
                throw new System.Exception("Forbidden value on teamNumber = " + teamNumber + ", it doesn't respect the following condition : teamNumber < 0");


        }


    }


}