using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.Types
{
    public class PaddockInstancesInformations : PaddockInformations
    {

        public const short Id = 509;
        public virtual short TypeId
        {
            get { return Id; }
        }

        public List<PaddockBuyableInformations> paddocks;


        public PaddockInstancesInformations()
        {
        }

        public PaddockInstancesInformations(uint maxOutdoorMount, uint maxItems, List<PaddockBuyableInformations> paddocks)
            : base(maxOutdoorMount, maxItems)
        {
            this.paddocks = paddocks;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)paddocks.Count);
            foreach (var item in paddocks)
            {
                item.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }


    }
}
