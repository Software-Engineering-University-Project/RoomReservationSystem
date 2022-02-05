using Manager;
using Reservations;
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
    public partial class FormTableView : Form
    {
        ReservationManager _reservationManager;
        int searchID;
        public FormTableView()
        {
            InitializeComponent();
            _reservationManager = new ReservationManager();
            searchID = 0;
        }

        public FormTableView(TableType type, int id)
        {
            InitializeComponent();
            _reservationManager = new ReservationManager();
            searchID = id;
            switch (type)
            {
                case (TableType.UserReservationsHistory):
                    {

                        InitializeTableWithClientReservationsHistory();
                    }
                    break;
                case (TableType.RoomHistory):
                    {

                        InitializeTableWithRoomHistory();
                    }
                    break;
                case (TableType.AllReservationsHistory):
                    {
                        InitializeTableWithAllReservations();
                    }
                    break;
            }



        }

        public void InitializeTableWithAllReservations()
        {
            listView.Items.Clear();
            listView.Columns.Clear();
            listView.View = View.Details;
            listView.Columns.Add("From");
            listView.Columns.Add("To");
            listView.Columns.Add("Room ID");
            listView.Columns.Add("Client ID");

            
            // do zrobienia: kolumny: from, to, room id, person id
            List<Reservation> reservList = _reservationManager.displayReservations();
            foreach (var r in reservList)
            {
                listView.Items.Add(new ListViewItem(new string[] { r.checkInDate.ToString(), r.checkOutDate.ToString(), r.clientId.ToString(), r.roomId.ToString() }));
            }

        }

        public void InitializeTableWithRoomHistory()
        {
            listView.Items.Clear();
            listView.Columns.Clear();
            listView.View = View.Details;
            listView.Columns.Add("From");
            listView.Columns.Add("To");
            listView.Columns.Add("Room ID");
            listView.Columns.Add("price");
            // do zrobienia: kolumny: from, to, room id/name, price
            List<Reservation> reservList = _reservationManager.getReservations(searchID, true);
            foreach (var r in reservList)
            {
                listView.Items.Add(new ListViewItem(new string[] { r.checkInDate.ToString(), r.checkOutDate.ToString(), r.roomId.ToString(), r.price.ToString() }));
            }
        }

        public void InitializeTableWithClientReservationsHistory()
        {
            listView.Items.Clear();
            listView.Columns.Clear();
            listView.View = View.Details;
            listView.Columns.Add("From");
            listView.Columns.Add("To");
            listView.Columns.Add("Room ID");
            listView.Columns.Add("price");


            // do zrobienia: kolumny: from, to, room id/name, price
            List<Reservation> reservList = _reservationManager.getReservations(searchID, false);
            foreach (var r in reservList)
            {
                listView.Items.Add(new ListViewItem(new string[] { r.checkInDate.ToString(), r.checkOutDate.ToString(), r.roomId.ToString(), r.price.ToString()}));
            }
            
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
