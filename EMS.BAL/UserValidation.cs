using EMS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BAL
{
    public class UserValidation
    {
        public LoggedUser IsValidUser(string userName, string password)
        {
            //string encrptPWD = password.GetSHA1();
            LoggedUser logedUser = null;// new LoggedUser() { IsActive = true, UserId = 2, BusinessId = 2, EmailId = "ramana@gmail.com", RoleName = "", RoleId = 1 };
            //LoggedUser logedUser = new LoggedUser() { IsActive = true, UserId = 1, BusinessId = 1, EmailId = "superadmin@gmail.com", RoleName = "Super Admin", RoleId = 2 };
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                cmd.AddParameters(userName, CommonConstants.UserName, System.Data.SqlDbType.VarChar);
                cmd.AddParameters(password, "@Password", System.Data.SqlDbType.VarChar);
                IDataReader reader = cmd.ExecuteDataReader(SqlProcedures.User_Verification);
                while (reader.Read())
                {
                    logedUser = new LoggedUser();
                    logedUser.BusinessId = reader[CommonColumns.BusinessID] == null ? 0 : Convert.ToInt32(reader[CommonColumns.BusinessID]);
                    logedUser.UserId = reader[CommonColumns.UserId] == null ? 0 : Convert.ToInt32(reader[CommonColumns.UserId]);
                    logedUser.UserName = reader[CommonColumns.UserName].ToString();
                    logedUser.RoleId = reader[CommonColumns.RoleId] == null ? 0 : Convert.ToInt32(reader[CommonColumns.RoleId]);
                    logedUser.RoleName = reader[CommonColumns.RoleName].ToString();
                    logedUser.EmailId = userName;
                    logedUser.IsActive = (bool)reader[CommonColumns.UserIsActive];
                    //logedUser.BusinessStatusId = reader.GetInt32("BusinessStatusId");
                    logedUser.BusinessStatusId = Convert.ToInt32(reader[CommonColumns.BusinessStatuId]);
                    logedUser.BusinessStatus = reader[CommonColumns.BusinessStatus].ToString();
                    logedUser.Country = reader[CommonColumns.Country].ToString();
                    logedUser.CountryId = Convert.ToInt32(reader[CommonColumns.CountryId]);
                    logedUser.GroupId = Convert.ToInt32(reader[CommonColumns.GroupId]);
                    logedUser.StateId = Convert.ToInt32(reader[CommonColumns.StateId]);
                    logedUser.State = reader[CommonColumns.State].ToString();
                    logedUser.CustomersRename = reader[CommonColumns.CustomersRename].ToString();
                    logedUser.LogMeOutId = Convert.ToInt32(reader[CommonColumns.LogMeOutId]);
                    logedUser.RenewalDate = reader[CommonColumns.RenewalDate].ToString();
                    //logedUser.TimeLimit = Convert.ToInt32(reader[CommonColumns.TimeLimit]);
                    logedUser.AccountClosingDate = reader[CommonColumns.AccountClosingDate].ToString();
                    if (logedUser.RoleId == 6)
                    {
                        logedUser.UserSessionEmployeeId = reader[CommonColumns.UserSessionEmployeeId] == null ? 0 : Convert.ToInt32(reader[CommonColumns.UserSessionEmployeeId]);
                    }
                    return logedUser;
                }
            }
            //if (logedUser != null)
            //{
            //    using (DBSqlCommand cmd = new DBSqlCommand())
            //    {
            //        var reader = cmd.ExecuteDataReader("");
            //    }
            //}
            return logedUser;// as LoggedUser;
        }

        public void VerifyUser(string userId)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                try
                {
                    cmd.AddParameters(userId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.ExecuteNonQuery(SqlProcedures.BusinessRegistrationVerification);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static int IsExistedEmail(string email)
        {
            var userID = 0;
            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    //cmd.AddParameters(businessId, CommonConstants.BusinessID, SqlDbType.VarChar);
                    cmd.AddParameters(email, CommonConstants.Email, SqlDbType.VarChar);

                    var exists = cmd.ExecuteScalar(SqlProcedures.GetUserEmail_IfExisted);
                    if (Convert.ToInt32(exists) > 0)
                    {
                        userID = Convert.ToInt32(exists);
                    }
                    return userID;
                }
                catch (Exception)
                { }
            }
            return userID;
        }

        public static void LogSessionDetails(object userId, object businessId, string sessionID)
        {
            throw new NotImplementedException();
        }

        public static void LogSessionDetails(int userId, int businessId, string sessionId)
        {
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(userId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(businessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(sessionId, "@SessionId", SqlDbType.VarChar);
                    cmd.ExecuteNonQuery(SqlProcedures.Insert_Session);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception Occured in LogSessionDetails" + ex.Message);
            }
        }

        public static void UpdateSessionDetails(int userId, int businessId, string sessionId)
        {
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(userId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(businessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(sessionId, "@SessionId", SqlDbType.VarChar);
                    cmd.ExecuteNonQuery(SqlProcedures.Update_EndSession);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception Occured in LogSessionDetails" + ex.Message);
            }
        }

        public static bool UpdatePassword(string newGuidPwd, int userID)
        {
            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(userID, CommonConstants.UserId, SqlDbType.VarChar);
                    cmd.AddParameters(newGuidPwd, "@UserPassword", SqlDbType.VarChar);

                    cmd.ExecuteNonQuery(SqlProcedures.Update_UserPassword);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception while updating password: " + ex.Message);
                }
            }
        }
    }

    public class LoggedUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public int BusinessId { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
        public string BusinessStatus { get; set; }
        public int BusinessStatusId { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }
        public int GroupId { get; set; }
        public int ModuleId { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public string CustomersRename { get; set; }
        public int LogMeOutId { get; set; }
        public int TimeLimit { get; set; }
        public string Message { get; set; }
        public string RenewalDate { get; set; }
        public string AccountClosingDate { get; set; }
        public int UserSessionEmployeeId { get; set; }

    }
}
