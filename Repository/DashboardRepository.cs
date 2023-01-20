using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ticket_tracker.Repository
{
    public class DashboardRepository
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["TestTracker"].ConnectionString;

        public DataSet GetTask(int? TaskId=null)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("GetAllTask", con);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.AddWithValue("@Id", TaskId);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);

                objSqlDataAdapter.Fill(ds);
                con.Close();
                return ds;
            }
        }
    }
}