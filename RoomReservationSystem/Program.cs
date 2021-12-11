using RoomReservationSystem.UserInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservationSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RoomReservationSystem.UserInterface.RoomReservationSystem());

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if(connection == null)
                {
                    Debug.WriteLine("connection error");
                    return;
                }
                connection.ConnectionString = connectionString;
                connection.Open();

                DbCommand command = factory.CreateCommand();
                if(command == null)
                {
                    Debug.WriteLine("connection error");
                    return;
                }
                command.Connection = connection;
                command.CommandText = "Select * from PersonalData";

                using(DbDataReader dataReader = command.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        Debug.WriteLine($"{dataReader["FirstName"]}");
                    }
                }
            }
        }
    }
}
