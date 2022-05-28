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
    public partial class Hills : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;


        public Hills()
        {
            InitializeComponent();
            BindGridView();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //upload picture button..........................................
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All files *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Add button....................................
            if(textBox1.Text=="" && richTextBox1.Text == "")
            {
                MessageBox.Show("Fill up all the information");
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Mountain values(@P_name, @Data, @pic)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@P_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Data", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@pic", saveImage());

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

        private byte[] saveImage()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM Mountain";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // reset button.......................
            ResetControll();
        }

        void ResetControll()
        {
            textBox1.Clear();
            richTextBox1.Clear();
            pictureBox1.Image = Properties.Resources.pngtree_vector_gallery_icon_png_image_515223;
        }










        /*private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           

        }*/


       

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Edit button...............................

            SqlConnection con = new SqlConnection(cs);
            string query = "update Mountain set P_Name = @P_name, P_des = @Data, P_Picture = @pic where P_Name = @P_name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@P_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Data", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@pic", saveImage());

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

        private void button6_Click(object sender, EventArgs e)
        {
            // Delete button...........................................
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Mountain where P_Name = @P_name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@P_name", textBox1.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Deleted Successfully!");
                BindGridView();
                ResetControll();
            }
            else
            {
                MessageBox.Show("error !!");
            }
            con.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[3].Value);
        }
    }
}
