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
    public partial class FormProfile : Form
    {
        private UserManager _userManager;

        public FormProfile(UserManager userManger)
        {
            InitializeComponent();
            _userManager = userManger;
            _userManager.getManagedUser(3);
            if(_userManager.managedUser != null)
            {
                initializeLabels();
            }
        }

        public void initializeLabels()
        {
            this.nameLabel.Text = _userManager.managedUser.name + " "+ _userManager.managedUser.surname;
            this.phoneNumLabel.Text = _userManager.managedUser.logon.phoneNumber;
            this.emailLabel.Text = _userManager.managedUser.logon.email;
            this.dateOfBirthLabel.Text = _userManager.managedUser.BirthDate.ToString();
            this.addressLabel.Text = _userManager.managedUser.address.street +" "+ _userManager.managedUser.address.propertyNumber + "/"+ _userManager.managedUser.address.apartmentNumber;
            this.cityLabel.Text = _userManager.managedUser.address.city;
            this.countryLabel.Text = _userManager.managedUser.address.country;
            this.postCodeLabel.Text = _userManager.managedUser.address.postCode;
        }

        private void displayHistoryButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormTableView(TableType.UserReservationsHistory));
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormNewPerson(FormMode.Edit, false, _userManager));
        }
    }
}
