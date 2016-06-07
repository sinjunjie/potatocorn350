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
        int currentGuestID = -1;
        List<HitBox> hitboxes = new List<HitBox>();
        
        public Booking()
        {
            InitializeComponent();
            this.Size = MasterControl.formSize;
            this.MinimizeBox = MasterControl.showMinimizeBox;
            this.MaximizeBox = MasterControl.showMaximizeBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tbGuestID.Text.Equals(String.Empty)){
                MessageBox.Show("Please input existing guest's ID first!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error); //Prompt the user that the Guest ID textbox requires data
                return; //Exit from this click event
            }
            int guestId = Convert.ToInt32(tbGuestID.Text);
            try
            {
                List<Guest> guestList = new DBManager().GetGuestById(guestId);
                Guest myGuest = guestList[0];
                tbFirstName.Text = myGuest.firstName;
                tbLastName.Text = myGuest.lastName;
                tbPhoneNum.Text = Convert.ToString(myGuest.phoneNum);
                tbEmail.Text = myGuest.email;
                tbAddress.Text = myGuest.guestAddress;
                tbCountry.Text = myGuest.country;
                currentGuestID = myGuest.guestId;
            }
            catch (Exception)
            {
                MessageBox.Show("There are no guests with this ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            manager.UpdateGuest(currentGuestID, tbFirstName.Text, tbLastName.Text, Convert.ToInt32(tbPhoneNum.Text), tbEmail.Text, tbAddress.Text, tbCountry.Text);
            MessageBox.Show("Details have been saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            int guestID = manager.InsertGuest(tbFirstName.Text, tbLastName.Text, Convert.ToInt32(tbPhoneNum.Text), tbEmail.Text, tbAddress.Text, tbCountry.Text);
            MessageBox.Show("Details have been created!", "Success!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            tbGuestID.Text = guestID.ToString();
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
            // TODO: This line of code loads data into the 'DatabaseDataset.Room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.DatabaseDataset.Room);
            comboBox1_SelectedIndexChanged(null, null);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            string RoomType = comboBox1.Text;

            decimal price = manager.GetRoomPriceByType(RoomType);

            textBox3.Text = price.ToString();//dynamically display the prices of each room type
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Booking has been confirmed! " + "Room Number: ???");
            //choose a room of selected type and change room status to Occupied, and display dates of occupancy

        }

        private void updateLayoutWithRooms(string header)
        {
            List<Room> roomList = new DBManager().GetAllRoomsWithHeader(header);
            hitboxes.Clear();
            Size rectSize = new Size(60, 30);
            int marginX = 20, marginY = 10;
                using (Graphics g = layoutPanel.CreateGraphics())
                {
                    SolidBrush brush = new SolidBrush(Color.Red); //Presume it's red color = occupied
                    StringFormat stringFormat= new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;

                    int count = 0;
                    foreach (Room room in roomList)
                    {
                        Rectangle rect = new Rectangle();
                        if (count < 5)
                        {
                            rect = new Rectangle(new Point((count * rectSize.Width) + (count * marginX), 0), rectSize);
                        }
                        else
                        {
                            rect = new Rectangle(new Point(((count - 5) * rectSize.Width) + ((count - 5) * marginX), rectSize.Height + marginY), rectSize);
                        }
                        g.FillRectangle(brush, rect);

                        count++;
                    }

                }
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            updateLayoutWithRooms("1");
            drawTimer.Stop();
        }

       
    }
}
