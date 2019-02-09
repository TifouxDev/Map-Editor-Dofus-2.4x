#region include
using DesignEditeurMap.Cellule;
using DesignEditeurMap.Editor;
using DesignEditeurMap.Enums;
using DesignEditeurMap.Manager;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace DesignEditeurMap.GameLoop
{
    public class GameLoop
    {
        #region Base SFML
        private RenderWindow m_window = null;
        private SFML.Graphics.View m_view = new SFML.Graphics.View();
        private SFML.Graphics.View m_miniMapview = new SFML.Graphics.View();
        #endregion

        private List<MapEditor> m_maps = new List<MapEditor>();

        public RenderWindow Window
        {
            get
            {
                return m_window;
            }
        }

        public List<MapEditor> Maps
        {
            get { return m_maps; }
        }

        public GameLoop(RenderWindow renderer)
        {
            m_window = renderer;
        }

        public bool MakeMap(LayerEnum couche)
        {
            try
            {
                var dumpMaps = new List<MapEditor>(m_maps);
                var current = dumpMaps.FirstOrDefault();


                if (current != null)
                {
                    var t = new System.Drawing.ColorConverter();
                    System.Drawing.Color color = (System.Drawing.Color)t.ConvertFromString(current.BackgroundColor);

                    this.Window.Clear(new SFML.Graphics.Color((byte)color.R, (byte)color.G, (byte)color.B, (byte)current.BackgroundAlpha));
                }
                foreach (var map in m_maps)
                {
                    if(map.Backgrounds != null)
                    {
                        foreach (BackgroundEditor bg in map.Backgrounds)
                        {
                            bg.Sprite.Position = new Vector2f(map.MapCells[0].Center.X + bg.Fixture.OffsetY, map.MapCells[0].Center.Y + bg.Fixture.OffsetY);
                            this.Window.Draw(bg.Sprite);
                        }
                    }
                  
                }

                for (int i = 0; i < 4; i++)
                {
                    var layers = dumpMaps.Select(x => x.Layer.FirstOrDefault(y => y.Type == (LayerEnum)i)).ToArray();
                    Dictionary<int, List<Test>> content = new Dictionary<int, List<Test>>();
                    Dictionary<MapEditor, LayerContent> list = new Dictionary<MapEditor, LayerContent>();

                    foreach (var map in dumpMaps)
                    {
                        if (!map.Layer.Any(x => x.Type == (LayerEnum)i))
                            continue;

                        list.Add(map, map.Layer.First(x => x.Type == (LayerEnum)i));


                        foreach (var layer in map.Layer.First(x => x.Type == (LayerEnum)i).Cells)
                        {
                            var cell = map.MapCells[layer.CELLID];
                            if (content.ContainsKey(cell.Id))
                                content[cell.Id].AddRange(layer.Elements);
                            else
                                content.Add(cell.Id, layer.Elements);
                        }


                        foreach (var value in content.OrderBy(x => x.Key))
                        {

                            foreach (var element in value.Value)
                            {
                                if (element.Sprite == null)
                                    continue;

                                element.Sprite.Position = element.GetPosToDrawTexture();
                                this.Window.Draw(element.Sprite);

                                if (i == (int)couche)
                                {
                                    SFML.Graphics.CircleShape cercle = new CircleShape();
                                    element.Manager.MapCells[element.CellID].Cercle.FillColor = Color.Red;
                                    element.Manager.MapCells[element.CellID].Cercle.Radius = 2;
                                    element.Manager.MapCells[element.CellID].Cercle.Position = element.Manager.MapCells[element.CellID].Center;
                                }


                            }
                        }

                    }

                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public void DrawGrid()
        {
            lock(CellManagerTest.Instance.Maps)
            {
                foreach (var map in CellManagerTest.Instance.Maps)
                {
                    foreach (var cell in map)
                    {
                        if (cell == null)
                            continue;

                        cell.DrawGridCell(m_window, SFML.Graphics.Color.Transparent, SFML.Graphics.Color.White, 1);
                    }

                }
            }
        }
    
        public void DrawBorderMap()
        {
            lock(CellManagerTest.Instance.Maps)
            {
                var dump = new List<List<MapCell>>(CellManagerTest.Instance.Maps);
                foreach (var map in dump)
                {
                    var cell13 = map.First(x => x.RealID == 13);
                    var cell27 = map.First(x => x.RealID == 27);

                    Vertex[] line = new Vertex[4]
                    {
                                new  Vertex(cell13.Points[1], SFML.Graphics.Color.Red),
                                new  Vertex(cell27.Points[2], SFML.Graphics.Color.Red),
                                new  Vertex(cell13.Points[1], SFML.Graphics.Color.Red),
                                new  Vertex(cell13.Points[0], SFML.Graphics.Color.Red),
                    };

                    this.Window.Draw(line, PrimitiveType.Lines);


                    List<int> right = new List<int>() { 55, 27, 83, 111, 139, 167, 195, 223, 251, 279, 307, 335, 363, 391, 419, 447, 475, 503, 531, 559 };

                    foreach (var id in right)
                    {
                        var cell = map.First(x => x.RealID == id);

                        line = new Vertex[4]
                        {
                                new  Vertex(cell.Points[1], SFML.Graphics.Color.Red),
                                new  Vertex(cell.Points[2], SFML.Graphics.Color.Red),
                                new  Vertex(cell.Points[2], SFML.Graphics.Color.Red),
                                new  Vertex(cell.Points[3], SFML.Graphics.Color.Red),
                        };

                        this.Window.Draw(line, PrimitiveType.Lines);
                    }

                    List<int> left = new List<int>() { 56, 0, 84, 28, 112, 168, 196, 280, 504, 532, 476, 448, 224, 140, 252, 308, 336, 364, 420, 392 };
                    foreach (var id in left)
                    {
                        var cell = map.First(x => x.RealID == id);
                        line = new Vertex[4]
                        {
                            new  Vertex(cell.Points[1], SFML.Graphics.Color.Red),
                            new  Vertex(cell.Points[0], SFML.Graphics.Color.Red),
                            new  Vertex(cell.Points[0], SFML.Graphics.Color.Red),
                            new  Vertex(cell.Points[3], SFML.Graphics.Color.Red),
                        };
                        this.Window.Draw(line, PrimitiveType.Lines);
                    }

                    List<int> bot = new List<int>() { 546, 547, 548, 549, 550, 551, 552, 553, 554, 555, 556, 557, 558, 559 };
                    foreach (var id in bot)
                    {
                        var cell = map.First(x => x.RealID == id);

                        line = new Vertex[4]
                        {
                                new  Vertex(cell.Points[0], SFML.Graphics.Color.Red),
                                new  Vertex(cell.Points[3], SFML.Graphics.Color.Red),
                                new  Vertex(cell.Points[3], SFML.Graphics.Color.Red),
                                new  Vertex(cell.Points[2], SFML.Graphics.Color.Red),
                        };

                        this.Window.Draw(line, PrimitiveType.Lines);
                    }

                    for (int i = 0; i < 13; i++)
                    {
                        var cell = map.First(x => x.RealID == i);
                        line = new Vertex[4]
                        {
                                new  Vertex(cell.Points[1], SFML.Graphics.Color.Red),
                                new  Vertex(cell.Points[2], SFML.Graphics.Color.Red),
                                new  Vertex(cell.Points[1], SFML.Graphics.Color.Red),
                                new  Vertex(cell.Points[0], SFML.Graphics.Color.Red),
                        };
                        this.Window.Draw(line, PrimitiveType.Lines);

                    }
                }

            }


        }

        public void SetMaps(List<MapEditor> maps)
        {
            m_maps = maps;
        }

    }
}




