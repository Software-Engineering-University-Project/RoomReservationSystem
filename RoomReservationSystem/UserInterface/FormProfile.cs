﻿using Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Users;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormProfile : Form
    {
        private UserManager _userManager;

        private RoomReservationSystem _roomReservationSystem;

        public FormProfile(UserManager userManger, RoomReservationSystem rs)
        {
            InitializeComponent();
            _userManager = userManger;
            _roomReservationSystem = rs;
            _userManager.getManagedUser(_userManager.currUser.id);
            if (_userManager.managedUser != null)
            {
                initializeLabels();
            }

            EnablePermissions();
        }

        private void EnablePermissions()
        {
            if (_userManager.currUser is Client)
            {
                EnableClientPermissions();
            }
            else if (_userManager.currUser is Worker)
            {
                EnableWorkerPermissions();
            }
            else if (_userManager.currUser is Admin)
            {
                EnableAdminPermissions();
            }
        }

        public void EnableClientPermissions()
        {
            SetComponentsVisibility(false);
        }
        public void EnableWorkerPermissions()
        {
            SetComponentsVisibility(false);
        }

        public void EnableAdminPermissions()
        {
            SetComponentsVisibility(true);
        }
        private void SetComponentsVisibility(bool deleteProfile = false)
        {
            this.deleteProfileButton.Visible = deleteProfile;
            this.deleteProfileButton.Enabled = deleteProfile;
        }

        public void initializeLabels()
        {
            this.nameLabel.Text = _userManager.managedUser.name + " " + _userManager.managedUser.surname;
            this.phoneNumLabel.Text = _userManager.managedUser.logon.phoneNumber;
            this.emailLabel.Text = _userManager.managedUser.logon.email;
            this.dateOfBirthLabel.Text = _userManager.managedUser.BirthDate.ToString();
            this.addressLabel.Text = _userManager.managedUser.address.street + " " + _userManager.managedUser.address.propertyNumber + "/" + _userManager.managedUser.address.apartmentNumber;
            this.cityLabel.Text = _userManager.managedUser.address.city;
            this.countryLabel.Text = _userManager.managedUser.address.country;
            this.postCodeLabel.Text = _userManager.managedUser.address.postCode;
        }

        private void displayHistoryButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormTableView(TableType.UserReservationsHistory, _userManager.managedUser.id));
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormNewPerson(FormMode.Edit, false, _userManager));
        }

        private void deleteProfileButton_Click(object sender, EventArgs e)
        {

            bool shouldDelete = ConfirmationPopup.ShowDialog("Do you confirm profile deletion?");

            if (shouldDelete)
            {
                _userManager.delete(_userManager.managedUser.id);
                _userManager.logout();
                _roomReservationSystem.LogOutLayoutSetter();
            }
        }
    }
}
