
using DesignEditeurMap.Cellule;
using DesignEditeurMap.Editor;
using DesignEditeurMap.Extension;
using SFML.System;
using ShadowEmu.Common.GameData.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Manager
{
    public class CellManagerTest : DataManager<CellManagerTest>
    {
        public MapCell[] Cells;
        public List<List<MapCell>> Maps = new List<List<MapCell>>();
        public int countX = 1;
        public int countY = 1;
        public CellManagerTest()
        {
            MapHeight = 20 * countY;
            MapWidth = 14 * countX;
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

        public MapCell[] mcells;


        private void SetCellNumber()
        {
            mcells = new MapCell[(countX * countY) * 560];

            int cellId = 0;
            int customCell = 0;

            //Maps.Clear();

            for (int axeY = 0; axeY < countY; axeY++)
            {

                for (int axeX = 0; axeX < countX; axeX++)
                {
                    List<MapCell> cells = new List<MapCell>();
                    for (int y = 0; y < 20; y++)
                    {
                        for (int x = 0; x < 14 * 2; x++)
                        {
                            var cell = new MapCell(cellId, x, y);

                            mcells[cell.Id] = cell;
                            mcells[cellId].Id = cellId;
                            customCell++;
                            cellId++;
                            if (customCell > 559)
                                customCell = 0;
                        }
                    }
                }



            }



        }

        public void Init()
        {
            MapHeight = 20 * countY;
            MapWidth = 14 * countX;
            SetCellNumber();
            BuildMap();
            CalculeMaps();
        }

        public void BuildMap()
        {
            int cellId = 0;
            double cellWidth = 86;
            double cellHeight = 43;
            double midCellHeight = cellHeight / 2;
            double midCellWidth = cellWidth / 2;
            CellManager.Instance.offsetX = 586;
            CellManager.Instance.offsetY = 543;
            int offsetX = CellManager.Instance.offsetX - 430;
            int offsetY = CellManager.Instance.offsetY - 258;
            for (int y = 0; y < 2 * MapHeight; y++)
            {
                if (y % 2 == 0)
                    for (int x = 0; x < MapWidth; x++)
                    {
                        var left = new Vector2f((int)(offsetX + x * cellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                        var top = new Vector2f((int)(offsetX + x * cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight));
                        var right = new Vector2f((int)(offsetX + x * cellWidth + cellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                        var down = new Vector2f((int)(offsetX + x * cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight + cellHeight));
                        mcells[cellId++].Points = new[] { left, top, right, down };


                    }
                else
                    for (int x = 0; x < MapWidth; x++)
                    {
                        var left = new Vector2f((int)(offsetX + x * cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                        var top = new Vector2f((int)(offsetX + x * cellWidth + cellWidth), (int)(offsetY + y * midCellHeight));
                        var right = new Vector2f((int)(offsetX + x * cellWidth + cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                        var down = new Vector2f((int)(offsetX + x * cellWidth + cellWidth), (int)(offsetY + y * midCellHeight + cellHeight));
                        mcells[cellId++].Points = new[] { left, top, right, down };
                    }
            }
        }



      private  Object thisLock = new Object();
        private void CalculeMaps()
        {
            int cellId = 0;
            double cellWidth = 86;
            double cellHeight = 43;
            double midCellHeight = cellHeight / 2;
            double midCellWidth = cellWidth / 2;
            CellManager.Instance.offsetX = 586;
            CellManager.Instance.offsetY = 543;
            int offsetX = CellManager.Instance.offsetX - 430;
            int offsetY = CellManager.Instance.offsetY - 258;
            lock(Maps)
            {
                Maps.Clear();

                int map = 0;
                for (int axeY = 1; axeY < countY + 1; axeY++)
                {
                    for (int u = 0; u < countX; u++)
                    {
                        if (Maps.Count - 1 < map)
                            Maps.Add(new List<MapCell>());

                        Maps[map].Clear();
                        var rand = new Random();
                        var color = new SFML.Graphics.Color((byte)(rand.Next(0, 90) % 255), (byte)(rand.Next(0, 90) % 255), (byte)(rand.Next(0, 90) % 255));

                        for (int y = 0; y < 2 * 20; y++)
                        {
                            if (y % 2 == 0)
                                for (int x = 0; x < 14; x++)
                                {
                                    var left = new Vector2f((int)(offsetX + x * cellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                                    var top = new Vector2f((int)(offsetX + x * cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight));
                                    var right = new Vector2f((int)(offsetX + x * cellWidth + cellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                                    var down = new Vector2f((int)(offsetX + x * cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight + cellHeight));
                                    var cell = mcells.FirstOrDefault(current => current != null && current.Points[0] == left && current.Points[1] == top && current.Points[2] == right && current.Points[3] == down);
                                    if (cell != null)
                                    {
                                        cell.RealID = cellId;
                                        Maps[map].Add(cell);
                                    }
                                    cellId++;
                                }
                            else
                                for (int x = 0; x < 14; x++)
                                {
                                    var left = new Vector2f((int)(offsetX + x * cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                                    var top = new Vector2f((int)(offsetX + x * cellWidth + cellWidth), (int)(offsetY + y * midCellHeight));
                                    var right = new Vector2f((int)(offsetX + x * cellWidth + cellWidth + midCellWidth), (int)(offsetY + y * midCellHeight + midCellHeight));
                                    var down = new Vector2f((int)(offsetX + x * cellWidth + cellWidth), (int)(offsetY + y * midCellHeight + cellHeight));
                                    var cell = mcells.FirstOrDefault(current => current != null && current.Points[0] == left && current.Points[1] == top && current.Points[2] == right && current.Points[3] == down);
                                    if (cell != null)
                                    {
                                        cell.RealID = cellId;
                                        Maps[map].Add(cell);
                                    }
                                    cellId++;
                                }
                        }
                        offsetX = (int)Maps[map][13].Center.X + 43;
                        cellId = 0;
                        map++;
                    }
                    offsetX = CellManager.Instance.offsetX - 430;
                    offsetY = (int)((CellManager.Instance.offsetY - 258) + (axeY * 10 * 86));
                }



            }


        }

    }
}
