using DesignEditeurMap.Enums;
using DesignEditeurMap.Manager;
using DesignEditeurMap.View.Map;
using DesignEditeurMap.View.Tiles;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DesignEditeurMap.View
{
    public partial class NewUI : Form
    {
        private System.Windows.Forms.Timer m_timer = new System.Windows.Forms.Timer();

        #region Base SFML
        private RenderWindow m_window = null;
        private SFML.Graphics.View m_view = new SFML.Graphics.View();
        private SFML.Graphics.View m_miniMapview = new SFML.Graphics.View();
        #endregion

        public NewUI()
        {
            InitializeComponent();
            this.dockPanel1.Theme = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
            this.FormClosing += NewUI_FormClosing;
            ShadowEmu.Common.GameData.D2O.ObjectDataManager.Initialize(AppDomain.CurrentDomain.BaseDirectory + @"\data\d2o");
        }

        private void NewUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

            if (File.Exists(configFile))
                File.Delete(configFile);

            dockPanel1.SaveAsXml(configFile);
        }

        SFML.Graphics.Font font = new SFML.Graphics.Font(AppDomain.CurrentDomain.BaseDirectory + @"\data\font.ttf");
        DeserializeDockContent m_deserializeDockContent;
        private void NewUI_Load(object sender, EventArgs e)
        {
            this.Shown += NewUI_Shown; ;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
         
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (File.Exists(configFile))
                dockPanel1.LoadFromXml(configFile, m_deserializeDockContent);
            else
            {
                UIManager.Instance.EditorForm.Show(dockPanel1, DockState.Document);
                UIManager.Instance.TileExplorer.Show(dockPanel1, DockState.DockLeft);
               UIManager.Instance.MapInformation.Show(dockPanel1, DockState.DockBottomAutoHide);
                UIManager.Instance.LayersExplorer.Show(dockPanel1, DockState.DockRight);
            }

            var themes = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
     
            this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, themes);

            UIManager.Instance.EditorForm.ChangePreviewLayer(Enums.LayerEnum.Ground);
            updateLayerSelection(Enums.LayerEnum.Ground);
            
            this.FormClosing += NewUI_FormClosing1;
            UIManager.Instance.EditorForm.ViewBorder = true;

             UIManager.Instance.EditorForm.NewMappProject();
               SaveAuto.Start();
          
    }

    private void NewUI_FormClosing1(object sender, FormClosingEventArgs e)
        {
            UIManager.Instance.EditorForm.Open = false;
        }

        private void NewUI_Shown(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.RegetPreview();
        }

        private void NewUI_GotFocus1(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.RegetPreview();
        }


        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == "DesignEditeurMap.Form2")
                return  UIManager.Instance.EditorForm;
            else if (persistString == "DesignEditeurMap.View.Tiles.TilesExplorer")
                return UIManager.Instance.TileExplorer;
            else if (persistString == "DesignEditeurMap.View.Map.MapInformations")
                return UIManager.Instance.MapInformation;

            return null;
        }

        private void CreateStandardMenu()
        {
            Form2 dummyDoc = CreateNewDocument();
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                dummyDoc.MdiParent = this;
                dummyDoc.Show();
            }
            else
                dummyDoc.Show(dockPanel1);


            Tiles.TilesExplorer tiles = new Tiles.TilesExplorer();
            tiles.RightToLeftLayout = true;

            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                tiles.MdiParent = this;
                tiles.Show();
            }
            else
                tiles.Show(dockPanel1);


        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        
        }

        private Form2 CreateNewDocument()
        {
            return new Form2();
        }

        private WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme mtheme = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();

        public void SetTheme()
        {
            this.dockPanel1.Theme = mtheme;
            this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, mtheme);
        }

        private void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        {
            visualStudioToolStripExtender1.SetStyle(menuStrip1, version, theme);
            visualStudioToolStripExtender1.SetStyle(toolStrip1, version, theme);
        }




        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

            if (File.Exists(configFile))
                File.Delete(configFile);

            dockPanel1.SaveAsXml(configFile);
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.ViewGrid = !UIManager.Instance.EditorForm.ViewGrid;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.ChangePreviewLayer(Enums.LayerEnum.Ground);
            updateLayerSelection(Enums.LayerEnum.Ground);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.ChangePreviewLayer(Enums.LayerEnum.Additional_Ground);
            updateLayerSelection(Enums.LayerEnum.Additional_Ground);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.ChangePreviewLayer(Enums.LayerEnum.Decor);
            updateLayerSelection(Enums.LayerEnum.Decor);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.ChangePreviewLayer(Enums.LayerEnum.Additional_Decor);
            updateLayerSelection(Enums.LayerEnum.Additional_Decor);
        }



        private void updateLayerSelection(Enums.LayerEnum layer)
        {
            if (layer == LayerEnum.Ground)
            {
                this.toolStripButton1.Enabled = true;
                this.toolStripButton2.Enabled = true;
                this.toolStripButton3.Enabled = true;

                this.toolStripButton4.Enabled = false;
            }
            else if (layer == LayerEnum.Additional_Ground)
            {
                this.toolStripButton1.Enabled = true;
                this.toolStripButton2.Enabled = true;
                this.toolStripButton4.Enabled = true;

                this.toolStripButton3.Enabled = false;
            }
            else if (layer == LayerEnum.Decor)
            {
                this.toolStripButton1.Enabled = true;
                this.toolStripButton4.Enabled = true;
                this.toolStripButton3.Enabled = true;

                this.toolStripButton2.Enabled = false;
            }
            else if (layer == LayerEnum.Additional_Decor)
            {
                this.toolStripButton4.Enabled = true;
                this.toolStripButton2.Enabled = true;
                this.toolStripButton3.Enabled = true;

                this.toolStripButton1.Enabled = false;
            }
        }

        private void nouveauToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>   UIManager.Instance.EditorForm.NewMappProject());

        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UINewMap().Show();
 
        }


    
        private bool stopDraw = false;
        private Project mCurrentProject = null;

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bool isProject = CellManagerTest.Instance.Maps.Count > 1;
            if(isProject)
                UIManager.Instance.EditorForm.SaveProject();
            else
                UIManager.Instance.EditorForm.SaveMap();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  UIManager.Instance.EditorForm.OpenProject()
            var openFileDialog1 = new OpenFileDialog();

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                UIManager.Instance.EditorForm.OpenProject(openFileDialog1.FileName);
   
        }

        private void oPENToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          //  var openFileDialog1 = new OpenFileDialog();

          //  DialogResult result = openFileDialog1.ShowDialog();
        //    if (result == DialogResult.OK)
                UIManager.Instance.EditorForm.OpenMap("");
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.ViewBorder = !UIManager.Instance.EditorForm.ViewBorder;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.Mode = OutilsEnum.CellWalkable;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.Mode = OutilsEnum.Paint;
        }
        private bool savePng = false;
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.SavePng();
         
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
       

        }

        private void openOldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                UIManager.Instance.EditorForm.OpenProject(openFileDialog1.FileName, true);
        }

        private void oldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                UIManager.Instance.EditorForm.OpenMap(openFileDialog1.FileName,true);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.Mode = OutilsEnum.TriggerChangeMap;
            resetAllButton();
            toolStripButton10.Enabled = false;
            UIManager.Instance.EditorForm.TypeToChangeMap = TypeChangeMapEnum.Top;
        }



        private void resetAllButton()
        {
            toolStripButton10.Enabled = true;
            toolStripButton11.Enabled = true;
            toolStripButton12.Enabled = true;
            toolStripButton13.Enabled = true;
        }

            private void toolStripButton11_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.Mode = OutilsEnum.TriggerChangeMap;
            resetAllButton();
            toolStripButton11.Enabled = false;
            UIManager.Instance.EditorForm.TypeToChangeMap = TypeChangeMapEnum.Bot;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.Mode = OutilsEnum.TriggerChangeMap;
            resetAllButton();
            toolStripButton12.Enabled = false;
            UIManager.Instance.EditorForm.TypeToChangeMap = TypeChangeMapEnum.Left;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.Mode = OutilsEnum.TriggerChangeMap;
                        resetAllButton();
            toolStripButton13.Enabled = false;
            UIManager.Instance.EditorForm.TypeToChangeMap = TypeChangeMapEnum.Right;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void NewUI_MouseClick(object sender, MouseEventArgs e)
        {
        
        }

        private void SaveAuto_Tick(object sender, EventArgs e)
        {
            bool isProject = CellManagerTest.Instance.Maps.Count > 1;
            if (isProject)
                UIManager.Instance.EditorForm.SaveProject();
            else
                UIManager.Instance.EditorForm.SaveMap();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frfrToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            UIManager.Instance.EditorForm.Mode = OutilsEnum.Selection;
        }
    }




  
}
