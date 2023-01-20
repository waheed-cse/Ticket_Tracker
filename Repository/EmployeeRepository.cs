using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ticket_tracker.Repository
{
    public class EmployeeRepository
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["TestTracker"].ConnectionString;

        public DataSet Getemployee()
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("select * from Employee", con);

                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);

                objSqlDataAdapter.Fill(ds);
                con.Close();
                return ds;
            }
        }

    }
}