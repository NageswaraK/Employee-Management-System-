using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class ApproveLeaves
    {
        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "EmployeeIDIsRequired")]
        public int EmployeeID { get; set; }

        public int BUID { get; set; }

        public int LocationID { get; set; }
    }

    public class ApproveLeavesList
    {

    }

    public class HolidaysMapping
    {
        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "EmployeeIDIsRequired")]
        public int EmployeeID { get; set; }

        public int CompanyID { get; set; }

        public int LocationID { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Comments { get; set; }
    }
}
