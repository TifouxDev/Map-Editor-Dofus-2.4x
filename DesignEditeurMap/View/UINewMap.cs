using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignEditeurMap.View
{
    public partial class UINewMap : Form
    {
        public UINewMap()
        {
            InitializeComponent();
        }

        private void UINewMap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => UIManager.Instance.EditorForm.NewProjet(textBox1.Text, (int)this.numericUpDown1.Value, (int)this.numericUpDown2.Value, this));
          
        }
    }
}
