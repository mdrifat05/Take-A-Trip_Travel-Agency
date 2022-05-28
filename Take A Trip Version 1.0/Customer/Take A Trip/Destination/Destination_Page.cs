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
    public partial class Destination_Page : Form
    {
        public Destination_Page()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            this.panel1.Controls.Clear();
            SeaBeach_Page sp = new SeaBeach_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            sp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(sp);
            sp.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Mountain_Page mp = new Mountain_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            mp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(mp);
            mp.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Forest_Page fp = new Forest_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            fp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(fp);
            fp.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Historical_Page hp = new Historical_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(hp);
            hp.Show();
        }
    }
}
