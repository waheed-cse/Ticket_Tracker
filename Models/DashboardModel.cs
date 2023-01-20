using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticket_tracker.Models
{
    public class DashboardModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public string AssignTo { get; set; }
        public string AssignBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AssignById { get; set; }
        public int AssignToId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
    }
}