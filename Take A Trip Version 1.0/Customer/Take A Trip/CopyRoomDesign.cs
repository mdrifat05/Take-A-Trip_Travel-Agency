using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Take_A_Trip
{
    public partial class CopyRoomDesign : Form
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
        public CopyRoomDesign()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Memo_Calculation.Hotel_name = label2.Text;
            Memo_Calculation.Hotel_number = label4.Text;
            Memo_Calculation.Booking_price = label6.Text;
            MessageBox.Show("Booking Added");
        }
    }
}
