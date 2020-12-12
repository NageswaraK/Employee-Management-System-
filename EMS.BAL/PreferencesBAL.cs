using EMS.Data;
using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BAL
{
    public static class PreferencesBAL
    {
        

        public static List<ManageLeaveMDL> GetManageLeaveDetails(int businessId)
        {
            var manageleaveFields = new List<ManageLeaveMDL>();
            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(businessId, CommonColumns.BusinessID, System.Data.SqlDbType.Int);
                    var ireader = cmd.ExecuteDataReader(SqlProcedures.usp_GetBusinessLeaveDetails);
                    while (ireader.Read())
                    {
                        var field = new ManageLeaveMDL
                        {
                            Leavevalue = ireader[CommonColumns.Leavevalue] != System.DBNull.Value ? ireader.GetFormatDecimal(ireader.GetOrdinal(CommonColumns.Leavevalue)) : 0
                        };
                        manageleaveFields.Add(field);
                    }
                    return manageleaveFields;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }
    }
}
