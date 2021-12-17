using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using RoomReservationSystem;

namespace RoomReservationSyster
{
	public class RoomManager : Manager.Manager
	{
		private Room _currentRoom;

		public RoomManager()
		{
			_currentRoom = new Room();
		}

		public void Delete(int id)
		{
			string provider = ConfigurationManager.AppSettings["provider"];
			string connectionString = ConfigurationManager.AppSettings["connectionString"];
			DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
			using (DbConnection connection = factory.CreateConnection())
			{
				if (connection != null)
				{
					connection.ConnectionString = connectionString;
					connection.Open();

					DbCommand command = factory.CreateCommand();
					if (command != null)
					{
						command.CommandType = System.Data.CommandType.StoredProcedure;
						command.Connection = connection;
						command.CommandText = "DeleteRoom";
						command.Parameters.Add(new SqlParameter("@RoomId", id));
					}
					command.ExecuteNonQuery();
				}
			}
		}

		public void Update(int id, Dictionary<string, string> updateValues, List<BedType> beds, 
			List<Meals> meals, List<RoomFacilities>facilities)
		{ 
			string provider = ConfigurationManager.AppSettings["provider"];
			string connectionString = ConfigurationManager.AppSettings["connectionString"];
			DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
			using (DbConnection connection = factory.CreateConnection())
			{
				if (connection != null)
				{
					connection.ConnectionString = connectionString;
					connection.Open();
					DbCommand command = factory.CreateCommand();
					if (command != null)
					{
						command.CommandType = System.Data.CommandType.StoredProcedure;
						command.Connection = connection;
						command.CommandText = "UpdateRoom";
						command.Parameters.Add(new SqlParameter("@RoomId", id));
						foreach (string parameter in updateValues.Keys)
						{
							switch (parameter)
							{
								case "Price":
									command.Parameters.Add(new SqlParameter("@Price",
										float.Parse(updateValues[parameter])));
									break;

								case "SquareMeterage":
									command.Parameters.Add(new SqlParameter("@SquareMeterage",
										float.Parse(updateValues[parameter])));
									break;

								case "Status":
									command.Parameters.Add(new SqlParameter("@Status", updateValues[parameter]));
									break;

								case "RoomStandard":
									command.Parameters.Add(new SqlParameter("@RoomStandard", updateValues[parameter]));
									break;

								case "MaxRoomGuests":
									command.Parameters.Add(new SqlParameter("@MaxRoomGuests", updateValues[parameter]));
									break;

							}
						}
						command.ExecuteNonQuery();
					}
				}
			}
		}

		public void Insert(string roomNumber, double price, double squareMeterage, int maxGuest,
			List<BedType> beds, List<Meals> meals, List<RoomFacilities> facilities, RoomStandard standard)
		{
			string provider = ConfigurationManager.AppSettings["provider"];
			string connectionString = ConfigurationManager.AppSettings["connectionString"];
			DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
			using (DbConnection connection = factory.CreateConnection())
			{
				int roomId = 0;
				if (connection != null)
				{
					connection.ConnectionString = connectionString;
					connection.Open();
					DbCommand command = factory.CreateCommand();
					if (command != null)
					{
						command.CommandType = System.Data.CommandType.StoredProcedure;
						command.Connection = connection;
						command.CommandText = "Insert_Rooms";
						command.Parameters.Add(new SqlParameter("@RoomPrice", price));
						command.Parameters.Add(new SqlParameter("@RoomSquareMetrage", squareMeterage));
						command.Parameters.Add(new SqlParameter("@RoomStandard", standard.ToString()));
						command.Parameters.Add(new SqlParameter("@RoomMaxGuestNumber", maxGuest));
						command.Parameters.Add(new SqlParameter("@RoomNumber", roomNumber));
						command.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Int));
						command.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;
						command.ExecuteNonQuery();
						roomId = (int) command.Parameters["@ReturnValue"].Value;
					}
					DbCommand addBeds = factory.CreateCommand();
					if (addBeds != null)
					{
						foreach (var bed in beds)
						{
							addBeds.CommandType = System.Data.CommandType.StoredProcedure;
							addBeds.Connection = connection;
							addBeds.CommandText = "Insert_BedTypesConnection";
							addBeds.Parameters.Add(new SqlParameter("@RoomId", roomId));
							addBeds.Parameters.Add(new SqlParameter("@BedDTypeID", (int)bed+1));
							addBeds.ExecuteNonQuery();
						}
					}


					foreach (var facility in facilities)
					{
						DbCommand addFacilities = factory.CreateCommand();
						if (addFacilities != null)
						{
							
							addFacilities.CommandType = System.Data.CommandType.StoredProcedure;
							addFacilities.Connection = connection;
							addFacilities.CommandText = "Insert_RoomFacilitiesConnection";
							addFacilities.Parameters.Add(new SqlParameter("@RoomId", roomId));
							addFacilities.Parameters.Add(new SqlParameter("@RoomFacilityID", (int) facility + 1));
							addFacilities.ExecuteNonQuery();
						}
					}

					DbCommand addMeals = factory.CreateCommand();
					if (addMeals != null)
					{
						foreach (var meal in meals)
						{
							addMeals.CommandType = System.Data.CommandType.StoredProcedure;
							addMeals.Connection = connection;
							addMeals.CommandText = "Insert_MealsTypeConnection";
							addMeals.Parameters.Add(new SqlParameter("@RoomId", roomId));
							addMeals.Parameters.Add(new SqlParameter("@MealTypeID", (int)meal + 1));
							addMeals.ExecuteNonQuery();
						}
					}
				}
			}
		}
	}
}
	

