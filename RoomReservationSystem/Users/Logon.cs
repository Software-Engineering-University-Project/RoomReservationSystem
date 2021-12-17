using System;


namespace RoomReservationSystem
{
	public class Logon: Encoder

	{
		public string phoneNumber { set; get; }
		public string email { set; get; }
		public string passWord { set; get; }

		String passWordEnccrypted { set; get; }

		public Logon()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public String encodePassword()
		{
			byte[] data = System.Text.Encoding.ASCII.GetBytes(passWord);
			data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
			passWordEnccrypted = System.Text.Encoding.ASCII.GetString(data);
			return passWordEnccrypted;
		}

        
    }
}
