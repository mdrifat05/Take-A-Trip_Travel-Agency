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
    public partial class Booking : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString);
        public Booking()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string sql = "update Booking_Ticket set username=@username, destination_name=@dn,agency_name=@ag , agency_number=@an , ticket_price=@tk ,bed_room_catagory=@bd , hotel_name=@ht , hotel_number=@hl, booking_price=@bk , total_bill=@tb , person_count=@pc , day_count=@dc ,tour_date=@to where id=@id";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@id", id.Text);
            com.Parameters.AddWithValue("@username", textBox1.Text);
            com.Parameters.AddWithValue("@dn", textBox2.Text);
            com.Parameters.AddWithValue("@ag", textBox3.Text);
            com.Parameters.AddWithValue("@an", textBox4.Text);
            com.Parameters.AddWithValue("@tk", textBox5.Text);
            com.Parameters.AddWithValue("@bd", textBox6.Text);
            com.Parameters.AddWithValue("@ht", textBox7.Text);
            com.Parameters.AddWithValue("@hl", textBox8.Text);
            com.Parameters.AddWithValue("@bk", textBox9.Text);
            com.Parameters.AddWithValue("@tb", textBox10.Text);
            com.Parameters.AddWithValue("@pc", textBox11.Text);
            com.Parameters.AddWithValue("@dc", textBox12.Text);
            com.Parameters.AddWithValue("@to", dateTimePicker1.Value);
            con.Open();
            int a = com.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Details Update Successfully");
                BindGridView();
            }
            else
            {
                MessageBox.Show("Sorry!Not Updated");
            }
            con.Close();
        }

        void BindGridView()
        { 
            string Q = "Select * from Booking_Ticket";
            SqlDataAdapter sda = new SqlDataAdapter(Q, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 20;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            textBox12.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            string qls = "delete from Booking_Ticket where id = @id";
            SqlCommand com = new SqlCommand(qls, con);

            com.Parameters.AddWithValue("@id", textBox13.Text);
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
    }
}
