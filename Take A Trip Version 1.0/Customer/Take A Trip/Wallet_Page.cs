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
    
    public partial class Wallet_Page : Form
    {
        public static string nofpersonstr = "";
        public static int person_Count = 1;
        public static double Get_Money;
        public static int StayingDay_Count = 1;

        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        private object GetUser_Name = Login_Form.GetUser_Name;
        public Wallet_Page()
        {
            InitializeComponent();
            Memo_frame c = new Memo_frame();
            c.Size = new Size(flowLayoutPanel1.Width - 50, c.Height);
            c.TopLevel = false;
            c.Visible = true;
            flowLayoutPanel1.Controls.Add(c);

            Show_Wallet();
           
        }

        private void Show_Wallet()
        {
           
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM CUSTOMER_DETAILS where Username = @user";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", GetUser_Name);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
              
                label1.Text = dr.GetValue(10).ToString();
                Get_Money = Convert.ToDouble(label1.Text);
            }

            con.Close();
        }


        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            nofpersonstr = numericUpDown1.Value.ToString();
            person_Count = Convert.ToInt32(nofpersonstr);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime departure = dateTimePicker1.Value.Date;
            DateTime arrival = dateTimePicker2.Value.Date;

            TimeSpan ts = arrival - departure;

             int days = ts.Days;

            label5.Text = days.ToString();
            StayingDay_Count = days;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add_Money am = new Add_Money();
            am.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking_History b = new Booking_History();
            b.Show();
        }
    }
}
