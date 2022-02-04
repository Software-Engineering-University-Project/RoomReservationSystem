using Manager;
using Reservations;
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
using Users;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormMakeReservation : Form
    {
        ReservationManager _reservationManager;
        UserManager _userManager;
        public FormMakeReservation()
        {
            InitializeComponent();
            _reservationManager = new ReservationManager();
            _userManager = new UserManager();
            dateFrom.MinDate = DateTime.Today;
            dateTo.MinDate = DateTime.Today;
        }


        private void MakeReservation()
        {
            
            Regex regex = new Regex(@"^[0-9]+$");
            DateTime reservationFrom = dateFrom.Value;
            DateTime reservationTO = dateTo.Value;
            String userID = this.userId.Text;
            String roomID = this.roomId.Text;
            if (regex.IsMatch(userID)) {
                if (regex.IsMatch(roomID)) {

                    Room room = Searcher.SearchRoomById(Int32.Parse(roomID));
                    if (room != null)
                    {
                        _userManager.getManagedUser(Int32.Parse(userID));
                        if (_userManager.managedUser != null)
                        {
                            if (reservationFrom.Date < reservationTO.Date)
                            {
                                List<Reservation> reservations = _reservationManager.getReservations(Int32.Parse(roomID), true);
                                bool isOccupied = false;
                                foreach (Reservation r in reservations)
                                {
                                    if ((reservationFrom > r.checkInDate ? reservationFrom : r.checkInDate) <= (reservationTO < r.checkOutDate ? reservationTO : r.checkOutDate))
                                    {
                                        isOccupied = true;
                                    }
                                }
                                if (!isOccupied)
                                {
                                    //wywołanie metody do tworzenia nowej rezerwacji

                                    bool added = _reservationManager.add(room.price, Int32.Parse(userID), Int32.Parse(roomID), reservationFrom, reservationTO);
                                    if (added)
                                    {
                                        ClearForm();
                                    }
                                }
                                else
                                {
                                    this.dateFrom.Value = DateTime.Now;
                                    this.dateTo.Value = DateTime.Now;
                                    InformationPopup.ShowDialog("Room is occupied at given time please change your dates", "Wrong date");
                                }
                            }
                            else
                            {
                                this.dateFrom.Value = DateTime.Now;
                                this.dateTo.Value = DateTime.Now;
                                InformationPopup.ShowDialog("You can't reservate room without a night, or with negative number of them", "Wrong date");
                            }
                        }
                        else
                        {
                            this.userId.Text = string.Empty;
                            InformationPopup.ShowDialog("No user with given ID, please check once more and change it", "No user info");
                        }
                    }
                    else
                    {
                        this.roomId.Text = string.Empty;
                        InformationPopup.ShowDialog("No room with given ID, please check once more and change it", "No room info");
                    }
                }
                else
                {
                    this.roomId.Text = string.Empty;
                    InformationPopup.ShowDialog("Room ID should be an number, please check once more and change it", "Wrong format");
                }
            }
            else
            {
                this.userId.Text = string.Empty;
                InformationPopup.ShowDialog("User ID should be an number, please check once more and change it", "Wrong format");
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
            updatePrice();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            updatePrice();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            updatePrice();
        }

        private void updatePrice()
        {
            DateTime reservationFrom = dateFrom.Value;
            DateTime reservationTO = dateTo.Value;
            Regex regex = new Regex(@"^[0-9]+$");
            String roomID = this.roomId.Text;
            if (roomID != "")
            {
                if (regex.IsMatch(roomID))
                {
                    Room room = Searcher.SearchRoomById(Int32.Parse(roomID));
                    if (room != null)
                    {
                        if (reservationFrom.Date < reservationTO.Date)
                        {
                            labelPrice.Text = (room.price * ((reservationTO - reservationFrom).Days + 1)).ToString();
                        }
                    }
                }
            }
            else
            {
                labelPrice.Text = "0";
            }
        }
    }
}
