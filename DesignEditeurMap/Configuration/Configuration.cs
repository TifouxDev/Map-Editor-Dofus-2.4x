using DesignEditeurMap.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Configuration
{
    public class Configuration : DataManager<Configuration>
    {
        public string TexturePath;
        public Configuration()
        {
            TexturePath = AppDomain.CurrentDomain.BaseDirectory + @"\data\img\";
        }
    }
}
