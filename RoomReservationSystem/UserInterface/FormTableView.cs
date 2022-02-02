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

        private void SetTableColumnsAndRows(int rows, int columns)
        {
            table.ColumnCount = rows;
            table.RowCount = columns;
        }

        public void InitializeTableWithAllReservations()
        {
            // do zrobienia: kolumny: from, to, room id, person id
            // SetTableColumnsAndRows(, );
            List<Reservation> reservlist = _reservationManager.displayReservations();
            SetTableColumnsAndRows(reservlist.Count, 4);
            // table.Controls.Add() <- dodatnie kontrolki do odpowiedniego wiersza i kolumny, u nas to labele

        }

        public void InitializeTableWithClientReservationsHistory()
        {
            // do zrobienia: kolumny: from, to, room id/name, price
            List<Reservation> reservlist = _reservationManager.getReservations(searchID, false);
            SetTableColumnsAndRows(reservlist.Count, 4);
        }

        public void InitializeTableWithRoomHistory()
        {

            // do zrobienia: kolumny: from, to, room id/name, price
            List<Reservation> reservlist = _reservationManager.getReservations(searchID, true);
            SetTableColumnsAndRows(reservlist.Count, 4);
        }
    }
}
