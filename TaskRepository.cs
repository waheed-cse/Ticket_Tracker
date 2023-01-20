using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Ticket_tracker.Models;

namespace Ticket_tracker
{
    public class TaskRepository
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["TestTracker"].ConnectionString;

        public DataSet GetTask()
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("select * from Task ", con);

                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);

                objSqlDataAdapter.Fill(ds);
                con.Close();
                return ds;
            }
        }

        public DataSet GetTaskById(int Id)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("select * from Task where TaskId='" + Id + "'", con);

                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);

                objSqlDataAdapter.Fill(ds);
                con.Close();
                return ds;
            }
        }

        public string AddTask(DashboardModel task)
        {
            string result;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("insert into Task (TaskName,Status,Priority,Description,AssignTo,CreatedDate,AssignBy,CreatedBy) values('" + task.TaskName + "','" + task.Status + "','" + task.Priority + "','" + task.Description + "'," + task.AssignToId + ",'" + task.CreatedDate + "'," + task.AssignById + ",'" + task.CreatedBy + "')", con);
                try
                {
                    objSqlCommand.ExecuteNonQuery();
                    result = "Saved";
                }
                catch (Exception ex)
                {
                    result= (ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
            return result;
        }

        public string UpdateTask(DashboardModel task)
        {
            string result;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand objSqlCommand = new SqlCommand("Update Task Set TaskName ='" + task.TaskName + "',Status='" + task.Status + "',CreatedBy='" + task.CreatedBy + "',AssignBy='" + task.AssignById + "',AssignTo='" + task.AssignToId + "',UpdatedBy='" + task.UpdatedBy + "',UpdatedDate='" + task.UpdateDate + "',Priority='" + task.Priority + "',Description='" + task.Description + "' where TaskId='" + task.TaskId + "'", con);
                try
                {
                    objSqlCommand.ExecuteNonQuery();
                    result = "Updated";
                }
                catch (Exception ex)
                {
                    result = (ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
            return result;
        }
    }
}