using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class TimeSheetVM
    {
        public long TimesheetId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int RegularHours { get; set; }
        public int OverTimeHours { get; set; }
        public long UserEmployeeId { get; set; }
        public long SNo { get; set; }
        public int BusinessId { get; set; }
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string EmployeeName { get; set; }

    }
}
