using System;

namespace Reservations
{
    class Reservation
    {
        public int id { set; get; }
        public DateTime reservationDate { set; get; }
        public int clientId { set; get; }
        public int roomId { set; get; }
        public double price { set; get; }
        public DateTime checkInDate { set; get; }
        public DateTime checkOutDate { set; get; }
    }
}