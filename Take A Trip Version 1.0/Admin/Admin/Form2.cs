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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString);
        public Form2()
        {
            InitializeComponent();
            BindGridView();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString);
            string Q = "Select * from CUSTOMER_DETAILS";
            SqlDataAdapter sda = new SqlDataAdapter(Q, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[11];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
          ;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ABC"].ConnectionString);
            string Q = "Select * from CUSTOMER_DETAILS";
            SqlDataAdapter sda = new SqlDataAdapter(Q, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[11];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;*/
        }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
             dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
             GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[11].Value);

        }
        private Image GetPhoto(byte[] p)
        {
            MemoryStream ms = new MemoryStream(p);
            return Image.FromStream(ms);
        }
            

        private void label2_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ABC"].ConnectionString);
            con.Open();
            string qls = "delete from CUSTOMER_DETAILS";
            SqlCommand com = new SqlCommand(qls, con);
            /*com.Parameters.AddWithValue("@id", textBox2.Text);
            int result = com.ExecuteNonQuery();
             *  con.Close();
            */
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            string qls = "delete from CUSTOMER_DETAILS where id = @id";
            SqlCommand com = new SqlCommand(qls, con);

            com.Parameters.AddWithValue("@id", textBox1.Text);
            con.Open();
            int result = com.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Deleted");
                BindGridView();
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
