using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class VacationsVM
    {
        public long LeaveId { get; set; }
        public long UserEmployeeId { get; set; }
        public int BusinessId { get; set; }
        public int UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int LeaveStatusId { get; set; }
        public string LeaveStatus { get; set; }
        public int Days { get; set; }
        public long SNo { get; set; }
    }
}
