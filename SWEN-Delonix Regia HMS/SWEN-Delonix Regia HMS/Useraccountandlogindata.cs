using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Done by Jun Jie

namespace SWEN_Delonix_Regia_HMS
{
    public partial class Useraccount_and_login_data : Form
    {
        public Useraccount_and_login_data()
        {
            InitializeComponent();
            this.Size = MasterControl.formSize;
            this.MinimizeBox = MasterControl.showMinimizeBox;//test
            this.MaximizeBox = MasterControl.showMaximizeBox;
        }

        private void Useraccount_and_login_data_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Dataset2.Account' table. You can move, or remove it, as needed.
            this.accountTableAdapter.Fill(this.JunJieDBDataSet.Account);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
