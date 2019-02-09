using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignEditeurMap
{
    public partial class TestUI : Form
    {
        public TestUI()
        {
            InitializeComponent();
        }

        private void TestUI_Load(object sender, EventArgs e)
        {
            var u1 = new Form2();
            u1.Dock = DockStyle.Fill;
            this.Controls.Add(u1);
        }
    }
}
