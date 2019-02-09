


















// Generated on 07/24/2016 18:35:44
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

    public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
    {

        public const uint Id = 6118;
        public uint MessageId
        {
            get { return Id; }
        }

        public double targetId;
        public short destinationCellId;
        public sbyte critical;
        public bool silentCast;
        public bool verboseCast;


        public AbstractGameActionFightTargetedAbilityMessage()
        {
        }

        public AbstractGameActionFightTargetedAbilityMessage(uint actionId, double sourceId, double targetId, short destinationCellId, sbyte critical, bool silentCast, bool verboseCast)
                 : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.destinationCellId = destinationCellId;
            this.critical = critical;
            this.silentCast = silentCast;
            this.verboseCast = verboseCast;
        }


        public void Serialize(IDataWriter writer)
        {

            base.Serialize(writer);

            byte box = 0;
            box = BooleanByteWrapper.SetFlag(box, 0, silentCast);
            box = BooleanByteWrapper.SetFlag(box, 1, verboseCast);
            writer.WriteByte(box);
            writer.WriteDouble(targetId);
            writer.WriteShort(destinationCellId);
            writer.WriteSByte(critical);
        }

        public void Deserialize(IDataReader reader)
        {

            base.Deserialize(reader);
            targetId = reader.ReadDouble();
            if (targetId < -9.007199254740992E15 || targetId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on targetId = " + targetId + ", it doesn't respect the following condition : targetId < -9.007199254740992E15 || targetId > 9.007199254740992E15");
            destinationCellId = reader.ReadShort();
            if (destinationCellId < -1 || destinationCellId > 559)
                throw new System.Exception("Forbidden value on destinationCellId = " + destinationCellId + ", it doesn't respect the following condition : destinationCellId < -1 || destinationCellId > 559");
            critical = reader.ReadSByte();
            if (critical < 0)
                throw new System.Exception("Forbidden value on critical = " + critical + ", it doesn't respect the following condition : critical < 0");
            silentCast = reader.ReadBoolean();


        }


    }


}