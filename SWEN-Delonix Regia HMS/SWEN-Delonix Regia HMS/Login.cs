using SWEN_Delonix_Regia_HMS.managers;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int result = new DBManager().DoLogin(tbUsername.Text, tbPassword.Text);
            if (result == 1)//Login success if it is 1
            {
                Useraccount_and_login_creation ss = new Useraccount_and_login_creation();
                ss.Show();
                this.Hide();
            }
            else //Login failed if it is 0
            {
                MessageBox.Show("Username and password does not match", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '*'; //You can put this to anything you want
            }
        }
    }
}
