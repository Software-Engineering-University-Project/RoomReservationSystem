using Manager;
using Reservations;
using System;
using System.Collections.Generic;
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
            InitializeTableAdminView();
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
                case (TableType.AdminView):
                    {
                        InitializeTableAdminView();
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
            
            List<Reservation> reservList = _reservationManager.displayReservations();
            foreach (var r in reservList)
            {
                listView.Items.Add(new ListViewItem(new string[] { r.checkInDate.ToString(), r.checkOutDate.ToString(), r.clientId.ToString(), r.roomId.ToString() }));
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewHeaderWidth();
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
            List<Reservation> reservList = _reservationManager.getReservations(searchID, true);
            foreach (var r in reservList)
            {
                listView.Items.Add(new ListViewItem(new string[] { r.checkInDate.ToString(), r.checkOutDate.ToString(), r.roomId.ToString(), r.price.ToString() }));
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewHeaderWidth();
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

            
            List<Reservation> reservList = _reservationManager.getReservations(searchID, false);
            foreach (var r in reservList)
            {
                listView.Items.Add(new ListViewItem(new string[] { r.checkInDate.ToString(), r.checkOutDate.ToString(), r.roomId.ToString(), r.price.ToString()}));
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewHeaderWidth();
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
        
        }

        public void InitializeTableAdminView()
        {
            listView.Items.Clear();
            listView.Columns.Clear();
            listView.View = View.Details;
            listView.Columns.Add("ID");
            listView.Columns.Add("Date");
            listView.Columns.Add("Room ID");
            listView.Columns.Add("Total Price");
            listView.Columns.Add("From");
            listView.Columns.Add("To");

            List<Reservation> reservationList = _reservationManager.displayAllReservations();
            foreach (var r in reservationList)
            {
                listView.Items.Add(new ListViewItem(new string[] { r.id.ToString(), r.reservationDate.ToString(), r.roomId.ToString(), r.price.ToString(), r.checkInDate.ToString(), r.checkOutDate.ToString() }));
            }

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewHeaderWidth();
        }
        
        private void ListViewHeaderWidth() {
            int HeaderWidth = (listView.Parent.Width - 2) / listView.Columns.Count;
            foreach (ColumnHeader header in listView.Columns)
            {
                header.Width = HeaderWidth;
            }
        }
    }
}
