using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CommonLayer.Cache;

namespace DAL.Library
{
    public class UserDbSet : DbConnect
    {

        public bool Loging(string userName, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM dbo.Users WHERE Login_Name=@userName AND Password=@password";
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@password", password);
                    //command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.Id = reader.GetInt32(0);
                            UserLoginCache.FullName = reader.GetString(1);
                            UserLoginCache.MobileNo = reader.GetString(2);
                            UserLoginCache.Email = reader.GetString(3);
                            UserLoginCache.UserType = reader.GetString(6);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }
    }
}
