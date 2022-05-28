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

namespace Take_A_Trip
{
    public partial class Ac_Bus : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public Ac_Bus()
        {
            InitializeComponent();
            Copy_AcBus();
        }
        public void Copy_AcBus()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM Ac_Bus";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Showing details 

            while (dr.Read())
            {
                CopyAcBus c = new CopyAcBus();
                c.Size = new Size(flowLayoutPanel1.Width - 50, c.Height);
                c.label2.Text = dr.GetValue(1).ToString();
                c.label4.Text = dr.GetValue(2).ToString();
                c.label6.Text = dr.GetValue(3).ToString();

                Memo_Calculation.Agency_name = dr.GetValue(1).ToString();
                Memo_Calculation.Agency_number = dr.GetValue(2).ToString();
                Memo_Calculation.Ticket_Price = dr.GetValue(3).ToString();


                c.TopLevel = false;
                c.Visible = true;
                flowLayoutPanel1.Controls.Add(c);
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Transport_Page tp = new Transport_Page() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tp.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(tp);
            tp.Show();
        }
    }
}
