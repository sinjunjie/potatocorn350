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
    public partial class Useraccount_and_login_creation : Form
    {
        public Useraccount_and_login_creation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            manager.CreateAccount(textBox2.Text, textBox3.Text, Boolean.Parse(comboBox1.Text));
            MessageBox.Show("Details has been created!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int accountId = Convert.ToInt32(textBox1.Text);
            List<Account> accountList = new DBManager().GetAccountById(accountId);
            Account myAccount = accountList[0];
            textBox2.Text = myAccount.username;
            textBox3.Text = myAccount.password;
            comboBox1.Text = Convert.ToString(myAccount.isAdmin);
        }
    }
}
