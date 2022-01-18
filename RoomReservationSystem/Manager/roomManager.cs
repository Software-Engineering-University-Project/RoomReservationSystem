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
	public class RoomManager 
	{
		public Room CurrentRoom { set; get; }
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
						command.ExecuteNonQuery();
					}
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
									command.Parameters.Add(new SqlParameter("@MaxRoomGuests", Convert.ToInt32(updateValues[parameter])));
									break;
								
								case "RoomNumber":
									command.Parameters.Add(new SqlParameter("@RoomNumber", updateValues[parameter]));
									break;
							}
						}
						command.ExecuteNonQuery();
					}
					DbCommand bedUpdate = factory.CreateCommand();
					 if (bedUpdate != null)
					 {
					 	List<BedType> bedTypes = new List<BedType>();
					 	bedUpdate.CommandType = System.Data.CommandType.StoredProcedure;
					 	bedUpdate.Connection = connection;
					 	bedUpdate.CommandText = "SearchRoomBeds";
					 	bedUpdate.Parameters.Add(new SqlParameter("@RoomId", id));
					 	using (DbDataReader dataReader = bedUpdate.ExecuteReader())
					 	{
					 		while (dataReader.Read())
					 		{
					 			bedTypes.Add((BedType) Enum.Parse(typeof(BedType),
					 				dataReader["BedDescription"].ToString(), true));
					 		}
					 	}
					
					 	List<BedType> toBeDeleted = new List<BedType>();
					 	foreach (BedType b in bedTypes)
					 	{
					 		if (!beds.Contains(b))
					 		{
					 			toBeDeleted.Add(b);
					 		}
					 	}
					 	beds.RemoveAll(b => bedTypes.Contains(b));
					 	foreach (BedType bed in toBeDeleted)
					 	{
					 		DbCommand bedDelete = factory.CreateCommand();
					 		if (bedDelete != null)
					 		{
					 			bedDelete.CommandType = System.Data.CommandType.StoredProcedure;
					 			bedDelete.Connection = connection;
					 			bedDelete.CommandText = "DeleteRoomBeds";
					 			bedDelete.Parameters.Add(new SqlParameter("@RoomId", id));
					 			bedDelete.Parameters.Add(new SqlParameter("@BedTypeDisc", bed.ToString()));
					 		}
					 	}
					
					 	foreach (BedType bed in beds)
					 	{
					 		DbCommand bedInsert = factory.CreateCommand();
					 		if (bedInsert != null)
					 		{
					 			bedInsert.CommandType = System.Data.CommandType.StoredProcedure;
					 			bedInsert.Connection = connection;
					 			bedInsert.CommandText = "Insert_BedTypesConnection";
					 			bedInsert.Parameters.Add(new SqlParameter("@RoomId", id));
					 			bedInsert.Parameters.Add(new SqlParameter("@BedDTypeID", (int)bed-1));
					 		}
					 	}
					 }
					 DbCommand mealUpdate = factory.CreateCommand();
					 if (mealUpdate != null)
					 {
					 	List<Meals> mealsTypes = new List<Meals>();
					 	mealUpdate.CommandType = System.Data.CommandType.StoredProcedure;
					 	mealUpdate.Connection = connection;
					 	mealUpdate.CommandText = "SearchRoomMeals";
					 	mealUpdate.Parameters.Add(new SqlParameter("@RoomId", id));
					 	using (DbDataReader dataReader = mealUpdate.ExecuteReader())
					 	{
					 		while (dataReader.Read())
					 		{
					 			mealsTypes.Add((Meals) Enum.Parse(typeof(Meals),
					 				dataReader["MealTypeDescription"].ToString(), true));
					 		}
					 	}
					
					 	List<Meals> toBeDeleted = new List<Meals>();
					 	foreach (Meals m in mealsTypes)
					 	{
					 		if (!meals.Contains(m))
					 		{
					 			toBeDeleted.Add(m);
					 		}
					 	}
					 	meals.RemoveAll(m => mealsTypes.Contains(m));
					 	foreach (Meals meal in toBeDeleted)
					 	{
					 		DbCommand bedDelete = factory.CreateCommand();
					 		if (bedDelete != null)
					 		{
					 			bedDelete.CommandType = System.Data.CommandType.StoredProcedure;
					 			bedDelete.Connection = connection;
					 			bedDelete.CommandText = "DeleteRoomBeds";
					 			bedDelete.Parameters.Add(new SqlParameter("@RoomId", id));
					 			bedDelete.Parameters.Add(new SqlParameter("@BedTypeDisc", meal.ToString()));
					 		}
					 	}
					
					 	foreach (Meals meal in meals)
					 	{
					 		DbCommand mealInsert = factory.CreateCommand();
					 		if (mealInsert != null)
					 		{
					 			mealInsert.CommandType = System.Data.CommandType.StoredProcedure;
					 			mealInsert.Connection = connection;
					 			mealInsert.CommandText = "Insert_MealsTypeConnection";
					 			mealInsert.Parameters.Add(new SqlParameter("@RoomId", id));
					 			mealInsert.Parameters.Add(new SqlParameter("@MealTypeID", (int)meal-1));
					 		}
					 	}
					 }
					 DbCommand facilitiesUpdate = factory.CreateCommand();
					 if (facilitiesUpdate != null)
					 {
					 	List<RoomFacilities> roomFacilities = new List<RoomFacilities>();
					 	facilitiesUpdate.CommandType = System.Data.CommandType.StoredProcedure;
					 	facilitiesUpdate.Connection = connection;
					 	facilitiesUpdate.CommandText = "SearchRoomFacilities";
					 	facilitiesUpdate.Parameters.Add(new SqlParameter("@RoomId", id));
					 	using (DbDataReader dataReader = facilitiesUpdate.ExecuteReader())
					 	{
					 		while (dataReader.Read())
					 		{
					 			roomFacilities.Add((RoomFacilities) Enum.Parse(typeof(RoomFacilities),
					 				dataReader["FacilityDescription"].ToString(), true));
					 		}
					 	}
					
					 	List<RoomFacilities> toBeDeleted = new List<RoomFacilities>();
					 	foreach (RoomFacilities f in roomFacilities)
					 	{
					 		if (!facilities.Contains(f))
					 		{
					 			toBeDeleted.Add(f);
					 		}
					 	}
					
					 	facilities.RemoveAll(m => roomFacilities.Contains(m));
					 	foreach (RoomFacilities f in toBeDeleted)
					 	{
					 		DbCommand facilitiesDelete = factory.CreateCommand();
					 		if (facilitiesDelete != null)
					 		{
					 			facilitiesDelete.CommandType = System.Data.CommandType.StoredProcedure;
					 			facilitiesDelete.Connection = connection;
					 			facilitiesDelete.CommandText = "DeleteRoomFacilitiesConnection";
					 			facilitiesDelete.Parameters.Add(new SqlParameter("@RoomId", id));
					 			facilitiesDelete.Parameters.Add(new SqlParameter("@FacilityId", (int) f - 1));
					 		}
					 	}
					
					 	foreach (RoomFacilities f in facilities)
					 	{
					 		DbCommand facilityInsert = factory.CreateCommand();
					 		if (facilityInsert != null)
					 		{
					 			facilityInsert.CommandType = System.Data.CommandType.StoredProcedure;
					 			facilityInsert.Connection = connection;
					 			facilityInsert.CommandText = "Insert_RoomFacilitiesConnection";
					 			facilityInsert.Parameters.Add(new SqlParameter("@RoomId", id));
					 			facilityInsert.Parameters.Add(new SqlParameter("@RoomFacilityID", (int) f - 1));
					 		}
					 	}
					 }
				}
			}
		}

		public void Insert(string roomNumber, double price, double squareMeterage, int maxGuest,
			List<BedType> beds, List<Meals> meals, List<RoomFacilities> facilities, string standard)
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
						command.Parameters.Add(new SqlParameter("@RoomStandard", standard));
						command.Parameters.Add(new SqlParameter("@RoomMaxGuestNumber", maxGuest));
						command.Parameters.Add(new SqlParameter("@RoomNumber", roomNumber));
						command.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Int));
						command.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;
						command.ExecuteNonQuery();
						roomId = (int) command.Parameters["@ReturnValue"].Value;
					}
					
					foreach (var bed in beds)
					{
						DbCommand addBeds = factory.CreateCommand();
						if (addBeds != null)
						{
							addBeds.CommandType = System.Data.CommandType.StoredProcedure;
							addBeds.Connection = connection;
							addBeds.CommandText = "Insert_BedTypesConnection";
							addBeds.Parameters.Add(new SqlParameter("@RoomId", roomId));
							addBeds.Parameters.Add(new SqlParameter("@BedDTypeID", (int) bed + 1));
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
					foreach (var meal in meals)
					{
						DbCommand addMeals = factory.CreateCommand();
						if (addMeals != null)
						{
							addMeals.CommandType = System.Data.CommandType.StoredProcedure;
							addMeals.Connection = connection;
							addMeals.CommandText = "Insert_MealsTypeConnection";
							addMeals.Parameters.Add(new SqlParameter("@RoomId", roomId));
							addMeals.Parameters.Add(new SqlParameter("@MealTypeID", (int) meal + 1));
							addMeals.ExecuteNonQuery();
						}
					}
				}
			}
		}

		public void GetUserById(int id)
		{
			CurrentRoom = Searcher.SearchRoomById(id);
		}
	}
}