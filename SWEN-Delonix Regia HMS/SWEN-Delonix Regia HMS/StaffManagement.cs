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
    public partial class StaffManagement : Form
    {
        public StaffManagement()
        {
            InitializeComponent();
            this.Size = MasterControl.formSize;
            this.MinimizeBox = MasterControl.showMinimizeBox;
            this.MaximizeBox = MasterControl.showMaximizeBox;
        }

        private void Staff_management_module_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void staffupdate_Click(object sender, EventArgs e)
        {
            new DBManager().UpdateStaff(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, (DateTime)dateTimePicker1.Value, textBox5.Text, textBox6.Text, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
        }
    }
}
