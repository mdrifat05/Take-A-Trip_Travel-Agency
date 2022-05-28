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
    public partial class UserProfile_page : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
         private object GetUser_Name = Login_Form.GetUser_Name;
      // private object GetUser_Name = "rifa";
        public UserProfile_page()
        {
            InitializeComponent();
            TextBox_Disable();
            User_ProfileInfo();
        }

        private void User_ProfileInfo()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM CUSTOMER_DETAILS where Username = @user";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", GetUser_Name);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            

            //Showing user details 
            if (dr.HasRows == true)
            {
                dr.Read();
                textBox1.Text = dr.GetValue(2).ToString();
                dateTimePicker1.Text = dr.GetValue(8).ToString();
                comboBox1.Text = dr.GetValue(9).ToString();
                textBox2.Text = dr.GetValue(7).ToString();
                textBox3.Text = dr.GetValue(6).ToString();
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                try 
                { 
                    this.pictureBox1.Image = getPhoto((byte[])dr.GetValue(11)); 
                }

                catch (System.InvalidCastException) 
                { 
                    this.pictureBox1.Image = Properties.Resources.dummy_pic; 
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
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button3.Visible = false;
            button1.Visible = false;
        }

        private void TextBox_Edit()
        {
            textBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button3.Visible  =  true;
            button1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox_Edit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All File *.*|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string query = "UPDATE CUSTOMER_DETAILS SET Name = @Name, Date_Of_Birth = @Date_Of_Birth, Gender = @Gender, Email = @Email, Phone_Number = @Phone_Number, Picture = @Picture where Username= @user";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", GetUser_Name);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Date_Of_Birth", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                cmd.Parameters.AddWithValue("@Phone_Number", textBox3.Text);
                cmd.Parameters.AddWithValue("@Picture", SavePhoto());

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your information Saved Successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
    }
}
