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
    public partial class Blog_Page : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public Blog_Page()
        {
            InitializeComponent();
            Copy_Blog();
        }
        public void Copy_Blog()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM Blog";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Showing user details 

            while (dr.Read())
            {
                Copy_Blog c = new Copy_Blog();
                c.Size = new Size(flowLayoutPanel1.Width - 50, c.Height);
                c.label1.Text = dr.GetValue(1).ToString();
                c.label2.Text = dr.GetValue(2).ToString();

                c.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                try
                {
                    c.pictureBox1.Image = getPhoto((byte[])dr.GetValue(3));
                }

                catch (System.InvalidCastException)
                {
                    // c.pictureBox1.Image = Properties.Resources.dummy_pic;
                }


                c.TopLevel = false;
                c.Visible = true;
                flowLayoutPanel1.Controls.Add(c);
            }
            con.Close();
        }
        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
    }
}
