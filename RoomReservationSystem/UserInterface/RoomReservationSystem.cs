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
using Users;

namespace RoomReservationSystem.UserInterface
{
    public partial class RoomReservationSystem : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private ViewManager viewManager = ViewManager.GetInstance();
        private UserManager userManager;
        public RoomReservationSystem()
        {
            InitializeComponent();
            ViewManager.SetDesktopPanel(this.panelDesktopPane);
            random = new Random();
            //  btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //do zrobienia: zmiana nazwy buttona logInProfile, na razie brakuje informacji o obecnym użytkowniku
            userManager = new UserManager();
            EnableGuestPermissions();
        }

        

        private void SetButtonsVisibility(bool logProfile = true, bool reservations = false, bool newReservation = false, bool newClient = false, bool newRoom = false,
            bool newWorker = false, bool searchClients = false, bool searchWorkers = false)
        {
            buttonLogInProfile.Visible = logProfile;
            buttonReservations.Visible = reservations;
            buttonNewReservation.Visible = newReservation;
            buttonNewClient.Visible = newClient;
            buttonNewRoom.Visible = newRoom;
            buttonNewWorker.Visible = newWorker;
            buttonSearchClients.Visible = searchClients;
            buttonSearchWorkers.Visible = searchWorkers;
        }

        public void EnableGuestPermissions()
        {
            buttonLogInProfile.Text = "Log in";
            SetButtonsVisibility();
        }
        public void EnableClientPermissions()
        {
            buttonLogInProfile.Text = "Profile";
            SetButtonsVisibility();
        }
        public void EnableWorkerPermissions()
        {
            buttonLogInProfile.Text = "Profile";
            SetButtonsVisibility(true, true, true, false, false, true, false);
        }

        public void EnableAdminPermissions()
        {
            SetButtonsVisibility(false, true, true, true, true, true, true, true);
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }


        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    UnselectButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Calibri", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            viewManager.DisplayChildForm(childForm, this.panelDesktopPane);   
            ActivateButton(btnSender);
            labelTitleBar.Text = header;
        }

        private void buttonLogInProfile_Click(object sender, EventArgs e)
        {//if ...
            if (userManager.currUser == null)
            {
                OpenChildForm(new FormLogIn(this,sender, userManager), sender, "LOG IN");
                //brak informacji o typie użytkownika

            }
            else { 
                OpenChildForm(new FormProfile(userManager), sender, "PROFILE");
            }
        }

        private void buttonSearchRooms_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSearchRooms(), sender, "SEARCH ROOMS");
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
            OpenChildForm(new FormNewPerson(FormMode.NewElement, false, userManager), sender, "NEW CLIENT");
        }

        private void buttonSearchWorkers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSearchWorker(), sender, "SEARCH WORKERS");
        }

        private void buttonNewWorker_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNewPerson(FormMode.NewElement, true, userManager), sender, "NEW WORKER");
        }

        private void buttonNewRoom_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNewRoom(FormMode.NewElement), sender, "NEW ROOM");
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

        public void afterChangeUserOpenForm(object sender)
        {
            
            OpenChildForm(new FormProfile(userManager), sender, "PROFILE");
        }
    }
}