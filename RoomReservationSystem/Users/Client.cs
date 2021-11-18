﻿using System;
using User;
using Address;
using Logon;

namespace Client
{
	public class Client : User
	{
		public string name { set; get; }
		public string surname { set; get; }
		public int id { set; get; }
		public Address address { set; get; }
		public Logon logon { set; get; }

		public Client()
		{
			
		}
	}
}