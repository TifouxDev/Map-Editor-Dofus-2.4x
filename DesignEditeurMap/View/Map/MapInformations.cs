using DesignEditeurMap.Attributes;
using DesignEditeurMap.Editor;
using ShadowEmu.Common.Protocol.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DesignEditeurMap.View.Map
{
    public partial class MapInformations : DockContent
    {
    
        public object OldValue
        {
            get;
            set;
        }

        public MapInformations()
        {
            InitializeComponent();

        }

        private void btn_Pin_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void mapInfoGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MapInformations_Load(object sender, EventArgs e)
        {
            //    UpdateGrid();

        }

        private MapEditor mMap = null;
        private Form2 mForm = null;
        Dictionary<string, object> properties = new Dictionary<string, object>();
        public void UpdateGrid(MapEditor map, Form2 test)
        {
            mMap = map;
            mForm = test;
            properties = new Dictionary<string, object>();
            this.mapInfoGrid.Rows.Clear();
            var list = map.GetType().GetFields().Where(x => x.GetCustomAttributes(typeof(Identifier), true).Length > 0).ToArray();
            int index = 0;
            foreach (FieldInfo fieldInfo in list)
            {
                Identifier myAttribute = (Identifier)fieldInfo.GetCustomAttribute(typeof(Identifier), true);
                properties.Add(fieldInfo.Name, fieldInfo.GetValue(map));
                this.mapInfoGrid.Rows.Add(fieldInfo.Name, fieldInfo.GetValue(map));         
                index++;
            }
        }

        private void RefreshInfo()
        {
            var subarea = ShadowEmu.Common.GameData.D2O.ObjectDataManager.Get<SubArea>(mMap.SubAreaId);
            if (subarea == null)
                return;

            var name = UIManager.Instance.D2I.GetText((int)subarea.nameId);
            comboBox1.Items.Clear();
            comboBox1.Items.Add(name);
            comboBox1.SelectedItem = comboBox1.Items[0];
        }



        private void mapInfoGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = mapInfoGrid.Rows[e.RowIndex];
       
            var field = mMap.GetType().GetFields().Where(x => x.GetCustomAttributes(typeof(Identifier), true).Length > 0).FirstOrDefault(x => x.Name == (string)currentRow.Cells[0].Value);


            if (field == null)
                return;

            Identifier myAttribute = (Identifier)field.GetCustomAttribute(typeof(Identifier), true);
            if (!myAttribute.canModify)
            {
                currentRow.Cells[e.ColumnIndex].Value = field.GetValue(mMap);
                return;
            }

            if (e.ColumnIndex != 1)
            {
                currentRow.Cells[e.ColumnIndex].Value = field.Name;
                return;
            }



            if (field.FieldType == typeof(Int32))
            {
                var testd = currentRow.Cells[1].Value;
                field.SetValue(mMap, int.Parse(currentRow.Cells[1].Value.ToString()));
            }

            if (field.Name == "BackgroundColor")
                mForm.ModifBackGroundColor(currentRow.Cells[1].Value.ToString());

            if(field.Name == "BackgroundAlpha")
                mForm.ModifAlphaColor(int.Parse(currentRow.Cells[1].Value.ToString()));

            //     UpdateGrid(mMap);
        }

        private void mapInfoGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
         
       
        }
    }
}
