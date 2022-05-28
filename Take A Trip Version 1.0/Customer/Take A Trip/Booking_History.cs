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
    public partial class Booking_History : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        private object GetUser_Name = Login_Form.GetUser_Name;
        public Booking_History()
        {
            InitializeComponent();
            Booking_history();
        }
        private void Booking_history()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM Booking_Ticket where username = @user";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", GetUser_Name);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();


            //Showing user details 
            while (dr.Read())
            {
                 History m = new History();
                m.Size = new Size(flowLayoutPanel1.Width - 50, m.Height);
                m.label22.Text = dr.GetValue(1).ToString();
                m.label2.Text = dr.GetValue(2).ToString();
                m.label4.Text = dr.GetValue(3).ToString();
                m.label6.Text = dr.GetValue(4).ToString();
                m.label8.Text = dr.GetValue(5).ToString();
                m.label10.Text = dr.GetValue(6).ToString();
                m.label12.Text = dr.GetValue(7).ToString();
                m.label14.Text = dr.GetValue(8).ToString();
                m.label16.Text = dr.GetValue(9).ToString();
                m.label18.Text = dr.GetValue(10).ToString();
                m.label19.Text = dr.GetValue(11).ToString();
                m.label20.Text = dr.GetValue(12).ToString();
                m.label23.Text = dr.GetValue(13).ToString();

                m.TopLevel = false;
                m.Visible = true;
                flowLayoutPanel1.Controls.Add(m);
            }
            con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
