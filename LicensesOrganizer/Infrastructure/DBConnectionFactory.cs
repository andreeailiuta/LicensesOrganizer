using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LicensesOrganizer.Infrastructure
{
    public class DBConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            var connString = ConfigurationManager.ConnectionStrings["LicenseOrganizerDb"].ConnectionString;
            var connection = new SqlConnection(connString);
            connection.Open();

            return connection;
        }
    }
}