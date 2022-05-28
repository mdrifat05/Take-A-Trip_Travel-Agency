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
    public partial class FourStar_Hotel : Form
    {
        public FourStar_Hotel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Hotel_Page hp = new Hotel_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(hp);
            hp.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            SingleBed_4Star hp = new SingleBed_4Star() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(hp);
            hp.Show();
            Memo_Calculation.Bed_RoomCatagory = "Single Bed Room";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
           DuelBed_4Star hp = new DuelBed_4Star() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(hp);
            hp.Show();
            Memo_Calculation.Bed_RoomCatagory = "Dual Bed Room";
        }
    }
}
