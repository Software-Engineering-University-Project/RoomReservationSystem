using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manager;
using RoomReservationSyster;

//do zrobienia: edycja facilities

namespace RoomReservationSystem.UserInterface
{
    public partial class FormRoom : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private RoomManager _roomManager;
        private UserManager _userManager;

        public FormRoom(RoomManager roomManager, UserManager userManager)
        {
            _roomManager = roomManager;
            InitializeComponent();
            //EnableGuestPermissions();
            
            this.roomNameLabel.Text = _roomManager.CurrentRoom.id.ToString();

            this.standard.Text = _roomManager.CurrentRoom.roomStandard.ToString();
            /**
            foreach( var meal in _roomManager.CurrentRoom.mealsProvided)
            {
                this.meals.Text += meal.ToString() + ",";
            }*/
            //this.meals.Text = this.meals.Text.Substring(0, room.mealsProvided.Count - 2);

            this.priceLabel.Text = _roomManager.CurrentRoom.price.ToString();

            this.maxNumGuests.Text = _roomManager.CurrentRoom.maxGuestNumber.ToString();

            this.squareMeters.Text = _roomManager.CurrentRoom.squareMeterage.ToString();

            this.commentText.Text = _roomManager.CurrentRoom.comment;

            foreach(var bed in _roomManager.CurrentRoom.beds)
            {
                this.typeOfBed.Text += bed.ToString() + ",";
            }
            //this.typeOfBed.Text = this.typeOfBed.Text.Substring(0, room.beds.Count - 2);

            foreach (var facility in _roomManager.CurrentRoom.facilitiesProvided)
            {
                this.facilities.Items.Add(facility.ToString());
            }

            _userManager = userManager;

        }

        public void EnableGuestPermissions()
        {
            SetComponentsVisibility();
        }
        public void EnableClientPermissions()
        {
            SetComponentsVisibility(true, false, false, false, false, false, false);
        }
        public void EnableWorkerPermissions()
        {
            SetComponentsVisibility(true, true, true, false, false, false, true);
        }

        public void EnableAdminPermissions()
        {
            SetComponentsVisibility(true, true, true, true, true, true, true);
        }
        private void SetComponentsVisibility(bool reservate = false, bool comment = false, 
            bool outOfService = false, bool delete = false, bool edit = false, bool editableValues = false, bool reservationHistory = false)
        {
            this.reservateButton.Visible = reservate;
            this.reservateButton.Enabled = reservate;
            this.commentText.Visible = comment;
            this.deleteRoomButton.Visible = delete;
            this.deleteRoomButton.Enabled = delete;
            this.editRoomButton.Visible = edit;
            this.editRoomButton.Enabled = edit;
            this.reservationsHistoryButton.Visible = reservationHistory;
            this.reservationsHistoryButton.Enabled = reservationHistory;
        }
        
        private void deleteRoomButton_Click(object sender, EventArgs e)
        {
            bool shouldDelete = ConfirmationPopup.ShowDialog("Do you confirm room deletion?");

            if (shouldDelete)
                _roomManager.Delete(_roomManager.CurrentRoom.id);
        }

        private void addCommentButton_Click(object sender, EventArgs e)
        {
            _roomManager.CurrentRoom.comment = this.commentText.Text;
        }

        private void reservateButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormMakeReservation(_userManager, _roomManager.CurrentRoom.id));
        }


        private void FormRoom_Load(object sender, EventArgs e)
        {

        }

        private void editRoomButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormNewRoom(_roomManager, FormMode.Edit));
        }

        private void reservationsHistoryButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormTableView(TableType.RoomHistory, _roomManager.CurrentRoom.id));
        }
    }
}