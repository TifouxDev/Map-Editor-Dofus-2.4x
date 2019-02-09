using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Attributes
{

    [AttributeUsage(AttributeTargets.Field)]
    public class Identifier : Attribute
    {
        public Identifier(bool can)
        {
            canModify = can;
        }
        public bool canModify;
    }
}
