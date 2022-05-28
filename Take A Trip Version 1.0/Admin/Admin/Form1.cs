using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            panel3.Height = button2.Height;
            panel3.Top = button2.Top;
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            Booking my = new Booking();
            panel3.Top = button1.Top;
            my.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Height = button3.Height;
            Form3 my = new Form3();
            panel3.Top = button3.Top;
            my.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel3.Height = button4.Height;
            Mas my = new Mas();
            panel3.Top = button4.Top;
            my.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
