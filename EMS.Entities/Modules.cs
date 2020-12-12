using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class Modules
    {
        public int ModuleId { get; set; }

        public string Module { get; set; }

        public int GroupId { get; set; }

        public Boolean AddCheck { get; set; }

        public Boolean EditCheck { get; set; }

        public Boolean DeleteCheck { get; set; }

        public Boolean ReadOnlyCheck { get; set; }

        public int ScreenId { get; set; }

        public string ScreenName { get; set; }

        public int LoginUserId { get; set; }

        public string PrivilegeIdList { get; set; }

        public int BusinessID { get; set; }
        public string Privilege { get; set; }
        public int PrivilegeId { get; set; }
        public int IsChk { get; set; }



    }

}
