using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace Take_A_Trip
{
    public partial class Booking_change : Form
    {
        private object GetUser_Name = Login_Form.GetUser_Name;
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public Booking_change()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string qur = "INSERT INTO User_Message VALUES(@username,@Message)";
            SqlCommand cmd = new SqlCommand(qur, con);
            con.Open();
            cmd.Parameters.AddWithValue("@username", GetUser_Name);
            cmd.Parameters.AddWithValue("@Message", richTextBox1.Text);

            int data_insert = cmd.ExecuteNonQuery();
            con.Close();
            if (data_insert > 0)
            {
                MessageBox.Show("Message Successfully Sent", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
