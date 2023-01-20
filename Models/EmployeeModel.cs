using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticket_tracker.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName  { get; set; }

        public string Contact { get; set; }
        public string Designation { get; set; }
    }
}