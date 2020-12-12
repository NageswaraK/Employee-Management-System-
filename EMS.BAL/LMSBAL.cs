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
    public class LMSBAL
    {

        #region LMS DropDowns
        public static IList<KeyValueVM> Get_Employees(int UserId, int BusinessId)
        {
            List<KeyValueVM> GetEmployees = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeNames);
                    while (ireader.Read())
                    {
                        var Employees = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.Name),
                            key = ireader.GetInt32(CommonColumns.UserEmployeeId),

                        };
                        GetEmployees.Add(Employees);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_Genders. Exception :" + ex.Message);
            }
            return GetEmployees;
        }

        public static IList<KeyValueVM> Get_Locations()
        {
            List<KeyValueVM> GetEmployees = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_Locations);
                    while (ireader.Read())
                    {
                        var Employees = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.LocationName),
                            key = ireader.GetInt32(CommonColumns.LocationId),

                        };
                        GetEmployees.Add(Employees);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_Genders. Exception :" + ex.Message);
            }
            return GetEmployees;
        }
        public static IList<KeyValueVM> GetCompanyName(int BusinessId, int UserId)
        {
            List<KeyValueVM> GetCompany = new List<KeyValueVM>();

            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);


                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_CompanyName);
                    while (ireader.Read())
                    {
                        var Employees = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.BusinessName),
                            key = ireader.GetInt32(CommonColumns.BusinessID),

                        };
                        GetCompany.Add(Employees);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return GetCompany;
        }

        public static IList<KeyValueVM> Get_LeaveType(int UserId)
        {
            List<KeyValueVM> GetLeaveType = new List<KeyValueVM>();
            int LeavetypeId = 0;
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(LeavetypeId, CommonConstants.LeavetypeId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_LeaveTypes);
                    while (ireader.Read())
                    {
                        var LeaveType = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.LeaveType),
                            key = ireader.GetInt32(CommonColumns.LeaveTypeId),

                        };
                        GetLeaveType.Add(LeaveType);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_Genders. Exception :" + ex.Message);
            }
            return GetLeaveType;
        }

        public static IList<KeyValueVM> Get_ReasonType(int UserId)
        {
            List<KeyValueVM> GetReasonType = new List<KeyValueVM>();
            int LeaveReasonId = 0;
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(LeaveReasonId, CommonConstants.LeaveReasonId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_Reasons);
                    while (ireader.Read())
                    {
                        var Reason = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.LeaveReason),
                            key = ireader.GetInt32(CommonColumns.LeaveReasonId),

                        };
                        GetReasonType.Add(Reason);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_Genders. Exception :" + ex.Message);
            }
            return GetReasonType;
        }

        public static IList<KeyValueVM> Get_Years(int UserId)
        {
            List<KeyValueVM> GetYears = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    //cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmpLeaves);
                    while (ireader.Read())
                    {
                        var Years = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.Year),
                            key = ireader.GetInt32(CommonColumns.Year),

                        };
                        GetYears.Add(Years);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_Genders. Exception :" + ex.Message);
            }
            return GetYears;
        }

        #endregion LMS DropDowns

        public static List<ViewApplyLeave> Get_EmpLeaveDetails(ViewApplyLeave _EmpLeave)
        {
            List<ViewApplyLeave> GetEmpVacations = new List<ViewApplyLeave>();
            return GetEmpVacations;
        }
        public static List<ViewApplyLeave> Get_EmpLeaveDetailsListForPayslip(ViewApplyLeave Data)
        {
            List<ViewApplyLeave> GetEmpVacations = new List<ViewApplyLeave>();
            //Data.Year = 2018;
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                try
                {
                    cmd.AddParameters(Data.Year, CommonConstants.Year, SqlDbType.Int);
                    cmd.AddParameters(Data.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(Data.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);


                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.GetEmployeeLeaveDeatails);

                    while (ireader.Read())
                    {
                        var EmpLeave = new ViewApplyLeave
                        {
                            EmployeeLeaveId = ireader.GetInt32(CommonColumns.EmployeeLeaveId),
                            UserEmployeeId = ireader.GetInt64(CommonColumns.UserEmployeeId),
                            BusinessId = ireader.GetInt32(CommonColumns.BusinessID),
                            EmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                            LeaveStartDate = ireader.GetDateTime(CommonColumns.LeaveStartDate).ToShortDateString(),
                            LeaveEndDate = ireader.GetDateTime(CommonColumns.LeaveEndDate).ToShortDateString(),
                            NoOfLeaveDays = ireader.GetInt32(CommonColumns.NoOfLeaveDays),
                            LeaveType = ireader.GetString(CommonColumns.LeaveType),
                            LeaveReason = ireader.GetString(CommonColumns.LeaveReason),
                            Description = ireader.GetString(CommonColumns.Description),
                            //FileStatus = ireader.GetString(CommonColumns.FileStatus),
                            LeaveStatus = ireader.GetString(CommonColumns.LeaveStatus),
                            LeaveStatusId = ireader.GetInt32(CommonColumns.LeaveStatusId),

                        };
                        GetEmpVacations.Add(EmpLeave);
                    }

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception in Get_EmpLeaveDetailsList. Exception :" + ex.Message);
                }

            }
            return GetEmpVacations;
        }

        public static List<ViewApplyLeave> Get_EmpLeaveDetailsList(ViewApplyLeave Data, int RoleId, int UserEmplyeeId)
        {
            List<ViewApplyLeave> GetEmpVacations = new List<ViewApplyLeave>();
            //Data.Year = 2018;
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                try
                {
                    cmd.AddParameters(Data.Year, CommonConstants.Year, SqlDbType.Int);
                    //cmd.AddParameters(Data.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    if (RoleId == 6)
                    {
                        cmd.AddParameters(UserEmplyeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    }
                    else
                    {
                        cmd.AddParameters(Data.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    }
                    cmd.AddParameters(Data.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);


                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.GetEmployeeLeaveDeatails);

                    while (ireader.Read())
                    {
                        var EmpLeave = new ViewApplyLeave
                        {
                            EmployeeLeaveId = ireader.GetInt32(CommonColumns.EmployeeLeaveId),
                            UserEmployeeId = ireader.GetInt64(CommonColumns.UserEmployeeId),
                            BusinessId = ireader.GetInt32(CommonColumns.BusinessID),
                            EmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                            LeaveStartDate = ireader.GetDateTime(CommonColumns.LeaveStartDate).ToShortDateString(),
                            LeaveEndDate = ireader.GetDateTime(CommonColumns.LeaveEndDate).ToShortDateString(),
                            NoOfLeaveDays = ireader.GetInt32(CommonColumns.NoOfLeaveDays),
                            LeaveType = ireader.GetString(CommonColumns.LeaveType),
                            LeaveReason = ireader.GetString(CommonColumns.LeaveReason),
                            Description = ireader.GetString(CommonColumns.Description),
                            //FileStatus = ireader.GetString(CommonColumns.FileStatus),
                            LeaveStatus = ireader.GetString(CommonColumns.LeaveStatus),
                            LeaveStatusId = ireader.GetInt32(CommonColumns.LeaveStatusId),

                        };
                        GetEmpVacations.Add(EmpLeave);
                    }

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception in Get_EmpLeaveDetailsList. Exception :" + ex.Message);
                }

            }
            return GetEmpVacations;
        }

        public static CommonMessages SaveEmployeeLeave(LMS Data)
        {
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (var Cmd = new DBSqlCommand())
                {

                    Cmd.AddParameters(Data.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    Cmd.AddParameters(Data.FromDate, CommonConstants.FromDate, SqlDbType.DateTime);
                    Cmd.AddParameters(Data.ToDate, CommonConstants.ToDate, SqlDbType.DateTime);
                    Cmd.AddParameters(Data.LeaveTypeId, CommonConstants.LeaveTypeId, SqlDbType.Int);
                    Cmd.AddParameters(Data.LeaveReasonId, CommonConstants.LeaveReasonId, SqlDbType.Int);
                    Cmd.AddParameters(Data.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    Cmd.AddParameters(Data.CurrentLeaveBalance, CommonConstants.CurrentLeaveBalance, SqlDbType.Int);
                    Cmd.AddParameters(Data.EffectiveLeave, CommonConstants.EffectiveLeave, SqlDbType.Int);
                    Cmd.AddParameters(Data.UserId, CommonConstants.UserId, SqlDbType.Int);
                    Cmd.AddParameters(Data.Description, CommonConstants.Description, SqlDbType.NVarChar);
                    Cmd.AddParameters(Data.FilePath, CommonConstants.FilePath, SqlDbType.NVarChar);

                    //Result = (int)Cmd.ExecuteScalar(SqlProcedures.Insert_EmployeeLeaves);
                    IDataReader ireader = Cmd.ExecuteDataReader(SqlProcedures.Insert_EmployeeLeaves);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.EmployeeLeaveId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }
                }

                return MessagesObj;

            }
            catch (Exception Ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = Ex.Message;
                MessagesObj.ErrorSeverity = Ex.Message;
                MessagesObj.ErrorState = Ex.Message;

                return MessagesObj;
            }
        }

        public static CommonMessages CancelLeave(ViewApplyLeave _CancelLeave)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                CommonMessages MessagesObj = new CommonMessages();
                try
                {
                    cmd.AddParameters(_CancelLeave.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(_CancelLeave.EmployeeLeaveId, CommonConstants.EmployeeLeaveId, SqlDbType.Int);
                    cmd.AddParameters(_CancelLeave.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(_CancelLeave.LeaveStatusId, CommonConstants.LeaveStatusId, SqlDbType.BigInt);
                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.usp_UpdateLeaveStatus);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.Result),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }

                    return MessagesObj;
                }
                catch (Exception ex)
                {
                    MessagesObj.Result = 0;
                    MessagesObj.Message = ex.Message;
                    MessagesObj.ErrorSeverity = ex.Message;
                    MessagesObj.ErrorState = ex.Message;

                    return MessagesObj;
                }
            }

        }


    }
}
