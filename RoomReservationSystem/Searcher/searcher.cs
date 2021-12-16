using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace RoomReservationSystem
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
                                worker.name = (string)dataReader["FirstName"];
                                worker.surname = (string)dataReader["LastName"];
                                people.Add(worker);
                            }
                        }
                    }
                }
            }
            return people;
        }

        public static List<Room> SearchRoom(string parameter, string searchValue)
        {
            return null;
        }
   }
}
