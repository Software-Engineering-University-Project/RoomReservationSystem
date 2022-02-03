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

        public bool add(String firstName, String secondName, DateTime dateOfBirth, String phoneNum,
            String postCode, String city, String eMail, String street, String houseNum, String flatNum, String country, Boolean worker, String passWord)
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
                    DbCommand validation = factory.CreateCommand();
                    if(validation!=null)
                    {
                        validation.CommandType = System.Data.CommandType.StoredProcedure;
                        validation.Connection = connection;
                        validation.CommandText = "Check_Unique_Values_Person";

                        validation.Parameters.Add(new SqlParameter("@email", eMail));
                        validation.Parameters.Add(new SqlParameter("@phoneNumber", phoneNum));

                        validation.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Bit));
                        validation.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;

                        validation.ExecuteNonQuery();
                        bool check = Convert.ToBoolean(validation.Parameters["@ReturnValue"].Value);

                        if(check == false)
                        {
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
                                Logon log = new Logon();
                                log.passWord = passWord;

                                DbCommand addPasswordCommand = factory.CreateCommand();
                                if (addPasswordCommand != null)
                                {
                                    addPasswordCommand.CommandType = System.Data.CommandType.StoredProcedure;
                                    addPasswordCommand.Connection = connection;
                                    addPasswordCommand.CommandText = "Insert_Logon";
                                    addPasswordCommand.Parameters.Add(new SqlParameter("@PersonID", id));
                                    addPasswordCommand.Parameters.Add(new SqlParameter("@LogonPassword", log.encodePassword()));

                                    addPasswordCommand.ExecuteNonQuery();
                                }

                            }
                        }
                        else 
                        {
                            return false;
                        }
                    }  
                }
            }
            return true;
        }

        public override void delete(int userId)
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
                        command.CommandText = "Delete_PersonalData_ById";

                        command.Parameters.Add(new SqlParameter("@Id", userId));

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void getCurrUser(int id)
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
                        command.CommandText = "Search_PersonalRoles_ByPersonId";

                        command.Parameters.Add(new SqlParameter("@id", id));

                        command.ExecuteNonQuery();

                        using (DbDataReader dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();
                            char role = (char)dataReader["PersonRole"];
                            switch (role)
                            {
                                case 'C':
                                    currUser = new Client();
                                    break;
                                case 'W':
                                    currUser = new Worker();
                                    break;
                                case 'A':
                                    currUser = new Admin();
                                    break;
                                default:
                                    currUser = new Client();
                                    break;
                            }
                        }

                        DbCommand getDetailsCommand = factory.CreateCommand();
                        if (getDetailsCommand != null)
                        {
                            getDetailsCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            getDetailsCommand.Connection = connection;
                            getDetailsCommand.CommandText = "Search_PersonalData_ById";

                            getDetailsCommand.Parameters.Add(new SqlParameter("@id", managedUser.id));

                            getDetailsCommand.ExecuteNonQuery();

                            using (DbDataReader dataReader = getDetailsCommand.ExecuteReader())
                            {
                                dataReader.Read();
                                currUser.name = (String)dataReader["FirstName"];
                                currUser.surname = (String)dataReader["LastName"];
                                currUser.id = (int)dataReader["PersonId"];
                                currUser.BirthDate = (DateTime)dataReader["BirthDate"];
                                currUser.address.country = (String)dataReader["Country"];
                                currUser.address.city = (String)dataReader["City"];
                                currUser.address.postCode = (String)dataReader["PostCode"];
                                currUser.address.street = (String)dataReader["Street"];
                                currUser.address.apartmentNumber = (String)dataReader["ApartamentNumber"];
                                currUser.address.propertyNumber = (String)dataReader["PropertyNumber"];
                                currUser.logon.phoneNumber = (String)dataReader["PhoneNumber"];
                                currUser.logon.email = (String)dataReader["EmailAddress"];
                            }

                        }
                    }
                }
            }
        }

        public void getManagedUser(int id)
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
                        command.CommandText = "Search_PersonalRoles_ByPersonId";

                        command.Parameters.Add(new SqlParameter("@id", id));

                        command.ExecuteNonQuery();

                        using(DbDataReader dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();
                            var role = dataReader["PersonRole"];
                            switch (role)
                            {
                                case 'C': managedUser = new Client();
                                    break;
                                case 'W': managedUser = new Worker();
                                    break;
                                case 'A': managedUser = new Admin();
                                    break;
                                default: managedUser = new Client();
                                    break;
                            }
                        }

                        DbCommand getDetailsCommand = factory.CreateCommand();
                        if (getDetailsCommand != null)
                        {
                            getDetailsCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            getDetailsCommand.Connection = connection;
                            getDetailsCommand.CommandText = "Search_PersonalData_ById";

                            getDetailsCommand.Parameters.Add(new SqlParameter("@id", id));

                            getDetailsCommand.ExecuteNonQuery();

                            using (DbDataReader dataReader = getDetailsCommand.ExecuteReader())
                            {
                                dataReader.Read();
                                managedUser.name = (String)dataReader["FirstName"];
                                managedUser.surname = (String)dataReader["LastName"];
                                managedUser.id = (int)dataReader["PersonId"];
                                managedUser.BirthDate = (DateTime)dataReader["BirthDate"];
                                managedUser.address.country = (String)dataReader["Country"];
                                managedUser.address.city = (String)dataReader["City"];
                                managedUser.address.postCode = (String)dataReader["PostCode"];
                                managedUser.address.street = (String)dataReader["Street"];
                                managedUser.address.apartmentNumber = (String)dataReader["ApartamentNumber"];
                                managedUser.address.propertyNumber = (String)dataReader["PropertyNumber"];
                                managedUser.logon.phoneNumber = (String)dataReader["PhoneNumber"];
                                managedUser.logon.email = (String)dataReader["EmailAddress"];
                            }

                        }
                    }
                }
            }
        }

        public void update(String firstName, String secondName, DateTime dateOfBirth, String phoneNum,
            String postCode, String city, String eMail, String street, String houseNum, String flatNum, String country,String passWord)
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
                        command.Parameters.Add(new SqlParameter("@Email", eMail));
                        command.Parameters.Add(new SqlParameter("@Street", street));
                        command.Parameters.Add(new SqlParameter("@PropertyNumber", houseNum));
                        command.Parameters.Add(new SqlParameter("@ApartamentNumber", flatNum));
                        command.Parameters.Add(new SqlParameter("@PostCode", postCode));
                        command.Parameters.Add(new SqlParameter("@Country", country));
                        command.Parameters.Add(new SqlParameter("@City", city));

                        command.Parameters.Add(new SqlParameter("@id", managedUser.id));

                        command.ExecuteNonQuery();

                        if (!passWord.Equals(""))
                        {

                            managedUser.logon.passWord = passWord;

                            DbCommand addPasswordCommand = factory.CreateCommand();
                            if (addPasswordCommand != null)
                            {
                                addPasswordCommand.CommandType = System.Data.CommandType.StoredProcedure;
                                addPasswordCommand.Connection = connection;
                                addPasswordCommand.CommandText = "Update_Logon";
                                addPasswordCommand.Parameters.Add(new SqlParameter("@PersonID", managedUser.id));
                                addPasswordCommand.Parameters.Add(new SqlParameter("@LogonPassword", managedUser.logon.encodePassword()));

                                addPasswordCommand.ExecuteNonQuery();
                            }
                        }

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

        public void login(String Password, String mailOrPhone)
        {
            Logon decryptedPassword = new Logon();
            decryptedPassword.passWord = Password;
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection != null)
                {
                    int id=0;
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    DbCommand command = factory.CreateCommand();
                    if (command != null)
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Connection = connection;
                        command.CommandText = "Search_Logon";

                        command.Parameters.Add(new SqlParameter("@LoginDetail", mailOrPhone));
                        
                        command.Parameters.Add(new SqlParameter("@LogonPassword", decryptedPassword.encodePassword()));
                        command.ExecuteNonQuery();
                        using (DbDataReader dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();
                            id = (int)dataReader["PersonID"];
                        }
                        if (id != 0)
                        {
                            getCurrUser(id);
                        }
                    }
                }
            }
        }

        public void logout()
        {
            currUser = null;
            managedUser = null;
        }

    }
}
