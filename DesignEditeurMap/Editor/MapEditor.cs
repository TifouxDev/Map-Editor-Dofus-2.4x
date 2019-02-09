using DesignEditeurMap.Attributes;
using DesignEditeurMap.Cellule;
using DesignEditeurMap.Enums;
using DesignEditeurMap.Look;
using DesignEditeurMap.Manager;
using SFML.Graphics;
using ShadowEmu.Common.GameData.Elements.Test;
using ShadowEmu.Common.GameData.Maps;
using ShadowEmu.Common.GameData.Maps.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Editor
{
    public class MapEditor : ICloneable
    {
        private Map m_map;
        private List<LayerContent> m_layers = new List<LayerContent>();

        [Identifier(true)]
        public int MapID = 0;

        [Identifier(true)]
        public string BackgroundColor = "#000000";

        [Identifier(true)]
        public int BackgroundAlpha = 0;


        [Identifier(true)]
        public int SubAreaId = 0;


        public Map Map
        {
            get { return m_map; }
        }

        public List<LayerContent> Layer
        {
            get { return m_layers; }
        }

        public List<CellData> Cells
        {
            get;
            set;
        }
        public List<MapCell> MapCells
        {
            get;
            set;
        }

        public List<BackgroundEditor> Backgrounds
        {
            get; set;
        }



        public MapEditor(Map map, List<MapCell> mapCells)
        {
            m_map = map;
            MapCells = mapCells;
            Cells = new List<CellData>();
            for (int i = 0; i < 560; i++)
                Cells.Add(new CellData());
            MapID = map.Id;
            SubAreaId = map.SubAreaId;

            PreLoading();
        }

        public MapEditor(Map map, List<MapCell> mapCells, List<CellData> data)
        {
            m_map = map;
            MapCells = mapCells;
            Cells = data;
            MapID = map.Id;
            SubAreaId = map.SubAreaId;
            PreLoading();
        }
        private void PreLoading()
        {
            if (m_map == null)
                return;

            m_layers = new List<LayerContent>();
            foreach (var layer in m_map.Layers.OrderBy(x => x.LayerId))
            {


                LayerContent instanceLayer = null;


                if (!m_layers.Any(x => x.Type == (LayerEnum)layer.LayerId))
                    m_layers.Add(new LayerContent() { Type = (LayerEnum)layer.LayerId });



                instanceLayer = m_layers.First(x => x.Type == (LayerEnum)layer.LayerId);

                // recupere Identifier qui est egale au ElementId que le serveur doit envoyer
                List<int> Identifierlist = (from i in layer.Cells
                                            from y in i.Elements
                                            where y is GraphicalElement && (y as GraphicalElement).Identifier != 0
                                            select (y as GraphicalElement).Identifier).ToList();

                List<int> ElementIdlist = (from i in layer.Cells
                                           from y in i.Elements
                                           where y is GraphicalElement && Identifierlist.Contains((y as GraphicalElement).Identifier)
                                           select (y as GraphicalElement).ElementId).ToList();

                foreach (var cell in layer.Cells.OrderBy(x => x.CellId))
                {

                    foreach (GraphicalElement element in cell.Elements.Where(x => x is GraphicalElement))
                    {
                        var graphicElement = TextureManager.Instance.GetElementData(element.ElementId);

                        if (graphicElement is NormalGraphicalElementData)
                        {
                            NormalGraphicalElementData g = graphicElement as NormalGraphicalElementData;


                            if (g != null && TextureManager.Instance.GetImageGfx(g.Gfx) != null)
                            {

                                var instance = new Test() { CellID = cell.CellId, GraphicalElement = element, Sprite = new Sprite(TextureManager.Instance.GetImageGfx(g.Gfx)), GraphicElement = graphicElement, Manager = this };
                                var test = instance.GetPosToDrawTexture();

                                var currentCell = GetCell(new System.Drawing.Point((int)test.X, (int)test.Y), false, instance.Sprite.TextureRect.Width, instance.Sprite.TextureRect.Height);
                                var d = instance.Sprite.TextureRect;
                                var testg = instance.GraphicalElement.PixelOffsetX;

                                instanceLayer.AddElement(cell.CellId, instance);

                            }
                        }
                        else if (graphicElement is EntityGraphicalElementData)
                        {
                  
                            var d = ActorLook.Parse((graphicElement as EntityGraphicalElementData).EntityLook);
                            if (d.BonesID == 650)
                            {
                                var j = TextureManager.Instance.GetImageGfx(650);

                                var instance = new Test() { CellID = cell.CellId, GraphicalElement = element, Sprite = new Sprite(new Texture(@"E:\Map Editor Britana\DesignEditeurMap\DesignEditeurMap\bin\Debug\data\img\655450.png")), GraphicElement = graphicElement, Manager = this };

                                instanceLayer.AddElement(cell.CellId, instance);
                            }
                        }

                    }
                }
            }
        }
        public MapCell GetCell(System.Drawing.Point p, bool outMap = false, int width = 0, int height = 0)
        {
            var searchRect = new System.Drawing.Rectangle(p.X, p.Y, width, height);
            return MapCells.FirstOrDefault(cell => cell != null && cell.IsInRectange(searchRect) && PointInPoly(p, cell.RectanglePoints));
        }

        public static bool PointInPoly(System.Drawing.Point p, System.Drawing.Point[] poly)
        {
            int xnew, ynew;
            int xold, yold;
            int x1, y1;
            int x2, y2;
            bool inside = false;

            if (poly.Length < 3)
                return false;

            xold = poly[poly.Length - 1].X;
            yold = poly[poly.Length - 1].Y;

            foreach (System.Drawing.Point t in poly)
            {
                xnew = t.X;
                ynew = t.Y;

                if (xnew > xold)
                {
                    x1 = xold;
                    x2 = xnew;
                    y1 = yold;
                    y2 = ynew;
                }
                else
                {
                    x1 = xnew;
                    x2 = xold;
                    y1 = ynew;
                    y2 = yold;
                }

                if ((xnew < p.X) == (p.X <= xold) && (p.Y - (long)y1) * (x2 - x1) < (y2 - (long)y1) * (p.X - x1))
                {
                    inside = !inside;
                }
                xold = xnew;
                yold = ynew;
            }
            return inside;
        }
     
       
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
