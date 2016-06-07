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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBManager managerUpdate = new DBManager();
            managerUpdate.UpdateStaff(Convert.ToInt32(textBox4.Text), tbxFirstName.Text, tbxLastName.Text, dateTimePicker1.Value, tbxBankAcc.Text, tbxStaffAdd.Text, Convert.ToInt32(tbxPhoneNum.Text), Convert.ToInt32(tbxDutyId.Text), Convert.ToInt32(tbxAccId.Text));
            MessageBox.Show("Details has been updated!"); ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DBManager().DeleteStaff(Convert.ToInt32(textBox3.Text));
            MessageBox.Show("Successfully delete staff");
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            List<Staff> sl = new DBManager().GetStaffById(Convert.ToInt32(textBox4.Text));
            
            tbxAccId.Text = sl[0].accountId.ToString();
            tbxFirstName.Text = sl[0].firstName;
            tbxLastName.Text = sl[0].lastName;
            dateTimePicker1.Text = sl[0].dateOfBirth.ToLongDateString();
            tbxBankAcc.Text = sl[0].bankAccountNumber.ToString();
            tbxStaffAdd.Text = sl[0].staffAddress;
            tbxDutyId.Text = sl[0].dutyId.ToString();
            tbxPhoneNum.Text = sl[0].phoneNumber.ToString();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DBManager managerCreate = new DBManager();
            managerCreate.InsertStaff(Convert.ToInt32(textBox4.Text),tbxFirstName.Text, tbxLastName.Text, dateTimePicker1.Value, tbxBankAcc.Text, tbxStaffAdd.Text, Convert.ToInt32(tbxPhoneNum.Text), Convert.ToInt32(tbxDutyId.Text), Convert.ToInt32(tbxAccId.Text));
            MessageBox.Show("Details has been created!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            this.Hide();
            page.Show(this);
        }


    }
}
