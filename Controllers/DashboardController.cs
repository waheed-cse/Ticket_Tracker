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
    public class DashboardController : Controller
    {
        // GET: Dashboard
       private readonly DashboardRepository _repository = new DashboardRepository();
        private readonly TaskRepository _taskRepository = new TaskRepository();
        private readonly EmployeeController employee = new EmployeeController();
        public ActionResult Index()
        {
            List<DashboardModel> dashboards = new List<DashboardModel>();
           
            DataSet ds = _repository.GetTask();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DashboardModel dashboard = new DashboardModel();
                dashboard.TaskId = Convert.ToInt32(dr["TaskId"]);
                dashboard.TaskName = Convert.ToString(dr["TaskName"]);
                dashboard.Status = Convert.ToString(dr["Status"]);
                dashboard.AssignBy = Convert.ToString(dr["AssignByName"]);
                dashboard.AssignTo = Convert.ToString(dr["AssignToName"]);
                dashboard.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                dashboard.AssignToId = Convert.ToInt32(dr["AssignTo"]);
                dashboard.AssignById = Convert.ToInt32(dr["AssignBy"]);
                dashboard.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                dashboard.Priority = Convert.ToString(dr["Priority"]);
                dashboard.Description = Convert.ToString(dr["Description"]);
                dashboards.Add(dashboard);
            }
           ViewBag.EmployeeList= employee.getAllEmployee();
            return View(dashboards);
        }

        public ActionResult GetTaskById(int Id)
        {
            DashboardModel dashboardModel=GetTaskId(Id);
            return View(dashboardModel);
        }


        private DashboardModel GetTaskId(int Id)
        {
            DashboardModel dashboardModel = new DashboardModel();
            DataSet dsDashboardModel = _repository.GetTask(Id);
            if (dsDashboardModel.Tables[0].Rows.Count > 0)
            {
                dashboardModel = new DashboardModel
                {

                    TaskId = Convert.ToInt32(dsDashboardModel.Tables[0].Rows[0]["TaskId"]),
                    TaskName = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["TaskName"]),
                    Status = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["Status"]),
                    AssignBy = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["AssignByName"]),
                    AssignTo = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["AssignToName"]),
                    CreatedDate = Convert.ToDateTime(dsDashboardModel.Tables[0].Rows[0]["CreatedDate"]),
                    AssignById = Convert.ToInt32(dsDashboardModel.Tables[0].Rows[0]["AssignBy"]),
                    AssignToId = Convert.ToInt32(dsDashboardModel.Tables[0].Rows[0]["AssignTo"]),
                    CreatedBy = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["CreatedBy"]),
                    Priority = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["Priority"]),
                    Description = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["Description"]),


                };

            }
            return dashboardModel;
        }
            
            public ActionResult GetTaskIdAjaxcall(int Id)
        {
            DashboardModel dashboardModel = new DashboardModel();
            DataSet dsDashboardModel = _repository.GetTask(Id);
            if (dsDashboardModel.Tables[0].Rows.Count > 0)
            {
                dashboardModel = new DashboardModel
                {

                    TaskId = Convert.ToInt32(dsDashboardModel.Tables[0].Rows[0]["TaskId"]),
                    TaskName = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["TaskName"]),
                    Status = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["Status"]),
                    AssignBy = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["AssignByName"]),
                    AssignTo = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["AssignToName"]),
                    CreatedDate = Convert.ToDateTime(dsDashboardModel.Tables[0].Rows[0]["CreatedDate"]),
                    AssignById = Convert.ToInt32(dsDashboardModel.Tables[0].Rows[0]["AssignBy"]),
                    AssignToId = Convert.ToInt32(dsDashboardModel.Tables[0].Rows[0]["AssignTo"]),
                    CreatedBy = Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["CreatedBy"]),
                    Priority=Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["Priority"]),
                    Description=Convert.ToString(dsDashboardModel.Tables[0].Rows[0]["Description"]),

                                    };
                ViewBag.EmployeeList = employee.getAllEmployee();

            }
             return Json(dashboardModel,"Result", JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        public DashboardModel UpdateTaskById(DashboardModel task)
        {

            DashboardModel dashboard = GetTaskId(task.TaskId);
            
                dashboard.Status = task.Status == "progress" ? "InProgress" : task.Status == "To-do" ? "Todo" : task.Status == "InTest" ? "Test" : task.Status == "Done" ? "Done" : task.Status;
                dashboard.AssignById = task.AssignById==0? 1: task.AssignById;
                dashboard.AssignToId = task.AssignToId;
                dashboard.UpdateDate = DateTime.Now;
                dashboard.UpdatedBy = task.UpdatedBy==null?"1":task.UpdatedBy;
                dashboard.Priority = task.Priority==null ? dashboard.Priority : task.Priority;
                dashboard.Description = task.Description == null ? dashboard.Description : task.Description;
                _taskRepository.UpdateTask(dashboard);
            
            return dashboard;
        }


        [HttpPost]
        public string SaveTicket(DashboardModel dashboard)
        {
            dashboard.CreatedBy = "1";
            dashboard.CreatedDate = DateTime.Now;
           string result= _taskRepository.AddTask(dashboard);
            return result;
        }
    }
}