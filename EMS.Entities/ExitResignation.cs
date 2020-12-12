using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class ExitResignation
    {
        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public int UserEmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime ResignationDate { get; set; }

        public string ReportManagerTo { get; set; }

        public string ResignationStatus { get; set; }

        public DateTime LastWorkingDate { get; set; }

        public string RepEmployeeName { get; set; }

        public DateTime Date { get; set; }
        public int RoleId { get; set; }
    }
}
