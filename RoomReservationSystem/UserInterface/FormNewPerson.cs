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
        }

        //metoda do wywołania, jeśli chcemy edytować dane za pomocą formularza
        public void InitializeTextFields(String firstName, String secondName, DateTime dateOfBirth, String phoneNum,
            String postCode, String city, String eMail, String street, String houseNum, String flatNum, String country)
        {
            this.firstName.Text = firstName;
            this.secondName.Text = secondName;
            this.dateOfBirth.Value = dateOfBirth;
            this.phoneNum.Text = phoneNum;
            this.postCode.Text = postCode;
            this.city.Text = city;
            this.eMail.Text = eMail;
            this.street.Text = street;
            this.houseNum.Text = houseNum;
            this.flatNum.Text = flatNum;
            this.country.Text = country;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

            if (_mode == FormMode.Edit) //nadpisanie danych
            {
                // potrzebny dostęp do danych zalogowanego użytkownika
                
            } 
            else if (_mode == FormMode.NewElement) // zapisanie nowego elementu
            {
                // potrzebny dostęp do informacji, jaki rodzaj użytkownika zapisujemy
                _userManager.add(this.firstName.Text, this.secondName.Text, this.dateOfBirth.Value, this.phoneNum.Text, this.postCode.Text, this.city.Text, this.eMail.Text, this.street.Text, this.houseNum.Text, this.flatNum.Text, this.country.Text, _isWorker);
            }

        }


    }
}
