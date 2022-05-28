using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_A_Trip
{
    public partial class Transport_Page : Form
    {
        public Transport_Page()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Ac_Bus ac = new Ac_Bus() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ac.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(ac);
            ac.Show();
            Memo_Calculation.Bus_catagory = "AC";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            NoneAC_Bus nc = new NoneAC_Bus(){ Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            nc.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(nc);
            nc.Show();
            Memo_Calculation.Bus_catagory = "None AC";
        }
    }
}
