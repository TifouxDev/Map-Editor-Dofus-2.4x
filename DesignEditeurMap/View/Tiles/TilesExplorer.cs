using DesignEditeurMap.Elements;
using DesignEditeurMap.Manager;
using ShadowEmu.Common.GameData.Maps;
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

namespace DesignEditeurMap.View.Tiles
{
    public partial class TilesExplorer : DockContent
    {
        public TilesExplorer()
        {
            InitializeComponent();
        }

        private void TilesExplorer_Load(object sender, EventArgs e)
        {
            try
            {
                MapsManager.Initialize(AppDomain.CurrentDomain.BaseDirectory + @"\data\maps");

                foreach (var name in TextureManager.Instance.GetAllTilesFolders())
                {
                    TreeNode node2 = new TreeNode("Sols");
                    TreeNode node3 = new TreeNode("Objects");
                    TreeNode[] array = new TreeNode[] { node2, node3 };
                    var  treeNode = new TreeNode(name, array);
                    treeView1.Nodes.Add(treeNode);
                }
            }
            catch(Exception m)
            {

            }

         //UIManager.Instance.EditorForm.Focus();
        }
        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                UIManager.Instance.EditorForm.SelecteTile(e.Item.Text, false, true);
            }
            catch (Exception m)
            {

            }

        }

        private bool waitLoading = false;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var xd = treeView1.SelectedNode;
                if(xd.FullPath.ToLower().Contains("sols"))
                {
                     if (!waitLoading)
                     {
                      Tile tile = TextureManager.Instance.GetTile(e.Node.Parent.Text);
                       Thread myNewThread = new Thread(() => LoadImage(tile, false));
                      myNewThread.Start();
                     }
                }
                else if (xd.FullPath.ToLower().Contains("objects"))
                {
                    if (!waitLoading)
                    {
                        Tile tile = TextureManager.Instance.GetTile(e.Node.Parent.Text);
                        Thread myNewThread = new Thread(() => LoadImage(tile, true));
                        myNewThread.Start();
                    }
                }

            }
            catch (Exception m)
            {

            }
           
        }

        private void LoadImage(Tile tile, bool type)
        {
            Application.DoEvents();
            try
            {
                waitLoading = true;
                if (listView1.InvokeRequired)
                {
                    listView1.BeginInvoke(new Action(delegate ()
                    {
                        listView1.Clear();
                    }));
                }
                else
                    listView1.Clear();

                ImageList il = new ImageList();

                List<ListViewItem> list = new List<ListViewItem>();
                if (!type)
                {
                  
                    bunifuCircleProgressbar1.BeginInvoke(new Action(delegate ()
                    {
                        bunifuCircleProgressbar1.Value = 0;
                        bunifuCircleProgressbar1.MaxValue = tile.Sols.Count - 1;
                        bunifuCircleProgressbar1.Visible = true;
                    }));
                }
                else
                {
     
                    bunifuCircleProgressbar1.BeginInvoke(new Action(delegate ()
                    {
                        bunifuCircleProgressbar1.Value = 0;
                        bunifuCircleProgressbar1.MaxValue = tile.Objects.Count - 1;
                        bunifuCircleProgressbar1.Visible = true;
                    }));
                }
     

                if(!type)
                {
                    for (int i = 0; i < tile.Sols.Count - 1; i++)
                    {
                        bunifuCircleProgressbar1.BeginInvoke(new Action(delegate ()
                        {
                            bunifuCircleProgressbar1.Value = i;
                        }));
                        var element = tile.Sols[i];
                        if (File.Exists(Configuration.Configuration.Instance.TexturePath + element + ".png"))
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromFile(Configuration.Configuration.Instance.TexturePath + element + ".png");

                            il.Images.Add(img);

                            ListViewItem lst = new ListViewItem();
                            lst.Text = element.ToString();
                            lst.ImageIndex = list.Count;

                            list.Add(lst);
                        }
                        else if (File.Exists(Configuration.Configuration.Instance.TexturePath + element + ".jpg"))
                        {
                            il.Images.Add(System.Drawing.Image.FromFile(Configuration.Configuration.Instance.TexturePath + element + ".jpg"));

                            ListViewItem lst = new ListViewItem();
                            lst.Text = element.ToString();
                            lst.ImageIndex = list.Count;

                            list.Add(lst);
                        }
                        Application.DoEvents();
                    }
                }
                else
                {
                    for (int i = 0; i < tile.Objects.Count - 1; i++)
                    {
                        bunifuCircleProgressbar1.BeginInvoke(new Action(delegate ()
                        {
                            bunifuCircleProgressbar1.Value = i;
                        }));
                        var element = tile.Objects[i];
                        if (File.Exists(Configuration.Configuration.Instance.TexturePath + element + ".png"))
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromFile(Configuration.Configuration.Instance.TexturePath + element + ".png");

                            il.Images.Add(img);

                            ListViewItem lst = new ListViewItem();
                            lst.Text = element.ToString();
                            lst.ImageIndex = list.Count;

                            list.Add(lst);
                        }
                        else if (File.Exists(Configuration.Configuration.Instance.TexturePath + element + ".jpg"))
                        {
                            il.Images.Add(System.Drawing.Image.FromFile(Configuration.Configuration.Instance.TexturePath + element + ".jpg"));

                            ListViewItem lst = new ListViewItem();
                            lst.Text = element.ToString();
                            lst.ImageIndex = list.Count;

                            list.Add(lst);
                        }
                        Application.DoEvents();
                    }
                }

          

                if (listView1.InvokeRequired)
                {
                    listView1.BeginInvoke(new Action(delegate ()
                    {
                        listView1.Items.AddRange(list.ToArray());
                        il.ImageSize = new Size(96, 96);
                        listView1.LargeImageList = il;
                    }));
                }
                else
                {
                    listView1.Items.AddRange(list.ToArray());
                    il.ImageSize = new Size(96, 96);
                    listView1.LargeImageList = il;
                }
                bunifuCircleProgressbar1.BeginInvoke(new Action(delegate ()
                {
                    bunifuCircleProgressbar1.Visible = false;
                }));
                waitLoading = false;
            }
            catch (Exception m)
            {

            }
        }
    }
}
