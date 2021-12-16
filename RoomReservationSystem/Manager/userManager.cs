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
        public Client currUser { set; get; }
        public Client managedUser { set; get; }
        public UserManager()
        {
            currUser = null;
            managedUser = null;
        }

        public void add(String firstName, String secondName, DateTime dateOfBirth, String phoneNum,
            String postCode, String city, String eMail, String street, String houseNum, String flatNum, String country, Boolean worker)
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection != null)
                {
                    int id = 0;
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    DbCommand command = factory.CreateCommand();
                    if (command != null)
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Connection = connection;
                        command.CommandText = "Insert_PersonalData_Procedure";


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

                        command.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Int));
                        command.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;


                        command.ExecuteNonQuery();
                        id = (int)command.Parameters["@ReturnValue"].Value;




                        DbCommand isWorkerCommand = factory.CreateCommand();
                        if (isWorkerCommand != null)
                        {
                            isWorkerCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            isWorkerCommand.Connection = connection;
                            isWorkerCommand.CommandText = "Insert_PersonRoles";
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

        public void update(String firstName, String secondName, DateTime dateOfBirth, String phoneNum,
            String postCode, String city, String eMail, String street, String houseNum, String flatNum, String country)
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
                        command.CommandText = "Update_PersonalData";
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

                        command.Parameters.Add(new SqlParameter("@id", managedUser.id));

                        command.ExecuteNonQuery();

                        managedUser.name = firstName;
                        managedUser.surname = secondName;
                        managedUser.BirthDate = dateOfBirth;
                        managedUser.logon.email = eMail;
                        managedUser.logon.phoneNumber = phoneNum;
                        managedUser.address.city = city;
                        managedUser.address.country = country;
                        managedUser.address.street = street;
                        managedUser.address.postCode = postCode;
                        managedUser.address.propertyNumber = houseNum;
                        managedUser.address.apartmentNumber = flatNum;
                    }
                }
            }
        }
    }
}
