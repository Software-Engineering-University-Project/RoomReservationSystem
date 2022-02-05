using System;
using System.Windows.Forms;
using Manager;


namespace RoomReservationSystem.UserInterface
{
    public partial class FormSearchClient : Form
    {
        UserManager _userManager;
        public FormSearchClient(UserManager userManager)
        {
            InitializeComponent();
            InitializeComboBox();
            _userManager = userManager;
        }

        public void InitializeComboBox()
        {
            comboBoxSearchClient.Items.Add("Name");
            comboBoxSearchClient.Items.Add("Surname");
            comboBoxSearchClient.Items.Add("PhoneNumber");
            comboBoxSearchClient.Items.Add("Email");
            comboBoxSearchClient.Items.Add("Street");
            comboBoxSearchClient.Items.Add("Country");
            comboBoxSearchClient.Items.Add("City");
        }

        private void buttonSearchClient_Click(object sender, EventArgs e)
        {
            var people = Searcher.SearchClient(comboBoxSearchClient.GetItemText(comboBoxSearchClient.SelectedItem), textBoxSearchClient.Text);

            listViewClients.Items.Clear();
            listViewClients.Columns.Clear();
            listViewClients.View = View.Details;
            listViewClients.Columns.Add("ID");
            listViewClients.Columns.Add("Name");
            listViewClients.Columns.Add("Surname");
            listViewClients.Columns.Add("Phone Number");
            listViewClients.Columns.Add("Birth Date");
            listViewClients.Columns.Add("Email Address");
            listViewClients.Columns.Add("Street");
            listViewClients.Columns.Add("Property No");
            listViewClients.Columns.Add("Apartament No");
            listViewClients.Columns.Add("Post Code");
            listViewClients.Columns.Add("Country");
            listViewClients.Columns.Add("City");

            foreach (var person in people)
            {
                listViewClients.Items.Add(new ListViewItem(new string[] { person.id.ToString(), person.name, person.surname, person.logon.phoneNumber, person.BirthDate.ToString(),
                                                            person.logon.email, person.address.street, person.address.propertyNumber, person.address.apartmentNumber,
                                                            person.address.postCode, person.address.country, person.address.city}));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool shouldDelete = ConfirmationPopup.ShowDialog("Do you confirm clients deletion?");

            if (shouldDelete)
                for (int i = 0; i < listViewClients.Items.Count; i++)
            {
                if (listViewClients.Items[i].Selected)
                {
                    int id = int.Parse(listViewClients.Items[i].SubItems[0].Text);
                    Searcher.DeleteUser(id);
                    listViewClients.Items[i].Remove();
                    i--;
                }
            }
        }

        private void listViewClients_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = listViewClients.SelectedItems[0];
            if (item != null)
            {
                int id = int.Parse(item.SubItems[0].Text);
                _userManager.getManagedUser(id);
                ViewManager.GetInstance().DisplayChildForm(new FormProfile(_userManager));
            }
            
        }
    }
}