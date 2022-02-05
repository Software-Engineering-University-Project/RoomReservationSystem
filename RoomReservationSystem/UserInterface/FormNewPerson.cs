using Manager;
using RoomReservationSystem.Users;
using System;
using System.Text.RegularExpressions;
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
            Regex phoneReg = new Regex(@"(\+[0-9]{2}|\+[0-9]{2}\(0\)|\(\+[0-9]{2}\)\(0\)|00[0-9]{2}|0)?([0-9]{9}|[0-9\-\s]{9,18})");
            Regex emailReg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            string fName = firstName.Text;
            string sName = firstName.Text;
            DateTime dob = dateOfBirth.Value;
            string phone = phoneNum.Text;
            string post = postCode.Text;
            string st = street.Text;
            string mail = eMail.Text;
            string house = houseNum.Text;
            string countryName = country.Text;
            string pass = password.Text;
            if (fName.Equals("") || sName.Equals("") || phone.Equals("") || post.Equals("") || st.Equals("") || house.Equals("") || countryName.Equals("") || mail.Equals("")) {
                InformationPopup.ShowDialog("Please fill all necessary information (Flat number is skippable)","Not enough data");
                return;
            }
            if (!phoneReg.IsMatch(phone))
            {
                InformationPopup.ShowDialog("Phone number is incorect", "Wrong phone number");
                return;
            }
            if (!emailReg.IsMatch(mail))
            {
                InformationPopup.ShowDialog("Mail is incorrect", "Wrong email");
                return;
            }
            DateTime eigthteen = new DateTime((DateTime.Today.Year - 18), DateTime.Today.Month, DateTime.Today.Day);
            if (dob.Date > eigthteen.Date){
                InformationPopup.ShowDialog("For reservate room you must be at least 18 years old", "Wrong age");
                return;
            }
            if (_mode == FormMode.Edit)
            {
                if (pass.Equals(""))
                {
                    if (ConfirmationPopup.ShowDialog("There is nothing in password box and you can't change it to empty. Do you confirm? ", "No password")) {
                        if (!_userManager.managedUser.Equals(null))
                        {
                            _userManager.update(this.firstName.Text, this.secondName.Text, this.dateOfBirth.Value, this.phoneNum.Text, this.postCode.Text, this.city.Text, this.eMail.Text, this.street.Text, this.houseNum.Text, this.flatNum.Text, this.country.Text, this.password.Text);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (!_userManager.managedUser.Equals(null))
                    {
                        _userManager.update(this.firstName.Text, this.secondName.Text, this.dateOfBirth.Value, this.phoneNum.Text, this.postCode.Text, this.city.Text, this.eMail.Text, this.street.Text, this.houseNum.Text, this.flatNum.Text, this.country.Text, this.password.Text);
                    }
                }

            }
            else if (_mode == FormMode.NewElement) 
            {

                if (pass.Equals(""))
                {
                    InformationPopup.ShowDialog("Password is mandatory to create account", "Not enough data");
                    return;
                }

                if (_userManager.add(this.firstName.Text, this.secondName.Text, this.dateOfBirth.Value, this.phoneNum.Text, this.postCode.Text, this.city.Text, this.eMail.Text, this.street.Text, this.houseNum.Text, this.flatNum.Text, this.country.Text, _isWorker, this.password.Text))
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
