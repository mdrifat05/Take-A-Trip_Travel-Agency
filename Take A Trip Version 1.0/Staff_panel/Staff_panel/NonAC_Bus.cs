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
    public partial class NonAC_Bus : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public NonAC_Bus()
        {
            InitializeComponent();
            BindGridView();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM NoneAC_Bus";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 25;
        }
        void ResetControll()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Add T..............................................
            if(textBox1.Text=="" && textBox2.Text =="" && textBox3.Text == "")
            {
                MessageBox.Show("fill up all the information");
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into NoneAC_Bus values(@T_Name, @T_Number, @T_price)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@T_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@T_Number", textBox3.Text);
                cmd.Parameters.AddWithValue("@T_price", textBox2.Text);

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
        private void button2_Click(object sender, EventArgs e)
        {
                    //. Update..............................
                    SqlConnection con = new SqlConnection(cs);
                    string query = "update NoneAC_Bus set T_Name = @T_name, T_Number = @T_Number, T_Price = @T_price where T_Name = @T_name";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@T_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@T_Number", textBox3.Text);
                    cmd.Parameters.AddWithValue("@T_price", textBox2.Text);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Data Updated Successfully !");
                        BindGridView();
                        ResetControll();
                    }
                    else
                    {
                        MessageBox.Show("error !!");
                    }
                    con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //reset button.................................................
            ResetControll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete ..................................
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from NoneAC_Bus where T_Name = @T_name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@T_name", textBox1.Text);


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
                MessageBox.Show("error !");
            }
            con.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
