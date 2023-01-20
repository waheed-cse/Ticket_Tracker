using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket_tracker.Models;
using Ticket_tracker.Repository;

namespace Ticket_tracker.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<DashboardModel> dashboards = new List<DashboardModel>();
                DashboardRepository repository = new DashboardRepository();
            DataSet ds = repository.GetTask();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                DashboardModel dashboard = new DashboardModel();
                dashboard.TaskId = Convert.ToInt32(dr.Table.Rows[0][0]);
                dashboard.TaskName= Convert.ToString(dr.Table.Rows[0]["TaskName"]);
                dashboard.Status= Convert.ToString(dr.Table.Rows[0]["Status"]);
                dashboard.AssignBy = Convert.ToString(dr.Table.Rows[0]["ASSIGNBY"]);
                dashboard.AssignTo = Convert.ToString(dr.Table.Rows[0]["ASSIGNTO"]);
                dashboard.Status = Convert.ToString(dr.Table.Rows[0]["CreatedDate"]);
                dashboards.Add(dashboard);
            }
            return View(dashboards);
        }



        public List<SelectListItem> getAllEmployee()
        {
            List<SelectListItem> employeeModels = new List<SelectListItem>();
            EmployeeRepository repository = new EmployeeRepository();
           DataSet ds= repository.Getemployee();
            foreach(DataRow dr in ds.Tables[0].Rows) {
                SelectListItem employee = new SelectListItem();
                employee.Value = Convert.ToString(dr["Id"]);
                employee.Text = Convert.ToString(dr["FirstName"]) + " " + Convert.ToString(dr["LastName"]);
                employeeModels.Add(employee);
            }
            return employeeModels;
        }
    }
}