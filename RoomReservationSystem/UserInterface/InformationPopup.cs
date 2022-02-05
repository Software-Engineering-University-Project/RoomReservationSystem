using System.Windows.Forms;

namespace RoomReservationSystem.UserInterface
{
    class InformationPopup
    {
        public static void ShowDialog(string message = "Warning ", string caption = "Warning")
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
        }
    }
}
