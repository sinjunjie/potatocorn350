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
           label1.Text = dutyList[0].dutyType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DBManager().UpdateStaff(Convert.ToInt32(tbxFirstName.Text), tbxDOB.Text, textBox3.Text, (DateTime)dateTimePicker1.Value, tbxLastName.Text, tbxBankAcc.Text, Convert.ToInt32(tbxStaffAdd.Text), Convert.ToInt32(tbxPhoneNum.Text), Convert.ToInt32(tbxAccId.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DBManager().DeleteStaff(Convert.ToInt32(textBox3.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
           List<Staff>sl = new DBManager().GetStaffById(Convert.ToInt32(textBox4.Text));
           
           tbxFirstName.Text = sl[0].firstName;
           tbxLastName.Text = sl[0].lastName;
           tbxDOB.Text = sl[0].dateOfBirth.ToLongDateString();
           tbxBankAcc.Text = sl[0].bankAccountNumber.ToString();
           tbxStaffAdd.Text = sl[0].staffAddress;
           tbxPhoneNum.Text = sl[0].phoneNumber.ToString();
           tbxDutyId.Text = sl[0].dutyId.ToString();
           tbxAccId.Text = sl[0].accountId.ToString();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
      
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
