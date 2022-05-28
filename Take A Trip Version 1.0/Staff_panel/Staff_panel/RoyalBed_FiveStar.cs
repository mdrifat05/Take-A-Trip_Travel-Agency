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
namespace Staff_panel
{
    public partial class RoyalBed_FiveStar : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;

        public RoyalBed_FiveStar()
        {
            InitializeComponent();
            BindGridView();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM RoyalBed_FiveStar";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 25;
        }
        void ResetControll()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            pictureBox2.Image = Properties.Resources.pngtree_vector_gallery_icon_png_image_515223;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add T..............................................
            if(textBox1.Text ==""&& textBox2.Text =="" && textBox3.Text == "")
            {
                MessageBox.Show("Fill up all the information");
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into RoyalBed_FiveStar values(@Hotel_Name, @Hotel_Number, @Hotel_Price, @Hotel_Picture)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Hotel_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Hotel_Number", textBox3.Text);
                cmd.Parameters.AddWithValue("@Hotel_Price", textBox2.Text);
                cmd.Parameters.AddWithValue("@Hotel_Picture", saveImage());

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Insert Successfull !!");
                    BindGridView();
                    ResetControll();
                }
                else
                {
                    MessageBox.Show("error !!");
                }
                con.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //reset button.................................................
            ResetControll();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //. Update..............................
            if(textBox1.Text =="" && textBox2.Text=="" && textBox3.Text == "")
            {
                MessageBox.Show("Fill up all the information");
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "update  RoyalBed_FiveStar set Hotel_Name = @H_name, Hotel_Number = @H_num, Hotel_Price = @H_Price, Hotel_Picture = @H_pic where Hotel_Name = @H_name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@H_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@H_num", textBox3.Text);
                cmd.Parameters.AddWithValue("@H_Price", textBox2.Text);
                cmd.Parameters.AddWithValue("@H_pic", saveImage());

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Updated Successfully!");
                    BindGridView();
                    ResetControll();
                }
                else
                {
                    MessageBox.Show("error !!");
                }
                con.Close();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //upload picture button..........................................
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All files *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }
        private byte[] saveImage()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Delete button...........................................
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from RoyalBed_FiveStar where Hotel_Name = @H_name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@H_name", textBox1.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Deleted Successfully !");
                BindGridView();
                ResetControll();
            }
            else
            {
                MessageBox.Show("error !");
            }
            con.Close();
        }

     
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            pictureBox2.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[4].Value);
        }
    }
}
