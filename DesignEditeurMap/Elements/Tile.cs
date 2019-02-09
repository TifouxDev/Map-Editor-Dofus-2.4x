using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Elements
{
    public class Tile
    {
        public string Name;
        public List<int> Sols = new List<int>();
        public List<int> Objects = new List<int>();

    }
}