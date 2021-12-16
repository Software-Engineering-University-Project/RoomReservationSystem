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
    public partial class FormSearchClient : Form
    {
        public FormSearchClient()
        {
            InitializeComponent();
            InitializeComboBox();
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

            foreach (var person in people)
            {
                listViewClients.Items.Add(new ListViewItem(new string[] { person.id.ToString(), person.name, person.surname }));
            }
        }
    }
}
