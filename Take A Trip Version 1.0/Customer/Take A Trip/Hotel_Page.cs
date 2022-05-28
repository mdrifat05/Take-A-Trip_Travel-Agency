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
    public partial class Hotel_Page : Form
    {
        public Hotel_Page()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            FourStar_Hotel ac = new FourStar_Hotel() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ac.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(ac);
            ac.Show();

            Memo_Calculation.Hotel_catagory = "Four Star";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            FiveStar_Hotel ac = new FiveStar_Hotel() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ac.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(ac);
            ac.Show();
            Memo_Calculation.Hotel_catagory = "Five Star";
        }
    }
}
