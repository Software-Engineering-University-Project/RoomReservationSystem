using Manager;
using RoomReservationSystem.Users;
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
    public partial class FormNewPerson : Form
    {
        private FormMode _mode;
        private UserManager _userManager;
        private Boolean _isWorker;
        public FormNewPerson(FormMode mode, Boolean isWorker, UserManager userManager)
        {
            InitializeComponent();
            country.DataSource = Enum.GetValues(typeof(Country));
            _mode = mode;
            _userManager = userManager;
            _isWorker = isWorker;
            if(_userManager.managedUser != null && mode.Equals(FormMode.Edit))
            {
                InitializeTextFields();
            }
        }

        //metoda do wywołania, jeśli chcemy edytować dane za pomocą formularza
        public void InitializeTextFields()
        {
            this.firstName.Text = _userManager.managedUser.name;
            this.secondName.Text = _userManager.managedUser.surname;
            this.dateOfBirth.Value = _userManager.managedUser.BirthDate;
            this.phoneNum.Text = _userManager.managedUser.logon.phoneNumber;
            this.postCode.Text = _userManager.managedUser.address.postCode;
            this.city.Text = _userManager.managedUser.address.city;
            this.eMail.Text = _userManager.managedUser.logon.email;
            this.street.Text = _userManager.managedUser.address.street;
            this.houseNum.Text = _userManager.managedUser.address.propertyNumber;
            this.flatNum.Text = _userManager.managedUser.address.apartmentNumber;
            this.country.Text = _userManager.managedUser.address.country;
            this.password.Text = _userManager.managedUser.logon.passWord;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

            if (_mode == FormMode.Edit) //nadpisanie danych
            {
                // potrzebny dostęp do danych zalogowanego użytkownika
                if (!_userManager.managedUser.Equals(null))
                {
                    _userManager.update(this.firstName.Text, this.secondName.Text, this.dateOfBirth.Value, this.phoneNum.Text, this.postCode.Text, this.city.Text, this.eMail.Text, this.street.Text, this.houseNum.Text, this.flatNum.Text, this.country.Text, this.password.Text);
                }
            } 
            else if (_mode == FormMode.NewElement) // zapisanie nowego elementu
            {
                // potrzebny dostęp do informacji, jaki rodzaj użytkownika zapisujemy
                if(_userManager.add(this.firstName.Text, this.secondName.Text, this.dateOfBirth.Value, this.phoneNum.Text, this.postCode.Text, this.city.Text, this.eMail.Text, this.street.Text, this.houseNum.Text, this.flatNum.Text, this.country.Text, _isWorker, this.password.Text))
                {
                    MessageBox.Show("Person has been added!");
                }
                else
                {
                    MessageBox.Show("Incorrect phone number or e-mail address!");
                }
            }

        }


    }
}
