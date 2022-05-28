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
    public partial class SignUp_Customer : Form
    {
        double wallet = 0;
        string gender = "";
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public SignUp_Customer()
        {
            InitializeComponent();
            pictureBox2.Visible = false;
            this.pictureBox2.Image = Properties.Resources.dummy_pic;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Staff")
            {
                SignUp_Staff ss = new SignUp_Staff();
                this.Hide();
                ss.Show();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login_Form lf = new Login_Form();
            this.Hide();
            lf.Show();
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                errorProvider1.Icon = Properties.Resources.check;
                errorProvider1.SetError(this.comboBox1, "user type selected");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.error;
                errorProvider1.SetError(this.comboBox1, "Please select user type");
            }
        }
        private void SignUp_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == ""|| (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Please Fill up the fileds", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Incorrect Confirm Password", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "INSERT INTO CUSTOMER_DETAILS VALUES(@User_Type,@Name,@Username,@Pass,@Confirm_Pass,@Phone_Number,@Email,@Date_Of_Birth,@Gender,@Wallet,@Picture)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@User_Type", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Username", textBox2.Text);
                cmd.Parameters.AddWithValue("@Pass", textBox3.Text);
                cmd.Parameters.AddWithValue("@Confirm_Pass", textBox4.Text);
                cmd.Parameters.AddWithValue("@Phone_Number", textBox5.Text);
                cmd.Parameters.AddWithValue("@Email", textBox6.Text);
                cmd.Parameters.AddWithValue("@Date_Of_Birth", Convert.ToDateTime(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@Picture", SavePhoto());
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Wallet", wallet);
               
                //check same username exists in the database
                bool exists = false;
                string query2 = "select count(*) from CUSTOMER_DETAILS where Username = @Username";
                SqlCommand cm = new SqlCommand(query2, con);
                cm.Parameters.AddWithValue("Username", textBox2.Text);
                exists = (int)cm.ExecuteScalar() > 0;
                if (exists)
                {
                    MessageBox.Show("This username has been using by another user.");
                    return;
                }


                int data_insert = cmd.ExecuteNonQuery();
                con.Close();
                if (data_insert > 0)
                {
                    MessageBox.Show("Your Account has been Successfully Created! Remember your password", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registration Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string reset = "";

            if (comboBox1.SelectedIndex != 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            textBox1.Text = reset;
            textBox2.Text = reset;
            textBox3.Text = reset;
            textBox4.Text = reset;
            textBox5.Text = reset;
            textBox6.Text = reset;
            dateTimePicker1.Text = reset;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox3, "Enter your password");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
            }
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                errorProvider3.Icon = Properties.Resources.error;
                errorProvider3.SetError(this.textBox4, "Enter Password for Confirm");
            }
            else if (textBox3.Text != textBox4.Text)
            {
                errorProvider3.Icon = Properties.Resources.error;
                errorProvider3.SetError(this.textBox4, "Incorrect Confirm Password");
            }
            else
            {
                errorProvider3.Icon = Properties.Resources.check;
                errorProvider3.SetError(this.textBox4, "Correct Confirm Password");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }
    }
}
