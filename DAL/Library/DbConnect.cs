using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Library
{
    public abstract class DbConnect
    {
        private readonly string connectionString;

        public DbConnect()
        {
            connectionString = "Server=.;DataBase=PharmaBooks; integrated security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
