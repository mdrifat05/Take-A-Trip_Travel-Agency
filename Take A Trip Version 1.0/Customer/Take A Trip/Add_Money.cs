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
namespace Take_A_Trip
{
    public partial class Add_Money : Form
    {
        public static double money;
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
         private object GetUser_Name = Login_Form.GetUser_Name;

        public Add_Money()
        {
            InitializeComponent();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="" && textBox2.Text == "123")
            {
                double w = Convert.ToDouble(this.textBox1.Text);

                money = money + w;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string query = "UPDATE CUSTOMER_DETAILS SET Wallet = @wallet  where Username= @user";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", GetUser_Name);
                cmd.Parameters.AddWithValue("@wallet", money);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Money added Successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Erroe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Money_Load(object sender, EventArgs e)
        {
          
            money = Wallet_Page.Get_Money;
        }
    }
}
