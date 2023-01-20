using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticket_tracker.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string  TaskName { get; set; }
        public string Status { get; set; }
        public string AssignTo { get; set; }
        public string AssignBy { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedBy { get; set; }
        public DateTime LastUpdatedBy { get; set; }
    }
}