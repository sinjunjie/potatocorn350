﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Done by Nigel

namespace SWEN_Delonix_Regia_HMS
{
    public partial class RoomAvailability : Form
    {
        public RoomAvailability()
        {
            InitializeComponent();
            this.Size = MasterControl.formSize;
            this.MinimizeBox = MasterControl.showMinimizeBox;
            this.MaximizeBox = MasterControl.showMaximizeBox;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            this.Hide();
            page.Show(this);
        }

        
    }
}
