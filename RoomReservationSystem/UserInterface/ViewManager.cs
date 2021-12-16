using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservationSystem.UserInterface
{
    class ViewManager
    {
        static private ViewManager _instance;

        private static Form _activeForm = null;

        private static Panel _desktopPanel = null;
        private ViewManager() { }

        public static ViewManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ViewManager();
            }
            return _instance;
        }

        public static void SetDesktopPanel(Panel panel)
        {
            _desktopPanel = panel;
        }
        public void  DisplayChildForm(Form childForm, Panel panelDesktopPane = null)
        {
            if (panelDesktopPane == null && _desktopPanel != null)
            {
                panelDesktopPane = _desktopPanel;
            }

            if(panelDesktopPane != null)
            { 
                if (_activeForm != null)
                    _activeForm.Close();

                _activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelDesktopPane.Controls.Add(childForm);
                panelDesktopPane.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }


    }
}
