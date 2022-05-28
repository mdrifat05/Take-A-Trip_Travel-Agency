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
using System.Runtime.InteropServices;
using Staff_panel;
using WindowsFormsApplication1;

namespace Take_A_Trip
{
    public partial class Login_Form : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
             int nHeightEllipse
        );
        public static object GetUser_Name;
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public Login_Form()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "username")
            {
                textBox1.Text = "";
            }
            else
            {

            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "password")
            {
                textBox2.Text = "";
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SignUp_Customer sf = new SignUp_Customer();
            this.Hide();
            sf.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;

            if (status == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.error;
                errorProvider1.SetError(this.textBox1, "Enter your username");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.check;
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox2, "Enter your Password");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Customer login
            if (comboBox1.SelectedIndex > -1)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (comboBox1.SelectedItem.ToString() == "Customer")
                    {
                        SqlConnection con = new SqlConnection(cs);
                        string query = "SELECT * FROM CUSTOMER_DETAILS where Username= @user and Pass = @pass";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@user", textBox1.Text);
                        cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            MessageBox.Show("Login Successful !!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetUser_Name = textBox1.Text;
                            Customer_Dashboard cd = new Customer_Dashboard();
                            this.Hide();
                            cd.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login Failed! Incorrect username & password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter username and password.", "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Please select user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //Staff login
            if (comboBox1.SelectedIndex > -1)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (comboBox1.SelectedItem.ToString() == "Staff")
                    {
                        SqlConnection con = new SqlConnection(cs);
                        string query = "SELECT * FROM STAFF_DETAILS where staff_Username= @user and Staff_Pass = @pass";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@user", textBox1.Text);
                        cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            MessageBox.Show("Login Successful !!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetUser_Name = textBox1.Text;
                            StaffHome_Page cd = new StaffHome_Page();
                            this.Hide();
                            cd.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login Failed! Incorrect username & password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter username and password.", "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            else
            {
                MessageBox.Show("Please select user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Admin login
            if (comboBox1.SelectedIndex > -1)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (comboBox1.SelectedItem.ToString() == "Admin")
                    {
                        if (textBox1.Text == "admin" && textBox2.Text == "takeatrip")
                        {
                            MessageBox.Show("Login Successful !!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form1 f = new Form1();
                            this.Hide();
                            f.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login Failed! Incorrect username & password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter username and password.", "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
