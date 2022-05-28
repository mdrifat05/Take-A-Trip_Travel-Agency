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

namespace Take_A_Trip
{
    public partial class CopyDestination_Form : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public CopyDestination_Form()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Memo_Calculation.Destination_name = button1.Tag.ToString();
            MessageBox.Show("Booking Added");

            //SeaBeach_Page p = new SeaBeach_Page();
            //p.panel1.Controls.Clear();
            //Mountain_Page m = new Mountain_Page();
            //m.panel1.Controls.Clear();
            //Historical_Page h = new Historical_Page();
            //h.panel1.Controls.Clear();
            //Forest_Page f = new Forest_Page();
            //f.panel1.Controls.Clear();

           
            //Transport_Page tp = new Transport_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //tp.FormBorderStyle = FormBorderStyle.None;
            //p.panel1.Controls.Add(tp);
            //m.panel1.Controls.Add(tp);
            //h.panel1.Controls.Add(tp);
            //f.panel1.Controls.Add(tp);
            //tp.Show();


        }
    }
}
