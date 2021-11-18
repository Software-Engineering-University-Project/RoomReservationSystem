using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace DataBaseAccess
{
    public List<User> GetPeople()
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("IOBaza")))
        {
            var output = connection.QueryAsync<Person>("dbo.Display_PersonalData").Result.ToList();
            return output;
        }
    }

    public void SetPeople()
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("IOBaza")))
        {
            //List<User> people = new List<User>();
            //people.Add(new User
            //{
            //    FirstName = "Julia",
            //    LastName = "Just",
            //    PhoneNumber = "111-111-111",
            //    BirthDate = "2004-03-11",
            //    EmailAddress = "juljust@gmail.com",
            //    Street = "Korola",
            //    PropertyNumber = "35a",
            //    ApartamentNumber = "1",
            //    PostCode = "42-605",
            //    Country = "Polska",
            //    City = "Tarnowskie Góry"
            //});
            //connection.Execute("dbo.Insert_PersonalData @FirstName, @LastName, @PhoneNumber, @BirthDate, @EmailAddress, @Street, @PropertyNumber, @ApartamentNumber, @PostCode, @Country, @City", people);
        }
    }

}

