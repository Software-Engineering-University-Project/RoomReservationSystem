using Manager;
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
using RoomReservationSyster;

namespace RoomReservationSystem.UserInterface
{
    public partial class RoomReservationSystem : Form
    {
        private Button _currentButton;
        private Random _random;
        private int _tempIndex;
        private ViewManager _viewManager = ViewManager.GetInstance();
        private UserManager _userManager;
        private RoomManager _roomManager;
        public RoomReservationSystem()
        {
            InitializeComponent();
            ViewManager.SetDesktopPanel(this.panelDesktopPane);
            _random = new Random();
            //  btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            _userManager = new UserManager();
            _roomManager = new RoomManager();
            EnableGuestPermissions();
        }

        

        private void SetButtonsVisibility(bool logProfile = true, bool logOut = false, bool reservations = false, bool newReservation = false, bool newClient = true, bool newRoom = false,
            bool newWorker = false, bool searchClients = false, bool searchWorkers = false)
        {
            this.buttonLogInProfile.Visible = logProfile;
            this.logOutButton.Visible = logOut;
            this.buttonReservations.Visible = reservations;
            this.buttonNewReservation.Visible = newReservation;
            this.buttonNewClient.Visible = newClient;
            this.buttonNewRoom.Visible = newRoom;
            this.buttonNewWorker.Visible = newWorker;
            this.buttonSearchClients.Visible = searchClients;
            this.buttonSearchWorkers.Visible = searchWorkers;
        }

        public void EnableGuestPermissions()
        {
            this.buttonLogInProfile.Text = "Log in";
            SetButtonsVisibility();
        }
        public void EnableClientPermissions()
        {
            this.buttonLogInProfile.Text = "Profile";
            SetButtonsVisibility(true, true, false, false, false);
        }
        public void EnableWorkerPermissions()
        {
            this.buttonLogInProfile.Text = "Profile";
            SetButtonsVisibility(true, true, true, true, false, false, true, false);
        }

        public void EnableAdminPermissions()
        {
            this.buttonLogInProfile.Text = "Profile";
            SetButtonsVisibility(true, true, true, true, true, true, true, true, true);
        }

        public void LogOutLayoutSetter()
        {
            EnableGuestPermissions();
            OpenChildForm(new FormLogIn(this, buttonLogInProfile, _userManager), buttonLogInProfile, "LOG IN");
        }

        private Color SelectThemeColor()
        {
            int index = _random.Next(ThemeColor.ColorList.Count);
            while (_tempIndex == index)
            {
                index = _random.Next(ThemeColor.ColorList.Count);
            }
            _tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }


        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_currentButton != (Button)btnSender)
                {
                    UnselectButton();
                    Color color = SelectThemeColor();
                    _currentButton = (Button)btnSender;
                    _currentButton.BackColor = color;
                    _currentButton.ForeColor = Color.White;
                    _currentButton.Font = new System.Drawing.Font("Calibri", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void UnselectButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender, String header)
        {
            _viewManager.DisplayChildForm(childForm, this.panelDesktopPane);   
            ActivateButton(btnSender);
            labelTitleBar.Text = header;
        }

        private void buttonSearchRooms_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSearchRooms(_roomManager, _userManager), sender, "SEARCH ROOMS");
        }

        private void buttonReservations_Click(object sender, EventArgs e)
        {

              OpenChildForm(new FormTableView(), sender, "RESERVATIONS");
        }

        private void buttonNewReservation_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMakeReservation(), sender, "NEW RESERVATION");
        }

        private void buttonSearchClients_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSearchClient(), sender, "SEARCH CLIENTS");
        }

        private void buttonNewClient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNewPerson(FormMode.NewElement, false, _userManager), sender, "NEW CLIENT");
        }

        private void buttonSearchWorkers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSearchWorker(), sender, "SEARCH WORKERS");
        }

        private void buttonNewWorker_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNewPerson(FormMode.NewElement, true, _userManager), sender, "NEW WORKER");
        }

        private void buttonNewRoom_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNewRoom(_roomManager, FormMode.NewElement), sender, "NEW ROOM");
        }

        private void RoomReservationSystem_Load(object sender, EventArgs e)
        {

        }


        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            _userManager.logout();
            LogOutLayoutSetter();
        }
        public void afterChangeUserOpenForm(object sender)
        {
            OpenChildForm(new FormProfile(_userManager, this), sender, "PROFILE");
        }
        private void buttonLogInProfile_Click(object sender, EventArgs e)
        {
            if (_userManager.currUser == null)
            {
                OpenChildForm(new FormLogIn(this,sender, _userManager), sender, "LOG IN");
                //brak informacji o typie użytkownika

            }
            else { 
                OpenChildForm(new FormProfile(_userManager, this), sender, "PROFILE");
            }
        }
    }
}