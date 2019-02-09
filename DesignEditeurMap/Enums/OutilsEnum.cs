using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Enums
{
    public enum OutilsEnum
    {
        CellMove,
        CellWalkable,
        CellWalkableInRP,
        CellWalkableInFight,
        Paint,
        TriggerChangeMap,
        Selection,
        Unknow,
    }

    public enum TypeChangeMapEnum
    {
        Top,
        Bot,
        Left,
        Right,
        Unknow,

    }
}
