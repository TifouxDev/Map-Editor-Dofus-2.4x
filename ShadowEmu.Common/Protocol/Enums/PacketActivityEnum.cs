using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.Enums
{
    public enum PacketActivityEnum
    {
        None = 0,
        RP = 1,
        Fight = 2,
        Exchange = 4,
        Paddock = 8,
        Connexion = 16,
        Zaap = 32,
        FightPrepare = 64,
        AlliancePanel = 128,
        GuildePannel = 256,
        MymycryPannel = 512,
        HavenBag = 1024,
        Shop = 2048,
    }
}
