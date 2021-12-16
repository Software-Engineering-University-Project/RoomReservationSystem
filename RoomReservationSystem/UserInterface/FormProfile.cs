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
        public FormProfile()
        {
            InitializeComponent();
        }

        public FormProfile(String name, String phoneNum, String email, String dateOfBirth, String streetAndHouseNum, String city, String country, String postCode)
        {
            InitializeComponent();

            this.nameLabel.Text = name;
            this.phoneNumLabel.Text = phoneNum;
            this.emailLabel.Text = email;
            this.dateOfBirthLabel.Text = dateOfBirth;
            this.addressLabel.Text = streetAndHouseNum;
            this.cityLabel.Text = city;
            this.countryLabel.Text = country;
            this.postCodeLabel.Text = postCode;
        }


        private void displayHistoryButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormTableView(TableType.UserReservationsHistory));
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            ViewManager.GetInstance().DisplayChildForm(new FormNewPerson(FormMode.Edit, false, new Manager.UserManager()));
        }
    }
}
