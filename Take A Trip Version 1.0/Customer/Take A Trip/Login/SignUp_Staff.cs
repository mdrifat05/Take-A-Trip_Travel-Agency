using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace Take_A_Trip
{
    public partial class SignUp_Staff : Form
    {
        string fgender = "";
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public SignUp_Staff()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SignUp_Customer sc = new SignUp_Customer();
            this.Hide();
            sc.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            SignUp_Customer sc = new SignUp_Customer();
            this.Close();
            sc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All File *.*|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || pictureBox2.Image == Properties.Resources.dummy_pic || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Please Fill up all the fields", "Application failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Your Confirm Password did not Match", "Application failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "INSERT INTO STAFF_DETAILS VALUES(@Name,@Username,@Pass,@Confirm_Pass,@Phone_Number,@Email,@Date_Of_Birth,@Gender,@Img)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Username", textBox2.Text);
                cmd.Parameters.AddWithValue("@Pass", textBox3.Text);
                cmd.Parameters.AddWithValue("@Confirm_Pass", textBox4.Text);
                cmd.Parameters.AddWithValue("@Phone_Number", textBox5.Text);
                cmd.Parameters.AddWithValue("@Email", textBox6.Text);
                cmd.Parameters.AddWithValue("@Date_Of_Birth", Convert.ToDateTime(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@Gender", fgender);
                cmd.Parameters.AddWithValue("@Img", SavePhoto());

                con.Open();
                //check same username exists in the database
                bool Exists = false;
                string query2 = "select count(*) from STAFF_DETAILS where Staff_Username = @Username";
                SqlCommand cm = new SqlCommand(query2, con);
                cm.Parameters.AddWithValue("Username", textBox2.Text);
                Exists = (int)cm.ExecuteScalar() > 0;
                if (Exists)
                {
                    MessageBox.Show("This username has been using by another user.");
                    return;
                }


                int data_insert = cmd.ExecuteNonQuery();
                con.Close();

                if (data_insert > 0)
                {
                    MessageBox.Show("Your Request has been Successfully Submitted! Remember your password", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Your Request is not submitted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms,pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string reset = "";
            textBox1.Text = reset;
            textBox2.Text = reset;
            textBox3.Text = reset;
            textBox4.Text = reset;
            textBox5.Text = reset;
            textBox6.Text = reset;
            dateTimePicker1.Text = reset;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox2.Image = Properties.Resources.dummy_pic;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                errorProvider1.Icon = Properties.Resources.error;
                errorProvider1.SetError(this.textBox3, "Enter your password");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.check;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox4, "Enter Password for Confirm");
            }
            else if (textBox3.Text != textBox4.Text)
            {
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox4, "Incorrect Confirm Password");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
                errorProvider2.SetError(this.textBox4, "Correct Confirm Password");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fgender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fgender = "Female";
        }
    }
}

