using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Take_A_Trip
{
    public partial class Customer_Dashboard : Form
    {
        private object GetUser_Name = Login_Form.GetUser_Name;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
             int nHeightEllipse
        );

        public Customer_Dashboard()
        {
            InitializeComponent();
            label1.Text = GetUser_Name.ToString();
            //label1.TextAlign = ContentAlignment.MiddleCenter;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            Hide_PanelBotton();
            button1.BackColor = Color.FromArgb(46, 51, 73);
            Panel_Hide();
            Hide_PanelBotton();
            button1.BackColor = Color.FromArgb(46, 51, 73);
            label3.Text = "Home Page";
            this.panel3.Controls.Clear();
            Home_Page hp = new Home_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hp.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(hp);
            hp.Show();

        }
        private void Panel_Hide()
        {
            flowLayoutPanel2.Visible = false;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Hide_PanelBotton()
        {
            if (flowLayoutPanel2.Visible == true)
            {
                flowLayoutPanel2.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                Hide_PanelBotton();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Hide_PanelBotton();
            button1.BackColor = Color.FromArgb(46, 51, 73);
            button2.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button6.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            label3.Text = "Home Page";
            this.panel3.Controls.Clear();
            Home_Page hp = new Home_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hp.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(hp);
            hp.Show();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            showSubMenu(flowLayoutPanel2);
            button3.BackColor = Color.FromArgb(46, 51, 73);
            label3.Text = "Destination Page";
            this.panel3.Controls.Clear();
            Destination_Page dp = new Destination_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dp.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(dp);
            dp.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Hide_PanelBotton();
            button1.BackColor = Color.FromArgb(24, 30, 54);
            button2.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button6.BackColor = Color.FromArgb(46, 51, 73);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            label3.Text = "Wallet Page";
            this.panel3.Controls.Clear();
            Wallet_Page wp = new Wallet_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            wp.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(wp);
            wp.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide_PanelBotton();
            button1.BackColor = Color.FromArgb(24, 30, 54);
            button2.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button6.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(46, 51, 73);
            label3.Text = "Blog Page";
            this.panel3.Controls.Clear();
            Blog_Page bp = new Blog_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            bp.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(bp);
            bp.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Hide_PanelBotton();
            label3.Text = "Contact us Page";
            this.panel3.Controls.Clear();
            ContactUs_Page cp = new ContactUs_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            cp.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(cp);
            cp.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(24, 30, 54);
            button2.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(46, 51, 73);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button6.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            label3.Text = "Destination Page";
            this.panel3.Controls.Clear();
            Destination_Page dp = new Destination_Page(){ Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dp.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(dp);
            dp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(24, 30, 54);
            button2.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(46, 51, 73);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button6.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            label3.Text = "Transport Page";
            this.panel3.Controls.Clear();
            Transport_Page tp = new Transport_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tp.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(tp);
            tp.Show();
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(24, 30, 54);
            button2.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(46, 51, 73);
            button6.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            label3.Text = "Hotel Page";
            this.panel3.Controls.Clear();
            Hotel_Page hpp = new Hotel_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            hpp.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(hpp);
            hpp.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label3.Text = "User Profile Page";
            this.panel3.Controls.Clear();
            UserProfile_page up = new UserProfile_page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            up.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(up);
            up.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login_Form lf = new Login_Form();
            this.Hide();
            lf.Show();
        }

        private void Customer_Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
