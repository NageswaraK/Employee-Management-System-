using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class LMS
    {
        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "EmployeeIDIsRequired")]
        public int UserEmployeeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "LeaveIDIsRequired")]
        public int LeaveTypeId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "ReasonIDIsRequired")]
        public int LeaveReasonId { get; set; }

        public string Description { get; set; }

        public bool Claim { get; set; }

        public int CurrentLeaveBalance { get; set; }

        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public int EffectiveLeave { get; set; }

        public string FilePath { get; set; }

        public List<DocId> DocIds { get; set; }
    }


    public class DocId
    {
        public int IndexId { get; set; }

        public string IndexColumnName { get; set; }

        public string IndexColumnValue { get; set; }

        public int DocumentClassId { get; set; }

    }

    public class ViewApplyLeave
    {
        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "EmployeeIDIsRequired")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "LeaveIDIsRequired")]
        public int LeaveYearID { get; set; }

        public long UserEmployeeId { get; set; }

        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public string EmployeeName { get; set; }

        public string Details { get; set; }

        public string Status { get; set; }

        public int Year { get; set; }

        public string LeaveStartDate { get; set; }

        public string LeaveEndDate { get; set; }

        public int NoOfLeaveDays { get; set; }

        public string LeaveType { get; set; }

        public string LeaveReason { get; set; }

        public string Description { get; set; }

        public string FileStatus { get; set; }

        public int EmployeeLeaveId { get; set; }

        public string LeaveStatus { get; set; }

        public int LeaveStatusId { get; set; }

        public int StatusId { get; set; }

    }

    public class ModifyWeeklyOff
    {
        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "EmployeeIDIsRequired")]
        public int EmployeeID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Comments { get; set; }

        public int WeeklyOffID { get; set; }
    }
}
