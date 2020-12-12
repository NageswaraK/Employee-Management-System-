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
    public class EmployeesBAL
    {
        #region AddEmployee

        public static CommonMessages SavePersonalDetails(AddEmployeeMDL AddEmployee)
        {
            var Password = AddEmployee.Password.GetSHA1();

            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(AddEmployee.BusinessID, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.UserID, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.EmployeeNumber, CommonConstants.EmployeeNumber, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.GenderID, CommonConstants.GenderId, SqlDbType.SmallInt);
                    cmd.AddParameters(AddEmployee.FirstName, CommonConstants.FirstName, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.LastName, CommonConstants.LastName, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.DOB, CommonConstants.DOB, SqlDbType.Date);
                    cmd.AddParameters(Password, CommonConstants.Password, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.Email, CommonConstants.Email, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.SSN, CommonConstants.SSN, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.EmployeeRoleId, CommonConstants.EmployeeRoleId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Insert_EmployeeDetails);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }

                    if (MessagesObj.Result > 0)
                        AddEmployee.UserEmployeeID = MessagesObj.Result;
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
                throw new ArgumentException("Exception in SavePersonalDetails. Exception :" + ex.Message);
            }
        }

        public static CommonMessages SaveProfessionalDetails(AddEmployeeMDL AddEmployee)
        {

            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(AddEmployee.BusinessID, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.UserID, CommonConstants.UserId, SqlDbType.Int);
                    //cmd.AddParameters(AddEmployee.EmployeeNumber, CommonConstants.EmployeeNumber, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.EmployeeDesignationID, CommonConstants.EmployeeDesignationID, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.EmployeeCTC, CommonConstants.EmployeeCTC, SqlDbType.Decimal);
                    cmd.AddParameters(AddEmployee.UserEmployeeID, CommonConstants.UserEmployeeID, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.PAN, CommonConstants.PAN, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.PF, CommonConstants.PF, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.UAN, CommonConstants.UAN, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.LocationId, CommonConstants.LocationId, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.ReportManagerTo, CommonConstants.ReportManagerTo, SqlDbType.Int);


                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeProfessionalDetails);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }

                    if (MessagesObj.Result > 0)
                        AddEmployee.UserEmployeeID = MessagesObj.Result;
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
                throw new ArgumentException("Exception in SaveProfessionalDetails. Exception :" + ex.Message);
            }

        }

        public static CommonMessages SaveEmployementDetails(AddEmployeeMDL AddEmployee)
        {

            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(AddEmployee.BusinessID, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.UserID, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.Title, CommonConstants.Title, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.UserEmployeeID, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.EmployeeStatusID, CommonConstants.EmployeeStatusId, SqlDbType.SmallInt);
                    cmd.AddParameters(AddEmployee.EmployeeModeID, CommonConstants.EmploymentModeId, SqlDbType.SmallInt);
                    cmd.AddParameters(AddEmployee.PayFrequencyID, CommonConstants.PayFrequecyId, SqlDbType.SmallInt);
                    cmd.AddParameters(AddEmployee.JoiningDate, CommonConstants.JoiningDate, SqlDbType.Date);
                    cmd.AddParameters(AddEmployee.PaymentTypeID, CommonConstants.PaymentTypeId, SqlDbType.SmallInt);
                    cmd.AddParameters(AddEmployee.VacationAllowed, CommonConstants.VacationAllowed, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployementDetails);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }

                    if (MessagesObj.Result > 0)
                        AddEmployee.UserEmployeeID = MessagesObj.Result;
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
                throw new ArgumentException("Exception in SaveEmployementDetails. Exception :" + ex.Message);
            }
        }

        public static CommonMessages SaveCommunicationDetails(AddEmployeeMDL AddEmployee)
        {

            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(AddEmployee.BusinessID, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.UserID, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.UserEmployeeID, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(AddEmployee.OfficeEmail, CommonConstants.OfficeEmail, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.PersonalEmail, CommonConstants.PersonalEmail, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.HomeAddress, CommonConstants.HomeAddress, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.AlternateAddress, CommonConstants.AlternateAddress, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.HomePhone, CommonConstants.HomePhone, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.HomeFax, CommonConstants.HomeFax, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.PersonalMobile, CommonConstants.PersonalMobile, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.OfficeMobile, CommonConstants.OfficeMobile, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Insert_EmployeeCommunication);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }

                    if (MessagesObj.Result > 0)
                        AddEmployee.UserEmployeeID = MessagesObj.Result;
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
                throw new ArgumentException("Exception in SaveCommunicationDetails. Exception :" + ex.Message);
            }
        }

        public static CommonMessages SaveBankDetails(AddEmployeeMDL AddEmployee)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                if (AddEmployee.BankName == "" && AddEmployee.AccountNum == "" && AddEmployee.BankAccountTypeID == null && AddEmployee.RoutingNum == "" && AddEmployee.BankAddress == "")
                {

                }
                else
                {
                    using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                    {
                        cmd.AddParameters(AddEmployee.BusinessID, CommonConstants.BusinessID, SqlDbType.Int);
                        cmd.AddParameters(AddEmployee.UserID, CommonConstants.UserId, SqlDbType.Int);
                        cmd.AddParameters(AddEmployee.UserEmployeeID, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                        cmd.AddParameters(AddEmployee.BankName, CommonConstants.BankName, SqlDbType.VarChar);
                        cmd.AddParameters(AddEmployee.AccountNum, CommonConstants.AccountNum, SqlDbType.VarChar);
                        cmd.AddParameters(AddEmployee.BankAccountTypeID, CommonConstants.BankAccountTypeId, SqlDbType.SmallInt);
                        cmd.AddParameters(AddEmployee.RoutingNum, CommonConstants.RountingNum, SqlDbType.VarChar);
                        cmd.AddParameters(AddEmployee.BankAddress, CommonConstants.BankAddress, SqlDbType.VarChar);

                        IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Insert_EmployeeBankDetails);
                        while (ireader.Read())
                        {
                            var EmpDet = new CommonMessages
                            {
                                Message = ireader.GetString(CommonColumns.ErrorMessage),
                                Result = ireader.GetInt32(CommonColumns.BankAccountsId),
                                ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                                ErrorState = ireader.GetString(CommonColumns.ErrorState),
                            };

                            MessagesObj = EmpDet;
                        }

                    }
                }
                //ts.Complete();
                return MessagesObj;
            }
            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in SaveBankDetails. Exception :" + ex.Message);
            }
            //}
        }

        public static CommonMessages SaveFamilyDetails(AddEmployeeMDL AddEmployee)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                if (AddEmployee._listFamilyDetails != null)
                {
                    foreach (var item in AddEmployee._listFamilyDetails)
                    {
                        if (item.FamilyFirstName != "" && item.FamilyLastName != "")
                        {
                            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                            {
                                cmd.AddParameters(AddEmployee.BusinessID, CommonConstants.BusinessID, SqlDbType.Int);
                                cmd.AddParameters(AddEmployee.UserID, CommonConstants.UserId, SqlDbType.Int);
                                cmd.AddParameters(AddEmployee.UserEmployeeID, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                                cmd.AddParameters(item.FamilyRelationID, CommonConstants.RelationId, SqlDbType.SmallInt);
                                cmd.AddParameters(item.FamilyFirstName, CommonConstants.FirstName, SqlDbType.VarChar);
                                cmd.AddParameters(item.FamilyLastName, CommonConstants.LastName, SqlDbType.VarChar);
                                cmd.AddParameters(item.FamilyGenderID, CommonConstants.GenderId, SqlDbType.SmallInt);
                                //cmd.AddParameters(item.FamilyDOB, CommonConstants.DOB, SqlDbType.Date);
                                cmd.AddParameters(item.FamilyPhone, CommonConstants.Phone, SqlDbType.VarChar);
                                cmd.AddParameters(item.FamilyEmail, CommonConstants.Email, SqlDbType.VarChar);

                                IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Insert_EmployeeFamilyDetails);
                                while (ireader.Read())
                                {
                                    var EmpDet = new CommonMessages
                                    {
                                        Message = ireader.GetString(CommonColumns.ErrorMessage),
                                        Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                                        ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                                        ErrorState = ireader.GetString(CommonColumns.ErrorState),
                                    };

                                    MessagesObj = EmpDet;
                                }

                            }
                        }
                    }
                }
                // ts.Complete();
                return MessagesObj;
            }
            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in SaveFamilyDetails. Exception :" + ex.Message);
            }
            //}
        }

        public static CommonMessages SaveAssetDetails(AddEmployeeMDL AddEmployee)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(AddEmployee.BusinessID, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.UserID, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(AddEmployee.UserEmployeeID, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(AddEmployee.EmployeeAssetId, CommonConstants.EmployeeAssetId, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.EmployeeAssetMake, CommonConstants.EmployeeAssetMake, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.EmployeeAssetModel, CommonConstants.EmployeeAssetModel, SqlDbType.VarChar);
                    cmd.AddParameters(AddEmployee.EmployeeAssetBarcode, CommonConstants.EmployeeAssetBarcode, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeAssetDetails);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }

                    if (MessagesObj.Result > 0)
                        AddEmployee.UserEmployeeID = MessagesObj.Result;
                }
                //ts.Complete();
                return MessagesObj;
            }
            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in SaveAssetDetails. Exception :" + ex.Message);
            }
            //}
        }

        public static bool CheckExists_Employee(string FirstName, string LastName, int BusinessId, int? UserEmployeeId)
        {
            var Result = false;
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {

                cmd.AddParameters(FirstName, CommonConstants.FirstName, SqlDbType.VarChar);
                cmd.AddParameters(LastName, CommonConstants.LastName, SqlDbType.VarChar);
                cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                int Res = (int)cmd.ExecuteScalar(SqlProcedures.CheckExists_Employee);
                if (Res == 1)
                    Result = false;
                else
                    Result = true;
            }
            return Result;
        }

        public static bool CheckExists_EmployeeNumber(string EmployeeNumber, int BusinessId, int? UserEmployeeId)
        {
            var Result = false;
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {

                cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                cmd.AddParameters(EmployeeNumber, CommonConstants.EmployeeNumber, SqlDbType.VarChar);
                cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                int Res = (int)cmd.ExecuteScalar(SqlProcedures.CheckExists_EmployeeNumber);
                if (Res == 1)
                    Result = false;
                else
                    Result = true;

            }
            return Result;
        }

        #endregion AddEmployee

        #region EmployeeList

        public static List<EmployeeListMDL> GetEmployeesList(int BusinessId, int UserId, int roleId, int UserEmplyeeId)
        {
            List<EmployeeListMDL> EmployeesList = new List<EmployeeListMDL>();
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    if (roleId == 6)
                    {
                        cmd.AddParameters(UserEmplyeeId, CommonConstants.UserEmployeeID, SqlDbType.Int);
                    }
                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeDetails);

                    while (ireader.Read())
                    {
                        var Employee = new EmployeeListMDL
                        {
                            UserEmployeeId = ireader.GetInt64(CommonColumns.UserEmployeeId),
                            FirstName = ireader.GetString(CommonColumns.FirstName),
                            LastName = ireader.GetString(CommonColumns.LastName),
                            Title = ireader.GetString(CommonColumns.Title),
                            DOB = ireader.GetDateTime(CommonColumns.EmployeeDOB),
                            SSN = ireader.GetString(CommonColumns.SSN),
                            Gender = ireader.GetString(CommonColumns.Gender),
                            EmployeeStatus = ireader.GetString(CommonColumns.EmployeeStatus),
                            EmploymentMode = ireader.GetString(CommonColumns.EmploymentMode),
                            PayFrequency = ireader.GetString(CommonColumns.PayFrequecy),
                            GenderId = ireader.GetInt32(CommonColumns.GenderId),
                            StatusId = ireader.GetInt32(CommonColumns.StatusId),
                            EmploymentModeId = ireader.GetInt32(CommonColumns.EmploymentModeId),
                            PayFrequecyId = ireader.GetInt32(CommonColumns.PayFrequecyId),
                            UserAccountsId = ireader.GetInt32(CommonColumns.UserAccountsId)
                        };
                        EmployeesList.Add(Employee);
                    }

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception in GetEmployeesList. Exception :" + ex.Message);
                }

                return EmployeesList;
            }
        }

        public static EmploymentDetailsMDL Validate_DeleteUserEmployee(EmploymentDetailsMDL EmpDet)
        {
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(EmpDet.UserEmployeeId, CommonConstants.EmployeeId, SqlDbType.Int);
                    cmd.AddParameters(EmpDet.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpDet.UserId, CommonConstants.UserId, SqlDbType.Int);

                    var EmploymentDetails = new EmploymentDetailsMDL();

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Validate_DeleteUserEmployee);
                    while (ireader.Read())
                    {
                        var EmploymentDet = new EmploymentDetailsMDL
                        {
                            Message = ireader.GetString(CommonColumns.Msg),
                            Result = ireader.GetInt32(CommonColumns.Result),
                        };

                        EmploymentDetails = EmploymentDet;
                    }
                    return EmploymentDetails;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Validate_DeleteUserEmployee. Exception :" + ex.Message);
                }
            }
        }

        public static bool Delete_UserEmployee(EmploymentDetailsMDL EmpDetails)
        {
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(EmpDetails.UserEmployeeId, CommonConstants.EmployeeId, SqlDbType.Int);
                    cmd.AddParameters(EmpDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpDetails.UserId, CommonConstants.UserId, SqlDbType.Int);

                    cmd.ExecuteNonQuery(SqlProcedures.Delete_UserEmployee);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new ArgumentException("Exception in Delete_UserEmployee. Exception :" + ex.Message);
            }
        }

        public static EmploymentDetailsMDL Get_EmployeeDetails(EmploymentDetailsMDL EmpDetails)
        {
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(EmpDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpDetails.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpDetails.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                    var EmployeeDetails = new EmploymentDetailsMDL();

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeDetails);
                    while (ireader.Read())
                    {
                        var EmployeeDet = new EmploymentDetailsMDL
                        {
                            FirstName = ireader.GetString(CommonColumns.EmployeeFirstName),
                            LastName = ireader.GetString(CommonColumns.EmployeeLastName),
                            Gender = ireader.GetString(CommonColumns.EmployeeGender),
                            Title = ireader.GetString(CommonColumns.EmployeeTitle),
                            DOB = (ireader.GetDateTime(CommonColumns.EmployeeDOB)),
                            Status = ireader.GetString(CommonColumns.EmployeeStatus),
                            Employment = ireader.GetString(CommonColumns.EmploymentMode),
                            PaymentFrequency = ireader.GetString(CommonColumns.PayFrequecy),
                            GenderId = ireader.GetInt32(CommonColumns.GenderId),
                            EmployeeStatusId = ireader.GetInt32(CommonColumns.StatusId),
                            EmploymentModeId = ireader.GetInt32(CommonColumns.EmploymentModeId),
                            PaymentFrequecyId = ireader.GetInt32(CommonColumns.PayFrequecyId),
                            ImagePath = ireader.GetString(CommonColumns.ImagePath),
                            UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            UserAccountsId = ireader.GetInt32(CommonColumns.UserAccountsId),
                            SocialSecurityNumber = ireader.GetString(CommonColumns.SSN),
                            JoiningDate = (ireader.GetDateTime(CommonColumns.JoiningDate)),
                            PaymentMethodId = ireader.GetInt32(CommonColumns.PaymentTypesId),
                            PaymentMethod = ireader.GetString(CommonColumns.PaymentType),
                            VacationAllowed = ireader.GetInt32(CommonColumns.VacationAllowed),
                            EmployeeNumber = ireader.GetString(CommonColumns.EmployeeNumber),
                            JoinedDate = ireader.GetString(CommonColumns.JoiningDate),
                            PAN = ireader.GetString(CommonColumns.PAN),
                            PF = ireader.GetString(CommonColumns.PF),
                            UAN = ireader.GetString(CommonColumns.UAN)
                        };

                        EmployeeDetails = EmployeeDet;
                    }
                    return EmployeeDetails;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_EmployeeDetails. Exception :" + ex.Message);
                }
            }
        }

        public static CommonMessages Update_EmployeeDetails(EmploymentDetailsMDL EmpDetails)
        {
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(EmpDetails.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpDetails.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(EmpDetails.GenderId, CommonConstants.GenderId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpDetails.FirstName, CommonConstants.FirstName, SqlDbType.VarChar);
                    cmd.AddParameters(EmpDetails.LastName, CommonConstants.LastName, SqlDbType.VarChar);
                    cmd.AddParameters(EmpDetails.DOB, CommonConstants.DOB, SqlDbType.Date);
                    cmd.AddParameters(EmpDetails.SocialSecurityNumber, CommonConstants.SSN, SqlDbType.VarChar);
                    cmd.AddParameters(EmpDetails.Title, CommonConstants.Title, SqlDbType.VarChar);
                    cmd.AddParameters(EmpDetails.EmployeeStatusId, CommonConstants.EmployeeStatusId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpDetails.EmploymentModeId, CommonConstants.EmploymentModeId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpDetails.PaymentFrequecyId, CommonConstants.PayFrequecyId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpDetails.JoiningDate, CommonConstants.JoiningDate, SqlDbType.Date);
                    cmd.AddParameters(EmpDetails.PaymentMethodId, CommonConstants.PaymentTypeId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpDetails.VacationAllowed, CommonConstants.VacationAllowed, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpDetails.EmployeeNumber, CommonConstants.EmployeeNumber, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeeDetails);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }
                    return MessagesObj;
                }
            }
            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in Update_EmployeeDetails. Exception :" + ex.Message);
            }
        }

        public static EmployeeCommunicationDetailsMDL Get_EmployeeCommunicationDetails(EmployeeCommunicationDetailsMDL EmpCommunicationDetails)
        {
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(EmpCommunicationDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpCommunicationDetails.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpCommunicationDetails.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                    var EmployeeCommunicationDetails = new EmployeeCommunicationDetailsMDL();

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeCommunicationDetails);
                    while (ireader.Read())
                    {
                        var EmployeeCommunicationDet = new EmployeeCommunicationDetailsMDL
                        {
                            UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            OfficieEmail = ireader.GetString(CommonColumns.EmployeeOfficeEmail),
                            OfficeMobile = ireader.GetString(CommonColumns.EmployeeOfficeMobile),
                            HomeAddress = ireader.GetString(CommonColumns.EmployeeHomeAddress),
                            HomePhone = ireader.GetString(CommonColumns.EmployeeHomePhone),
                            HomeFAX = ireader.GetString(CommonColumns.EmployeeHomeFax),
                            PersonalEmail = ireader.GetString(CommonColumns.EmployeePersonalEmail),
                            AlternateAddress = ireader.GetString(CommonColumns.EmployeeAlternateAddress),
                            PersonalMobile = ireader.GetString(CommonColumns.EmployeePersonalMobile)
                        };

                        EmployeeCommunicationDetails = EmployeeCommunicationDet;
                    }
                    return EmployeeCommunicationDetails;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_EmployeeCommunicationDetails. Exception :" + ex.Message);
                }
            }
        }

        public static CommonMessages Update_EmployeeCommunicationDetails(EmployeeCommunicationDetailsMDL EmpCommunicationDetails)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {

                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(EmpCommunicationDetails.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpCommunicationDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpCommunicationDetails.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(EmpCommunicationDetails.OfficieEmail, CommonConstants.OfficeEmail, SqlDbType.VarChar);
                    cmd.AddParameters(EmpCommunicationDetails.PersonalEmail, CommonConstants.PersonalEmail, SqlDbType.VarChar);
                    cmd.AddParameters(EmpCommunicationDetails.HomeAddress, CommonConstants.HomeAddress, SqlDbType.VarChar);
                    cmd.AddParameters(EmpCommunicationDetails.AlternateAddress, CommonConstants.AlternateAddress, SqlDbType.VarChar);
                    cmd.AddParameters(EmpCommunicationDetails.HomePhone, CommonConstants.HomePhone, SqlDbType.VarChar);
                    cmd.AddParameters(EmpCommunicationDetails.HomeFAX, CommonConstants.HomeFax, SqlDbType.VarChar);
                    cmd.AddParameters(EmpCommunicationDetails.PersonalMobile, CommonConstants.PersonalMobile, SqlDbType.VarChar);
                    cmd.AddParameters(EmpCommunicationDetails.OfficeMobile, CommonConstants.OfficeMobile, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeeCommunicationDetails);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }
                    //ts.Complete();
                    return MessagesObj;
                }
            }
            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in Update_EmployeeCommunicationDetails. Exception :" + ex.Message);
            }
            //}
        }

        public static EmployeeBankDetailsMDL Get_EmployeeBankDetails(EmployeeBankDetailsMDL EmpBankDetails)
        {
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(EmpBankDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpBankDetails.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpBankDetails.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                    var EmployeeBankDetails = new EmployeeBankDetailsMDL();

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeBankDetails);
                    while (ireader.Read())
                    {
                        var EmployeeBankDet = new EmployeeBankDetailsMDL
                        {
                            BankAccountsId = ireader.GetInt32(CommonColumns.BankAccountsId),
                            BankName = ireader.GetString(CommonColumns.EmployeeBankName),
                            Account = ireader.GetString(CommonColumns.EmployeeAccountNo),
                            AccountTypeName = ireader.GetString(CommonColumns.EmployeeAccountType),
                            Routing = ireader.GetString(CommonColumns.EmployeeRountingNo),
                            BankAddress = ireader.GetString(CommonColumns.EmployeeAddress),
                            BankAccountTypeId = ireader.GetInt32(CommonColumns.BankAccountTypeId)
                        };

                        EmployeeBankDetails = EmployeeBankDet;
                    }
                    return EmployeeBankDetails;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_EmployeeBankDetails. Exception :" + ex.Message);
                }

            }
        }

        public static CommonMessages Update_EmployeeBankDetails(EmployeeBankDetailsMDL EmpBankDetails)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {

                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(EmpBankDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpBankDetails.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpBankDetails.BankAccountsId, CommonConstants.BankAccountsId, SqlDbType.Int);
                    cmd.AddParameters(EmpBankDetails.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(EmpBankDetails.BankName, CommonConstants.BankName, SqlDbType.VarChar);
                    cmd.AddParameters(EmpBankDetails.Account, CommonConstants.AccountNum, SqlDbType.VarChar);
                    cmd.AddParameters(EmpBankDetails.BankAccountTypeId, CommonConstants.BankAccountTypeId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpBankDetails.Routing, CommonConstants.RountingNum, SqlDbType.VarChar);
                    cmd.AddParameters(EmpBankDetails.BankAddress, CommonConstants.BankAddress, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeeBankDetails);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.BankAccountsId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }
                    //ts.Complete();
                    return MessagesObj;
                }
            }
            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in Update_EmployeeBankDetails. Exception :" + ex.Message);
            }
            //}
        }

        public static List<EmployeeFamilyDetailsMDL> Get_EmployeeFamilyDetails(int BusinessId, int UserId, int UserEmployeeId)
        {
            var EmployeeFamilyDetails = new List<EmployeeFamilyDetailsMDL>();
            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeFamilyDetails);
                    while (ireader.Read())
                    {
                        var EmployeeFamilyDet = new EmployeeFamilyDetailsMDL
                        {
                            FamilyDetailsId = ireader.GetInt32(CommonColumns.FamilyDetailsId),
                            UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            Relation = ireader.GetString(CommonColumns.EmployeeRelation),
                            Name = ireader.GetString(CommonColumns.EmployeeFamilyName),
                            DOB = (ireader.GetDateTime(CommonColumns.EmployeeDOB)),
                            Gender = ireader.GetString(CommonColumns.EmployeeGender),
                            GenderId = ireader.GetInt32(CommonColumns.GenderId),
                            RelationId = ireader.GetInt32(CommonColumns.RelationId),
                            FirstName = ireader.GetString(CommonColumns.FirstName),
                            LastName = ireader.GetString(CommonColumns.LastName),
                            Phone = ireader.GetString(CommonColumns.Phone),
                            Email = ireader.GetString(CommonColumns.EmployeeEmail)

                        };

                        EmployeeFamilyDetails.Add(EmployeeFamilyDet);
                    }

                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_EmployeeFamilyDetails. Exception :" + ex.Message);
                }
            }
            return EmployeeFamilyDetails;
        }

        public static CommonMessages Insert_EmployeeFamilyDetails(EmployeeFamilyDetailsMDL EmpFamilyDetails)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {

                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(EmpFamilyDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.RelationId, CommonConstants.RelationId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpFamilyDetails.FirstName, CommonConstants.FirstName, SqlDbType.VarChar);
                    cmd.AddParameters(EmpFamilyDetails.LastName, CommonConstants.LastName, SqlDbType.VarChar);
                    cmd.AddParameters(EmpFamilyDetails.GenderId, CommonConstants.GenderId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpFamilyDetails.DOB, CommonConstants.DOB, SqlDbType.Date);
                    cmd.AddParameters(EmpFamilyDetails.Phone, CommonConstants.Phone, SqlDbType.VarChar);
                    cmd.AddParameters(EmpFamilyDetails.Email, CommonConstants.Email, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Insert_EmployeeFamilyDetails);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }
                }
                //ts.Complete();
                return MessagesObj;
            }
            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in Insert_EmployeeFamilyDetails. Exception :" + ex.Message);
            }
            // }
        }

        public static CommonMessages Update_EmployeeFamilyDetails(EmployeeFamilyDetailsMDL EmpFamilyDetails)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(EmpFamilyDetails.FamilyDetailsId, CommonConstants.FamilyDetailsId, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.RelationId, CommonConstants.RelationId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpFamilyDetails.FirstName, CommonConstants.FirstName, SqlDbType.VarChar);
                    cmd.AddParameters(EmpFamilyDetails.LastName, CommonConstants.LastName, SqlDbType.VarChar);
                    cmd.AddParameters(EmpFamilyDetails.GenderId, CommonConstants.GenderId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpFamilyDetails.DOB, CommonConstants.DOB, SqlDbType.Date);
                    cmd.AddParameters(EmpFamilyDetails.Phone, CommonConstants.Phone, SqlDbType.VarChar);
                    cmd.AddParameters(EmpFamilyDetails.Email, CommonConstants.Email, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeeFamilyDetails);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.FamilyDetailsId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }
                    //ts.Complete();
                    return MessagesObj;
                }
            }
            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in Update_EmployeeFamilyDetails. Exception :" + ex.Message);
            }
            //}
        }

        public static CommonMessages Delete_EmployeeFamilyDetails(EmployeeFamilyDetailsMDL EmpFamilyDetails)
        {
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(EmpFamilyDetails.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(EmpFamilyDetails.FamilyDetailsId, CommonConstants.FamilyDetailsId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Delete_EmployeeFamilyDetails);
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
            }

            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in Delete_EmployeeFamilyDetails. Exception :" + ex.Message);
            }
        }

        public static List<EmployeeDeductionsMDL> Get_EmployeeDeductions(int BusinessId, int UserId, int UserEmployeeId)
        {
            var EmpDeductionDetails = new List<EmployeeDeductionsMDL>();

            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeDeductions);
                    while (ireader.Read())
                    {
                        var EmpDeductionDet = new EmployeeDeductionsMDL
                        {
                            DeductionTypesId = ireader.GetInt32(CommonColumns.DeductionTypesId),
                            DeductionType = ireader.GetString(CommonColumns.DeductionType),
                            DeductionPercent = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.DeductionPercent)),
                        };

                        EmpDeductionDetails.Add(EmpDeductionDet);
                    }

                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_EmployeeDeductions. Exception :" + ex.Message);
                }
            }

            return EmpDeductionDetails;
        }

        public static CommonMessages Update_EmployeeDeductions(EmployeeDeductionsMDL EmpDeductions)
        {
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(EmpDeductions.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(EmpDeductions.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(EmpDeductions.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(EmpDeductions.DeductionTypesId, CommonConstants.DeductionTypesId, SqlDbType.SmallInt);
                    cmd.AddParameters(EmpDeductions.DeductionPercent, CommonConstants.DeductionPercent, SqlDbType.Decimal);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeeDeductions);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }
                    return MessagesObj;
                }
            }
            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in Update_EmployeeDeductions. Exception :" + ex.Message);
            }
        }

        public static List<TimeSheetDetailsMDL> Get_TimeSheets(int BusinessId, int UserId, int UserEmployeeId)
        {
            var EmpTimeSheetDetails = new List<TimeSheetDetailsMDL>();

            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(1, CommonConstants.PageNo, SqlDbType.Int);
                    cmd.AddParameters(5, CommonConstants.PageSize, SqlDbType.Int);
                    cmd.AddParameters("Date", CommonConstants.SortColumn, SqlDbType.VarChar);
                    cmd.AddParameters("DESC", CommonConstants.SortOrder, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeTimeSheets);
                    while (ireader.Read())
                    {
                        var EmpTimeSheetDet = new TimeSheetDetailsMDL
                        {
                            TimesheetId = ireader.GetInt32(CommonColumns.TimeSheetId),
                            Date = (ireader.GetDateTime(CommonColumns.Date)),
                            Description = ireader.GetString(CommonColumns.Description),
                            RegularHours = ireader.GetString(CommonColumns.RegularHours),
                            OverTimeHours = ireader.GetString(CommonColumns.OverTimeHours),
                            UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ProjectId = ireader.GetInt32(CommonColumns.ProjectId),
                            SNo = ireader.GetInt32(CommonColumns.SNo),
                            EmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                            TimesheetstatusId = ireader.GetInt32(CommonColumns.TimesheetstatusId)

                        };

                        EmpTimeSheetDetails.Add(EmpTimeSheetDet);
                    }

                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_TimeSheets. Exception :" + ex.Message);
                }
            }

            return EmpTimeSheetDetails;
        }

        public static List<VacationStatusMDL> Get_Vacations(int BusinessId, int UserId, int UserEmployeeId)
        {
            var EmployeeVacation = new List<VacationStatusMDL>();

            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(1, CommonConstants.PageNo, SqlDbType.Int);
                    cmd.AddParameters(5, CommonConstants.PageSize, SqlDbType.Int);
                    cmd.AddParameters("FromDate", CommonConstants.SortColumn, SqlDbType.VarChar);
                    cmd.AddParameters("DESC", CommonConstants.SortOrder, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeVacation);
                    while (ireader.Read())
                    {
                        var EmpVacation = new VacationStatusMDL
                        {
                            LeaveId = ireader.GetInt32(CommonColumns.LeaveId),
                            UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            FromDate = (ireader.GetDateTime(CommonColumns.FromDate)),
                            ToDate = (ireader.GetDateTime(CommonColumns.ToDate)),
                            LeaveStatusId = ireader.GetInt32(CommonColumns.LeaveStatusId),
                            LeaveStatus = ireader.GetString(CommonColumns.LeaveStatus),
                            Days = ireader.GetInt32(CommonColumns.Days),
                            SNo = ireader.GetInt32(CommonColumns.SNo),
                            EmployeeName = ireader.GetString(CommonColumns.EmployeeName)

                        };

                        EmployeeVacation.Add(EmpVacation);
                    }

                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_Vacations. Exception :" + ex.Message);
                }
            }

            return EmployeeVacation;
        }

        public static List<PayrollStatusMDL> Get_Payrolls(int BusinessId, int UserId, int UserEmployeeId)
        {
            var EmployeePayroll = new List<PayrollStatusMDL>();
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(1, CommonConstants.PageNo, SqlDbType.Int);
                    cmd.AddParameters(5, CommonConstants.PageSize, SqlDbType.Int);
                    cmd.AddParameters("Date", CommonConstants.SortColumn, SqlDbType.VarChar);
                    cmd.AddParameters("DESC", CommonConstants.SortOrder, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeePayrolls);
                    while (ireader.Read())
                    {
                        var EmpPayroll = new PayrollStatusMDL
                        {
                            RegularHours = ireader.GetString(CommonColumns.RegularHours),
                            OverTimeHours = ireader.GetString(CommonColumns.OverTimeHours),
                            Amount = ireader.GetString(CommonColumns.Amount),
                            Status = ireader.GetString(CommonColumns.EmployeePayRollStatus),
                            StatusId = ireader.GetInt32(CommonColumns.StatusId),
                            EmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                            BankAccountsId = ireader.GetInt32(CommonColumns.BankAccountsId),
                            EmployeePayrollId = ireader.GetInt32(CommonColumns.EmployeePayRollId),
                            UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            FromDate = ireader.GetDateTime(CommonColumns.FromDate),
                            ToDate = ireader.GetDateTime(CommonColumns.ToDate)
                        };

                        EmployeePayroll.Add(EmpPayroll);
                    }

                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_Payrolls. Exception :" + ex.Message);
                }
            }
            return EmployeePayroll;
        }

        #endregion EmployeeList

        #region TimeSheet

        public static List<TimeSheetMDL> Get_EmployeeTimeSheets(TimeSheetMDL TimeSheet)
        {
            List<TimeSheetMDL> GetEmpTimeSheets = new List<TimeSheetMDL>();
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                try
                {
                    cmd.AddParameters(TimeSheet.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(TimeSheet.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(TimeSheet.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(TimeSheet.ProjectId, CommonConstants.ProjectId, SqlDbType.BigInt);
                    cmd.AddParameters(TimeSheet.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(TimeSheet.ToDate, CommonConstants.ToDate, SqlDbType.Date);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeTimeSheets);

                    while (ireader.Read())
                    {
                        var EmpTimeSheet = new TimeSheetMDL
                        {
                            SNo = ireader.GetInt32(CommonColumns.SNo),
                            TimeSheetId = ireader.GetInt32(CommonColumns.TimeSheetId),
                            Date = ireader.GetDateTime(CommonColumns.Date),
                            Description = ireader.GetString(CommonColumns.Description),
                            RegularHours = ireader.GetInt32(CommonColumns.RegularHours),
                            OverTimeHours = ireader.GetInt32(CommonColumns.OverTimeHours),
                            UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            ProjectId = ireader.GetInt32(CommonColumns.ProjectId),
                            EmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                            ProjectName = ireader.GetString(CommonColumns.Project),
                            TimesheetstatusId = ireader.GetInt32(CommonColumns.TimesheetstatusId)
                        };
                        GetEmpTimeSheets.Add(EmpTimeSheet);
                    }

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception in Get_EmployeeTimeSheets. Exception :" + ex.Message);
                }

            }
            return GetEmpTimeSheets;
        }

        public static CommonMessages Weekly_EmployeeTimeSheet(TimeSheetMDL TimeSheet, string[] DatesStr, string[] RegularHoursStr, string[] OverTimeHoursStr)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BusinessId", typeof(Int32));
            dt.Columns.Add("UserId", typeof(Int32));
            dt.Columns.Add("UserEmployeeId", typeof(Int32));
            dt.Columns.Add("ProjectId", typeof(Int32));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("RegularHours", typeof(Int32));
            dt.Columns.Add("OverTimeHours", typeof(Int32));

            for (int i = 0; i < DatesStr.Length; i++)
            {
                dt.Rows.Add(TimeSheet.BusinessId, TimeSheet.UserId, TimeSheet.UserEmployeeId, TimeSheet.ProjectId, DatesStr[i], TimeSheet.Description, RegularHoursStr[i], OverTimeHoursStr[i]);
            }

            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                CommonMessages MessagesObj = new CommonMessages();
                try
                {
                    cmd.AddParameters(TimeSheet.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(dt, CommonConstants.WeeklyTimesheet_Info, SqlDbType.Structured);

                    var Result = cmd.ExecuteScalar(SqlProcedures.Weekly_EmployeeTimeSheet);

                    return MessagesObj;
                }
                catch (Exception ex)
                {
                    MessagesObj.Result = 0;
                    MessagesObj.Message = ex.Message;
                    MessagesObj.ErrorSeverity = ex.Message;
                    MessagesObj.ErrorState = ex.Message;

                    return MessagesObj;
                    throw new ArgumentException("Exception in Weekly_EmployeeTimeSheet. Exception :" + ex.Message);
                }
            }


        }

        public static CommonMessages Insert_EmployeeTimeSheet(TimeSheetMDL TimeSheet)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                //using (TransactionScope ts = new TransactionScope())
                //{
                CommonMessages MessagesObj = new CommonMessages();
                try
                {
                    cmd.AddParameters(TimeSheet.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(TimeSheet.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(TimeSheet.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(TimeSheet.ProjectId, CommonConstants.ProjectId, SqlDbType.BigInt);
                    cmd.AddParameters(TimeSheet.Date, CommonConstants.Date, SqlDbType.DateTime);
                    cmd.AddParameters(TimeSheet.Description, CommonConstants.Description, SqlDbType.VarChar);
                    cmd.AddParameters(TimeSheet.RegularHours, CommonConstants.RegularHours, SqlDbType.SmallInt);
                    cmd.AddParameters(TimeSheet.OverTimeHours, CommonConstants.OverTimeHours, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Insert_EmployeeTimeSheet);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.TimesheetId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }


                    //ts.Complete();
                    return MessagesObj;
                }
                catch (Exception ex)
                {
                    MessagesObj.Result = 0;
                    MessagesObj.Message = ex.Message;
                    MessagesObj.ErrorSeverity = ex.Message;
                    MessagesObj.ErrorState = ex.Message;

                    return MessagesObj;
                    throw new ArgumentException("Exception in Insert_EmployeeTimesheet. Exception :" + ex.Message);
                }
            }

            // }
        }

        public static CommonMessages Update_EmployeeTimeSheet(TimeSheetMDL TimeSheet)
        {

            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                //using (TransactionScope ts = new TransactionScope())
                //{
                CommonMessages MessagesObj = new CommonMessages();
                try
                {
                    cmd.AddParameters(TimeSheet.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(TimeSheet.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(TimeSheet.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(TimeSheet.ProjectId, CommonConstants.ProjectsId, SqlDbType.BigInt);
                    cmd.AddParameters(TimeSheet.Date, CommonConstants.Date, SqlDbType.DateTime);
                    cmd.AddParameters(TimeSheet.Description, CommonConstants.Description, SqlDbType.VarChar);
                    cmd.AddParameters(TimeSheet.RegularHours, CommonConstants.RegularHours, SqlDbType.SmallInt);
                    cmd.AddParameters(TimeSheet.OverTimeHours, CommonConstants.OverTimeHours, SqlDbType.SmallInt);
                    cmd.AddParameters(TimeSheet.TimeSheetId, CommonConstants.TimeSheetId, SqlDbType.BigInt);
                    cmd.AddParameters(TimeSheet.TimesheetstatusId, CommonConstants.TimesheetstatusId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeeTimeSheet);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.TimesheetId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }


                    //ts.Complete();
                    return MessagesObj;
                }
                catch (Exception ex)
                {
                    MessagesObj.Result = 0;
                    MessagesObj.Message = ex.Message;
                    MessagesObj.ErrorSeverity = ex.Message;
                    MessagesObj.ErrorState = ex.Message;

                    return MessagesObj;
                    throw new ArgumentException("Exception in Update_EmployeeTimesheet. Exception :" + ex.Message);
                }
            }

            // }
        }


        public static CommonMessages Delete_EmployeeTimeSheet(TimeSheetMDL TimeSheet)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                CommonMessages MessagesObj = new CommonMessages();

                try
                {
                    cmd.AddParameters(TimeSheet.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(TimeSheet.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(TimeSheet.TimeSheetId, CommonConstants.TimeSheetId, SqlDbType.BigInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Delete_EmployeeTimeSheet);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.TimesheetId),
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
                    throw new ArgumentException("Exception in Delete_EmployeeTimesheet. Exception :" + ex.Message);
                }
            }

        }


        #endregion TimeSheet

        #region Vacation Schedule

        public static List<VacationMDL> Get_EmployeeVacation(VacationMDL Vacation)
        {
            List<VacationMDL> GetEmpVacations = new List<VacationMDL>();
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                try
                {
                    cmd.AddParameters(Vacation.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(Vacation.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(Vacation.ToDate, CommonConstants.ToDate, SqlDbType.Date);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeVacation);

                    while (ireader.Read())
                    {
                        var EmpVacation = new VacationMDL
                        {
                            SNo = ireader.GetInt32(CommonColumns.SNo),
                            LeaveId = ireader.GetInt32(CommonColumns.LeaveId),
                            UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            FromDate = ireader.GetDateTime(CommonColumns.FromDate),
                            ToDate = ireader.GetDateTime(CommonColumns.ToDate),
                            LeaveStatusId = ireader.GetInt32(CommonColumns.LeaveStatusId),
                            LeaveStatus = ireader.GetString(CommonColumns.LeaveStatus),
                            NoOfDays = ireader.GetInt32(CommonColumns.Days),
                            EmployeeName = ireader.GetString(CommonColumns.EmployeeName)
                        };
                        GetEmpVacations.Add(EmpVacation);
                    }

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception in Get_EmployeeVacation. Exception :" + ex.Message);
                }

            }
            return GetEmpVacations;
        }

        public static CommonMessages Insert_EmployeeVacation(VacationMDL Vacation)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                //using (TransactionScope ts = new TransactionScope())
                //{
                CommonMessages MessagesObj = new CommonMessages();
                try
                {
                    cmd.AddParameters(Vacation.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(Vacation.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(Vacation.ToDate, CommonConstants.ToDate, SqlDbType.Date);
                    cmd.AddParameters(Vacation.LeaveStatusId, CommonConstants.LeaveStatusId, SqlDbType.SmallInt);
                    cmd.AddParameters(Vacation.NoOfDays, CommonConstants.Days, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Insert_EmployeeVacation);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.LeaveId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }


                    //ts.Complete();
                    return MessagesObj;
                }
                catch (Exception ex)
                {
                    MessagesObj.Result = 0;
                    MessagesObj.Message = ex.Message;
                    MessagesObj.ErrorSeverity = ex.Message;
                    MessagesObj.ErrorState = ex.Message;

                    return MessagesObj;
                    throw new ArgumentException("Exception in Insert_EmployeeVacation. Exception :" + ex.Message);
                }
            }

            //}
        }


        public static CommonMessages Update_EmployeeVacation(VacationMDL Vacation)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                //using (TransactionScope ts = new TransactionScope())
                //{
                CommonMessages MessagesObj = new CommonMessages();
                try
                {
                    cmd.AddParameters(Vacation.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(Vacation.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(Vacation.ToDate, CommonConstants.ToDate, SqlDbType.Date);
                    cmd.AddParameters(Vacation.LeaveStatusId, CommonConstants.LeaveStatusId, SqlDbType.Int);
                    cmd.AddParameters(Vacation.LeaveId, CommonConstants.LeaveId, SqlDbType.Int);
                    cmd.AddParameters(Vacation.NoOfDays, CommonConstants.Days, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeeVacation);
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


                    //ts.Complete();
                    return MessagesObj;
                }
                catch (Exception ex)
                {
                    MessagesObj.Result = 0;
                    MessagesObj.Message = ex.Message;
                    MessagesObj.ErrorSeverity = ex.Message;
                    MessagesObj.ErrorState = ex.Message;

                    return MessagesObj;
                    throw new ArgumentException("Exception in Update_EmployeeVacationDetails. Exception :" + ex.Message);
                }
            }

            // }
        }



        public static CommonMessages Delete_EmployeeVacation(VacationMDL Vacation)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                CommonMessages MessagesObj = new CommonMessages();
                try
                {
                    cmd.AddParameters(Vacation.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(Vacation.LeaveId, CommonConstants.LeaveId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Delete_EmployeeVacation);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.LeaveId),
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
                    throw new ArgumentException("Exception in Delete_EmployeeVacation. Exception :" + ex.Message);
                }
            }

        }



        public static List<VacationMDL> GetVacationsDD()
        {
            List<VacationMDL> GetVacations = new List<VacationMDL>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeVacationsStatus);
                    while (ireader.Read())
                    {
                        var Vacation = new VacationMDL
                        {
                            LeaveStatus = ireader.GetString(CommonColumns.LeaveStatus),
                            LeaveStatusId = ireader.GetInt32(CommonColumns.LeaveStatusId),

                        };
                        GetVacations.Add(Vacation);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in GetVacationsDD. Exception :" + ex.Message);
            }
            return GetVacations;
        }

        public static CommonMessages Update_EmployeeVacationStatus(VacationMDL Vacation)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                CommonMessages MessagesObj = new CommonMessages();
                try
                {
                    cmd.AddParameters(Vacation.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(Vacation.LeaveId, CommonConstants.LeaveId, SqlDbType.BigInt);
                    cmd.AddParameters(Vacation.LeaveStatusId, CommonConstants.LeaveStatusId, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeeVacationStatus);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.LeaveId),
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
                    throw new ArgumentException("Exception in Update_EmployeeVacationStatus. Exception :" + ex.Message);
                }
            }

        }

        #endregion Vacation Schedule

        #region Payroll

        public static List<PayrollMDL> Get_EmployeePayrolls(PayrollMDL Payroll)
        {
            List<PayrollMDL> GetEmpPayrolls = new List<PayrollMDL>();
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                try
                {
                    cmd.AddParameters(Payroll.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Payroll.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Payroll.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(Payroll.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(Payroll.ToDate, CommonConstants.ToDate, SqlDbType.Date);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeePayrolls);

                    while (ireader.Read())
                    {
                        var EmpPayroll = new PayrollMDL
                        {
                            RegularHours = ireader.GetInt32(CommonColumns.RegularHours),
                            OverTimeHours = ireader.GetInt32(CommonColumns.OverTimeHours),
                            Amount = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.Amount)),
                            Status = ireader.GetString(CommonColumns.Status),
                            StatusId = ireader.GetInt32(CommonColumns.StatusId),
                            EmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                            BankAccountsId = ireader.GetInt32(CommonColumns.BankAccountsId),
                            EmployeePayrollId = ireader.GetInt32(CommonColumns.EmployeePayRollId),
                            UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                            FromDate = ireader.GetDateTime(CommonColumns.FromDate),
                            ToDate = ireader.GetDateTime(CommonColumns.ToDate),
                            BankName = ireader.GetString(CommonColumns.BankName)
                        };
                        GetEmpPayrolls.Add(EmpPayroll);
                    }

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception in Get_EmployeePayrolls. Exception :" + ex.Message);
                }

            }
            return GetEmpPayrolls;
        }


        public static CommonMessages Insert_EmployeePayroll(PayrollMDL Payroll)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                CommonMessages MessagesObj = new CommonMessages();
                //using (TransactionScope ts = new TransactionScope())
                //{
                try
                {
                    cmd.AddParameters(Payroll.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Payroll.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Payroll.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(Payroll.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(Payroll.ToDate, CommonConstants.ToDate, SqlDbType.Date);
                    cmd.AddParameters(Payroll.RegularHours, CommonColumns.RegularHours, SqlDbType.SmallInt);
                    cmd.AddParameters(Payroll.OverTimeHours, CommonColumns.OverTimeHours, SqlDbType.SmallInt);
                    cmd.AddParameters(Payroll.Amount, CommonColumns.Amount, SqlDbType.Money);
                    cmd.AddParameters(Payroll.StatusId, CommonColumns.StatusId, SqlDbType.SmallInt);
                    cmd.AddParameters(Payroll.BankAccountsId, CommonColumns.BankAccountsId, SqlDbType.BigInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Insert_EmployeePayroll);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.EmployeePayRollId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }
                    //ts.Complete();
                    return MessagesObj;
                }
                catch (Exception ex)
                {
                    MessagesObj.Result = 0;
                    MessagesObj.Message = ex.Message;
                    MessagesObj.ErrorSeverity = ex.Message;
                    MessagesObj.ErrorState = ex.Message;

                    return MessagesObj;
                    throw new ArgumentException("Exception in InsertEmployeePayroll. Exception :" + ex.Message);
                }
            }

            //}
        }



        public static CommonMessages Update_EmployeePayroll(PayrollMDL Payroll)
        {
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(Payroll.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Payroll.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Payroll.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(Payroll.RegularHours, CommonConstants.RegularHours, SqlDbType.Int);
                    cmd.AddParameters(Payroll.OverTimeHours, CommonConstants.OverTimeHours, SqlDbType.Int);
                    cmd.AddParameters(Payroll.Amount, CommonConstants.Amount, SqlDbType.Money);
                    cmd.AddParameters(Payroll.StatusId, CommonColumns.StatusId, SqlDbType.SmallInt);
                    cmd.AddParameters(Payroll.BankAccountsId, CommonColumns.BankAccountsId, SqlDbType.BigInt);
                    cmd.AddParameters(Payroll.EmployeePayrollId, CommonColumns.EmployeePayRollId, SqlDbType.VarChar);
                    cmd.AddParameters(Payroll.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(Payroll.ToDate, CommonConstants.ToDate, SqlDbType.Date);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeePayroll);
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
            }

            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in Update_EmployeePayroll. Exception :" + ex.Message);
            }
        }







        public static CommonMessages Delete_EmployeePayroll(PayrollMDL Payroll)
        {
            CommonMessages MessagesObj = new CommonMessages();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    cmd.AddParameters(Payroll.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Payroll.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Payroll.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(Payroll.EmployeePayrollId, CommonConstants.EmployeePayrollId, SqlDbType.BigInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Delete_EmployeePayroll);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.EmployeePayRollId),
                            ErrorSeverity = ireader.GetString(CommonColumns.ErrorSeverity),
                            ErrorState = ireader.GetString(CommonColumns.ErrorState)
                        };

                        MessagesObj = EmpDet;
                    }

                    return MessagesObj;
                }
            }

            catch (Exception ex)
            {
                MessagesObj.Result = 0;
                MessagesObj.Message = ex.Message;
                MessagesObj.ErrorSeverity = ex.Message;
                MessagesObj.ErrorState = ex.Message;

                return MessagesObj;
                throw new ArgumentException("Exception in Delete_EmployeePayroll. Exception :" + ex.Message);
            }
        }

        public static CommonMessages Update_EmployeePayrollStatus(PayrollMDL Payroll)
        {
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                CommonMessages MessagesObj = new CommonMessages();
                try
                {

                    cmd.AddParameters(Payroll.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Payroll.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Payroll.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.BigInt);
                    cmd.AddParameters(Payroll.EmployeePayrollId, CommonConstants.EmployeePayrollId, SqlDbType.BigInt);
                    cmd.AddParameters(Payroll.StatusId, CommonConstants.StatusId, SqlDbType.SmallInt);
                    cmd.AddParameters(Payroll.BankAccountsId, CommonConstants.BankAccountsId, SqlDbType.BigInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Update_EmployeePayrollStatus);
                    while (ireader.Read())
                    {
                        var EmpDet = new CommonMessages
                        {
                            Message = ireader.GetString(CommonColumns.ErrorMessage),
                            Result = ireader.GetInt32(CommonColumns.EmployeePayRollId),
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
                    throw new ArgumentException("Exception in Update_EmployeePayrollStatus. Exception :" + ex.Message);
                }
            }
        }

        #endregion Payroll

        #region EmployeeDropDowns

        public static IList<KeyValueVM> Get_Genders(int UserId)
        {
            List<KeyValueVM> GetGenders = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_Genders);
                    while (ireader.Read())
                    {
                        var Gender = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.Gender),
                            key = ireader.GetInt32(CommonColumns.GenderId),

                        };
                        GetGenders.Add(Gender);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_Genders. Exception :" + ex.Message);
            }
            return GetGenders;
        }

        public static IList<KeyValueVM> Get_EmplyeeStatus(int UserId)
        {
            List<KeyValueVM> EmpStatusList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmplyeeStatus);
                    while (ireader.Read())
                    {
                        var EmpStatus = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.EmployeeStatus),
                            key = ireader.GetInt32(CommonColumns.EmployeeStatusId),

                        };
                        EmpStatusList.Add(EmpStatus);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmplyeeStatus. Exception :" + ex.Message);
            }
            return EmpStatusList;
        }

        public static IList<KeyValueVM> Get_EmploymentMode(int UserId)
        {
            List<KeyValueVM> EmpModeList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmploymentMode);
                    while (ireader.Read())
                    {
                        var EmpMode = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.EmploymentMode),
                            key = ireader.GetInt32(CommonColumns.EmploymentModeId)

                        };
                        EmpModeList.Add(EmpMode);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmploymentMode. Exception :" + ex.Message);
            }
            return EmpModeList;
        }

        public static IList<KeyValueVM> Get_EmployeePayFrequecy(int UserId)
        {
            List<KeyValueVM> EmpPayFreqList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeePayFrequecy);
                    while (ireader.Read())
                    {
                        var EmpPayFreq = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.PayFrequecy),
                            key = ireader.GetInt32(CommonColumns.PayFrequecyId),

                        };
                        EmpPayFreqList.Add(EmpPayFreq);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmployeePayFrequecy. Exception :" + ex.Message);
            }
            return EmpPayFreqList;
        }

        public static IList<KeyValueVM> Get_EmployeePaymentTypes(int UserId)
        {
            List<KeyValueVM> EmpPaymentTypeList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(0, CommonConstants.IsInvoice, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_PaymentTypes);
                    while (ireader.Read())
                    {
                        var EmpPaymentType = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.PaymentDesc),
                            key = ireader.GetInt32(CommonColumns.PaymentTypesId),

                        };
                        EmpPaymentTypeList.Add(EmpPaymentType);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmployeePayFrequecy. Exception :" + ex.Message);
            }
            return EmpPaymentTypeList;
        }


        public static IList<KeyValueVM> Get_HumanRelations()
        {
            List<KeyValueVM> HumanRelationsList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_HumanRelations);
                    while (ireader.Read())
                    {
                        var HumanRelation = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.Relation),
                            key = ireader.GetInt32(CommonColumns.RelationId),

                        };
                        HumanRelationsList.Add(HumanRelation);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_HumanRelations. Exception :" + ex.Message);
            }
            return HumanRelationsList;
        }


        public static IList<KeyValueVM> Get_EmpDesignations()
        {
            List<KeyValueVM> EmpDesignationList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.GetEmployeeDesignations);
                    while (ireader.Read())
                    {
                        var EmpDesignation = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.EmployeeDesignationName),
                            key = ireader.GetInt32(CommonColumns.EmployeeDesignationID),

                        };
                        EmpDesignationList.Add(EmpDesignation);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmpDesignations. Exception :" + ex.Message);
            }
            return EmpDesignationList;
        }

        public static IList<KeyValueVM> Get_EmpLocations()
        {
            List<KeyValueVM> EmpDesignationList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_Locations);
                    while (ireader.Read())
                    {
                        var EmpDesignation = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.LocationName),
                            key = ireader.GetInt32(CommonColumns.LocationId),

                        };
                        EmpDesignationList.Add(EmpDesignation);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmpDesignations. Exception :" + ex.Message);
            }
            return EmpDesignationList;
        }

        public static IList<KeyValueVM> Get_EmpAssets()
        {
            List<KeyValueVM> EmpAssetList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmpAssets);
                    while (ireader.Read())
                    {
                        var EmpAsset = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.AssetName),
                            key = ireader.GetInt32(CommonColumns.AssetId),

                        };
                        EmpAssetList.Add(EmpAsset);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmpAssets. Exception :" + ex.Message);
            }
            return EmpAssetList;
        }

        public static IList<KeyValueVM> Get_EmpRoles()
        {
            List<KeyValueVM> EmpRoleList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmpRoles);
                    while (ireader.Read())
                    {
                        var EmpRoles = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.UserRoles),
                            key = ireader.GetInt32(CommonColumns.UserRolesId),

                        };
                        EmpRoleList.Add(EmpRoles);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmpRoles. Exception :" + ex.Message);
            }
            return EmpRoleList;
        }

        public static IList<KeyValueVM> Get_EmployeePayrollStatus(int BusinessId, int UserId)
        {
            List<KeyValueVM> PayrollStatusList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeePayrollStatus);
                    while (ireader.Read())
                    {
                        var PayrollStatus = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.Status),
                            key = ireader.GetInt32(CommonColumns.StatusId)

                        };
                        PayrollStatusList.Add(PayrollStatus);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmployeePayrollStatus. Exception :" + ex.Message);
            }
            return PayrollStatusList;
        }

        public static IList<TimeSheetMDL> GetEmployeeWeeklyTimeSheet()
        {
            List<TimeSheetMDL> WeekDaysList = new List<TimeSheetMDL>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeTimeSheetWeekDates);
                    while (ireader.Read())
                    {
                        var WeekDays = new TimeSheetMDL
                        {
                            ShowDay = ireader.GetString(CommonColumns.ShowDay),
                            WeekStartDay = ireader.GetString(CommonColumns.WeekStartDay),
                            WeekEndDay = ireader.GetString(CommonColumns.WeekEndDay)
                        };
                        WeekDaysList.Add(WeekDays);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmployeePayrollStatus. Exception :" + ex.Message);
            }
            return WeekDaysList;
        }

        public static IList<TimeSheetMDL> Get_EmployeeTimeSheetDates(string Fromdate)
        {
            List<TimeSheetMDL> WeekDaysList = new List<TimeSheetMDL>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(Fromdate, CommonConstants.FromDate, SqlDbType.Date);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeTimeSheetDates);
                    while (ireader.Read())
                    {
                        var WeekDays = new TimeSheetMDL
                        {
                            AllDates = ireader.GetString(CommonColumns.Dates),
                            AllDays = ireader.GetString(CommonColumns.Days)

                        };
                        WeekDaysList.Add(WeekDays);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_EmployeePayrollStatus. Exception :" + ex.Message);
            }
            return WeekDaysList;
        }

        #endregion EmployeeDropDowns

        #region EmployeeCommonMethods

        public static List<EmployeeListMDL> Get_EmpAutoFiling(int BusinessId, int UserId, string keyword)
        {
            var EmpNamesList = new List<EmployeeListMDL>();
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.BigInt);
                    cmd.AddParameters(keyword, CommonConstants.Keyword, SqlDbType.VarChar);

                    var ireader = cmd.ExecuteDataReader(SqlProcedures.Get_PaymentsPaidBy);

                    while (ireader.Read())
                    {
                        var EmpName = new EmployeeListMDL
                        {
                            UserEmployeeId = ireader.GetInt16(CommonColumns.PaidById),
                            FullName = ireader.GetString(CommonColumns.PaidBy),
                            DOB = DateTime.Now
                        };
                        EmpNamesList.Add(EmpName);
                    }
                    return EmpNamesList;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_EmpAutoFiling. Exception :" + ex.Message);
                }
            }
        }

        public static IList<KeyValueVM> Get_ProjectAutoFiling(int BusinessId, int UserId, string keyword, BusinessItemsTypes businessItemsTypes)
        {
            List<KeyValueVM> ProjectNamesList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Convert.ToInt16(businessItemsTypes), CommonConstants.ItemTypeId, SqlDbType.Int);
                    cmd.AddParameters(keyword, CommonConstants.Keyword, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_BusinessItems);
                    while (ireader.Read())
                    {
                        var ProjectName = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.Title),
                            longkey = ireader.GetInt64(CommonColumns.ItemId)

                        };
                        ProjectNamesList.Add(ProjectName);
                    }
                    return ProjectNamesList;
                }

            }
            catch (Exception ex)
            {
                return null;
                throw new ArgumentException("Exception in Get_ProjectAutoFiling. Exception :" + ex.Message);
            }

        }

        public static IList<KeyValueVM> Get_UserBankAutoFiling(int BusinessId, int UserId, string keyword)
        {
            List<KeyValueVM> BanksList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(keyword, CommonConstants.Keyword, SqlDbType.VarChar);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeePayrollBanks);
                    while (ireader.Read())
                    {
                        var Bank = new KeyValueVM
                        {
                            value = ireader.GetString("Bank"),
                            longkey = ireader.GetInt64(CommonColumns.BankAccountsId)

                        };
                        BanksList.Add(Bank);
                    }
                    return BanksList;
                }

            }
            catch (Exception ex)
            {
                return null;
                throw new ArgumentException("Exception in Get_UserBankAutoFiling. Exception :" + ex.Message);
            }

        }

        public static VacationMDL Get_EmployeePTOFields(int BusinessId, int UserId, int UserEmployeeId)
        {
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                    var EmpPTOFields = new VacationMDL();

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeePTOFields);
                    while (ireader.Read())
                    {
                        var PTOFields = new VacationMDL
                        {
                            PTOAvailable = ireader.GetInt32(CommonColumns.PTOAvailable),
                            PTOUsed = ireader.GetInt32(CommonColumns.PTOUsed),
                            PTORemaining = ireader.GetInt32(CommonColumns.PTORemaining),
                            PTOPlannedOrApproved = ireader.GetInt32(CommonColumns.PTOPlannedOrApproved)

                        };

                        EmpPTOFields = PTOFields;
                    }
                    return EmpPTOFields;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_EmployeePTOFields. Exception :" + ex.Message);
                }
            }
        }


        public static PayrollMDL Get_EmployeeNextPayrollDates(int BusinessId, int UserId, int UserEmployeeId)
        {
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                    var EmpPayrollDates = new PayrollMDL();

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_EmployeeNextPayrollDates);
                    while (ireader.Read())
                    {
                        var PayrollDates = new PayrollMDL
                        {
                            PayFromDate = ireader.GetString(CommonColumns.FromDate),
                            PayToDate = ireader.GetString(CommonColumns.ToDate)
                        };

                        EmpPayrollDates = PayrollDates;
                    }
                    return EmpPayrollDates;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_EmployeeNextPayrollDates. Exception :" + ex.Message);
                }
            }
        }

        public static List<PayrollMDL> CheckExists_EmployeePayrolls(PayrollMDL PayRoll)
        {
            var EmpPayrollsList = new List<PayrollMDL>();

            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(PayRoll.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(PayRoll.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(PayRoll.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(PayRoll.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(PayRoll.ToDate, CommonConstants.ToDate, SqlDbType.Date);
                    cmd.AddParameters(PayRoll.EmployeePayrollId, CommonConstants.EmployeePayrollId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.CheckExists_EmployeePayrolls);
                    while (ireader.Read())
                    {
                        var EmpPayroll = new PayrollMDL
                        {
                            FromDate = ireader.GetDateTime(CommonColumns.FromDate),
                            ToDate = ireader.GetDateTime(CommonColumns.ToDate),
                            Status = ireader.GetString(CommonColumns.Status)
                        };

                        EmpPayrollsList.Add(EmpPayroll);
                    }

                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in CheckExists_EmployeePayrolls. Exception :" + ex.Message);
                }
            }

            return EmpPayrollsList;
        }

        public static bool CheckExists_EmployeeTimesheet(TimeSheetMDL TimeSheet)
        {
            var Result = false;
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                cmd.AddParameters(TimeSheet.UserId, CommonConstants.UserId, SqlDbType.Int);
                cmd.AddParameters(TimeSheet.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                cmd.AddParameters(TimeSheet.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.VarChar);
                if (TimeSheet.IsTimeSheet)
                {
                    cmd.AddParameters(TimeSheet.Date, CommonConstants.Date, SqlDbType.Date);
                }
                else
                {
                    cmd.AddParameters(TimeSheet.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(TimeSheet.ToDate, CommonConstants.ToDate, SqlDbType.Date);
                }
                cmd.AddParameters(TimeSheet.TimeSheetId, CommonConstants.TimeSheetId, SqlDbType.Int);

                int Res = (int)cmd.ExecuteScalar(SqlProcedures.CheckExists_EmployeeTimesheet);
                if (Res == 1)
                    Result = false;
                else
                    Result = true;

            }
            return Result;
        }

        public static List<VacationMDL> CheckExists_EmployeeVacation(VacationMDL Vacation)
        {
            var EmpVacations = new List<VacationMDL>();

            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(Vacation.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(Vacation.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Vacation.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(Vacation.FromDate, CommonConstants.FromDate, SqlDbType.Date);
                    cmd.AddParameters(Vacation.ToDate, CommonConstants.ToDate, SqlDbType.Date);
                    cmd.AddParameters(Vacation.LeaveId, CommonConstants.LeaveId, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.CheckExists_EmployeeVacation);
                    while (ireader.Read())
                    {
                        var Vacations = new VacationMDL
                        {
                            FromDate = ireader.GetDateTime(CommonColumns.FromDate),
                            ToDate = ireader.GetDateTime(CommonColumns.ToDate),
                            Status = ireader.GetString(CommonColumns.Status)
                        };

                        EmpVacations.Add(Vacations);
                    }

                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in CheckExists_EmployeeVacation. Exception :" + ex.Message);
                }
            }

            return EmpVacations;
        }


        public static List<EmployeeListMDL> Get_EmpAutoText(EmployeeListMDL AddEmployee)
        {
            var EmpNamesList = new List<EmployeeListMDL>();
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(AddEmployee.BusinessID, CommonConstants.BusinessID, SqlDbType.Int);
                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.GetEmployeeNames);

                    while (ireader.Read())
                    {
                        var EmpName = new EmployeeListMDL
                        {
                            UserEmployeeId = ireader.GetInt16(CommonColumns.EmployeeId),
                            DisplayName = ireader.GetString(CommonColumns.DisplayName)
                        };
                        EmpNamesList.Add(EmpName);
                    }
                    return EmpNamesList;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Get_EmpAutoText. Exception :" + ex.Message);
                }
            }
        }

        #endregion EmployeeCommonMethods

        #region Designation
        public static CommonMessages SaveEmpDesignation(Designation _Designation)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {

                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(0, CommonConstants.EmployeeDesignationID, SqlDbType.Int);
                    cmd.AddParameters(_Designation.EmployeeDesignationName, CommonConstants.EmployeeDesignationName, SqlDbType.NVarChar);
                    cmd.AddParameters(_Designation.LoggInUserId, CommonConstants.LoggInUserId, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Upsert_EmployeeDesination);
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
                }

                //ts.Complete();
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
            // }

        }

        public static CommonMessages UpdateEmpDesignation(UpdateDesignation _Designation)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {

                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(_Designation.EmployeeDesignationID, CommonConstants.EmployeeDesignationID, SqlDbType.Int);
                    cmd.AddParameters(_Designation.EmployeeDesignationName, CommonConstants.EmployeeDesignationName, SqlDbType.NVarChar);
                    cmd.AddParameters(_Designation.LoggInUserId, CommonConstants.LoggInUserId, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Upsert_EmployeeDesination);
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
                }

                //ts.Complete();
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
            // }

        }

        public static CommonMessages DeleteEmpDesignation(DeleteDesignation _Designation)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {

                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(_Designation.EmployeeDesignationID, CommonConstants.EmployeeDesignationID, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Delete_EmployeeDesination);
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
                }

                //ts.Complete();
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
            //}

        }

        public static List<Designation> Get_DesignationList(int EmployeeDesignationID)
        {
            List<Designation> DesignationList = new List<Designation>();
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                try
                {
                    cmd.AddParameters(EmployeeDesignationID, CommonConstants.EmployeeDesignationID, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_DesigntionList);

                    while (ireader.Read())
                    {
                        var EmpDesignation = new Designation
                        {
                            EmployeeDesignationID = ireader.GetInt32(CommonColumns.EmployeeDesignationID),
                            EmployeeDesignationName = ireader.GetString(CommonColumns.EmployeeDesignationName)

                        };
                        DesignationList.Add(EmpDesignation);
                    }

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception in GetEmployeesList. Exception :" + ex.Message);
                }

                return DesignationList;
            }
        }


        #endregion Designation

        #region Resignation

        public static List<ExitResignation> Get_EmpResignationList(ExitResignation Data)
        {
            List<ExitResignation> GetExitResignation = new List<ExitResignation>();
            using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
            {
                try
                {
                    if (Data.RoleId == 3 || Data.RoleId == 4 || Data.RoleId == 5)
                    {
                        cmd.AddParameters(Data.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                        cmd.AddParameters(0, CommonConstants.UserEmployeeId, SqlDbType.Int);
                        cmd.AddParameters(Data.UserId, CommonConstants.UserId, SqlDbType.Int);


                        IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.usp_GetResignationDetails);

                        while (ireader.Read())
                        {
                            var EmpResign = new ExitResignation
                            {
                                UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                                EmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                                ResignationDate = ireader.GetDateTime(CommonColumns.ResignationDate).Date,
                                RepEmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                                ReportManagerTo = ireader.GetString(CommonColumns.ReportManagerTo),
                                ResignationStatus = ireader.GetString(CommonColumns.ResignationStatus),
                                LastWorkingDate = ireader.GetDateTime(CommonColumns.LastWorkingDate)
                            };
                            GetExitResignation.Add(EmpResign);
                        }
                    }
                    else
                    {
                        cmd.AddParameters(Data.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                        cmd.AddParameters(Data.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                        cmd.AddParameters(Data.UserId, CommonConstants.UserId, SqlDbType.Int);


                        IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.usp_GetResignationDetails);

                        while (ireader.Read())
                        {
                            var EmpResign = new ExitResignation
                            {
                                UserEmployeeId = ireader.GetInt32(CommonColumns.UserEmployeeId),
                                EmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                                ResignationDate = ireader.GetDateTime(CommonColumns.ResignationDate).Date,
                                RepEmployeeName = ireader.GetString(CommonColumns.EmployeeName),
                                ReportManagerTo = ireader.GetString(CommonColumns.ReportManagerTo),
                                ResignationStatus = ireader.GetString(CommonColumns.ResignationStatus),
                                LastWorkingDate = ireader.GetDateTime(CommonColumns.LastWorkingDate)
                            };
                            GetExitResignation.Add(EmpResign);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception in Get_EmpResignationList. Exception :" + ex.Message);
                }

            }
            return GetExitResignation;
        }

        public static CommonMessages SaveEmpResignDetails(ExitResignation _Resignation)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
            CommonMessages MessagesObj = new CommonMessages();
            try
            {

                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {
                    cmd.AddParameters(_Resignation.BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(_Resignation.UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);
                    cmd.AddParameters(_Resignation.UserId, CommonConstants.UserId, SqlDbType.Int);
                    cmd.AddParameters(_Resignation.Date, CommonConstants.Date, SqlDbType.DateTime);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.usp_ApplyForResignation);
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
                }

                //ts.Complete();
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
            // }

        }
        #endregion Resignation



    }
}
