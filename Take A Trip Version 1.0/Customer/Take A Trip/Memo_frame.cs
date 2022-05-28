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
    public partial class Memo_frame : Form
    {
        private object GetUser_Name = Login_Form.GetUser_Name;
        string cs = ConfigurationManager.ConnectionStrings["TakeATrip"].ConnectionString;
        public double total_bill = 0;
        public int nop = Wallet_Page.person_Count;
        public int sdc = Wallet_Page.StayingDay_Count;

        public Memo_frame()
        {
          
            InitializeComponent();
            label2.Text = Memo_Calculation.Destination_name;
                
            //for AC bus 
                label4.Text = Memo_Calculation.Agency_name + " Catagory " + Memo_Calculation.Bus_catagory;
                label6.Text = Memo_Calculation.Agency_number;
                label8.Text = Memo_Calculation.Ticket_Price;
            //for None AC bus 
                label4.Text = Memo_Calculation.Agency_name + " Catagory " + Memo_Calculation.Bus_catagory;
                label6.Text = Memo_Calculation.Agency_number;
                label8.Text = Memo_Calculation.Ticket_Price;
            //for None AC bus 
                label10.Text = Memo_Calculation.Bed_RoomCatagory + " Hotel "+ Memo_Calculation.Hotel_catagory;
                label12.Text = Memo_Calculation.Hotel_name;
                label14.Text = Memo_Calculation.Hotel_number;
                label16.Text = Memo_Calculation.Booking_price;
                label19.Text = " number of ticket "+nop;
                label20.Text = " booking day count " + sdc;
            try
            {
                total_bill = (Convert.ToDouble(label8.Text ?? "0")* nop) + (Convert.ToDouble(label16.Text ?? "0")*sdc);
                label18.Text = total_bill.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Wallet_Page.Get_Money > 0)
            {
                if (total_bill <= Wallet_Page.Get_Money)
                {
                    SqlConnection con = new SqlConnection(cs);
                    Wallet_Page w = new Wallet_Page();


                        string qur = "INSERT INTO Booking_Ticket VALUES(@username,@Destination_Name,@Agency_Name,@Agency_Number,@Ticket_Price,@Bed_Room_Catagory,@Hotel_Name,@Hotel_Number,@Booking_Price,@Total_Bill,@Person_Count,@Day_Count,@Tour_Date)";
                        SqlCommand cm = new SqlCommand(qur, con);
                        con.Open();
                        cm.Parameters.AddWithValue("@username", GetUser_Name);
                        cm.Parameters.AddWithValue("@Destination_Name", label2.Text);
                        cm.Parameters.AddWithValue("@Agency_Name", label4.Text);
                        cm.Parameters.AddWithValue("@Agency_Number", label6.Text);
                        cm.Parameters.AddWithValue("@Ticket_Price", label8.Text);
                        cm.Parameters.AddWithValue("@Bed_Room_Catagory", label10.Text);
                        cm.Parameters.AddWithValue("@Hotel_Name", label12.Text);
                        cm.Parameters.AddWithValue("@Hotel_Number", label14.Text);
                        cm.Parameters.AddWithValue("@Booking_Price", label16.Text);
                        cm.Parameters.AddWithValue("@Total_Bill", label18.Text);
                        cm.Parameters.AddWithValue("@Person_count", label19.Text);
                        cm.Parameters.AddWithValue("@Day_Count", label20.Text);
                        cm.Parameters.AddWithValue("@Tour_Date",(w.dateTimePicker1.Value));


                    Wallet_Page.Get_Money = Wallet_Page.Get_Money - total_bill;
                       
                       
                        string query = "UPDATE CUSTOMER_DETAILS SET Wallet = @wallet  where Username= @user";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@user", GetUser_Name);
                        cmd.Parameters.AddWithValue("@wallet", Wallet_Page.Get_Money);
                        cmd.ExecuteNonQuery();

                    int  data_insert = cm.ExecuteNonQuery();
                    con.Close();
                    if (data_insert > 0)
                    {
                        MessageBox.Show("Booking Successful", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Booking Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                 
                }
                else
                {
                    MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
