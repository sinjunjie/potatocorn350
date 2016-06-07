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
            this.Size = MasterControl.formSize;
            this.MinimizeBox = MasterControl.showMinimizeBox;
            this.MaximizeBox = MasterControl.showMaximizeBox;
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

        private void button3_Click(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            manager.UpdateAccount(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, Boolean.Parse(comboBox1.Text));
            MessageBox.Show("Details has been saved!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new DBManager().DeleteAccount(Convert.ToInt32(textBox4.Text));
            MessageBox.Show("Successfully delete staff");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            this.Hide();
            page.Show(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Useraccount_and_login_creation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Dataset1.Account' table. You can move, or remove it, as needed.
            this.accountTableAdapter.Fill(this.Dataset.Account);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Useraccount_and_login_data page = new Useraccount_and_login_data();
            this.Hide();
            page.Show(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            this.Hide();
            page.Show(this);
        }
    }
}
