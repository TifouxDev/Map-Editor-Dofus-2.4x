using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Config
{
    public class Configuration : Attribute
    {
        public string Name;
        public Configuration(string name)
        {
            Name = name;
        }
    }
}
