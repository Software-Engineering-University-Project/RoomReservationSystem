using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormSearchRooms : Form
    {
        public FormSearchRooms()
        {
            InitializeComponent();
            FillFacilitiesList();
            FillGuestComboBox();
            FillTypesOfBedList();
        }


        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            //brak walidacji
            double priceMin = Int32.Parse(priceFrom.Text);
            double priceMax = Int32.Parse(priceTo.Text);

            DateTime dateFrom = this.dateFrom.Value;
            DateTime dateTo = this.dateTo.Value;

            int guests = comboBoxGuestsNum.SelectedIndex +1;

            List<BedType> bedList = new List<BedType>();
            List<RoomFacilities> facilities = new List<RoomFacilities>();

            var checkedBeds = typesOfBedList.CheckedIndices;

            foreach (var bed in checkedBeds)
            {
                bedList.Add((BedType)bed);
            }

            var checkedFacilities = facilitiesList.CheckedIndices;

            foreach (var fac in  checkedFacilities)
            {
                facilities.Add((RoomFacilities)fac);
            }

            //wywołanie metody do wyszukiwania z parametrami
        }

        private void FillFacilitiesList()
        {
            foreach (var facility in Enum.GetNames(typeof(RoomFacilities)))
            {
                facilitiesList.Items.Add(facility);
            }
        }

        private void FillGuestComboBox()
        {
            for(int i=0; i< 8; i++ )
            {
                comboBoxGuestsNum.Items.Add(i.ToString());
            }
        }

        private void FillTypesOfBedList()
        {
            foreach (var bed in Enum.GetNames(typeof(BedType)))
            {
                typesOfBedList.Items.Add(bed);
            }
        }


        private void roomsList_DoubleClick(object sender, EventArgs e)
        {
            //wyświetlenie widoku pokoju
            //wyszukiwanie pokoju z listy
            //wyświetlanie pokoju
            //ViewManager.GetInstance().DisplayChildForm(new FormRoom(room));
        }

 
    }
}
