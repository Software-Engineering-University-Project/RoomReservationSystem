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
        
        public FormRoom(RoomManager roomManager)
        {
            _roomManager = roomManager;
            InitializeComponent();
            //EnableGuestPermissions();
            
            this.roomNameLabel.Text = _roomManager.CurrentRoom.id.ToString();

            this.standard.Text = _roomManager.CurrentRoom.roomStandard.ToString();

            foreach( var meal in _roomManager.CurrentRoom.mealsProvided)
            {
                this.meals.Text += meal.ToString() + ",";
            }
            //this.meals.Text = this.meals.Text.Substring(0, room.mealsProvided.Count - 2);

            this.priceLabel.Text = _roomManager.CurrentRoom.price.ToString();

            this.maxNumGuests.Text = _roomManager.CurrentRoom.maxGuestNumber.ToString();

            this.squareMeters.Text = _roomManager.CurrentRoom.squareMeterage.ToString();

            foreach(var bed in _roomManager.CurrentRoom.beds)
            {
                this.typeOfBed.Text += bed.ToString() + ",";
            }
            //this.typeOfBed.Text = this.typeOfBed.Text.Substring(0, room.beds.Count - 2);

            foreach (var facility in _roomManager.CurrentRoom.facilitiesProvided)
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
            SetComponentsVisibility(true, false, false, false, false, false);
        }
        public void EnableWorkerPermissions()
        {
            SetComponentsVisibility(true, true, true, false, false, false);
        }

        public void EnableAdminPermissions()
        {
            SetComponentsVisibility(true, true, true, true, true, true);
        }
        private void SetComponentsVisibility(bool reservate = false, bool comment = false, 
            bool outOfService = false, bool delete = false, bool edit = false, bool editableValues = false)
        {
            reservateButton.Visible = reservate;
            reservateButton.Enabled = reservate;
            addCommentButton.Visible = comment;
            addCommentButton.Enabled = comment;
            commentText.Visible = comment;
            isOutOfService.Visible = outOfService;
            isOutOfService.Enabled = outOfService;
            deleteRoomButton.Visible = delete;
            deleteRoomButton.Enabled = delete;
            editRoomButton.Visible = edit;
            editRoomButton.Enabled = edit;
        }
        
        private void deleteRoomButton_Click(object sender, EventArgs e)
        {
            _roomManager.Delete(_roomManager.CurrentRoom.id);
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
            ViewManager.GetInstance().DisplayChildForm(new FormNewRoom(_roomManager, FormMode.Edit));
        }
    }
}