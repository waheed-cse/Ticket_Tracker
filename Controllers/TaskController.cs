using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket_tracker.Models;

namespace Ticket_tracker.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllTask()
        {
            List<TaskModel> tasks = new List<TaskModel>();
            TaskRepository rs = new TaskRepository();
            DataSet ds = rs.GetTask();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                TaskModel task = new TaskModel();
                task.TaskId = Convert.ToInt32(dr.Table.Rows[0][0]);
                task.TaskName = Convert.ToString(dr.Table.Rows[0]["TaskName"]);
                tasks.Add(task);
            }
            return View(tasks);
        }
    }
}