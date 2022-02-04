using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manager;
using Users;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormLogIn : Form
    {
        public FormLogIn(RoomReservationSystem parentForm, object sender, UserManager userManager)
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
            password.PasswordChar = '*';
            _userManager = userManager;
            _parent = parentForm;
            _sender = sender;
        }

        private UserManager _userManager;

        private RoomReservationSystem _parent;
        private object _sender;
        //to delete
        private void FormLogIn_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            //login
            if(password.Text != "")
            {
                if (login.Text != "")
                {
                    _userManager.login(password.Text, login.Text);
                    if (_userManager.currUser != null)
                    {
                        if (_userManager.currUser == null)
                        {
                            _parent.EnableGuestPermissions();
                        }
                        else if (_userManager.currUser is Admin)
                        {
                            _parent.EnableAdminPermissions();
                        }
                        else if (_userManager.currUser is Worker)
                        {
                            _parent.EnableWorkerPermissions();
                        }
                        else if (_userManager.currUser is Client)
                        {
                            _parent.EnableClientPermissions();
                        }
                        _parent.afterChangeUserOpenForm(_sender);
                    }
                    else
                    {
                        password.Text = "";
                        login.Text ="";
                        InformationPopup.ShowDialog("Wrong login or password provided", "Wrond data");
                    }
                }
                else
                {
                    InformationPopup.ShowDialog("No login provided", "No login");
                }
            }
            else
            {
                InformationPopup.ShowDialog("No password provided", "No password");
            }
            
        }
    }
}
