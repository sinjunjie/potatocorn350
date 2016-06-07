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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //public string connectionString = "Server=woodmon122.duckdns.org;Database=JunjieDB;User=swen;Password=swen";
            
            this.Hide();
            Useraccount_and_login_creation ss = new Useraccount_and_login_creation();
            ss.Show();
        }
    }
}
