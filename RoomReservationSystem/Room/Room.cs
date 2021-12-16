using System;
using System.Collections.Generic;

namespace RoomReservationSystem
{
    public class Room
    {
        public int id { set; get; }
        public string roomNumber { set; get; }
        public double price { set; get; }
        public double squareMeterage { set; get; }
        public int maxGuestNumber { set; get; }
        public List<BedType> beds { set; get; }
        public List<Meals> mealsProvided { set; get; }
        public List<RoomFacilities> facilitiesProvided { set; get; }
        public RoomStandard roomStandard { set; get; }
    }
}