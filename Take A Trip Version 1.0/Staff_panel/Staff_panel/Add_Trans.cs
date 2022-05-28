using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace Staff_panel
{
    public partial class Add_Trans : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;

        public Add_Trans()
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
            panel1.Controls.Add(childform);
            panel1.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AcBus());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AcBus());
        }
    }
}
