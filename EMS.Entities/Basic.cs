using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class Basic
    {
        public int BusinessID { get; set; }
        public int UserId { get; set; }
    }

    public class OrganizaionBasic : Basic
    {
        public int UserAccountsId { get; set; }
    }

    public class ModelHelper
    {
        public int Sno { get; set; }
    }
}
