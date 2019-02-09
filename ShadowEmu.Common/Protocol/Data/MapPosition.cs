

















// Generated on 01/12/2017 03:53:15
using System;
using System.Collections.Generic;
using ShadowEmu.Common.GameData.D2O;

namespace ShadowEmu.Common.Protocol.Data
{

    [D2oClass("MapPositions")]

    public class MapPosition : IDataObject
    {

        public const String MODULE = "MapPositions";
        public int id;
        public int posX;
        public int posY;
        public Boolean outdoor;
        public int capabilities;
        public int nameId;
        public Boolean showNameOnFingerpost;
        public List<AmbientSound> sounds;
        public List<List<int>> playlists;
        public int subAreaId;
        public int worldMap;
        public Boolean hasPriorityOnWorldmap;
        public Boolean isUnderWater;

        private const int CAPABILITY_ALLOW_CHALLENGE = 1;
        private const int CAPABILITY_ALLOW_AGGRESSION = 2;
        private const int CAPABILITY_ALLOW_TELEPORT_TO = 4;
        private const int CAPABILITY_ALLOW_TELEPORT_FROM = 8;
        private const int CAPABILITY_ALLOW_EXCHANGES_BETWEEN_PLAYERS = 16;
        private const int CAPABILITY_ALLOW_HUMAN_VENDOR = 32;
        private const int CAPABILITY_ALLOW_COLLECTOR = 64;
        private const int CAPABILITY_ALLOW_SOUL_CAPTURE = 128;
        private const int CAPABILITY_ALLOW_SOUL_SUMMON = 256;
        private const int CAPABILITY_ALLOW_TAVERN_REGEN = 512;
        private const int CAPABILITY_ALLOW_TOMB_MODE = 1024;
        private const int CAPABILITY_ALLOW_TELEPORT_EVERYWHERE = 2048;
        private const int CAPABILITY_ALLOW_FIGHT_CHALLENGES = 4096;

        public bool allowChallenge
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_CHALLENGE) != 0;
            }
        }

        public bool allowAggression
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_AGGRESSION) != 0;
            }
        }

        public bool allowTeleportTo
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_TELEPORT_TO) != 0;
            }
        }

        public bool allowTeleportFrom
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_TELEPORT_FROM) != 0;
            }
        }

        public bool allowExchanges
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_EXCHANGES_BETWEEN_PLAYERS) != 0;
            }
        }

        public bool allowHumanVendor
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_HUMAN_VENDOR) != 0;
            }
        }

        public bool allowTaxCollector
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_COLLECTOR) != 0;
            }
        }

        public bool allowSoulCapture
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_SOUL_CAPTURE) != 0;
            }
        }

        public bool allowSoulSummon
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_SOUL_SUMMON) != 0;
            }
        }

        public bool allowTavernRegen
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_TAVERN_REGEN) != 0;
            }
        }

        public bool allowTombMode
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_TOMB_MODE) != 0;
            }
        }

        public bool allowTeleportEverywhere
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_TELEPORT_EVERYWHERE) != 0;
            }
        }

        public bool allowFightChallenges
        {
            get
            {
                return (this.capabilities & CAPABILITY_ALLOW_FIGHT_CHALLENGES) != 0;
            }
        }
    }

}