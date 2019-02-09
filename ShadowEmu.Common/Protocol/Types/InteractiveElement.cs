


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class InteractiveElement : NetworkType
{

public const short Id = 80;
public virtual short TypeId
{
    get { return Id; }
}

public int elementId;
        public int elementTypeId;
        public Types.InteractiveElementSkill[] enabledSkills;
        public Types.InteractiveElementSkill[] disabledSkills;
        public bool onCurrentMap;
        

public InteractiveElement()
{
}

public InteractiveElement(int elementId, int elementTypeId, Types.InteractiveElementSkill[] enabledSkills, Types.InteractiveElementSkill[] disabledSkills, bool onCurrentMap)
        {
            this.elementId = elementId;
            this.elementTypeId = elementTypeId;
            this.enabledSkills = enabledSkills;
            this.disabledSkills = disabledSkills;
            this.onCurrentMap = onCurrentMap;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteInt(elementId);
            writer.WriteInt(elementTypeId);
            writer.WriteUShort((ushort)enabledSkills.Length);
            foreach (var entry in enabledSkills)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)disabledSkills.Length);
            foreach (var entry in disabledSkills)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteBoolean(onCurrentMap);
            

}

public virtual void Deserialize(IDataReader reader)
{

elementId = reader.ReadInt();
            if (elementId < 0)
                throw new System.Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
            elementTypeId = reader.ReadInt();
            var limit = reader.ReadUShort();
            enabledSkills = new Types.InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                 enabledSkills[i] = ProtocolTypeManager.GetInstance<Types.InteractiveElementSkill>(reader.ReadShort());
                 enabledSkills[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            disabledSkills = new Types.InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                 disabledSkills[i] = ProtocolTypeManager.GetInstance<Types.InteractiveElementSkill>(reader.ReadShort());
                 disabledSkills[i].Deserialize(reader);
            }
            onCurrentMap = reader.ReadBoolean();
            

}


}


}