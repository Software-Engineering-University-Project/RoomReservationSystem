using System;


namespace RoomReservationSystem
{
	public class Client : User
	{
		public string name { set; get; }
		public string surname { set; get; }
		public int id { set; get; }
		public Address address { set; get; }
		public Logon logon { set; get; }

		public DateTime BirthDate { set; get; }

		public Client()
		{
			address = new Address();
			logon = new Logon();
		}
	}
}
