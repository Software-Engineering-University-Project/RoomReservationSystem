using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationSystem.Reservation
{
    class Reservation
    {
        public int id { set; get; }
        public DateTime reservationDate { set; get; }
        public int clientId { set; get; }
        public int roomId { set; get; }
        public float price { set; get; }
        public DateTime checkInDate { set; get; }
        public DateTime checkOutDate { set; get; }

        public Reservation()
        {

        }
    }
}
