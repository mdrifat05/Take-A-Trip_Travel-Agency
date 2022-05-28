using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_panel
{
    public partial class Add_Des : Form
    {
        public Add_Des()
        {
            InitializeComponent();
        }


        //........................................................................
        private Form activeForm = null;
        private void OpenChildForm(Form childform)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panelDes.Controls.Add(childform);
            panelDes.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new H_plac());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forest());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Hills());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Sea());
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        //.......................................................



    }
}
