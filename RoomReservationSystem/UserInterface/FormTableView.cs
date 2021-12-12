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
        public FormTableView()
        {
            InitializeComponent();

        }

        public FormTableView(TableType type)
        {
            InitializeComponent();

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

            // table.Controls.Add() <- dodatnie kontrolki do odpowiedniego wiersza i kolumny, u nas to labele
        }

        public void InitializeTableWithClientReservationsHistory()
        {
            // do zrobienia: kolumny: from, to, room id/name, price
        }

        public void InitializeTableWithRoomHistory()
        {
            // do zrobienia: kolumny: from, to, room id/name, price
        }
    }
}
