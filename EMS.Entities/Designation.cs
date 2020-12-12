using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class Designation
    {
        public int DesignationId { get; set; }

        public string DesignationName { get; set; }

        public int EmployeeDesignationID { get; set; }

        public string EmployeeDesignationName { get; set; }

        public int LoggInUserId { get; set; }
    }

    public class UpdateDesignation
    {
        public int DesignationId { get; set; }

        public string DesignationName { get; set; }

        public int EmployeeDesignationID { get; set; }

        public string EmployeeDesignationName { get; set; }

        public int LoggInUserId { get; set; }
    }

    public class DeleteDesignation
    {
        public int EmployeeDesignationID { get; set; }

        public string EmployeeDesignationName { get; set; }
    }
}
