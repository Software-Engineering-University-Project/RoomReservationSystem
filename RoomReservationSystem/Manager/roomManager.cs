using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security;
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
					connection.Close();
				}
			}
		}

		public void Update(string roomNumber, double price, double squareMeterage, int maxGuest, string standard, string comment,
			List<BedType> beds, List<Meals> meals, List<RoomFacilities> facilities)
		{
			Dictionary<string, string> updateValues =
				PrepareRoomUpdateData(roomNumber, price, squareMeterage, maxGuest, standard, comment);
			
			IEnumerable<BedType> bedsToDelete = CurrentRoom.beds.Except(beds);

			IEnumerable<BedType> bedsToAdd = beds.Except(CurrentRoom.beds);

			IEnumerable<Meals> mealsToDelete = CurrentRoom.mealsProvided.Except(meals);

			IEnumerable<Meals> mealsToAdd = meals.Except(CurrentRoom.mealsProvided);

			IEnumerable<RoomFacilities> facilitiesToDelete = CurrentRoom.facilitiesProvided.Except(facilities);

			IEnumerable<RoomFacilities> facilitiesToAdd = facilities.Except(CurrentRoom.facilitiesProvided);

			string provider = ConfigurationManager.AppSettings["provider"];
			string connectionString = ConfigurationManager.AppSettings["connectionString"];
			DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
			using (DbConnection connection = factory.CreateConnection())
			{
				if (connection != null)
				{
					connection.ConnectionString = connectionString;
					connection.Open();
					UpdateRoomData(connection, factory, updateValues);
					UpdateRoomBeds(connection, factory, bedsToAdd, bedsToDelete);
					UpdateRoomMeals(connection, factory, mealsToAdd, mealsToDelete);
					UpdateRoomFacilities(connection, factory, facilitiesToAdd, facilitiesToDelete);
					connection.Close();
				}
			}
		}

		public bool Insert(string roomNumber, double price, double squareMeterage, int maxGuest,
			List<BedType> beds, List<Meals> meals, List<RoomFacilities> facilities, string standard, string comment)
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
					DbCommand validation = factory.CreateCommand();
					if (validation!=null)
					{
						validation.CommandType = System.Data.CommandType.StoredProcedure;
						validation.Connection = connection;
						validation.CommandText = "Check_Unique_Values_Room";
						validation.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
						validation.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Bit));
						validation.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;

						validation.ExecuteNonQuery();
						bool check = Convert.ToBoolean(validation.Parameters["@ReturnValue"].Value);

						if (check == false)
						{
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
								command.Parameters.Add(new SqlParameter("@RoomComment", comment));
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
									addFacilities.Parameters.Add(
										new SqlParameter("@RoomFacilityID", (int) facility + 1));
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

						else
						{
							return false;
						}
					}
					connection.Close();
				}
			}
			return true;
		}


		public void ReadUserById(int id)
		{
			CurrentRoom = Searcher.SearchRoomById(id);
		}

		private void UpdateRoomData(DbConnection connection, DbProviderFactory factory,
			Dictionary<string, string> updateValues)
		{
			DbCommand command = factory.CreateCommand();
			if (command != null)
			{
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Connection = connection;
				command.CommandText = "UpdateRoom";
				command.Parameters.Add(new SqlParameter("@RoomId", CurrentRoom.id));
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
							command.Parameters.Add(new SqlParameter("@MaxRoomGuests",
								Convert.ToInt32(updateValues[parameter])));
							break;

						case "RoomNumber":
							command.Parameters.Add(new SqlParameter("@RoomNumber", updateValues[parameter]));
							break;
						
						case "RoomComment":
							command.Parameters.Add(new SqlParameter("@RoomComment", updateValues[parameter]));
							break;
					}
				}

				command.ExecuteNonQuery();
			}
		}

		private void UpdateRoomBeds(DbConnection connection, DbProviderFactory factory, IEnumerable<BedType> bedsToAdd,
			IEnumerable<BedType> bedsToDelete)
		{
			foreach (BedType bed in bedsToDelete)
			{
				DbCommand bedDelete = factory.CreateCommand();
				if (bedDelete != null)
				{
					bedDelete.CommandType = System.Data.CommandType.StoredProcedure;
					bedDelete.Connection = connection;
					bedDelete.CommandText = "DeleteRoomBeds";
					bedDelete.Parameters.Add(new SqlParameter("@RoomId", CurrentRoom.id));
					bedDelete.Parameters.Add(new SqlParameter("@BedTypeDisc", bed.ToString()));
					bedDelete.ExecuteNonQuery();
				}
			}

			foreach (BedType bed in bedsToAdd)
			{
				DbCommand bedInsert = factory.CreateCommand();
				if (bedInsert != null)
				{
					bedInsert.CommandType = System.Data.CommandType.StoredProcedure;
					bedInsert.Connection = connection;
					bedInsert.CommandText = "Insert_BedTypesConnection";
					bedInsert.Parameters.Add(new SqlParameter("@RoomId", CurrentRoom.id));
					bedInsert.Parameters.Add(new SqlParameter("@BedDTypeID", (int) bed - 1));
					bedInsert.ExecuteNonQuery();
				}
			}

		}

		private void UpdateRoomMeals(DbConnection connection, DbProviderFactory factory, IEnumerable<Meals> mealsToAdd,
			IEnumerable<Meals> mealsToDelete)
		{
			foreach (Meals meal in mealsToDelete)
			{
				DbCommand bedDelete = factory.CreateCommand();
				if (bedDelete != null)
				{
					bedDelete.CommandType = System.Data.CommandType.StoredProcedure;
					bedDelete.Connection = connection;
					bedDelete.CommandText = "DeleteMealTypeConnection";
					bedDelete.Parameters.Add(new SqlParameter("@RoomId", CurrentRoom.id));
					bedDelete.Parameters.Add(new SqlParameter("@MealTypeID", meal.ToString()));
					bedDelete.ExecuteNonQuery();
				}
			}
			foreach (Meals meal in mealsToAdd)
			{
				DbCommand mealInsert = factory.CreateCommand();
				if (mealInsert != null)
				{
					mealInsert.CommandType = System.Data.CommandType.StoredProcedure;
					mealInsert.Connection = connection;
					mealInsert.CommandText = "Insert_MealsTypeConnection";
					mealInsert.Parameters.Add(new SqlParameter("@RoomId", CurrentRoom.id));
					mealInsert.Parameters.Add(new SqlParameter("@MealTypeID", (int) meal - 1));
					mealInsert.ExecuteNonQuery();
				}
			}

		}

		private void UpdateRoomFacilities(DbConnection connection, DbProviderFactory factory, IEnumerable<RoomFacilities> facilitiesToAdd, IEnumerable<RoomFacilities> facilitiesToDelete)
		{
			foreach (RoomFacilities f in facilitiesToDelete)
			{
				DbCommand facilitiesDelete = factory.CreateCommand();
				if (facilitiesDelete != null)
				{
					facilitiesDelete.CommandType = System.Data.CommandType.StoredProcedure;
					facilitiesDelete.Connection = connection;
					facilitiesDelete.CommandText = "DeleteRoomFacilitiesConnection";
					facilitiesDelete.Parameters.Add(new SqlParameter("@RoomId", CurrentRoom.id));
					facilitiesDelete.Parameters.Add(new SqlParameter("@FacilityId", (int) f - 1));
					facilitiesDelete.ExecuteNonQuery();
				}
			}

			foreach (RoomFacilities f in facilitiesToAdd)
			{
				DbCommand facilityInsert = factory.CreateCommand();
				if (facilityInsert != null)
				{
					facilityInsert.CommandType = System.Data.CommandType.StoredProcedure;
					facilityInsert.Connection = connection;
					facilityInsert.CommandText = "Insert_RoomFacilitiesConnection";
					facilityInsert.Parameters.Add(new SqlParameter("@RoomId", CurrentRoom.id));
					facilityInsert.Parameters.Add(new SqlParameter("@RoomFacilityID", (int) f - 1));
					facilityInsert.ExecuteNonQuery();
				}
			}
		}

		private Dictionary<string, string> PrepareRoomUpdateData(string roomNumber, double price, double squareMeterage, int maxGuest,
			string standard, string comment)
		{
			Dictionary<string, string> updateValues = new Dictionary<string, string>();
			if (CurrentRoom.roomNumber != roomNumber)
			{
				updateValues["RoomNumber"] = roomNumber;
			}

			if (CurrentRoom.price != price)
			{
				updateValues["Price"] = Convert.ToString(price, CultureInfo.InvariantCulture);
			}

			if (CurrentRoom.squareMeterage != squareMeterage)
			{
				updateValues["SquareMeterage"] = Convert.ToString(squareMeterage, CultureInfo.InvariantCulture);
			}

			if (CurrentRoom.maxGuestNumber != maxGuest)
			{
				updateValues["MaxRoomGuests"] = Convert.ToString(maxGuest);
			}

			if (CurrentRoom.roomStandard.ToString() != standard)
			{
				updateValues["RoomStandard"] = standard;
			}
			
			if (CurrentRoom.comment != comment)
			{
				updateValues["RoomComment"] = comment;
			}

			return updateValues;
		}
	}
}


