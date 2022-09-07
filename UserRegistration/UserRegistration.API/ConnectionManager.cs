using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace UserRegistration.API
{
    public static class ConnectionManager
    {
        private static IConfiguration Configuration;

        /// <summary>
        /// Open a new SQLServer
        /// </summary>
        /// <returns>A new opened connection</returns>
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection("Server=138.36.2.38;Initial Catalog=UserRegistrationBD; User ID=sa; Password=Genpp@3000; Integrated Security=False;");
            connection.Open();
            return connection;
        }
    }
}
