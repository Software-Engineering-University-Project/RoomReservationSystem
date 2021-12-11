using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormMakeReservation : Form
    {
        public FormMakeReservation()
        {
            InitializeComponent();
        }


        private void GetUserData()
        {
         // dateFrom
         // dateTo
         // userId
         //roomId
        }

        public void EnableClientPermissions()
        {
            userId.Visible = false;
            labelUserID.Visible= false;

            roomId.Visible = false;
            labelRoomId.Visible = false;
        }

        public void EnableHighPermissions()
        {
            userId.Visible = true;
            labelUserID.Visible = true;

            roomId.Visible = true;
            labelRoomId.Visible = true;
        }

        private void makeReservationButton_Click(object sender, EventArgs e)
        {

        }

        private void userId_TextChanged(object sender, EventArgs e)
        {

        }

        private void roomId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
