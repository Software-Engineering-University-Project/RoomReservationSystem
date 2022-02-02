using Reservations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    class ReservationManager : Manager<Reservation>
    {
        public override void delete(int Id)
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
                        command.CommandText = "Delete_Reservation_ById";

                        command.Parameters.Add(new SqlParameter("@Id", Id));

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public bool add(double pricePerNight, int userId, int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            double totalPrize = pricePerNight * (checkOutDate - checkInDate).Days;
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
                        command.CommandText = "Insert_Reservation_Procedure";


                        command.Parameters.Add(new SqlParameter("@PersonID", userId));
                        command.Parameters.Add(new SqlParameter("@RoomID", roomId));
                        command.Parameters.Add(new SqlParameter("@TotalPrice", totalPrize));
                        command.Parameters.Add(new SqlParameter("@checkInDate", checkInDate));
                        command.Parameters.Add(new SqlParameter("@checkOutDate", checkInDate));
                        command.Parameters.Add(new SqlParameter("@reservationDate", DateTime.Now));


                        command.ExecuteNonQuery();
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }

        public List<Reservation> displayReservations() { 
            List<Reservation> reservations = new List<Reservation>();
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
                       
                        command.CommandText = "Display_Reservation_ByRoomID";
                           
                        



                        using (DbDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Reservation reservation = new Reservation();
                                reservation.id = (int)dataReader["ReservationId"];
                                reservation.reservationDate = (DateTime)dataReader["ReservationDate"];
                                reservation.roomId = (int)dataReader["RoomId"];
                                reservation.clientId = (int)dataReader["PersonId"];
                                reservation.price = (float)dataReader["TotalPrice"];
                                reservation.checkInDate = (DateTime)dataReader["BeginDate"];
                                reservation.checkOutDate = (DateTime)dataReader["EndDate"];
                                reservations.Add(reservation);
                            }
                        }
                    }

                }
                return reservations;
            }
            
        
        }


        public List<Reservation> getReservations(int clientId, bool isRoom)
        {
            List<Reservation> reservations = new List<Reservation>();
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
                        if (isRoom)
                        {
                            command.CommandText = "Search_Reservation_ByRoomID";
                            command.Parameters.Add(new SqlParameter("@RoomID", clientId));
                        }
                        else
                        {
                            command.CommandText = "Search_Reservation_ByPersonID";
                            command.Parameters.Add(new SqlParameter("@PersonID", clientId));
                        }



                        using (DbDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Reservation reservation = new Reservation();
                                reservation.id = (int)dataReader["ReservationId"];
                                reservation.reservationDate = (DateTime)dataReader["ReservationDate"];
                                reservation.roomId = (int)dataReader["RoomId"];
                                reservation.clientId = (int)dataReader["PersonId"];
                                reservation.price = (float)dataReader["TotalPrice"];
                                reservation.checkInDate = (DateTime)dataReader["BeginDate"];
                                reservation.checkOutDate = (DateTime)dataReader["EndDate"];
                                reservations.Add(reservation);
                            }
                        }
                    }

                }
                return reservations;
            }
        }
    }
}
