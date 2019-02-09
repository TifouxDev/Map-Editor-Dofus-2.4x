using DesignEditeurMap.Cellule;
using DesignEditeurMap.Extension;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Manager
{
    public class CellManager : DataManager<CellManager>
    {
        public MapCell[] Cells;

        public CellManager()
        {
            MapHeight = 20;
            MapWidth = 14;
            SetCellNumber();
            Init();
        }

        private int m_mapHeight;

        public int MapHeight
        {
            get { return m_mapHeight; }
            set
            {
                m_mapHeight = value;
                SetCellNumber();
            }
        }

        private int m_mapWidth;

        public int MapWidth
        {
            get { return m_mapWidth; }
            set
            {
                m_mapWidth = value;
                SetCellNumber();
            }
        }

        private void SetCellNumber()
        {
            Cells = new MapCell[2 * MapHeight * MapWidth];
            int d = 1;
            int cellId = 0;
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth * 2; x++)
                {
                    var cell = new MapCell(cellId++);
                    Cells[cell.Id] = cell;
                }
            }
        }

        public void Init()
        {
            BuildMap();
        }
        public int offsetX = 86;
        public int offsetY = 43;

        public void BuildMap()
        {
            int cellId = 0;
            double cellWidth = 86;
            double cellHeight = 43;
            double midCellHeight = cellHeight / 2;
            double midCellWidth = cellWidth / 2;

            for (int y = 0; y < 2 * MapHeight; y++)
            {
                if (y % 2 == 0)
                    for (int x = 0; x < MapWidth; x++)
                    {
                        var left = new Vector2f((int)(offsetX + x * cellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                        var top = new Vector2f((int)(offsetX + x * cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight));
                        var right = new Vector2f((int)(offsetX + x * cellWidth + cellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                        var down = new Vector2f((int)(offsetX + x * cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight + cellHeight));
                        Cells[cellId++].Points = new[] { left, top, right, down };
                    }
                else
                    for (int x = 0; x < MapWidth; x++)
                    {
                        var left = new Vector2f((int)(offsetX + x * cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                        var top = new Vector2f((int)(offsetX + x * cellWidth + cellWidth), (int)(offsetY + y * midCellHeight));
                        var right = new Vector2f((int)(offsetX + x * cellWidth + cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                        var down = new Vector2f((int)(offsetX + x * cellWidth + cellWidth), (int)(offsetY + y * midCellHeight + cellHeight));
                        Cells[cellId++].Points = new[] { left, top, right, down };
                    }
            }
        }

    }
}
