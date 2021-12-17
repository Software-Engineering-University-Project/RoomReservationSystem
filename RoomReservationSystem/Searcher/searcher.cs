using System;

namespace Searcher
{
    public static class Searcher
    {
        public static List<Client> SearchClient(string parameter, string searchValue)
        {
            List<Client> people = new List<Client>();
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
                        command.CommandText = "SearchClient";
                        switch (parameter)
                        {
                            case "Name":
                                command.Parameters.Add(new SqlParameter("@FirstName", searchValue));
                                break;

                            case "Surname":
                                command.Parameters.Add(new SqlParameter("@LastName", searchValue));
                                break;

                            case "PhoneNumber":
                                command.Parameters.Add(new SqlParameter("@PhoneNumber", searchValue));
                                break;

                            case "Email":
                                command.Parameters.Add(new SqlParameter("@Email", searchValue));
                                break;

                            case "Street":
                                command.Parameters.Add(new SqlParameter("@Street", searchValue));
                                break;

                            case "Country":
                                command.Parameters.Add(new SqlParameter("@Country", searchValue));
                                break;

                            case "City":
                                command.Parameters.Add(new SqlParameter("@City", searchValue));
                                break;

                        }

                        using (DbDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Client client = new Client();
                                client.id = (int)dataReader["PersonID"];
                                client.name = (string)dataReader["FirstName"];
                                client.surname = (string)dataReader["LastName"];
                                people.Add(client);
                            }
                        }
                    }
                }
            }

            return people;
        }

        public static List<Worker> SearchWorker(string parameter, string searchValue)
        {
            List<Worker> people = new List<Worker>();
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
                        command.CommandText = "SearchWorker";

                        switch (parameter)
                        {
                            case "Name":
                                command.Parameters.Add(new SqlParameter("@FirstName", searchValue));
                                break;

                            case "Surname":
                                command.Parameters.Add(new SqlParameter("@LastName", searchValue));
                                break;

                            case "PhoneNumber":
                                command.Parameters.Add(new SqlParameter("@PhoneNumber", searchValue));
                                break;

                            case "Email":
                                command.Parameters.Add(new SqlParameter("@Email", searchValue));
                                break;

                            case "Street":
                                command.Parameters.Add(new SqlParameter("@Street", searchValue));
                                break;

                            case "Country":
                                command.Parameters.Add(new SqlParameter("@Country", searchValue));
                                break;

                            case "City":
                                command.Parameters.Add(new SqlParameter("@City", searchValue));
                                break;

                        }

                        using (DbDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Worker worker = new Worker();
                                worker.name = (string) dataReader["FirstName"];
                                worker.surname = (string) dataReader["LastName"];
                                people.Add(worker);
                            }
                        }
                    }
                }
            }

            return people;
        }

    public static List<Room> SearchRooms(DateTime beginDate, DateTime endDate, List<RoomFacilities> facilitiesList,
            double minPrice, double maxPrice, int maxGuestNumber)
        {
            List<Room> rooms = new List<Room>();
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
                        command.CommandText = "SearchRoom";
                        command.Parameters.Add(new SqlParameter("@MinRoomPrice", minPrice));
                        command.Parameters.Add(new SqlParameter("@MaxRoomPrice", maxPrice));
                        command.Parameters.Add(new SqlParameter("@BeginDate", beginDate));
                        command.Parameters.Add(new SqlParameter("@EndDate", endDate));
                        command.Parameters.Add(new SqlParameter("@MaxGuestNumber", maxGuestNumber));
                        using (DbDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Room room = new Room();
                                room.price = (double) dataReader["RoomPrice"];
                                room.id = Int32.Parse(dataReader["RoomID"].ToString());
                                room.squareMeterage = (double) dataReader["RoomSquareMetrage"];
                                room.roomStandard = (RoomStandard) Enum.Parse(typeof(RoomStandard),
                                    dataReader["RoomStandard"].ToString(), true);
                                room.roomState = (RoomState) Enum.Parse(typeof(RoomState),
                                    dataReader["RoomStatus"].ToString(), true);
                                room.roomNumber = dataReader["RoomNumber"].ToString();
                                room.maxGuestNumber = Int32.Parse(dataReader["RoomMaxGuestNumber"].ToString());
                                rooms.Add(room);
                            }
                        }
                    }

                    List<int> removedIds = new List<int>();
                    foreach (Room r in rooms)
                    {
                        foreach (var facility in facilitiesList)
                        {
                            DbCommand facilitiesCommand = factory.CreateCommand();
                            if (facilitiesCommand != null)
                            {
                                facilitiesCommand.CommandType = System.Data.CommandType.StoredProcedure;
                                facilitiesCommand.Connection = connection;
                                facilitiesCommand.CommandText = "CheckFacility";
                                facilitiesCommand.Parameters.Add(new SqlParameter("@FacilityId", (int) facility + 1));
                                facilitiesCommand.Parameters.Add(new SqlParameter("@RoomId", r.id));
                                int count = (int) facilitiesCommand.ExecuteScalar();
                                if (count == 0)
                                {
                                    removedIds.Add(r.id);
                                    break;
                                }
                            }
                        }
                    }

                    rooms.RemoveAll(r => removedIds.Contains(r.id));
                }
            }

            return rooms;
        }

        public static Room SearchRoomById(int id)
        {
            Room room = new Room();
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
                        command.CommandText = "SearchRoom";
                        command.Parameters.Add(new SqlParameter("@RoomId", id));
                        using (DbDataReader dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();
                            room.price = (double) dataReader["RoomPrice"];
                            room.id = Int32.Parse(dataReader["RoomID"].ToString());
                            room.squareMeterage = (double) dataReader["RoomSquareMetrage"];
                            room.roomStandard = (RoomStandard) Enum.Parse(typeof(RoomStandard),
                                dataReader["RoomStandard"].ToString(), true);
                            room.roomState = (RoomState) Enum.Parse(typeof(RoomState),
                                dataReader["RoomStatus"].ToString(), true);
                            room.roomNumber = dataReader["RoomNumber"].ToString();
                            room.maxGuestNumber = Int32.Parse(dataReader["RoomMaxGuestNumber"].ToString());
                        }
                    }

                    DbCommand facilitiesCommand = factory.CreateCommand();
                    if (facilitiesCommand != null)
                    {
                        List<RoomFacilities> facilitiesList = new List<RoomFacilities>();
                        facilitiesCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        facilitiesCommand.Connection = connection;
                        facilitiesCommand.CommandText = "SearchRoomFacilities";
                        facilitiesCommand.Parameters.Add(new SqlParameter("@RoomId", room.id));
                        using (DbDataReader dataReader = facilitiesCommand.ExecuteReader())
                        {

                            while (dataReader.Read())
                            {
                                facilitiesList.Add((RoomFacilities) Enum.Parse(typeof(RoomFacilities),
                                    dataReader["FacilityDescription"].ToString(), true));
                            }
                        }

                        room.facilitiesProvided = facilitiesList;
                    }

                    DbCommand bedCommand = factory.CreateCommand();
                    if (bedCommand != null)
                    {
                        List<BedType> bedTypes = new List<BedType>();
                        bedCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        bedCommand.Connection = connection;
                        bedCommand.CommandText = "SearchRoomBeds";
                        bedCommand.Parameters.Add(new SqlParameter("@RoomId", room.id));
                        using (DbDataReader dataReader = bedCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                bedTypes.Add((BedType) Enum.Parse(typeof(BedType),
                                    dataReader["BedDescription"].ToString(), true));
                            }
                        }

                        room.beds = bedTypes;
                    }

                    DbCommand mealsCommand = factory.CreateCommand();
                    if (mealsCommand != null)
                    {
                        List<Meals> mealsList = new List<Meals>();
                        mealsCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        mealsCommand.Connection = connection;
                        mealsCommand.CommandText = "SearchRoomMeals";
                        mealsCommand.Parameters.Add(new SqlParameter("@RoomId", room.id));
                        using (DbDataReader dataReader = mealsCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                mealsList.Add((Meals) Enum.Parse(typeof(Meals),
                                    dataReader["MealTypeDescription"].ToString(), true));
                            }
                        }
                    
                        room.mealsProvided = mealsList;
                    }
                }
            }
            return room;
        }
    }
}
