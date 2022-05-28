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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            BindGridView();
        }

        private byte[] Savephoto()
        {
            MemoryStream ms = new MemoryStream();
            return ms.GetBuffer();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString);
            string Q = "Select * from STAFF_DETAILS";
            SqlDataAdapter sda = new SqlDataAdapter(Q, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[9];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
        
        }

    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString);
            string qls = "delete from STAFF_DETAILS where id = @id";
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
