using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Employee : IEmployee
    {
        public Employee ()
        {
        }

        public DataTable GetEmployees ()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings ["DefaultConnection"];
            SqlConnection connection = new SqlConnection ();
            //connection.ConnectionString = @"Data Source=localhost\SQLExpress2005; Initial Catalog=Northwind; User ID=sa; Password=admin";
            connection.ConnectionString = settings.ConnectionString;
            SqlCommand command = new SqlCommand ("SELECT * FROM Employees", connection);
            SqlDataReader sqlDataReader;

            connection.Open ();

            sqlDataReader = command.ExecuteReader (CommandBehavior.CloseConnection);

            DataTable dataTable = new DataTable ();
            dataTable.Load (sqlDataReader, LoadOption.OverwriteChanges);

            return dataTable;
        }
    }
}

