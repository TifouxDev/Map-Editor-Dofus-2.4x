using DesignEditeurMap.Cellule;
using DesignEditeurMap.Constant;
using DesignEditeurMap.Editor;
using DesignEditeurMap.Elements;
using DesignEditeurMap.Enums;
using DesignEditeurMap.Manager;
using DesignEditeurMap.View;
using DesignEditeurMap.View.Map;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using ShadowEmu.Common.GameData.D2O;
using ShadowEmu.Common.GameData.Elements.Test;
using ShadowEmu.Common.GameData.Maps;
using ShadowEmu.Common.GameData.Maps.Elements;
using ShadowEmu.Common.IO;
using ShardowEditor.I18n;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DesignEditeurMap
{

    public partial class Form2 : DockContent
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);

   
        #region Base SFML
        private RenderWindow m_window = null;
        private SFML.Graphics.View m_view = new SFML.Graphics.View();
        private SFML.Graphics.View m_miniMapview = new SFML.Graphics.View();
        #endregion
        #region Mapping
        private List<LayerContent> m_layers = new List<LayerContent>();
        private bool m_viewCase;
        private bool m_viewBorder;
        private OutilsEnum m_outil = OutilsEnum.Unknow;
        private LayerEnum m_layer = LayerEnum.Unknow;
        public TypeChangeMapEnum TypeToChangeMap = TypeChangeMapEnum.Unknow;


        #endregion

        public bool ViewGrid
        {
            get { return m_viewCase; }
            set
            {
                m_viewCase = value;
            }
        }

        public bool ViewBorder
        {
            get { return m_viewBorder; }
            set
            {
                m_viewBorder = value;
            }
        }


        public OutilsEnum Mode
        {
            get { return m_outil; }
            set
            {
                m_outil = value;
            }
        }

        public int CellSelected = 0;

        private System.Drawing.Point m_lastLocation;
        private float gameZoom = 1;
        public bool redraw = true;
        public Project mCurrentProject;


        private GameLoop.GameLoop rendering;

        public Form2()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            m_window = new RenderWindow(pictureBox1.Handle);

            m_window.SetFramerateLimit(5000);

            m_view.Reset(new FloatRect(0f, 0f, pictureBox1.Width, pictureBox1.Height));
            m_view.Zoom(gameZoom);

            m_window.SetView(m_view);

            m_outil = OutilsEnum.Paint;
            LayerSelection(LayerEnum.Ground);
            m_window.MouseMoved += M_window_MouseMoved;
            m_window.KeyPressed += M_window_KeyPressed;
            m_window.MouseButtonPressed += M_window_MouseButtonPressed;
            m_window.MouseButtonReleased += M_window_MouseButtonReleased;
            m_window.MouseWheelMoved += M_window_MouseWheelMoved;

            Open = true;
            mCurrentProject = null;
            rendering = new GameLoop.GameLoop(m_window);

            CellManagerTest.Instance.countX = 1;
            CellManagerTest.Instance.countY = 1;
            CellManagerTest.Instance.Init();

            Task.Factory.StartNew(() => Running());
        }

        System.Windows.Forms.Timer t;
        private void T_Tick(object sender, EventArgs e)
        {
            Running();
        }
        private void Running()
        {
          
            while (m_window.IsOpen)
            {
                EventTest();
                Application.DoEvents();
                if (saveToPng)
                {
                    var img = this.m_window.Capture();
                    var test = img.SaveToFile(AppDomain.CurrentDomain.BaseDirectory + @"\data\rendue\0.png");
                }
                m_window.DispatchEvents();
                m_window.Clear(SFML.Graphics.Color.Transparent);
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Draw(m_window);
                watch.Stop();
                Console.WriteLine("Time: {0}h {1}m {2}s {3}ms", watch.Elapsed.Hours, watch.Elapsed.Minutes, watch.Elapsed.Seconds, watch.Elapsed.Milliseconds);
                Console.WriteLine(" temps : " + watch.Elapsed);
                m_window.Display();
            }



        }

        private void PictureBox1_HandleCreated(object sender, EventArgs e)
        {


        }

        public bool Open = false;



        private void EventTest()
        {
            if (!ApplicationIsActivated())
                return;

            //  Mouse.IsButtonPressed(Mouse.Button.)
            if (m_preview.Sprite != null)
            {

                if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                {
                    m_preview.GraphicalElement.PixelOffsetX -= 1;
                    var lastpreviewLayer = GetCurrentMap().Layer.FirstOrDefault(x => x.Cells.Any(y => y.Elements.Any(z => z.isPreview == true)));
                    if (lastpreviewLayer != null)
                    {
                        var cellPreview = lastpreviewLayer.Cells.FirstOrDefault(x => x.Elements.Any(y => y.isPreview));
                        if (cellPreview != null)
                        {

                            var prevElement = cellPreview.Elements.FirstOrDefault(x => x.isPreview);
                            if (prevElement != null)
                                cellPreview.Elements.Remove(prevElement);


                        }
                    }

                    AddTile(CurrentCellID, GetCurrentMap(), true);
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
                {
                    m_preview.GraphicalElement.PixelOffsetY -= 1;
                    var lastpreviewLayer = GetCurrentMap().Layer.FirstOrDefault(x => x.Cells.Any(y => y.Elements.Any(z => z.isPreview == true)));
                    if (lastpreviewLayer != null)
                    {
                        var cellPreview = lastpreviewLayer.Cells.FirstOrDefault(x => x.Elements.Any(y => y.isPreview));
                        if (cellPreview != null)
                        {

                            var prevElement = cellPreview.Elements.FirstOrDefault(x => x.isPreview);
                            if (prevElement != null)
                                cellPreview.Elements.Remove(prevElement);


                        }
                    }

                    AddTile(CurrentCellID, GetCurrentMap(), true);
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    m_preview.GraphicalElement.PixelOffsetX += 1;
                    var lastpreviewLayer = GetCurrentMap().Layer.FirstOrDefault(x => x.Cells.Any(y => y.Elements.Any(z => z.isPreview == true)));
                    if (lastpreviewLayer != null)
                    {
                        var cellPreview = lastpreviewLayer.Cells.FirstOrDefault(x => x.Elements.Any(y => y.isPreview));
                        if (cellPreview != null)
                        {

                            var prevElement = cellPreview.Elements.FirstOrDefault(x => x.isPreview);
                            if (prevElement != null)
                                cellPreview.Elements.Remove(prevElement);


                        }
                    }

                    AddTile(CurrentCellID, GetCurrentMap(), true);
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    m_preview.GraphicalElement.PixelOffsetY += 1;
                    var lastpreviewLayer = GetCurrentMap().Layer.FirstOrDefault(x => x.Cells.Any(y => y.Elements.Any(z => z.isPreview == true)));
                    if (lastpreviewLayer != null)
                    {
                        var cellPreview = lastpreviewLayer.Cells.FirstOrDefault(x => x.Elements.Any(y => y.isPreview));
                        if (cellPreview != null)
                        {

                            var prevElement = cellPreview.Elements.FirstOrDefault(x => x.isPreview);
                            if (prevElement != null)
                                cellPreview.Elements.Remove(prevElement);


                        }
                    }

                    AddTile(CurrentCellID, GetCurrentMap(), true);
                }

            }
            // Movement de la camera via les touches directionnel.
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                m_view.Move(new Vector2f(0, -32));
                m_window.SetView(m_view);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                m_view.Move(new Vector2f(0, +32));
                m_window.SetView(m_view);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                m_view.Move(new Vector2f(-32, 0));
                m_window.SetView(m_view);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                m_view.Move(new Vector2f(+32, 0));
                m_window.SetView(m_view);
            }


        }

        private void M_window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            lock (thisLock)
            {
                if (!ApplicationIsActivated())
                    return;

                if (m_preview.Sprite != null)
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    {
                        m_preview.GraphicalElement.Altitude += 1;
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.T))
                    {
                        m_preview.GraphicalElement.Altitude -= 1;
                    }
                    if (e.Code == Keyboard.Key.P)
                    {
                        var map = GetCurrentMap();

                        if (map == null)
                            return;

                        for (int i = 0; i < 560; i++)
                            AddTile(i, map);
                    }

                    if (e.Code == Keyboard.Key.R)
                    {

                        if (m_preview.GraphicElement is NormalGraphicalElementData && (m_preview.GraphicElement as NormalGraphicalElementData).HorizontalSymmetry)
                        {
                            var newPreview = TextureManager.Instance.GetRotateElementDataByGfx((m_preview.GraphicElement as NormalGraphicalElementData).Gfx, false);
                            if (newPreview != null)
                            {
                                m_preview.GraphicElement = newPreview;
                                m_preview.GraphicalElement = new GraphicalElement() { Altitude = 0, ElementId = m_preview.GraphicElement.Id, FinalTeint = new ColorMultiplicator(0, 0, 0), Hue = new ColorMultiplicator(0, 0, 0), Identifier = 0, OffsetX = 0, OffsetY = 0, PixelOffsetX = 0, PixelOffsetY = 0, Shadow = new ColorMultiplicator(0, 0, 0) };
                                m_preview.isPreview = true;
                                m_preview.Sprite = new Sprite(TextureManager.Instance.GetImageGfx(newPreview.Gfx));
                            }
                        }
                        else if (m_preview.GraphicElement is NormalGraphicalElementData)

                        {
                            var newPreview = TextureManager.Instance.GetRotateElementDataByGfx((m_preview.GraphicElement as NormalGraphicalElementData).Gfx, true);
                            if (newPreview != null)
                            {
                                m_preview.GraphicElement = newPreview;
                                m_preview.GraphicalElement = new GraphicalElement() { Altitude = 0, ElementId = m_preview.GraphicElement.Id, FinalTeint = new ColorMultiplicator(0, 0, 0), Hue = new ColorMultiplicator(0, 0, 0), Identifier = 0, OffsetX = 0, OffsetY = 0, PixelOffsetX = 0, PixelOffsetY = 0, Shadow = new ColorMultiplicator(0, 0, 0) };
                                m_preview.Sprite = new Sprite(TextureManager.Instance.GetImageGfx(newPreview.Gfx));
                                // m_preview.Sprite.Color = new SFML.Graphics.Color(, 0, 0);
                                m_preview.isPreview = true;
                            }
                        }


                    }

                    if (e.Code == Keyboard.Key.O)
                    {
                        m_view.Zoom(1.1f);
                        m_window.SetView(m_view);
                    }
                    if (e.Code == Keyboard.Key.L)
                    {
                        m_view.Zoom(0.9f);

                        m_window.SetView(m_view);
                    }


                }
            }

        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                m_view.Zoom(1.1f);
            }
            else
            {
                m_view.Zoom(0.9f);
            }
            m_window.SetView(m_view);
        }

        private void M_window_MouseWheelMoved(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                m_view.Zoom(1.1f);
            }
            else
            {
                m_view.Zoom(0.9f);
            }
            m_window.SetView(m_view);
        }

        private void M_window_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            if (IsMouseLeftButtonPressed && Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                m_view.Move(new Vector2f((DefaultOffsetX - e.X) * ((0.50f * (CellManagerTest.Instance.countX * CellManagerTest.Instance.countY))), ((DefaultOffsetY - e.Y) * ((0.50f * (CellManagerTest.Instance.countX * CellManagerTest.Instance.countY))))));
                m_window.SetView(m_view);

                DefaultOffsetX = e.X;
                DefaultOffsetY = e.Y;

            }
        }

        public void RegetPreview()
        {
            // if (m_preview.GraphicElement == null)
            //     return;
            //  if (m_preview.Sprite != null)
            //  return;

            //     SelecteTile(m_preview.GraphicElement.Gfx.ToString());

            pictureBox1.BeginInvoke(new Action(delegate ()
            {
                pictureBox1.Focus();
            }));
        }
        private void M_window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                DefaultOffsetX = e.X;
                DefaultOffsetY = e.Y;

                IsMouseLeftButtonPressed = false;
            }
        }

        private bool IsMouseLeftButtonPressed = false;
        private int DefaultOffsetX = 0;
        public int DefaultOffsetY = 0;

        private void M_window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {

            if (e.Button == Mouse.Button.Left)
            {
                var pos = SFML.Window.Mouse.GetPosition(m_window);
                DefaultOffsetX = pos.X;
                DefaultOffsetY = pos.Y;

                IsMouseLeftButtonPressed = true;
            }

        }

        private List<T> Clone<T>(IEnumerable<T> oldList)
        {
            return new List<T>(oldList);
        }

        private void Draw(RenderWindow window)
        {
            if (m_outil == OutilsEnum.Paint)
                rendering.MakeMap(m_layer);

            if (m_viewBorder && m_viewCase)
            {
                rendering.DrawGrid();
                rendering.DrawBorderMap();

            }
            else if (!m_viewBorder && m_viewCase)
            {
                rendering.DrawGrid();
            }
            else if (m_viewBorder && !m_viewCase)
            {
                rendering.DrawBorderMap();
            }




        }

        private void DrawBorderMap(RenderWindow window)
        {
            foreach (var map in CellManagerTest.Instance.Maps)
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
                window.Draw(line, PrimitiveType.Lines);


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
                    window.Draw(line, PrimitiveType.Lines);
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
                    window.Draw(line, PrimitiveType.Lines);
                }
                //546,547,548,549,550,551,552,553,554,555,556,557,558,559

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
                    window.Draw(line, PrimitiveType.Lines);
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
                    window.Draw(line, PrimitiveType.Lines);

                }
            }


        }

        private void DrawNewGrille()
        {
            foreach (var map in CellManagerTest.Instance.Maps)
            {
                DrawBorderTry2(m_window, map);
            }


        }
        private void DrawBorderTry(RenderWindow render)
        {


        }


        private MapEditor m_lastMap = null;

        public MapEditor GetCurrentMap()
        {
            var position = Mouse.GetPosition(m_window);
            var coords = m_window.MapPixelToCoords(position);

            var mousePos = new System.Drawing.Point((int)coords.X, (int)coords.Y);
            var currentMap = GetMap(mousePos);

            if (currentMap != null)
            {
                #region Je suis un salopard  suppression preview sur la map actuel
                if (currentMap != m_lastMap && m_lastMap != null)
                {

                    foreach (var layer in new List<LayerContent>(m_lastMap.Layer))
                    {
                        foreach (var cell in layer.Cells)
                        {
                            for (int i = 0; i < cell.Elements.Count; i++)
                            {
                                if (cell.Elements[i].isPreview)
                                {
                                    m_lastMap.Layer.First(x => x.Type == layer.Type).Cells.First(y => y.CELLID == cell.CELLID).Elements.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                #endregion

                m_lastMap = currentMap;
            }


            return currentMap;
        }

        private MapCell GetCurrentCell()
        {
            RegetPreview();
            var position = Mouse.GetPosition(m_window);
            var coords = m_window.MapPixelToCoords(position);

            var mousePos = new System.Drawing.Point((int)coords.X, (int)coords.Y);

            var map = GetMap(mousePos);
            if (map == null)
                return null;

            return map.GetCell(mousePos);
        }

        private void DrawBorderTry2(RenderWindow render, List<MapCell> map)
        {
            Vertex[] line = new Vertex[12]
                      {
                              new  Vertex(map[0].Center, SFML.Graphics.Color.Red),
               new  Vertex(map[13].Center, SFML.Graphics.Color.Red),

               new  Vertex(  map[13].Center, SFML.Graphics.Color.Red),
               new  Vertex(  map[27].Center, SFML.Graphics.Color.Red),

               new  Vertex(  map[27].Center, SFML.Graphics.Color.Red),
               new  Vertex(  map[559].Center, SFML.Graphics.Color.Red),

               new  Vertex(  map[559].Center, SFML.Graphics.Color.Red),
               new  Vertex(  map[546].Center, SFML.Graphics.Color.Red),

               new  Vertex(  map[546].Center, SFML.Graphics.Color.Red),
               new  Vertex(  map[532].Center, SFML.Graphics.Color.Red),

               new  Vertex(  map[532].Center, SFML.Graphics.Color.Red),
               new  Vertex(  map[0].Center, SFML.Graphics.Color.Red),
                      };
            render.Draw(line, PrimitiveType.Lines);
        }



        #region Interface
        private bool m_mouseDown;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            m_lastLocation = e.Location;
            m_mouseDown = true;
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            m_mouseDown = false;
        }

        private void RefreshUI()
        {

        }

        private void CloseBtn_Click_1(object sender, EventArgs e)
        {
            RefreshUI();

        }


        private void MinimizeBtn_Click(object sender, EventArgs e)
        {

            RefreshUI();
        }

        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m_lastLocation = e.Location;
            m_mouseDown = true;
        }

        private void splitContainer1_Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m_mouseDown = false;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void MaximizeBtn_Click(object sender, EventArgs e)
        {

            RefreshUI();
        }

        private void MinimizeBtn_Click_1(object sender, EventArgs e)
        {

            RefreshUI();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            m_lastLocation = e.Location;
            m_mouseDown = true;

        }

        private int CurrentCellID;




        public MapEditor GetMap(System.Drawing.Point point)
        {
            return rendering.Maps.FirstOrDefault(x => x.GetCell(point) != null);

        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            m_mouseDown = false;

        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        public static bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        private object thisLock = new object();


        private void Event()
        {
            lock (thisLock)
            {
                if (!ApplicationIsActivated())
                    return;


                if (m_preview.Sprite != null)
                {

                    if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                    {
                        m_preview.GraphicalElement.PixelOffsetX -= 1;
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
                    {
                        m_preview.GraphicalElement.PixelOffsetY -= 1;
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                    {
                        m_preview.GraphicalElement.PixelOffsetX += 1;
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                    {
                        m_preview.GraphicalElement.PixelOffsetY += 1;
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    {
                        m_preview.GraphicalElement.Altitude += 1;
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.P))
                    {
                        var map = GetCurrentMap();

                        if (map == null)
                            return;

                        for (int i = 0; i < 560; i++)
                            AddTile(i, map);

                    }

                    if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                    {

                        if (m_preview.GraphicElement is NormalGraphicalElementData && (m_preview.GraphicElement as NormalGraphicalElementData).HorizontalSymmetry)
                        {
                            var newPreview = TextureManager.Instance.GetRotateElementDataByGfx((m_preview.GraphicElement as NormalGraphicalElementData).Gfx, false);
                            if (newPreview != null)
                            {
                                m_preview.GraphicElement = newPreview;
                                m_preview.GraphicalElement = new GraphicalElement() { Altitude = 0, ElementId = m_preview.GraphicElement.Id, FinalTeint = new ColorMultiplicator(0, 0, 0), Hue = new ColorMultiplicator(0, 0, 0), Identifier = 0, OffsetX = 0, OffsetY = 0, PixelOffsetX = 0, PixelOffsetY = 0, Shadow = new ColorMultiplicator(0, 0, 0) };
                                m_preview.isPreview = true;
                                m_preview.Sprite = new Sprite(TextureManager.Instance.GetImageGfx(newPreview.Gfx));
                            }
                        }
                        else if (m_preview.GraphicElement is NormalGraphicalElementData)
                        {
                            var newPreview = TextureManager.Instance.GetRotateElementDataByGfx((m_preview.GraphicElement as NormalGraphicalElementData).Gfx, true);
                            if (newPreview != null)
                            {
                                m_preview.GraphicElement = newPreview;
                                m_preview.GraphicalElement = new GraphicalElement() { Altitude = 0, ElementId = m_preview.GraphicElement.Id, FinalTeint = new ColorMultiplicator(0, 0, 0), Hue = new ColorMultiplicator(0, 0, 0), Identifier = 0, OffsetX = 0, OffsetY = 0, PixelOffsetX = 0, PixelOffsetY = 0, Shadow = new ColorMultiplicator(0, 0, 0) };
                                m_preview.Sprite = new Sprite(TextureManager.Instance.GetImageGfx(newPreview.Gfx));
                                m_preview.isPreview = true;
                            }
                        }
                    }

                    if (Keyboard.IsKeyPressed(Keyboard.Key.O))
                    {
                        m_view.Zoom(1.1f);
                        m_window.SetView(m_view);
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.L))
                    {
                        m_view.Zoom(0.9f);
                        m_window.SetView(m_view);
                    }
                }
            }



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //   NewMap();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            RefreshUI();
        }



        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {

        }



        public void NewProjet(string name, int x, int y, UINewMap test)
        {
            CellManagerTest.Instance.countX = x;
            CellManagerTest.Instance.countY = y;
            CellManagerTest.Instance.Init();
            mCurrentProject = new Project()
            {
                Name = name
            };
            lock (rendering.Maps)
            {
                rendering.Maps.Clear();
                foreach (var map in CellManagerTest.Instance.Maps)
                {
                    rendering.Maps.Add(new MapEditor(new Map(), map));
                }
                test.Invoke((MethodInvoker)delegate
                {
                    test.Close();
                });
            }

        }



        public void NewMappProject()
        {
            mCurrentProject = new Project()
            {
                Name = "!map"
            };

            List<MapEditor> listMaps = new List<MapEditor>();

            CellManagerTest.Instance.countX = 3;
            CellManagerTest.Instance.countY = 3;
            CellManagerTest.Instance.Init();

            foreach (var map in CellManagerTest.Instance.Maps)
            {
                listMaps.Add(new MapEditor(new Map(), map));
            }


            rendering.SetMaps(listMaps);



        }


        #region Gestion dectection cellule
        //public MapCell GetCell(System.Drawing.Point p, bool outMap = false)
        //{
        //    var searchRect = new System.Drawing.Rectangle(p.X, p.Y, 0, 0);
        //    if(outMap)
        //        return CellManagerTest.Instance.Cells.FirstOrDefault(cell => cell != null && cell.IsInRectange(searchRect) && PointInPoly(p, cell.RectanglePoints));
        //    else
        //        return CellManagerTest.Instance.maps.First().FirstOrDefault(cell => cell != null && cell.IsInRectange(searchRect) && PointInPoly(p, cell.RectanglePoints));
        //}

        //public static bool PointInPoly(System.Drawing.Point p, System.Drawing.Point[] poly)
        //{
        //    int xnew, ynew;
        //    int xold, yold;
        //    int x1, y1;
        //    int x2, y2;
        //    bool inside = false;

        //    if (poly.Length < 3)
        //        return false;

        //    xold = poly[poly.Length - 1].X;
        //    yold = poly[poly.Length - 1].Y;

        //    foreach (System.Drawing.Point t in poly)
        //    {
        //        xnew = t.X;
        //        ynew = t.Y;

        //        if (xnew > xold)
        //        {
        //            x1 = xold;
        //            x2 = xnew;
        //            y1 = yold;
        //            y2 = ynew;
        //        }
        //        else
        //        {
        //            x1 = xnew;
        //            x2 = xold;
        //            y1 = ynew;
        //            y2 = yold;
        //        }

        //        if ((xnew < p.X) == (p.X <= xold) && (p.Y - (long)y1) * (x2 - x1) < (y2 - (long)y1) * (p.X - x1))
        //        {
        //            inside = !inside;
        //        }
        //        xold = xnew;
        //        yold = ynew;
        //    }
        //    return inside;
        //}

        #endregion

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            m_viewCase = !m_viewCase;
            //  Draw(m_window);
            redraw = false;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //DialogResult result = openFileDialog1.ShowDialog();
            //m_maps.Clear();
            //if (result == DialogResult.OK)
            //{
            //    BigEndianReader reader = new BigEndianReader(File.ReadAllBytes(openFileDialog1.FileName));

            //    byte header = reader.ReadByte();
            //    bool flag2 = header != 77;
            //    if (flag2 && header != 150)
            //    {
            //        reader.Seek(2, SeekOrigin.Begin);
            //        var test = Decompress(reader.ReadBytes((int)reader.BytesAvailable));
            //        reader = new BigEndianReader(test);
            //    }

            //    reader.SetPosition(0);

            //    Map map = new Map();
            //    map.Init(reader);
            //    m_maps.Add(new MapEditor(map, CellManagerTest.Instance.Maps[0]));
            //}

            Task.Run(() => relaod());
            //   relaod();

        }

        private static Stream Decompress(byte[] input)
        {
            var output = new MemoryStream();

            using (var compressStream = new MemoryStream(input))
            using (var decompressor = new DeflateStream(compressStream, CompressionMode.Decompress))
                decompressor.CopyTo(output);

            output.Position = 0;
            return output;
        }


        private void relaod()
        {
            lock (rendering.Maps)
            {

                rendering.Maps.Clear();
                var currentId = 84804608;
                var map = MapsManager.GetMapFromId(currentId);
                int maxX = CellManagerTest.Instance.countX;

                int maxY = CellManagerTest.Instance.countY;
                int i = 0;

                int f = 0;
                for (int v = 0; v < maxY; v++)
                {

                    for (i = f; i < maxX; i++)
                    {
                        map = MapsManager.GetMapFromId(currentId);
                        rendering.Maps.Add(new MapEditor(map, CellManagerTest.Instance.Maps[i]));
                        currentId = map.RightNeighbourId;
                        f++;
                    }
                    currentId = rendering.Maps[rendering.Maps.Count - CellManagerTest.Instance.countX].Map.BottomNeighbourId;
                    maxX += CellManagerTest.Instance.countX;

                }

            }


        }
        private void LoadMap()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                BigEndianReader reader = new BigEndianReader(File.ReadAllBytes(openFileDialog1.FileName));
                byte header = reader.ReadByte();
                bool flag2 = header != 77;
                if (flag2)
                {
                    MemoryStream stream = new MemoryStream(reader.Data)
                    {
                        Position = 2L
                    };
                    DeflateStream stream2 = new DeflateStream(stream, CompressionMode.Decompress);
                    byte[] buffer = new byte[50001];
                    MemoryStream destination = new MemoryStream(buffer);
                    stream2.CopyTo(destination);
                    destination.Position = 0L;
                    reader = new BigEndianReader(destination);
                }
                reader.SetPosition(0);
                Map map2 = new Map();
                map2.Init(reader);

            }

        }
        #region Outils de selection 

        private void LayerSelection(LayerEnum layer)
        {
            m_layer = layer;
            if (layer == LayerEnum.Ground)
            {
                this.bunifuImageButton2.Enabled = true;
                this.bunifuImageButton3.Enabled = true;
                this.bunifuImageButton4.Enabled = true;

                this.bunifuImageButton1.Enabled = false;
            }
            else if (layer == LayerEnum.Additional_Ground)
            {
                this.bunifuImageButton1.Enabled = true;
                this.bunifuImageButton3.Enabled = true;
                this.bunifuImageButton4.Enabled = true;

                this.bunifuImageButton2.Enabled = false;
            }
            else if (layer == LayerEnum.Decor)
            {
                this.bunifuImageButton1.Enabled = true;
                bunifuImageButton2.Enabled = true;
                bunifuImageButton4.Enabled = true;

                this.bunifuImageButton3.Enabled = false;
            }
            else if (layer == LayerEnum.Additional_Decor)
            {
                this.bunifuImageButton1.Enabled = true;
                bunifuImageButton2.Enabled = true;
                bunifuImageButton3.Enabled = true;
                this.bunifuImageButton4.Enabled = false;
            }

        }




        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            ChangePreviewLayer(LayerEnum.Ground);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            ChangePreviewLayer(LayerEnum.Additional_Ground);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            ChangePreviewLayer(LayerEnum.Decor);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            ChangePreviewLayer(LayerEnum.Additional_Decor);
        }


        public void ChangePreviewLayer(LayerEnum type)
        {

            lock (rendering.Maps)
            {
                foreach (var map in rendering.Maps)
                {
                    var currentLayer = GetLayer(map);

                    foreach (var cell in currentLayer.Cells)
                    {
                        if (cell.Elements.Any(y => y.isPreview))
                        {
                            cell.Elements.RemoveAt(cell.Elements.Count - 1);
                            m_preview.Type = type;
                        }
                    }
                }
                LayerSelection(type);
            }



        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            //    m_outil = OutilsEnum.Rubbet;
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            m_outil = OutilsEnum.Paint;
        }
        #endregion

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {


            m_preview.GraphicElement = TextureManager.Instance.GetElementDataByGfx(int.Parse(e.Item.Text));
            m_preview.GraphicalElement = new GraphicalElement() { Altitude = 0, ElementId = m_preview.GraphicElement.Id, FinalTeint = new ColorMultiplicator(0, 0, 0), Hue = new ColorMultiplicator(0, 0, 0), Identifier = 0, OffsetX = 0, OffsetY = 0, PixelOffsetX = 0, PixelOffsetY = 0, Shadow = new ColorMultiplicator(0, 0, 0) };
            m_preview.Sprite = new Sprite(TextureManager.Instance.GetImageGfx(int.Parse(e.Item.Text)));
            m_preview.isPreview = true;
        }

        private Test m_preview = new Test();


        private LayerContent GetLayer(MapEditor map)
        {
            var layer = map.Layer.FirstOrDefault(x => x.Type == m_layer);
            if (layer != null)
                return layer;

            map.Layer.Add(new LayerContent() { Cells = new List<CellEditor>(), Type = (LayerEnum)m_layer });

            return map.Layer.FirstOrDefault(x => x.Type == m_layer);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void AddTile(int cellID, MapEditor map, bool isPreview = false, bool isMousePress = false)
        {
            if (map == null)
                return;

            if (!map.Layer.Any(x => x.Type == m_layer))
                map.Layer.Add(new LayerContent() { Cells = new List<CellEditor>(), Type = m_layer });

            LayerContent layer = (LayerContent)map.Layer.First(x => x.Type == m_layer);
            if (m_preview.GraphicElement == null)
                return;


            var element = new Test()
            {
                CellID = cellID,
                GraphicalElement = (GraphicalElement)m_preview.GraphicalElement.Clone(),
                GraphicElement = m_preview.GraphicElement,
                Sprite = new Sprite(TextureManager.Instance.GetImageGfx((int)(m_preview.GraphicElement as NormalGraphicalElementData).Gfx)),
                Type = m_layer,
                isPreview = isPreview,
                after = m_preview.after,
                before = m_preview.before,
                CellIdOUT = m_preview.CellIdOUT,
                isCellOut = m_preview.isCellOut,
                Manager = map
            };


            layer.AddElement(cellID, element, isMousePress);


        }
        private void AddTile(int cellID, MapEditor map, Test tile)
        {
            if (map == null)
                return;

            if (!map.Layer.Any(x => x.Type == m_layer))
                map.Layer.Add(new LayerContent() { Cells = new List<CellEditor>(), Type = m_layer });

            LayerContent layer = (LayerContent)map.Layer.First(x => x.Type == m_layer);
            if (m_preview.GraphicElement == null)
                return;


            var element = new Test()
            {
                CellID = cellID,
                GraphicalElement = (GraphicalElement)tile.GraphicalElement.Clone(),
                GraphicElement = tile.GraphicElement,
                Sprite = new Sprite(TextureManager.Instance.GetImageGfx((int)(tile.GraphicElement as NormalGraphicalElementData).Gfx)),
                Type = m_layer,
                isPreview = false,
                after = m_preview.after,
                before = m_preview.before,
                CellIdOUT = m_preview.CellIdOUT,
                isCellOut = m_preview.isCellOut,
                Manager = map
            };

            layer.AddElement(cellID, element);


        }
        public void SelecteTile(string name, bool focus = false, bool newSelect = false)
        {
            m_preview.GraphicElement = TextureManager.Instance.GetElementDataByGfx(int.Parse(name));

            if (newSelect == true)
            {
                m_preview.GraphicalElement = new GraphicalElement() { Altitude = 0, ElementId = m_preview.GraphicElement.Id, FinalTeint = new ColorMultiplicator(0, 0, 0), Hue = new ColorMultiplicator(0, 0, 0), Identifier = 0, OffsetX = 0, OffsetY = 0, PixelOffsetX = 0, PixelOffsetY = 0, Shadow = new ColorMultiplicator(0, 0, 0) };
            }
            else
            {
                if (m_preview.GraphicalElement != null)
                    m_preview.GraphicalElement = new GraphicalElement() { Altitude = m_preview.GraphicalElement.Altitude, ElementId = m_preview.GraphicElement.Id, FinalTeint = new ColorMultiplicator(0, 0, 0), Hue = new ColorMultiplicator(0, 0, 0), Identifier = 0, OffsetX = m_preview.GraphicalElement.OffsetX, OffsetY = m_preview.GraphicalElement.OffsetY, PixelOffsetX = m_preview.GraphicalElement.PixelOffsetX, PixelOffsetY = m_preview.GraphicalElement.PixelOffsetY, Shadow = new ColorMultiplicator(0, 0, 0) };
                else
                    return;

            }

            m_preview.Sprite = new Sprite(TextureManager.Instance.GetImageGfx(int.Parse(name)));
            m_preview.isPreview = true;

            this.pictureBox1.Focus();
        }

        private void Relink(Map currentMap, MapEditor editor)
        {
            lock (rendering.Maps)
            {
                var list = rendering.Maps.Where(x => x.Map.Id != editor.Map.Id).ToArray();

                foreach (var map in list)
                {
                    var orientation = editor.MapCells[0].Point.OrientationTo(map.MapCells[0].Point, false);
                    var dist = editor.MapCells[0].Point.DistanceToCell(map.MapCells[0].Point);
                    if (dist == 860 || dist == 1204)
                    {
                        if (orientation == ShadowEmu.Common.Protocol.Enums.DirectionsEnum.DIRECTION_SOUTH_EAST)
                        {
                            currentMap.RightNeighbourId = map.Map.Id;
                        }
                        else if (orientation == ShadowEmu.Common.Protocol.Enums.DirectionsEnum.DIRECTION_NORTH_WEST)
                        {
                            currentMap.LeftNeighbourId = map.Map.Id;
                        }
                        else if (orientation == ShadowEmu.Common.Protocol.Enums.DirectionsEnum.DIRECTION_NORTH_EAST)
                        {
                            currentMap.BottomNeighbourId = map.Map.Id;
                        }
                        else if (orientation == ShadowEmu.Common.Protocol.Enums.DirectionsEnum.DIRECTION_SOUTH_WEST)
                        {
                            currentMap.TopNeighbourId = map.Map.Id;
                        }
                    }
                }
            }


        }
        public void OpenMap(string path, bool old = false)
        {

            //BigEndianReader reader = new BigEndianReader(File.ReadAllBytes(path));
            //m_maps.Clear();

            //CellManagerTest.Instance.countX = 1;
            //CellManagerTest.Instance.countY = 1;
            //CellManagerTest.Instance.Init();


            //byte header = reader.ReadByte();
            //bool flag2 = header != 77;
            //if (flag2 && header != 150)
            //{
            //    reader.Seek(2, SeekOrigin.Begin);
            //    var test = Decompress(reader.ReadBytes((int)reader.BytesAvailable));
            //    reader = new BigEndianReader(test);
            //}

            //reader.SetPosition(0);

            Map map = MapsManager.GetMapFromId(88082704);
            //     map.Init(reader, old);
            lock (rendering.Maps)
            {
                rendering.Maps.Add(new MapEditor(map, CellManagerTest.Instance.Maps[0], map.Cells));

                var m = new System.Drawing.ColorConverter();

                System.Drawing.Color c = System.Drawing.Color.FromArgb(0, map.BackgroundRed, map.BackgroundGreen, map.BackgroundBlue);

                rendering.Maps.First().BackgroundColor = System.Drawing.ColorTranslator.ToHtml(c);
                rendering.Maps.First().BackgroundAlpha = map.BackgroundAlpha;
            }



        }


        public void OpenProject(string path, bool old = false)
        {
            BigEndianReader reader = new BigEndianReader(File.ReadAllBytes(path));
            int mapsCountX = reader.ReadInt();
            int mapsCountY = reader.ReadInt();
            lock (rendering.Maps)
            {
                rendering.Maps.Clear();

                CellManagerTest.Instance.countX = mapsCountX;
                CellManagerTest.Instance.countY = mapsCountY;
                CellManagerTest.Instance.Init();

                int m = 0;
                for (int i = 0; i < (mapsCountX * mapsCountY); i++)
                {
                    Map map = new Map();
                    map.Init(reader, old);

                    rendering.Maps.Add(new MapEditor(map, CellManagerTest.Instance.Maps[m], map.Cells));
                    m++;
                }

            }

            mCurrentProject.Name = (string)(path.Split('\\').Last()).Split('.').First();
        }

        public static List<T> CloneList<T>(List<T> oldList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, oldList);
            stream.Position = 0;
            return (List<T>)formatter.Deserialize(stream);
        }




        public void SaveProject()
        {
            BigEndianWriter writer = new BigEndianWriter();
            writer.WriteInt(CellManagerTest.Instance.countX);
            writer.WriteInt(CellManagerTest.Instance.countY);



            try
            {
                lock (rendering.Maps)
                {
                    int v = 0;
                    foreach (var currentMap in rendering.Maps)
                    {
                        currentMap.Map.Id = v;
                        v++;
                        currentMap.Map.LeftNeighbourId = -1;
                        currentMap.Map.RightNeighbourId = -1;
                        currentMap.Map.TopNeighbourId = -1;
                        currentMap.Map.BottomNeighbourId = -1;

                    }

                    var listMap = CloneClass.CloneObject<List<MapEditor>>(rendering.Maps);
                    foreach (var currentMap in listMap)
                    {
                        Relink(currentMap.Map, currentMap);
                    }

                    foreach (var currentMap in listMap)
                    {

                        Map map = MapsManager.GetMapFromId(88212759);
                        map.Layers = new List<Layer>();
                        map.LeftNeighbourId = currentMap.Map.LeftNeighbourId;
                        map.TopNeighbourId = currentMap.Map.TopNeighbourId;
                        map.BottomNeighbourId = currentMap.Map.BottomNeighbourId;
                        map.RightNeighbourId = currentMap.Map.RightNeighbourId;




                        map.Id = currentMap.Map.Id;

                        foreach (var layer in currentMap.Layer)
                            layer.RemoveAllPreview();



                        map.Cells = currentMap.Cells;

                        for (int i = 0; i < 4; i++)
                        {
                            foreach (var layer in currentMap.Layer.Where(x => x.Type == (LayerEnum)i))
                            {
                                Layer current = new Layer();
                                current.LayerId = i;
                                current.Cells = new List<Cell>();

                                foreach (var cell in layer.Cells.OrderBy(x => x.CELLID))
                                {
                                    List<BasicElement> elements = new List<BasicElement>();
                                    foreach (Test element in cell.Elements)
                                    {
                                        if (!element.isPreview)
                                            elements.Add(element.GraphicalElement);
                                    }



                                    if (current.Cells.Any(x => x.CellId == cell.CELLID))
                                    {
                                        var mirroir = current.Cells.First(h => h.CellId == cell.CELLID);
                                        mirroir.Elements.AddRange(elements);
                                    }
                                    else
                                    {
                                        current.Cells.Add(new Cell()
                                        {
                                            CellId = cell.CELLID,
                                            Elements = elements,
                                        });
                                    }

                                }




                                map.Layers.Add(current);
                            }
                        }
                        map.Write(writer);
                    }


                    //    map.Write(AppDomain.CurrentDomain.BaseDirectory + @"data\save");

                    mCurrentProject.Name = mCurrentProject.Name == "!map" ? "projectSansNom" + Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"data\save").Length + 1 : mCurrentProject.Name;


                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\save\project\" + mCurrentProject.Name + ".mdProject"))
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"data\save\project\" + mCurrentProject.Name + ".mdProject");


                    File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"data\save\project\" + mCurrentProject.Name + ".mdProject", writer.Data);
                }

            }
            catch (Exception e)
            {
            }

        }


        public void SaveMap()
        {
            var currentMap = rendering.Maps.First();
            currentMap.Map.Id = 0;

            Map map = MapsManager.GetMapFromId(88212759);
            map.Layers = new List<Layer>();



            map.LeftNeighbourId = -1;
            map.TopNeighbourId = -1;
            map.BottomNeighbourId = -1;
            map.RightNeighbourId = -1;




            Relink(map, currentMap);


            map.Cells = currentMap.Cells;
            for (int i = 0; i < 4; i++)
            {


                foreach (var layer in currentMap.Layer.Where(x => x.Type == (LayerEnum)i))
                {
                    Layer current = new Layer();
                    current.LayerId = i;
                    current.Cells = new List<Cell>();

                    foreach (var cell in layer.Cells.OrderBy(x => x.CELLID))
                    {
                        List<BasicElement> elements = new List<BasicElement>();

                        foreach (Test element in cell.Elements)
                        {
                            if (element.Sprite == null)
                                continue;
                            if (!element.isPreview)
                                elements.Add(element.GraphicalElement);
                        }
                        current.Cells.Add(new Cell()
                        {
                            CellId = cell.CELLID,
                            Elements = elements,
                        });
                    }
                    map.Layers.Add(current);
                }
            }




            if (currentMap.Map.Id == 0)
                map.Id = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"data\save").Length + 1;
            else
                map.Id = currentMap.Map.Id;

            map.Write(AppDomain.CurrentDomain.BaseDirectory + @"data\save");
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            lock (rendering.Maps)
            {
                foreach (var currentMap in rendering.Maps)
                {
                    Map map = MapsManager.GetMapFromId(88212759);
                    map.Layers = new List<Layer>();
                    map.LeftNeighbourId = -1;
                    map.TopNeighbourId = -1;
                    map.BottomNeighbourId = -1;
                    map.RightNeighbourId = -1;
                    Relink(map, currentMap);


                    map.Cells = currentMap.Cells;
                    for (int i = 0; i < 4; i++)
                    {


                        foreach (var layer in currentMap.Layer.Where(x => x.Type == (LayerEnum)i))
                        {
                            Layer current = new Layer();
                            current.LayerId = i;
                            current.Cells = new List<Cell>();

                            foreach (var cell in layer.Cells.OrderBy(x => x.CELLID))
                            {
                                List<BasicElement> elements = new List<BasicElement>();

                                foreach (Test element in cell.Elements)
                                {
                                    if (!element.isPreview)
                                        elements.Add(element.GraphicalElement);
                                }
                                current.Cells.Add(new Cell()
                                {
                                    CellId = cell.CELLID,
                                    Elements = elements,
                                });
                            }
                            map.Layers.Add(current);
                        }
                    }




                    if (currentMap.Map.Id == 0)
                        map.Id = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"data\save").Length + 1;
                    else
                        map.Id = currentMap.Map.Id;

                    map.Write(AppDomain.CurrentDomain.BaseDirectory + @"data\save");

                }
            }

        }



        public List<Test> TryElement(List<Test> elements)
        {
            List<Test> test = new List<Test>();
            foreach (var element in elements.Where(x => x.isCellOut == true && x.before == true).OrderBy(x => x.CellIdOUT))
                test.Add(element);

            foreach (var element in elements.Where(x => x.isCellOut == false).OrderBy(x => x.CellID))
                test.Add(element);

            foreach (var element in elements.Where(x => x.isCellOut == true && x.after == true).OrderBy(x => x.CellIdOUT))
                test.Add(element);

            return test;
        }




        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            m_outil = OutilsEnum.Paint;
        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {
            m_outil = OutilsEnum.CellWalkable;
        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            m_outil = OutilsEnum.CellWalkableInFight;
        }

        private void bunifuImageButton14_Click(object sender, EventArgs e)
        {
            m_outil = OutilsEnum.CellWalkableInRP;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.M))
                return;
            try
            {
                var currentMap = GetCurrentMap();


                if (currentMap == null)
                    return;

                var cell = GetCurrentCell();

                if (cell != null)
                {

                    var newCellID = cell.RealID;


                    if (m_preview.Sprite == null && m_outil == OutilsEnum.Paint)
                    {
                        CurrentCellID = cell.RealID;
                        return;

                    }
                    var layer = GetLayer(currentMap);


                    if (CurrentCellID == newCellID)
                        return;

                    CurrentCellID = newCellID;
                    m_preview.Manager = currentMap;
                    if (m_mouseDown)
                    {

                        if (m_outil == OutilsEnum.Paint)
                        {

                            if (e.Button == MouseButtons.Left)
                            {
                                //if(currentMap.Layer[layer[newCellID].)
                                AddTile(newCellID, currentMap, false, true);
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                // var layer = GetLayer();
                                var celltest = layer.Cells.FirstOrDefault(x => x.CELLID == newCellID);
                                if (celltest == null)
                                    return;

                                if (celltest.Elements.Where(x => x.isPreview == false).ToArray().Length > 0)
                                {
                                    var element = celltest.Elements.Where(x => x.isPreview == false).Last();
                                    celltest.Elements.Remove(element);
                                }
                            }
                        }
                        else
                        {

                            if (m_outil == OutilsEnum.CellWalkable)
                            {
                                if (e.Button == MouseButtons.Left)
                                    currentMap.Cells[newCellID].Mov = false;
                                else if (e.Button == MouseButtons.Right)
                                    currentMap.Cells[newCellID].Mov = true;

                            }
                            else if (m_outil == OutilsEnum.CellWalkableInRP)
                            {
                                if (e.Button == MouseButtons.Left)
                                    currentMap.Cells[newCellID].NonWalkableDuringRP = false;
                                else if (e.Button == MouseButtons.Right)
                                    currentMap.Cells[newCellID].NonWalkableDuringRP = true;

                            }
                            else if (m_outil == OutilsEnum.CellWalkableInFight)
                            {
                                if (e.Button == MouseButtons.Left)
                                    currentMap.Cells[newCellID].NonWalkableDuringFight = false;
                                else if (e.Button == MouseButtons.Right)
                                    currentMap.Cells[newCellID].NonWalkableDuringRP = true;

                            }


                        }
                    }
                    else
                    {
                        var lastpreviewLayer = currentMap.Layer.FirstOrDefault(x => x.Cells.Any(y => y.Elements.Any(z => z.isPreview == true)));
                        if (lastpreviewLayer != null)
                        {
                            var cellPreview = lastpreviewLayer.Cells.FirstOrDefault(x => x.Elements.Any(y => y.isPreview));
                            if (cellPreview != null)
                            {

                                var prevElement = cellPreview.Elements.FirstOrDefault(x => x.isPreview);
                                if (prevElement != null)
                                    cellPreview.Elements.Remove(prevElement);


                            }
                        }

                        AddTile(CurrentCellID, currentMap, true);

                    }





                }
            }
            catch (Exception g)
            {


            }

        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            var map = GetCurrentMap();

            if (map == null)
                return;

            if (m_outil == OutilsEnum.Paint)
            {

                if (e.Button == MouseButtons.Left)
                {
                    AddTile(CurrentCellID, map);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    var layer = GetLayer(map);
                    var celltest = layer.Cells.FirstOrDefault(x => x.CELLID == CurrentCellID);
                    if (celltest == null)
                        return;

                    if (celltest.Elements.Where(x => x.isPreview == false).ToArray().Length > 0)
                    {
                        var element = celltest.Elements.Where(x => x.isPreview == false).Last();
                        celltest.Elements.Remove(element);
                    }
                }
            }
            else
            {

                if (m_outil == OutilsEnum.CellWalkable)
                {
                    if (e.Button == MouseButtons.Left)
                        map.Cells[CurrentCellID].Mov = false;
                    else if (e.Button == MouseButtons.Right)
                        map.Cells[CurrentCellID].Mov = true;

                }
                else if (m_outil == OutilsEnum.CellWalkableInRP)
                {
                    if (e.Button == MouseButtons.Left)
                        map.Cells[CurrentCellID].NonWalkableDuringRP = false;
                    else if (e.Button == MouseButtons.Right)
                        map.Cells[CurrentCellID].NonWalkableDuringRP = true;

                }
                else if (m_outil == OutilsEnum.CellWalkableInFight)
                {
                    if (e.Button == MouseButtons.Left)
                        map.Cells[CurrentCellID].NonWalkableDuringFight = false;
                    else if (e.Button == MouseButtons.Right)
                        map.Cells[CurrentCellID].NonWalkableDuringRP = true;

                }
                else if (m_outil == OutilsEnum.TriggerChangeMap)
                {

                    if (TypeToChangeMap == TypeChangeMapEnum.Unknow)
                        return;

                    if (TypeToChangeMap == TypeChangeMapEnum.Top)
                    {
                        map.Cells[CurrentCellID].IsTopChange = !map.Cells[CurrentCellID].IsTopChange;
                        map.Cells[CurrentCellID].IsBotChange = false;
                        map.Cells[CurrentCellID].IsLeftChange = false;
                        map.Cells[CurrentCellID].IsRightChange = false;

                    }
                    else if (TypeToChangeMap == TypeChangeMapEnum.Bot)
                    {
                        map.Cells[CurrentCellID].IsBotChange = !map.Cells[CurrentCellID].IsBotChange;
                        map.Cells[CurrentCellID].IsTopChange = false;
                        map.Cells[CurrentCellID].IsLeftChange = false;
                        map.Cells[CurrentCellID].IsRightChange = false;
                    }
                    else if (TypeToChangeMap == TypeChangeMapEnum.Left)
                    {
                        map.Cells[CurrentCellID].IsLeftChange = !map.Cells[CurrentCellID].IsLeftChange;
                        map.Cells[CurrentCellID].IsBotChange = false;
                        map.Cells[CurrentCellID].IsTopChange = false;
                        map.Cells[CurrentCellID].IsRightChange = false;
                    }
                    else if (TypeToChangeMap == TypeChangeMapEnum.Right)
                    {
                        map.Cells[CurrentCellID].IsRightChange = !map.Cells[CurrentCellID].IsRightChange;
                        map.Cells[CurrentCellID].IsBotChange = false;
                        map.Cells[CurrentCellID].IsLeftChange = false;
                        map.Cells[CurrentCellID].IsTopChange = false;
                    }





                }


            }
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            m_mouseDown = true;
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            m_mouseDown = false;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }
        private bool saveToPng = false;
        private void bunifuImageButton15_Click(object sender, EventArgs e)
        {
            saveToPng = true;
        }

        public void SavePng()
        {
            saveToPng = true;

        }

        public void ModifBackGroundColor(string color)
        {
            rendering.Maps.First().BackgroundColor = color;
        }
        public void ModifAlphaColor(int color)
        {
            rendering.Maps.First().BackgroundAlpha = color;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.M) && Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                var map = GetCurrentMap();
                if (map == null)
                    return;

                map.BackgroundColor = rendering.Maps.First().BackgroundColor;
                map.BackgroundAlpha = rendering.Maps.First().BackgroundAlpha;

                UIManager.Instance.MapInformation.UpdateGrid(GetCurrentMap(), this);
            }


            if (saveToPng)
            {
                var img = this.m_window.Capture();

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\data\rendue"))
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\data\rendue");

                var count = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\data\rendue").Length + 1;
                var test = img.SaveToFile(AppDomain.CurrentDomain.BaseDirectory + @"\data\rendue\" + count + ".png");
                saveToPng = false;
            }
            Application.DoEvents();
            m_window.DispatchEvents();
            this.EventTest();
            //Draw(m_window);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Running();
        }
    }
}

public class Enity
{
    public MapCell Cell;
    public CellEditor Editor;
}
#region Autres Classe utils
public class Test : ICloneable
{

    public GraphicalElement GraphicalElement;
    public Sprite Sprite;
    public EleGraphicalData GraphicElement;
    public int CellID;
    public bool Center = false;
    public LayerEnum Type;
    public bool view = true;
    public bool isPreview = false;
    public bool before = false;
    public bool after = false;

    public bool isCellOut = false;
    public int CellIdOUT = 0;
    public MapEditor Manager;

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public Vector2f GetPosToDrawTexture()
    {
        if (GraphicElement is NormalGraphicalElementData)
        {
            var cellPos = Manager.MapCells[CellID].Center;

            var gfx = TextureManager.Instance.GetImageGfx((GraphicElement as NormalGraphicalElementData).Gfx);

            var pos1 = new Vector2f((cellPos.X - (GraphicElement as NormalGraphicalElementData).Origin.X),
                 (cellPos.Y - (GraphicElement as NormalGraphicalElementData).Origin.Y));

            pos1.X += (float)GraphicalElement.PixelOffsetX;
            pos1.Y += (float)GraphicalElement.PixelOffsetY;

            if (GraphicalElement.Altitude != 0)
                pos1.Y = (float)(pos1.Y + Math.Round(AtouinConstants.CELL_HALF_HEIGHT - (GraphicalElement.Altitude * 10) + GraphicalElement.PixelOffsetY) - AtouinConstants.CELL_HALF_HEIGHT);


            if ((GraphicElement as NormalGraphicalElementData).HorizontalSymmetry)
            {
                Sprite.Scale = new Vector2f(-1, Sprite.Scale.Y);
                pos1.X += (int)Sprite.Texture.Size.X;
            }
            return new Vector2f((float)pos1.X, (float)pos1.Y);
        }
        else if (GraphicElement is EntityGraphicalElementData && (GraphicElement as EntityGraphicalElementData).EntityLook == "{650}")
        {
            //jusqu'ici ok

            var cellPos = Manager.MapCells[CellID].Center;

            // (GraphicElement as EntityGraphicalElementData).
            var gfx = TextureManager.Instance.GetImageGfx(655450);

            //    var d= TextureManager.Instance.instance.GraphicalDatas.Where(x => x.Key == this.GraphicalElement.Identifier).ToArray();
            //     var origine = (NormalGraphicalElementData)TextureManager.Instance.GetElementDataByGfx(this.GraphicalElement.ElementId);
            var pos1 = new Vector2f((cellPos.X),
                 (cellPos.Y));

            pos1.X += (float)GraphicalElement.PixelOffsetX;
            pos1.Y += (float)GraphicalElement.PixelOffsetY;

            if (GraphicalElement.Altitude != 0)
                pos1.Y = (float)(pos1.Y + Math.Round(AtouinConstants.CELL_HALF_HEIGHT - (GraphicalElement.Altitude * 10) + GraphicalElement.PixelOffsetY) - AtouinConstants.CELL_HALF_HEIGHT);



            return new Vector2f((float)pos1.X, (float)pos1.Y);
        }
        return new Vector2f(0, 0);
    }
}


public class LayerContent
{

    public List<CellEditor> Cells = new List<CellEditor>();
    public LayerEnum Type;

    public LayerContent()
    {

    }

    public void AddElement(int cellID, Test element, bool ismoussDown = false)
    {
        CellEditor currentCell = null;

        if (!Cells.Any(x => x.CELLID == cellID))
            Cells.Add(new CellEditor(cellID));


        currentCell = Cells.First(x => x.CELLID == cellID);

        if (ismoussDown)
        {
            var elements = currentCell.Elements.Where(x => x.isPreview != true).ToArray();

            if (elements.Length > 0)
            {
                if (elements.Last().GraphicalElement.ElementId != element.GraphicalElement.ElementId)
                    currentCell.AddElement(element);
            }
            else
            {
                currentCell.AddElement(element);
            }

        }
        else
        {
            currentCell.AddElement(element);
        }



    }


    public void RemoveAllPreview()
    {
        foreach (var cell in Cells)
        {
            cell.Elements = cell.Elements.Where(x => x.isPreview == false).ToList();





        }
    }
}

public class CellEditor
{

    private int m_cellID;


    public int CELLID
    {
        get { return m_cellID; }
    }

    public List<Test> Elements
    {
        get { return m_elements; }
        set { m_elements = value; }
    }

    public CellEditor(int cellID)
    {
        m_cellID = cellID;
    }

    private List<Test> m_elements = new List<Test>();

    public void AddElement(Test element)
    {

        if (m_elements.Count > 0 && m_elements.Last().isPreview)
        {
            var dump = m_elements.Last();
            m_elements.Remove(dump);
            m_elements.Add(element);
            m_elements.Add(dump);
        }
        else
        {
            m_elements.Add(element);
        }
    }
}
public class Project
{
    public string Name;
    public int X, Y;


    public bool IsMap()
    {
        return Name == "!map" ? true : false;
    }
}
#endregion

