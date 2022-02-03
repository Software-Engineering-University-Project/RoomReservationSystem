using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manager;
using Reservations;
using RoomReservationSyster;

namespace RoomReservationSystem.UserInterface
{
    // this.considerDateCheckBox.Checked <= pobieranie boola z checkboxa
    public partial class FormSearchRooms : Form
    {
        ReservationManager _reservationManager
        public FormSearchRooms()
        {
            InitializeComponent();
            FillFacilitiesList();
            FillGuestComboBox();
            FillTypesOfBedList();
            roomsList.Clear();
            _reservationManager = new ReservationManager();
        }

        private RoomManager _roomManager;
        public FormSearchRooms(RoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            //brak walidacji
            double priceMin = Int32.Parse(priceFrom.Text);
            double priceMax = Int32.Parse(priceTo.Text);

            DateTime dateFrom = this.dateFrom.Value;
            DateTime dateTo = this.dateTo.Value;

            int guests = comboBoxGuestsNum.SelectedIndex;

            List<BedType> bedList = new List<BedType>();
            List<RoomFacilities> facilities = new List<RoomFacilities>();

            var checkedBeds = typesOfBedList.CheckedIndices;

            foreach (var bed in checkedBeds)
            {
                bedList.Add((BedType) bed);
            }

            var checkedFacilities = facilitiesList.CheckedIndices;

            foreach (var fac in checkedFacilities)
            {
                facilities.Add((RoomFacilities) fac);
            }

            List<RoomFacilities> selectedFacilities = new List<RoomFacilities>();
            foreach (var checkedFacility in checkedFacilities)
            {
                selectedFacilities.Add((RoomFacilities)checkedFacility);
            }
            List<Room> rooms = Searcher.SearchRooms(dateFrom, dateTo, selectedFacilities,
                priceMin, priceMax, guests);

            foreach (Room r in rooms)
            {
                List<Reservation> reservations = _reservationManager.getReservations(r.id, true);
                bool isOccupied = false;
                foreach (Reservation re in reservations)
                {
                    if ((dateFrom > re.checkInDate ? dateFrom : re.checkInDate) <= (dateTo < re.checkOutDate ? dateTo : re.checkOutDate))
                    {
                        isOccupied = true;
                    }
                }
                if (!isOccupied)
                {
                    roomsList.Items.Add(r.id.ToString());
                }
            }
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
            Room room = Searcher.SearchRoomById(Convert.ToInt32(roomsList.FocusedItem.Text));
            ViewManager.GetInstance().DisplayChildForm(new FormRoom(room));
        }
    }
}