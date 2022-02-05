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
            EnablePermissions();
        }

        public FormMakeReservation(UserManager userManager, int roomId)
        {
            InitializeComponent();
            _reservationManager = new ReservationManager();
            _userManager =  userManager;
            this.userId.Text = _userManager.managedUser.id.ToString();
            this.roomId.Text = roomId.ToString();

            EnablePermissions();
        }


        private void MakeReservation()
        {
            
            Regex regex = new Regex(@"^[0-9]+$");
            DateTime reservationFrom = dateFrom.Value;
            DateTime reservationTO = dateTo.Value;
            String userID = this.userId.Text;
            String roomID = this.roomId.Text;
            if (roomId == null || userID == null)
            {
                this.roomId.Text = string.Empty;
                InformationPopup.ShowDialog("There is no room with that id", "Incorrect data");
            }
            else
            {
                if (reservationTO == reservationFrom)
                {
                    this.dateFrom.Value = DateTime.Now;
                    this.dateTo.Value = DateTime.Now;
                    InformationPopup.ShowDialog("You must reservate at least one night", "Wrong date");
                }
                else
                {
                    if (regex.IsMatch(userID))
                    {
                        if (regex.IsMatch(roomID))
                        {

                            Room room = Searcher.SearchRoomById(Int32.Parse(roomID));
                            if (room != null)
                            {
                                _userManager.getManagedUser(Int32.Parse(userID));
                                if (_userManager.managedUser != null)
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
            }
        }

        private void EnablePermissions()
        {
            if (_userManager.currUser != null)
            {
                if (_userManager.currUser is Client)
                {
                    EnableClientPermissions();
                }
                else
                {
                    EnableHighPermissions();
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
            userId.ReadOnly = true;
            roomId.ReadOnly = true;
        }

        public void EnableHighPermissions()
        {
            userId.ReadOnly = false;
            roomId.ReadOnly = false;
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
