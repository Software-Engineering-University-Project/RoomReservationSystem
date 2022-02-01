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

        private Room _room;
        public FormRoom(Room room)
        {
            _roomManager = new RoomManager();
            _room = room;
            InitializeComponent();
            //EnableGuestPermissions();
            
            this.roomNameLabel.Text = room.id.ToString();

            this.standard.Text = room.roomStandard.ToString();

            foreach( var meal in room.mealsProvided)
            {
                this.meals.Text += meal.ToString() + ",";
            }
            //this.meals.Text = this.meals.Text.Substring(0, room.mealsProvided.Count - 2);

            this.priceLabel.Text = room.price.ToString();

            this.maxNumGuests.Text = room.maxGuestNumber.ToString();

            this.squareMeters.Text = room.squareMeterage.ToString();

            foreach(var bed in room.beds)
            {
                this.typeOfBed.Text += bed.ToString() + ",";
            }
            //this.typeOfBed.Text = this.typeOfBed.Text.Substring(0, room.beds.Count - 2);

            foreach (var facility in room.facilitiesProvided)
            {
                this.facilities.Items.Add(facility.ToString());
            }

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
            this.addCommentButton.Visible = comment;
            this.addCommentButton.Enabled = comment;
            this.commentText.Visible = comment;
            this.isOutOfService.Visible = outOfService;
            this.isOutOfService.Enabled = outOfService;
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
                _roomManager.Delete(_room.id);
        }

        private void addCommentButton_Click(object sender, EventArgs e)
        {
            // wpisanie komentarza do modelu
        }

        private void reservateButton_Click(object sender, EventArgs e)
        {

        }


        private void FormRoom_Load(object sender, EventArgs e)
        {

        }

        private void editRoomButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormNewRoom(FormMode.Edit));
        }

        private void reservationsHistoryButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormTableView(TableType.UserReservationsHistory));
        }
    }
}