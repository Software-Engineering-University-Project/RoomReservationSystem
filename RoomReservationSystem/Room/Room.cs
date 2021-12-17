using System;
using System.Collections.Generic;
using RoomReservationSyster;

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
        public RoomState roomState { set; get; }

        public Room()
        {
            beds = new List<BedType>();
            mealsProvided = new List<Meals>();
            facilitiesProvided = new List<RoomFacilities>();
        }
        
    }
}