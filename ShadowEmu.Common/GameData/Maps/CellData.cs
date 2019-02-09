using ShadowEmu.Common.IO;
using ShadowEmu.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowEmu.Common.GameData.Maps
{
    [Serializable()]
    public class CellData
    {
        private int tmpbytesv9;
        private int tmp;
        public CellData()
        {

  
            Los = false;
            FarmCell = false;
            MapChangeData = 0;
            MoveZone = 0;
            Speed = 0;
       
            Arrow = 0;
            LosMov = 0;
            Mov = true;
            NonWalkableDuringFight = false;
            NonWalkableDuringRP = false;
            TopArrow = false;
            BottomArrow = false;
            RightArrow = false;
            LeftArrow = false;
            IsTopChange = false;
            IsBotChange = false;
            IsLeftChange = false;
            IsRightChange = false;
            Red = false;
            Blue = false;
        }

            public CellData(CellData cell)
        {
            Floor = cell.Floor;
            LosMov = cell.LosMov;
            Los = cell.Los;
            FarmCell = cell.FarmCell;
            MapChangeData = cell.MapChangeData;
            MoveZone = cell.MoveZone;
            Speed = cell.Speed;
            Arrow = cell.Arrow;
            Mov = cell.Mov;
            NonWalkableDuringFight = cell.NonWalkableDuringFight;
            NonWalkableDuringRP = cell.NonWalkableDuringRP;
            TopArrow = cell.TopArrow;
            BottomArrow = cell.BottomArrow;
            RightArrow = cell.RightArrow;
            LeftArrow = cell.LeftArrow;
            Red = cell.Red;
            Blue = cell.Blue;
            IsTopChange = (MapChangeData & 64) > 0 ? true : false;
            IsBotChange = (MapChangeData & 4) > 0 ? true : false;
            IsLeftChange = (MapChangeData & 16) > 0 ? true : false; ;
            IsRightChange = (MapChangeData & 1) > 0 ? true : false;
        }

        private void GenerateTmp()
        {

            var test = "1111111111111";
            test = SetFlag(test, 1, !Mov);
            test = SetFlag(test, 2, NonWalkableDuringFight);
            test = SetFlag(test, 4, NonWalkableDuringRP);

            test = SetFlag(test, 8, !Los);
            test = SetFlag(test, 16, Blue);
            test = SetFlag(test, 32, Red);
            test = SetFlag(test, 64, Visible);
            test = SetFlag(test, 128, FarmCell);
            test = SetFlag(test, 256, HavenbagCell);
            test = SetFlag(test, 512, TopArrow);
            test = SetFlag(test, 1024, BottomArrow);
            test = SetFlag(test, 2048, RightArrow);
            test = SetFlag(test, 4096, LeftArrow);
            tmpbytesv9 = Convert.ToInt16(test, 2);
        }
       
      
        public string SetFlag(string xD, int offset, bool value)
        {

            int index = 0;

            for (int b = 0; b < 300; b++)
            {
                var m = Math.Pow(2, b);
                if (m == offset)
                {
                    index = b;
                    break;
                }
            }
            string lol = "";
            int test = 0;
            for (int i = xD.Length; i > 0; i--)
            {
                if (test == index)
                    lol = Convert.ToInt32(value) + lol;
                else
                    lol = xD[i - 1] + lol;

                test++;
            }

            return lol;

        }
        // Methods
        internal void Init(BigEndianReader Reader, int MapVersion)
        {
            this.Floor = (Reader.ReadByte() * 10);
            if (this.Floor == -1280)
                return;

            if (MapVersion >= 9)
            {
                tmpbytesv9 = Reader.ReadInt16();

                Mov = (tmpbytesv9 & 1) == 0;
                NonWalkableDuringFight = (tmpbytesv9 & 2) != 0;
                NonWalkableDuringRP = (tmpbytesv9 & 4) != 0;
                Los = (tmpbytesv9 & 8) == 0;
                Blue = (tmpbytesv9 & 16) != 0;
                Red = (tmpbytesv9 & 32) != 0;
                Visible = (tmpbytesv9 & 64) != 0;
                FarmCell = (tmpbytesv9 & 128) != 0;

                if (MapVersion >= 10)
                {
                    HavenbagCell = (tmpbytesv9 & 256) != 0;
                    TopArrow = (tmpbytesv9 & 512) != 0;
                    BottomArrow = (tmpbytesv9 & 1024) != 0;
                    RightArrow = (tmpbytesv9 & 2048) != 0;
                    LeftArrow = (tmpbytesv9 & 4096) != 0;
                }
                else
                {
                    TopArrow = (tmpbytesv9 & 256) != 0;
                    BottomArrow = (tmpbytesv9 & 512) != 0;
                    RightArrow = (tmpbytesv9 & 1024) != 0;
                    LeftArrow = (tmpbytesv9 & 2048) != 0;
                }
            }
            else
            {
                LosMov = Reader.ReadSByte();
              
                this.Los = (LosMov & 2) >> 1 == 1;
                this.Mov = (LosMov & 1) == 1;
                this.Visible = (LosMov & 64) >> 6 == 1;
                this.FarmCell = ((LosMov & 32) >> 5) == 1;
                this.Blue = (LosMov & 16) >> 4 == 1;
                this.Red = (LosMov & 8) >> 3 == 1;
                this.NonWalkableDuringRP = (LosMov & 128) >> 7 == 1;
                this.NonWalkableDuringFight = (LosMov & 4) >> 2 == 1;
            }
            this.Speed = Reader.ReadByte();
            this.MapChangeData = Reader.ReadByte();
            if (MapVersion > 5)
            {
                this.MoveZone = Reader.ReadByte();
            }
            if (MapVersion == 8)
            {
                 tmp = Reader.ReadByte();
                Arrow = 15 & tmp;
            }
            IsTopChange = (MapChangeData & 64) > 0 ? true : false;
            IsBotChange = (MapChangeData & 4) > 0 ? true : false;
            IsLeftChange = (MapChangeData & 16) > 0 ? true : false; ;
            IsRightChange = (MapChangeData & 1) > 0 ? true : false;
        }

        public int Id;
        public bool Blue;
        public bool IsShoot;
        public bool FarmCell;
        public bool Los;
        public bool Mov
        {
            get;
            set;
        }
        public bool HavenbagCell;
        public bool NonWalkableDuringFight;
        public bool NonWalkableDuringRP;
        public bool Red;
        public bool Visible;
        public bool TopArrow;
        public bool BottomArrow;
        public bool RightArrow;
        public bool LeftArrow;
        public int Floor;
        public int LosMov;
        public uint MapChangeData;
        public int MoveZone;
        public int Speed;
        public int Arrow = 0;


        public bool IsRightChange
        {
            get;
            set;
         
        }
      
        public bool IsLeftChange
        {
            get;set;

        }
        public bool IsTopChange
        {
            get;set;
        }
        public bool IsBotChange
        {
            get;
            set;

        }
    }
}
