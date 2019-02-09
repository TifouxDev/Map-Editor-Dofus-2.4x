using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Cellule
{
    public class MapCell
    {

        public int Id;
        public int RealID;
        private Vector2f[] m_points;
        public int X, Y;
        public MapPoint Point;
        public MapCell(int id, int x, int y)
        {
            Id = id;
            Active = true;
            X = x;
            Y = y;
          
        }
        public MapCell(int id)
        {
            Id = id;
            Active = true;
         
        }
        public SFML.Graphics.CircleShape Cercle = new CircleShape();
        public Vector2f[] Points
        {
            get { return m_points; }
            set
            {
                m_points = value;
                List<Point> points = new List<Point>();
                foreach (var point in value)
                {
                    points.Add(new Point((int)point.X, (int)point.Y));
                }
                RectanglePoints = points.ToArray();
                RefreshBounds();
                Point = new MapPoint((int)Center.X, (int)Center.Y);
            }
        }

        public bool Active
        {
            get;
            set;
        }


        public Vector2f Center
        {
            get { return new Vector2f((Points[0].X + Points[2].X) / 2, (Points[1].Y + Points[3].Y) / 2); }
        }

        public float Height
        {
            get { return Points[3].Y - Points[1].Y; }
        }

        public float Width
        {
            get
            {
                return Points[2].X - Points[0].X;
            }
        }


        public Rectangle Rectangle
        {
            get;
            private set;
        }

        public Point[] RectanglePoints
        {
            get;
            set;
        }
        public void RefreshBounds()
        {

            int x = RectanglePoints.Min(entry => entry.X);
            int y = RectanglePoints.Min(entry => entry.Y);

            int width = RectanglePoints.Max(entry => entry.X) - x;
            int height = RectanglePoints.Max(entry => entry.Y) - y;

            Rectangle = new Rectangle(x, y, width, height);

        }

        public bool IsInRectange(Rectangle rect)
        {
            return Rectangle.IntersectsWith(rect);
        }

        public ConvexShape BorderMovTrue = null;
        public ConvexShape BorderMovFalse = null;

        public ConvexShape BorderTopChangeTrue = null;
        public ConvexShape BorderTopChangeFalse = null;


        public void DrawCellMove(RenderWindow window, bool state)
        {
            if(state)
            {
                if(BorderMovTrue == null)
                {
                    ConvexShape polygon = new ConvexShape();
                    polygon.SetPointCount(4);
                    polygon.SetPoint(0, new Vector2f(this.Points[0].X, this.Points[0].Y));
                    polygon.SetPoint(1, new Vector2f(this.Points[1].X, this.Points[1].Y));
                    polygon.SetPoint(2, new Vector2f(this.Points[2].X, this.Points[2].Y));
                    polygon.SetPoint(3, new Vector2f(this.Points[3].X, this.Points[3].Y));
                    polygon.FillColor = SFML.Graphics.Color.Transparent;
                    polygon.OutlineColor = SFML.Graphics.Color.Red;
                    polygon.FillColor = new SFML.Graphics.Color(17, 76, 7, 80);

                    polygon.OutlineThickness = 1;

                    BorderMovTrue = polygon;
                }
                window.Draw(BorderMovTrue);
            }
            else
            {
                if (BorderMovFalse == null)
                {
                    ConvexShape polygon = new ConvexShape();
                    polygon.SetPointCount(4);
                    polygon.SetPoint(0, new Vector2f(this.Points[0].X, this.Points[0].Y));
                    polygon.SetPoint(1, new Vector2f(this.Points[1].X, this.Points[1].Y));
                    polygon.SetPoint(2, new Vector2f(this.Points[2].X, this.Points[2].Y));
                    polygon.SetPoint(3, new Vector2f(this.Points[3].X, this.Points[3].Y));
                    polygon.FillColor = SFML.Graphics.Color.Transparent;
                    polygon.OutlineColor = SFML.Graphics.Color.Black;
                    polygon.FillColor = new SFML.Graphics.Color(255, 0, 15, 80);

                    polygon.OutlineThickness = 1;

                    BorderMovFalse = polygon;
                }
                window.Draw(BorderMovFalse);
            }
        }



        private ConvexShape m_PolygonneCell = null;
        public void DrawColorCell(RenderWindow window,SFML.Graphics.Color fillColor, SFML.Graphics.Color outlineColor, int outlineThickness = 1)
        {
            if(m_PolygonneCell == null)
            {
                ConvexShape polygon = new ConvexShape();
                polygon.SetPointCount(4);
                polygon.SetPoint(0, new Vector2f(this.Points[0].X, this.Points[0].Y));
                polygon.SetPoint(1, new Vector2f(this.Points[1].X, this.Points[1].Y));
                polygon.SetPoint(2, new Vector2f(this.Points[2].X, this.Points[2].Y));
                polygon.SetPoint(3, new Vector2f(this.Points[3].X, this.Points[3].Y));
              
                polygon.OutlineThickness = outlineThickness;

                m_PolygonneCell = polygon;
            }
            m_PolygonneCell.OutlineColor = outlineColor;
            m_PolygonneCell.FillColor = fillColor;
            m_PolygonneCell.OutlineThickness = outlineThickness;
            window.Draw(m_PolygonneCell);
        }












        public void DrawBorder(RenderWindow window, SFML.Graphics.Color fillColor, SFML.Graphics.Color outLineColor, int outLineSize = 1)
        {
            ConvexShape polygon = new ConvexShape();
            polygon.SetPointCount(4);
            polygon.SetPoint(0, new Vector2f(this.Points[0].X, this.Points[0].Y));
            polygon.SetPoint(1, new Vector2f(this.Points[1].X, this.Points[1].Y));
            polygon.SetPoint(2, new Vector2f(this.Points[2].X, this.Points[2].Y));
            polygon.SetPoint(3, new Vector2f(this.Points[3].X, this.Points[3].Y));
            polygon.FillColor = SFML.Graphics.Color.Transparent;
            polygon.OutlineColor = outLineColor;
            polygon.FillColor = fillColor;
        
            polygon.OutlineThickness = outLineSize;
            window.Draw(polygon);
        }



        public void DrawCellMapChangeTopMove(RenderWindow window, bool top)
        {
            if (top)
            {
                if (BorderTopChangeTrue == null)
                {
                    ConvexShape polygon = new ConvexShape();
                    polygon.SetPointCount(4);
                    polygon.SetPoint(0, new Vector2f(this.Points[0].X, this.Points[0].Y));
                    polygon.SetPoint(1, new Vector2f(this.Points[1].X, this.Points[1].Y));
                    polygon.SetPoint(2, new Vector2f(this.Points[2].X, this.Points[2].Y));
                    polygon.SetPoint(3, new Vector2f(this.Points[3].X, this.Points[3].Y));
                    polygon.FillColor = SFML.Graphics.Color.Transparent;
                    polygon.OutlineColor = SFML.Graphics.Color.White;
                    polygon.FillColor = new SFML.Graphics.Color(17, 76, 7, 80);

                    polygon.OutlineThickness = 1;

                    BorderTopChangeTrue = polygon;
                }
                window.Draw(BorderTopChangeTrue);
            }
            else
            {
                if (BorderTopChangeFalse == null)
                {
                    ConvexShape polygon = new ConvexShape();
                    polygon.SetPointCount(4);
                    polygon.SetPoint(0, new Vector2f(this.Points[0].X, this.Points[0].Y));
                    polygon.SetPoint(1, new Vector2f(this.Points[1].X, this.Points[1].Y));
                    polygon.SetPoint(2, new Vector2f(this.Points[2].X, this.Points[2].Y));
                    polygon.SetPoint(3, new Vector2f(this.Points[3].X, this.Points[3].Y));
                    polygon.FillColor = SFML.Graphics.Color.Transparent;
                    polygon.OutlineColor = SFML.Graphics.Color.White;
                    polygon.FillColor = new SFML.Graphics.Color(255, 0, 15, 80);

                    polygon.OutlineThickness = 1;

                    BorderTopChangeFalse = polygon;
                }
                window.Draw(BorderTopChangeFalse);
            }
        }


        public void DrawGridCell(RenderWindow window, SFML.Graphics.Color fillColor, SFML.Graphics.Color outLineColor, int outLineSize = 1)
        {


            if(m_PolygonneCell == null)
            {
                ConvexShape polygon = new ConvexShape();
                polygon.SetPointCount(4);
                polygon.SetPoint(0, new Vector2f(this.Points[0].X, this.Points[0].Y));
                polygon.SetPoint(1, new Vector2f(this.Points[1].X, this.Points[1].Y));
                polygon.SetPoint(2, new Vector2f(this.Points[2].X, this.Points[2].Y));
                polygon.SetPoint(3, new Vector2f(this.Points[3].X, this.Points[3].Y));
                polygon.FillColor = SFML.Graphics.Color.Transparent;
                polygon.OutlineColor = outLineColor;
                polygon.FillColor = fillColor;

                polygon.OutlineThickness = outLineSize;
                m_PolygonneCell = polygon;
            }
  
            window.Draw(m_PolygonneCell);

        }
    }
}