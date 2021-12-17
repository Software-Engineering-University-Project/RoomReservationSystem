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

            foreach (var person in people)
            {
                listViewWorkers.Items.Add(new ListViewItem(new string[] { person.id.ToString(), person.name, person.surname }));
            }
        }
    }
}
