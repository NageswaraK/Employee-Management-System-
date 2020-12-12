using EMS.Data;
using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BAL
{
    public class Privileges
    {
        public static IList<Modules> GetPrivileges()
        {
            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    var ireader = cmd.ExecuteDataReader(SqlProcedures.Get_ModulesForGroupsAndRoles);
                    var listItems = new List<Modules>();
                    while (ireader.Read())
                    {
                        var item = new Modules
                        {
                            ModuleId = ireader.GetInt16(CommonColumns.ModuleId),
                            Module = ireader.GetString(CommonColumns.Module)
                        };
                        listItems.Add(item);
                    }


                    return listItems;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static IList<Modules> GetAllSCreensPermissions(int BusinessId, int GroupId, int UserId)
        {
            var listItems = new List<Modules>();
            using (var cmd = new DBSqlCommand())
            {
                try
                {

                    cmd.AddParameters(UserId, CommonConstants.LoggInUserId, SqlDbType.SmallInt);
                    cmd.AddParameters(GroupId, CommonColumns.GroupNameId, SqlDbType.Int);
                    cmd.AddParameters(BusinessId, CommonColumns.BusinessID, SqlDbType.Int);
                    var ireader = cmd.ExecuteDataReader(SqlProcedures.usp_UserAccessPrivileges);


                    while (ireader.Read())
                    {
                        var item = new Modules
                        {
                            ScreenId = ireader.GetInt32(CommonColumns.ScreenId),
                            PrivilegeId = ireader.GetInt32(CommonColumns.PrivilegeId),
                            GroupId = ireader.GetInt32(CommonColumns.GroupNameId),
                            LoginUserId = ireader.GetInt32(CommonColumns.UserId),
                            Privilege = ireader.GetString(CommonColumns.Privilege),
                            ScreenName = ireader.GetString(CommonColumns.ScreenName)

                        };

                        listItems.Add(item);
                    }



                }
                catch
                {
                    return null;
                }
            }
            return listItems;
        }

        public static List<Modules> GetGroupScreenPrivileges(int ModuleId, int GroupId, int BusinessId)
        {
            var listItems = new List<Modules>();
            using (var cmd = new DBSqlCommand())
            {
                try
                {

                    cmd.AddParameters(ModuleId, CommonConstants.ModuleId, SqlDbType.SmallInt);
                    cmd.AddParameters(GroupId, CommonColumns.GroupId, SqlDbType.Int);
                    cmd.AddParameters(BusinessId, CommonColumns.BusinessID, SqlDbType.Int);
                    var ireader = cmd.ExecuteDataReader(SqlProcedures.Bind_ScreenPrivileges);


                    while (ireader.Read())
                    {
                        var item = new Modules
                        {
                            ScreenId = ireader.GetInt32(CommonColumns.ScreenId),
                            ScreenName = ireader.GetString(CommonColumns.ScreenName),
                            Module = ireader.GetString(CommonColumns.ModuleName),
                            ModuleId = ireader.GetInt32(CommonColumns.ModuleId),
                            Privilege = ireader.GetString(CommonColumns.PrivilegeName),
                            PrivilegeId = ireader.GetInt32(CommonColumns.PrivilegeId)

                        };

                        listItems.Add(item);
                    }



                }
                catch
                {
                    return null;
                }
            }
            return listItems;
        }

        public static bool SaveGroupScreenPrivileges(Modules Modules)
        {
            using (var cmd = new DBSqlCommand())
            {
                cmd.AddParameters(Modules.LoginUserId, CommonConstants.LoginUserId, SqlDbType.Int);
                cmd.AddParameters(Modules.BusinessID, CommonConstants.BusinessID, SqlDbType.Int);
                cmd.AddParameters(Modules.GroupId, CommonConstants.GroupNameId, SqlDbType.Int);
                cmd.AddParameters(Modules.ScreenId, CommonConstants.ScreenId, SqlDbType.Int);
                cmd.AddParameters(Modules.PrivilegeIdList, CommonConstants.PrivilegeIdList, SqlDbType.VarChar);
                cmd.AddParameters(Modules.IsChk, CommonConstants.IsChk, SqlDbType.Int);

                cmd.ExecuteNonQuery(SqlProcedures.Insert_Update_GroupScreenPrivileges);

            }
            return true;
        }


    }
}
