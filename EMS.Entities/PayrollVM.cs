using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class PayrollVM
    {

        public DateTime Date { get; set; }
        public int RegularHours { get; set; }
        public int OverTimeHours { get; set; }
        //[DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public int BusinessId { get; set; }
        public int UserId { get; set; }
        public long RowNum { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string EmployeeName { get; set; }
        public Int64? BankId { get; set; }
        public Int64? EmployeePayrollId { get; set; }
        public Int64? UserEmployeeId { get; set; }
    }
}
