using System.Windows.Forms;

namespace RoomReservationSystem.UserInterface
{
    class ConfirmationPopup
    {
        public static bool ShowDialog(string message= "Do you confirm? ", string caption = "Warning")
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                return true;
            }
            else
                return false;
        }
    }
}
