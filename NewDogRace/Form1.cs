using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDogRace
{
    public partial class Form1 : Form
    {
        int inc = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (inc < 100)
            {
                inc += 10;
                pbLoading.Value = inc;
            }
            else
            {
                frmTrack obj = new frmTrack();
                obj.Show();
                tmr.Enabled = false;
                this.Hide();
            }
            

        }
    }
}
