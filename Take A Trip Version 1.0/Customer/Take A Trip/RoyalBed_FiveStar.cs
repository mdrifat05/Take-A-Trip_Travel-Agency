﻿using System;
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
    public partial class RoyalBed_FiveStar : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public RoyalBed_FiveStar()
        {
            InitializeComponent();
            Copy_BedRoomDesign();
        }

        public void Copy_BedRoomDesign()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM RoyalBed_FiveStar";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Showing user details 

            while (dr.Read())
            {
                CopyRoomDesign c = new CopyRoomDesign();
                c.Size = new Size(flowLayoutPanel1.Width - 50, c.Height);
                c.label2.Text = dr.GetValue(1).ToString();
                c.label4.Text = dr.GetValue(2).ToString();
                c.label6.Text = dr.GetValue(3).ToString();

                //c.button1.Tag = dr.GetValue(1).ToString();

                c.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                try
                {
                    c.pictureBox1.Image = getPhoto((byte[])dr.GetValue(4));
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            FiveStar_Hotel nc = new FiveStar_Hotel() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            nc.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(nc);
            nc.Show();
        }
    }
}
