using ShadowEmu.Common.GameData.Maps;
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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            D2pFile d2p = new D2pFile(AppDomain.CurrentDomain.BaseDirectory + @"\data\d2p");
            int step = 0;
            foreach (var file in d2p.ListD2pFileDlm)
            {

                label1.Invoke((MethodInvoker)delegate {
                    label1.Text = "Chargement des élements : " + step + "/" + d2p.ListD2pFileDlm.Count;
                });


                var elements = file.GetDictionnary();

                bunifuCircleProgressbar1.Invoke((MethodInvoker)delegate {
                    bunifuCircleProgressbar1.Value = 0;
                    bunifuCircleProgressbar1.MaxValue = 100;
                });

                int i = 0;

                foreach (var element in elements)
                {
                    bunifuCircleProgressbar1.Invoke((MethodInvoker)delegate {
                        bunifuCircleProgressbar1.Value = (i * 100) / (elements.Count);
                    });

                    var name = element.Key.Split('/').Last();

                    if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\data\img\" + element.Key.Split('/').Last()))
                    {
                        var bit = file.ReadFile(element.Key);
                        System.IO.File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"\data\img\" + element.Key.Split('/').Last(), bit);
                    }
                    i++;
                }
                step++;
            }

            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\data\init.conf", "");
            Application.Run(new NewUI());
            this.Invoke((MethodInvoker)delegate {
                this.Close();
            });

        }
    }

}
