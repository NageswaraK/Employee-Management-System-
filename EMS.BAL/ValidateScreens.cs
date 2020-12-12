using EMS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BAL
{
    public class ValidateScreens
    {
        public static int CheckPermission(int ScreenId, int GroupId)
        {

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(ScreenId, CommonConstants.ScreenId, SqlDbType.Int);
                    cmd.AddParameters(GroupId, CommonConstants.GroupId, SqlDbType.Int);
                    cmd.AddParameters(232, CommonConstants.BusinessID, SqlDbType.Int);
                    var Result = cmd.ExecuteScalar(SqlProcedures.Validate_ScreenPrivilege);
                    return Convert.ToInt32(Result);

                }
                catch
                {
                    return -1;
                }
            }


        }
    }
}
