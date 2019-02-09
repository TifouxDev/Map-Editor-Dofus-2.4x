using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DesignEditeurMap.View.Tiles
{
    public partial class LayerExplorer : DockContent
    {
        public LayerExplorer()
        {
            InitializeComponent();
        }

        private void LayerExplorer_Load(object sender, EventArgs e)
        {
            ImageList imgs = new ImageList();

            imgs.ImageSize = new Size(50, 50);
       

            listView1.SmallImageList = imgs;
            listView1.Items.Add("lol", 0);
            listView1.Items.Add("lol", 2);
        }
    }
}
