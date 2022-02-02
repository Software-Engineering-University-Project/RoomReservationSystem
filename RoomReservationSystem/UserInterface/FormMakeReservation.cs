using Manager;
using RoomReservationSyster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormMakeReservation : Form
    {
        ReservationManager _reservationManager;
        public FormMakeReservation()
        {
            InitializeComponent();
            _reservationManager = new ReservationManager();
            
        }


        private void MakeReservation()
        {
            
            Regex regex = new Regex(@"^[0-9]+$");
            DateTime reservationFrom = dateFrom.Value;
            DateTime reservationTO = dateTo.Value;
            String userID = this.userId.Text;
            String roomID = this.roomId.Text;
            if (regex.IsMatch(userID) && regex.IsMatch(roomID)) { 
                Room room = Searcher.SearchRoomById(Int32.Parse(roomID));
            //wywołanie metody do tworzenia nowej rezerwacji

                bool added = _reservationManager.add(room.price, Int32.Parse(userID), Int32.Parse(roomID),reservationFrom, reservationTO);
                if (added)
                {
                    ClearForm();
                }
                
            }
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
