using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoomReservationSystem;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormSearchWorker : Form
    {
        public FormSearchWorker()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        public void InitializeComboBox()
        {
            comboBoxSearchWorker.Items.Add("Name");
            comboBoxSearchWorker.Items.Add("Surname");
            comboBoxSearchWorker.Items.Add("PhoneNumber");
            comboBoxSearchWorker.Items.Add("Email");
            comboBoxSearchWorker.Items.Add("Street");
            comboBoxSearchWorker.Items.Add("Country");
            comboBoxSearchWorker.Items.Add("City");
        }

        private void buttonSearchWorker_Click(object sender, EventArgs e)
        {
            var people = Searcher.SearchWorker(comboBoxSearchWorker.GetItemText(comboBoxSearchWorker.SelectedItem), textBoxSearchWorker.Text);

            listViewWorkers.Items.Clear();
            listViewWorkers.Columns.Clear();
            listViewWorkers.View = View.Details;
            listViewWorkers.Columns.Add("ID");
            listViewWorkers.Columns.Add("Name");
            listViewWorkers.Columns.Add("Surname");
            listViewWorkers.Columns.Add("Phone Number");
            listViewWorkers.Columns.Add("Birth Date");
            listViewWorkers.Columns.Add("Email Address");
            listViewWorkers.Columns.Add("Street");
            listViewWorkers.Columns.Add("Property No");
            listViewWorkers.Columns.Add("Apartament No");
            listViewWorkers.Columns.Add("Post Code");
            listViewWorkers.Columns.Add("Country");
            listViewWorkers.Columns.Add("City");

            foreach (var person in people)
            {
                listViewWorkers.Items.Add(new ListViewItem(new string[] { person.id.ToString(), person.name, person.surname, person.logon.phoneNumber, person.BirthDate.ToString(),
                                                            person.logon.email, person.address.street, person.address.propertyNumber, person.address.apartmentNumber,
                                                            person.address.postCode, person.address.country, person.address.city}));
            }
        }

        private void buttonDeleteWorker_Click(object sender, EventArgs e)
        {
            bool shouldDelete = ConfirmationPopup.ShowDialog("Do you confirm workers deletion?");

            if (shouldDelete)
                for (int i = 0; i < listViewWorkers.Items.Count; i++)
                {
                    if (listViewWorkers.Items[i].Selected)
                    {
                        int id = Int32.Parse(listViewWorkers.Items[i].SubItems[0].Text);
                        Searcher.DeleteUser(id);
                        listViewWorkers.Items[i].Remove();
                        i--;
                    }
                }
        }

        private void listViewWorkers_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}