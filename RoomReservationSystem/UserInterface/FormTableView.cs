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
            table.Controls.Clear();
            // do zrobienia: kolumny: from, to, room id, person id
            // SetTableColumnsAndRows(, );
            List<Reservation> reservList = _reservationManager.displayReservations();
            SetTableColumnsAndRows(reservList.Count, 4);
            Label[] headerLabel = new Label[4];
            headerLabel[0].Text = "From";
            headerLabel[1].Text = "To";
            headerLabel[2].Text = "Room ID";
            headerLabel[3].Text = "Client ID";
            for (int i = 0; i < 4; i++)
            {
                table.Controls.Add(headerLabel[i], 0, i);
            }
            // table.Controls.Add() <- dodatnie kontrolki do odpowiedniego wiersza i kolumny, u nas to labele
            for (int i = 0; i< reservList.Count;i++)
            {
                Label[] lbl = new Label[4];
                lbl[0].Text = reservList[i].checkInDate.ToString();
                lbl[1].Text = reservList[i].checkOutDate.ToString();
                lbl[2].Text = reservList[i].roomId.ToString();
                lbl[3].Text = reservList[i].clientId.ToString();
                for(int j = 0; j < 4; j++)
                {
                    table.Controls.Add(lbl[j], j,i);
                }
                
            }
            
        }

        public void InitializeTableWithRoomHistory()
        {
            table.Controls.Clear();
            // do zrobienia: kolumny: from, to, room id/name, price
            List<Reservation> reservList = _reservationManager.getReservations(searchID, true);
            SetTableColumnsAndRows(reservList.Count, 4);
            List<Label> headerLabels = new List<Label>();
            for(int i = 0; i < 4; i++)
            {
                headerLabels.Add(new Label());
            }
            headerLabels[0].Text = "From";
            headerLabels[1].Text = "To";
            headerLabels[2].Text = "Room ID";
            headerLabels[3].Text = "Price";
            for (int i = 0; i < 4; i++)
            {
                table.Controls.Add(headerLabels[i], 0, i);
            }
            for (int i = 0; i < reservList.Count; i++)
            {
                List<Label> lbls = new List<Label>();
                for (int j = 0; j < 4; j++)
                {
                    lbls.Add(new Label());
                }
                lbls[0].Text = reservList[i].checkInDate.ToString();
                lbls[1].Text = reservList[i].checkOutDate.ToString();
                lbls[2].Text = reservList[i].roomId.ToString();
                lbls[3].Text = reservList[i].price.ToString();
                for (int j = 0; j < 4; j++)
                {
                    table.Controls.Add(lbls[j], j, i);
                }

            }
        }

        public void InitializeTableWithClientReservationsHistory()
        {
            table.Controls.Clear();
            // do zrobienia: kolumny: from, to, room id/name, price
            List<Reservation> reservList = _reservationManager.getReservations(searchID, false);
            SetTableColumnsAndRows(reservList.Count+1, 4);
            List<Label> headerLabels = new List<Label>();
            for(int i = 0; i < 4; i++)
            {
                headerLabels.Add(new Label());
            }
            headerLabels[0].Text = "From";
            headerLabels[1].Text = "To";
            headerLabels[2].Text = "Client ID";
            headerLabels[3].Text = "Price";
            for(int i = 0; i < 4; i++)
            {
                table.Controls.Add(headerLabels[i], i, 0);
            }
            

            for (int i = 0; i < reservList.Count; i++)
            {
                List<Label> lbls = new List<Label>();
                for (int j = 0; j < 4; j++)
                {
                    lbls.Add(new Label());
                }
                lbls[0].Text = reservList[i].checkInDate.ToString();
                lbls[1].Text = reservList[i].checkOutDate.ToString();
                lbls[2].Text = reservList[i].clientId.ToString();
                lbls[3].Text = reservList[i].price.ToString();
                for (int j = 0; j < 4; j++)
                {
                    table.Controls.Add(lbls[j], j, i+1);
                }

            }
        }
    }
}
