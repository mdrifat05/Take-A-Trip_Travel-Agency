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
    public partial class FiveStar_Hotel : Form
    {
        public FiveStar_Hotel()
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
            RoyalBed_FiveStar hp = new RoyalBed_FiveStar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(hp);
            hp.Show();
            Memo_Calculation.Bed_RoomCatagory = "Royal Bed Room";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            MotelBed_FiveStar hp = new MotelBed_FiveStar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(hp);
            hp.Show();
            Memo_Calculation.Bed_RoomCatagory = "Motel Bed Room";
        }
    }
}
