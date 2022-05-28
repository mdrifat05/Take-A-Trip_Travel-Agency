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
    public partial class Blog : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public Blog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //upload picture button..........................................
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All files *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                iconPictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Add button....................................
            if (textBox1.Text == "" && richTextBox1.Text == "")
            {
                MessageBox.Show("Fill up all the information");
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Blog values(@Blog_Title, @Blog_Description, @Blog_Picture)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Blog_Title", textBox1.Text);
                cmd.Parameters.AddWithValue("@Blog_Description", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@Blog_Picture", saveImage());

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Insert Successfull !!");
                    ResetControll();
                }
                else
                {
                    MessageBox.Show("error!!!!!!!");
                }
                con.Close();
            }
          
          
        }
        private byte[] saveImage()
        {
            MemoryStream ms = new MemoryStream();
            iconPictureBox1.Image.Save(ms, iconPictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        void ResetControll()
        {
            textBox1.Clear();
            richTextBox1.Clear();
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.GlobeAsia;
        }
    }
}
