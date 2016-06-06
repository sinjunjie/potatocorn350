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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DBManager().UpdateStaff(2,textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DBManager().DeleteStaff(Convert.ToInt32(textBox3.Text));
        }

    }
}
