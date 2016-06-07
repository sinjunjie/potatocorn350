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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int guestId = Convert.ToInt32(textBox1.Text);
            List<Guest> guestList = new DBManager().GetGuestById(guestId);
            Guest myGuest = guestList[0];
            textBox2.Text = myGuest.firstName;
            tbLastName.Text = myGuest.lastName;
            textBox4.Text = Convert.ToString(myGuest.phoneNum);
            tbEmail.Text = myGuest.email;
            textBox6.Text = myGuest.guestAddress;
            textBox7.Text = myGuest.country;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DBManager manager = new DBManager();
            if (textBox1 == null)
            {
                MessageBox.Show("Please input existing guest's ID first!", "Error",
                MessageBoxButtons.OK);//Error message to show that guest id is not found in database
            }
            else{
            manager.UpdateGuest(Convert.ToInt32(textBox1.Text), textBox2.Text, tbLastName.Text, Convert.ToInt32(textBox4.Text), tbEmail.Text, textBox6.Text, textBox7.Text);
            MessageBox.Show("Details have been saved!");
            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            manager.InsertGuest(textBox2.Text, tbLastName.Text, Convert.ToInt32(textBox4.Text), tbEmail.Text, textBox6.Text, textBox7.Text);
            MessageBox.Show("Details have been created!");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            this.Hide();
            page.Show(this);//return to main menu
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Booking_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'junjieDBDataSet.Room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.junjieDBDataSet.Room);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            MessageBox.Show(this.comboBox1.SelectedItem.ToString());//dynamically display the prices of each room type
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Booking has been confirmed! " + "Room Number: ???");
            //choose a room of selected type and change room status to Occupied, and display dates of occupancy

        }

       
    }
}
