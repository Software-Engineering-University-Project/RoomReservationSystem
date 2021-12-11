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

//do zrobienia: edycja facilities

namespace RoomReservationSystem.UserInterface
{
    public partial class FormRoom : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public FormRoom()
        {
            InitializeComponent();
            EnableGuestPermissions();
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
            isOutOfService.Visible = outOfService;
            isOutOfService.Enabled = outOfService;
            deleteRoomButton.Visible = delete;
            deleteRoomButton.Enabled = delete;
            editTextButton.Visible = edit;
            editTextButton.Enabled = edit;

            SetEditableValues(editableValues);
        }
        private void SetEditableValues(bool isEditable)
        {
            typeOfBed.ReadOnly = !isEditable;
            maxNumGuests.ReadOnly = !isEditable;
            squareMeters.ReadOnly = !isEditable;
        }

        private void SetRoomName()
        {
           // roomNameLabel.Text
        }
        private void SetImage()
        {
          //  roomImage
        }
        private void SetTypeOfBedValue()
        {
            // typeOfBed.Text
        }

        private void SetNumOfGuests()
        {
            // maxNumGuests.Text
        }

        private void SetSquareMeters()
        {
           // squareMeters.Text
        }

        private void SetPrice(float price)
        {
            priceLabel.Text = price.ToString();
        }
        private void editTextButton_Click(object sender, EventArgs e)
        {
            //wartości z squareMeter.Text, maxNumGuests.Text itd zostają wpisane do modelu
        }

        private void deleteRoomButton_Click(object sender, EventArgs e)
        {

        }

        private void addCommentButton_Click(object sender, EventArgs e)
        {
            // wpisanie komentarza do modelu
        }

        private void reservateButton_Click(object sender, EventArgs e)
        {

        }

        private void commentText_TextChanged(object sender, EventArgs e)
        {
            HideCaret(commentText.Handle);
        }

        private void maxNumGuests_TextChanged(object sender, EventArgs e)
        {
            HideCaret(maxNumGuests.Handle);
        }

        private void typeOfBed_TextChanged(object sender, EventArgs e)
        {
            HideCaret(typeOfBed.Handle);
        }

        private void squareMeters_TextChanged(object sender, EventArgs e)
        {
            HideCaret(squareMeters.Handle);
        }
    }
}
