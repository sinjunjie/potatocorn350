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
        Room selectedRoom = new Room();
        List<HitBox> hitboxes = new List<HitBox>();
        JunJieDBDataSet.GetRoomOccupancyDataTable dt = new JunJieDBDataSet.GetRoomOccupancyDataTable();
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
            // TODO: This line of code loads data into the 'Dataset.GetRoomsByHeader' table. You can move, or remove it, as needed.
            this.getRoomsByHeaderTableAdapter.Fill(this.Dataset.GetRoomsByHeader);
            // TODO: This line of code loads data into the 'Dataset.Room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.Dataset.Room);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(currentGuestID == -1){
                MessageBox.Show("Please select or create a guest first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new DBManager().InsertBooking(currentGuestID, (DateTime)dateTimePicker1.Value, (DateTime)dateTimePicker2.Value, (int)numericUpDown1.Value, (int)numericUpDown2.Value, tbRemarks.Text, selectedRoom.roomId);
            updateLayoutWithRooms(comboBox2.Text);
            MessageBox.Show("Your Booking has been confirmed! " + "Room Number: " + selectedRoom.roomHeader + selectedRoom.roomNumber);
            //choose a room of selected type and change room status to Occupied, and display dates of occupancy

        }

        private void updateLayoutWithRooms(string header)
        {
            new JunJieDBDataSetTableAdapters.GetRoomOccupancyTableAdapter().Fill(dt, dateTimePicker1.Value, dateTimePicker2.Value);
            layoutPanel.CreateGraphics().Clear(this.BackColor);
            List<Room> roomList = new DBManager().GetAllRoomsWithHeader(header);
            hitboxes.Clear();
            Size rectSize = new Size(60, 30);
            int marginX = 20, marginY = 10;
                using (Graphics g = layoutPanel.CreateGraphics())
                {
                    StringFormat stringFormat= new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;


                    int count = 0;
                    foreach (Room room in roomList)
                    {
                        bool isOccupied = false;
                        foreach (JunJieDBDataSet.GetRoomOccupancyRow row in dt)
                        {
                            if (row.roomId == room.roomId)
                            {
                                isOccupied = true;
                                break;
                            }
                        }
                        SolidBrush brush = new SolidBrush(Color.Red); //Presume it's red color = occupied
                        SolidBrush textBrush = new SolidBrush(Color.White);
                        Rectangle rect = new Rectangle();
                        if (count < 5)
                        {
                            rect = new Rectangle(new Point((count * rectSize.Width) + (count * marginX), 0), rectSize);
                        }
                        else
                        {
                            rect = new Rectangle(new Point(((count - 5) * rectSize.Width) + ((count - 5) * marginX), rectSize.Height + marginY), rectSize);
                        }

                        if (!isOccupied)
                        {
                            textBrush = new SolidBrush(Color.Black);
                            brush = new SolidBrush(Color.Green);
                        }
                        g.FillRectangle(brush, rect);
                        g.DrawString(room.roomHeader + room.roomNumber, new Font(new FontFamily("Arial"), 12, FontStyle.Regular), textBrush, rect, stringFormat);
                        HitBox h = new HitBox(rect);
                        h.Tag = room;
                        hitboxes.Add(h);
                        count++;
                    }

                }
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            updateLayoutWithRooms("2");
            drawTimer.Stop();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            new JunJieDBDataSetTableAdapters.GetRoomOccupancyTableAdapter().Fill(dt, dateTimePicker1.Value, dateTimePicker2.Value);
            updateLayoutWithRooms(comboBox2.Text);
        }

        private void layoutPanel_MouseMove(object sender, MouseEventArgs e)
        {
            bool hit = false;
            foreach (HitBox i in hitboxes)
            {
                if (i.Hit(e.X, e.Y))
                {
                    hit = true;
                    Cursor = Cursors.Hand;
                    break;
                }
            }
            if (hit)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void layoutPanel_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void layoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Room r = new Room();
                bool hit = false;
                foreach (HitBox i in hitboxes)
                {
                    if (i.Hit(e.X, e.Y))
                    {
                        hit = true;
                        r = (Room)i.Tag;
                        break;
                    }
                }
                if (hit)
                {
                    selectedRoom = r;
                    lblRoomPrice.Text = "Price per Night: " + r.roomPrice.ToString();
                    lblRoomType.Text =  "Room Type: " + r.roomType.ToString();
                    lblRoomNum.Text = "Room Number: " + r.roomHeader.ToString() + r.roomNumber.ToString();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            updateLayoutWithRooms(comboBox2.Text);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            updateLayoutWithRooms(comboBox2.Text);
        }

       
    }
}
