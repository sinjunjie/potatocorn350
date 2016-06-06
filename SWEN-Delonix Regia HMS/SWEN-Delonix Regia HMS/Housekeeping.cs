using SWEN_Delonix_Regia_HMS.managers;
using SWEN_Delonix_Regia_HMS.model;
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
    public partial class Housekeeping : Form
    {
        public Housekeeping()
        {
            InitializeComponent();
        }

        private void Housekeeping_Load(object sender, EventArgs e)
        {
           List<Duty> dutyList =  new DBManager().GetAllDuties();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DBManager().DeleteStaff(Convert.ToInt32(textBox3.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
           List<Staff>sl = new DBManager().GetStaffById(Convert.ToInt32(textBox4.Text));
           label2.Text = sl[0].accountId.ToString();
           label3.Text = sl[0].firstName;
           label4.Text = sl[0].lastName;
           label5.Text = sl[0].dateOfBirth.ToLongDateString();
           label6.Text = sl[0].bankAccountNumber.ToString();
           label7.Text = sl[0].staffAddress;
           label8.Text = sl[0].dutyId.ToString();
           label9.Text = sl[0].staffId.ToString();

        }

    }
}
