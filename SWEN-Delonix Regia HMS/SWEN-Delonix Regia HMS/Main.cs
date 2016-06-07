using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWEN_Delonix_Regia_HMS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Size = MasterControl.formSize;
            this.MinimizeBox = MasterControl.showMinimizeBox;
            this.MaximizeBox = MasterControl.showMaximizeBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Useraccount_and_login_creation page = new Useraccount_and_login_creation();
            //this.Hide();
            //page.Show(this);

            Login page = new Login();
            this.Hide();
            page.Show(this);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Housekeeping page = new Housekeeping();
            this.Hide();
            page.Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Booking page = new Booking();
            this.Hide();
            page.Show(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RoomAvailability page = new RoomAvailability();
            this.Hide();
            page.Show(this);
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
