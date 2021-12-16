using System;
using Users;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Manager
{
	public class UserManager : Manager<Client>
	{
		public UserManager() { }

        public void add(String firstName, String secondName, DateTime dateOfBirth, String phoneNum,
            String postCode, String city, String eMail, String street, String houseNum, String flatNum, String country,Boolean worker)
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
                       
                        command.Connection = connection;
                        command.CommandText = "Insert_PersonalData_function";
                        command.Parameters.Add(new SqlParameter("@FirstName", firstName));
                        command.Parameters.Add(new SqlParameter("@LastName", secondName));
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", phoneNum));
                        command.Parameters.Add(new SqlParameter("@BirthDate", dateOfBirth));
                        command.Parameters.Add(new SqlParameter("@EmailAddress", eMail));
                        command.Parameters.Add(new SqlParameter("@Street", street));
                        command.Parameters.Add(new SqlParameter("@PropertyNumber", houseNum));
                        command.Parameters.Add(new SqlParameter("@ApartamentNumber", flatNum));
                        command.Parameters.Add(new SqlParameter("@PostCode", postCode));
                        command.Parameters.Add(new SqlParameter("@Country", country));
                        command.Parameters.Add(new SqlParameter("@City", city));
                        
                        int id = (int)command.ExecuteScalar();
                        DbCommand isWorkerCommand = factory.CreateCommand();
                        if(isWorkerCommand != null)
                        {
                            isWorkerCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            isWorkerCommand.Connection = connection;
                            isWorkerCommand.CommandText = "Insert_PersonalRoles";
                            isWorkerCommand.Parameters.Add(new SqlParameter("@PersonID", id));
                            if (worker)
                            {
                                isWorkerCommand.Parameters.Add(new SqlParameter("@PersonRole", "W"));
                            }
                            else
                            {
                                isWorkerCommand.Parameters.Add(new SqlParameter("@PersonRole", "C"));
                            }
                            isWorkerCommand.ExecuteNonQuery();
                        }
                        
                    }
                }
            }
        }

        public override void delete()
        {
            throw new NotImplementedException();
        }

        public override Client get()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
