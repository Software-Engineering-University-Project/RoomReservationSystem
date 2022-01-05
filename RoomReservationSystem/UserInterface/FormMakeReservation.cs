using Manager;
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
        private UserManager _userManager;
        private RoomManager _roomManager;
        private ReservationManager _reservationManager;
        public FormMakeReservation()
        {
            InitializeComponent();
            _userManager = new UserManager();
            _roomManager = new RoomManager();
            _reservationManager = new ReservationManager();
        }


        private void MakeReservation()
        {
            //brak walidacji
            DateTime reservationFrom = dateFrom.Value;
            DateTime reservationTO = dateTo.Value;
            String userID = this.userId.Text;
            String roomID = this.roomId.Text;

            //wywołanie metody do tworzenia nowej rezerwacji

        //    if dodane
          //      ClearForm();
        }

        private void ClearForm()
        {
            this.dateFrom.Value = DateTime.Now;
            this.dateTo.Value = DateTime.Now;
            this.userId.Text = string.Empty;
            this.roomId.Text = string.Empty;
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
            MakeReservation();
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
