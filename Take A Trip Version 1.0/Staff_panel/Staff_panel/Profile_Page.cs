using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Staff_panel
{
    public partial class Profile_Page : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        private static object GetUser_Name = "kabir";
        public Profile_Page()
        {
            InitializeComponent();
            User_ProfileInfo();
            TextBox_Disable();
        }


        //.........................................................
        private void User_ProfileInfo()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM STAFF_DETAILS where Staff_Username = @user";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", GetUser_Name);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();


            //Showing user details 
            if (dr.HasRows == true)
            {
                dr.Read();
                textBox1.Text = dr.GetValue(1).ToString();
                dateTimePicker1.Text = dr.GetValue(7).ToString();
                comboBox1.Text = dr.GetValue(8).ToString();
                textBox3.Text = dr.GetValue(6).ToString();
                textBox4.Text = dr.GetValue(5).ToString();
                this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                try
                {
                    this.iconPictureBox1.Image = getPhoto((byte[])dr.GetValue(9));
                }

                catch (System.InvalidCastException)
                {
                    this.iconPictureBox1.Image = Properties.Resources.iyyyyyyyyyyyyyystockphoto_1179573547_170667a;
                }

            }

            con.Close();
        }

        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private void TextBox_Disable()
        {
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

    }
}
