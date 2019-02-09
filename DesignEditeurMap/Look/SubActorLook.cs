using DesignEditeurMap.Look;
using ShadowEmu.Common.Protocol.Enums;
using ShadowEmu.Common.Protocol.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.World.Game.Characters.Look
{
    public class SubActorLook
    {
        private SubEntityBindingPointCategoryEnum m_bindingCategory;
        private sbyte m_bindingIndex;
        private ActorLook m_look;
        public sbyte BindingIndex
        {
            get
            {
                return this.m_bindingIndex;
            }
            set
            {
                this.m_bindingIndex = value;
            }
        }
        public SubEntityBindingPointCategoryEnum BindingCategory
        {
            get
            {
                return this.m_bindingCategory;
            }
            set
            {
                this.m_bindingCategory = value;
            }
        }

        public SubActorLook(sbyte index, SubEntityBindingPointCategoryEnum category, ActorLook look)
        {
            this.m_bindingIndex = index;
            this.m_bindingCategory = category;
            this.m_look = look;

        }
        public ActorLook Look
        {
            get { return m_look; }
        }
        public override string ToString()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append((sbyte)this.BindingCategory);
            stringBuilder.Append("@");
            stringBuilder.Append(this.BindingIndex);
            stringBuilder.Append("=");
            stringBuilder.Append(this.Look);
            return stringBuilder.ToString();
        }

        public SubEntity GetSubEntity()
        {
            return null;
        }
    }
}
