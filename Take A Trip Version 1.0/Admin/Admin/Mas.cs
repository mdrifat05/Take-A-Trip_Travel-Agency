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

namespace WindowsFormsApplication1
{
    public partial class Mas : Form
    {
        public Mas()
        {
            InitializeComponent();
            BindGridView();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString);
            string Q = "Select * from  User_Message";
            SqlDataAdapter sda = new SqlDataAdapter(Q, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString);
            string qls = "delete from User_Message where username = @username";
            SqlCommand com = new SqlCommand(qls, con);
            com.Parameters.AddWithValue("@username", textBox1.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
