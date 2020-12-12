using EMS.BAL;
using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration;
//using EMS.Root;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.IO;
using System.Web.UI;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.Common;


namespace EMS.Controllers
{
    public class EmployeesController : Controller
    {
        private int _userId;
        private int _useremployeeId;
        private string _userName;
        private int _businessId;
        private int _roleId;
        private string _dateFormat = "MM/dd/yyyy";
        private string _noFormat = "(2222.00)";
        private string _currency = "en-US";
        private string _yearEnd = "December-31";
        private string _Country = "";
        private string _State = "";
        private string _CustomersRename = "";
        private string _AccountClosingDate = "";
        private int _StateId;
        private int _CountryId;
        private int _GroupNameId;
        private int _ModuleId;
        private EMS.BAL.LoggedUser loggedUser = null;

        #region CommonMethods


        public ActionResult SessionExpires()
        {
            return RedirectToAction("Logout", "Home");
        }


        public int UserId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _userId = loggedUser.UserId; //db.Users.First<User>(user => user.Email.Equals(User.Identity.Name));
                    //_userId = logedUser.UserId;
                    return _userId;
                }
                else
                {
                    SessionExpires();
                    return 0;
                }

            }
        }
        public int RoleId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _roleId = loggedUser.RoleId;
                    return _roleId;
                }
                else
                {
                    SessionExpires();
                    return 0;
                }
            }
        }
        public string UserName
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _userName = loggedUser.UserName;
                    return _userName;
                }
                else
                {
                    SessionExpires();
                    return "";
                }
            }

        }
        public int UserSessionEmployeeId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _useremployeeId = loggedUser.UserSessionEmployeeId;
                    return _useremployeeId;
                }
                else
                {
                    SessionExpires();
                    return 0;
                }
            }
        }

        public string Country
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _Country = loggedUser.Country;
                    return _Country;
                }
                else
                {
                    SessionExpires();
                    return "";
                }

            }
            set
            {
                if (Session["userInfo"] != null)
                {
                    _Country = value;
                    ((EMS.BAL.LoggedUser)Session["userInfo"]).Country = _Country;
                    loggedUser.Country = _Country;
                }
            }
        }

        public string CustomersRename
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _CustomersRename = loggedUser.CustomersRename;
                    return _CustomersRename;
                }
                else
                {
                    SessionExpires();
                    return "";
                }

            }
            set
            {
                if (Session["userInfo"] != null)
                {
                    _CustomersRename = value;
                    ((EMS.BAL.LoggedUser)Session["userInfo"]).CustomersRename = _CustomersRename;
                    loggedUser.CustomersRename = _CustomersRename;
                }
            }
        }

        public int CountryId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _CountryId = loggedUser.CountryId;
                    return _CountryId;
                }
                else
                {
                    SessionExpires();
                    return 0;
                }

            }
            set
            {
                if (Session["userInfo"] != null)
                {
                    _CountryId = value;
                    ((EMS.BAL.LoggedUser)Session["userInfo"]).CountryId = _CountryId;
                    loggedUser.CountryId = _CountryId;
                }
            }
        }
        public string State
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _State = loggedUser.State;
                    return _State;
                }
                else
                {
                    SessionExpires();
                    return "";
                }
            }
            set
            {
                if (Session["userInfo"] != null)
                {
                    _State = value;
                    ((EMS.BAL.LoggedUser)Session["userInfo"]).State = _State;
                    loggedUser.Country = _State;
                }
            }
        }

        public int StateId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _StateId = loggedUser.StateId;
                    return _StateId;
                }
                else
                {
                    SessionExpires();
                    return 0;
                }
            }
            set
            {
                if (Session["userInfo"] != null)
                {
                    _StateId = value;
                    ((EMS.BAL.LoggedUser)Session["userInfo"]).StateId = _StateId;
                    loggedUser.StateId = _StateId;
                }
            }
        }
        public int BusinessId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _businessId = loggedUser.BusinessId; //db.Users.First<User>(user => user.Email.Equals(User.Identity.Name));
                    //_userId = logedUser.UserId;
                    return _businessId;
                }
                else
                {
                    SessionExpires();
                    return 0;
                }

            }
        }
        public int GroupId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _GroupNameId = loggedUser.GroupId;
                    return _GroupNameId;
                }
                else
                {
                    SessionExpires();
                    return 0;
                }
            }
        }

        public string PreferredDt
        {
            get
            {
                if (HttpRuntime.Cache["DateFormat"] != null)
                {
                    ViewBag.PreferenceDt = HttpRuntime.Cache["DateFormat"].ToString();
                    return HttpRuntime.Cache["DateFormat"].ToString();
                }
                return _dateFormat;
            }
        }

        public string PreferredNo
        {
            get
            {
                if (HttpRuntime.Cache["NumberFormat"] != null)
                    return HttpRuntime.Cache["NumberFormat"].ToString();
                return _noFormat;
            }
        }

        public string PreferredCurrency
        {
            get
            {
                //
                if (HttpRuntime.Cache["PrimaryCurrency"] != null)
                    return HttpRuntime.Cache["PrimaryCurrency"].ToString();
                return _currency;
            }
        }
        public string FiscalYearFormat
        {
            get
            {
                if (HttpRuntime.Cache["FiscalYearFormat"] != null)
                    return HttpRuntime.Cache["FiscalYearFormat"].ToString();
                return _yearEnd;
            }

        }

        public int ModuleId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _ModuleId = loggedUser.ModuleId;
                    return _ModuleId;
                }
                else
                {
                    SessionExpires();
                    return 0;
                }
            }
        }


        public String GetCustomersRename()
        {

            return CustomersRename;
        }

        public string AccountClosingDate
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _AccountClosingDate = loggedUser.AccountClosingDate;
                    return _AccountClosingDate;
                }
                else
                {
                    SessionExpires();
                    return "";
                }
            }
            set
            {
                if (Session["userInfo"] != null)
                {
                    _AccountClosingDate = value;
                    ((EMS.BAL.LoggedUser)Session["userInfo"]).AccountClosingDate = _AccountClosingDate;
                    loggedUser.AccountClosingDate = _AccountClosingDate;
                }
            }
        }
        #endregion

        #region AddEmployee
        [OutputCache(Duration = 10)]
        public ActionResult AddEmployee()
        {
            try
            {
                var Result = BAL.ValidateScreens.CheckPermission(16, GroupId);
                if (Result == 1)
                {
                    AddEmployeeMDL AddEmployee = new AddEmployeeMDL();
                    AddEmployeeFamilyMDL AddEmployeeFamily = new AddEmployeeFamilyMDL();
                    AddEmployeeFamily.GenderList = EmployeesBAL.Get_Genders(UserId).ToList();
                    AddEmployeeFamily.RelationList = EmployeesBAL.Get_HumanRelations().ToList();

                    List<AddEmployeeFamilyMDL> AddEmployeeFamilyList = new List<AddEmployeeFamilyMDL>();
                    AddEmployeeFamilyList.Add(AddEmployeeFamily);
                    AddEmployee._listFamilyDetails = AddEmployeeFamilyList;

                    AddEmployee.DeductionInsEmpId = 1;
                    AddEmployee.DeductionInsEmplId = 2;
                    AddEmployee.PensionInsEmpId = 3;
                    AddEmployee.PensionInsEmplId = 4;

                    ViewBag.GenderList = new SelectList(EmployeesBAL.Get_Genders(UserId), "key", "value");
                    ViewBag.EmployeeStatusList = new SelectList(EmployeesBAL.Get_EmplyeeStatus(UserId), "key", "value");
                    ViewBag.EmployeeModeList = new SelectList(EmployeesBAL.Get_EmploymentMode(UserId), "key", "value");
                    ViewBag.PayFrequencyList = new SelectList(EmployeesBAL.Get_EmployeePayFrequecy(UserId), "key", "value");
                    ViewBag.PayMethodList = new SelectList(EmployeesBAL.Get_EmployeePaymentTypes(UserId), "key", "value");
                    ViewBag.HumanRelationList = new SelectList(EmployeesBAL.Get_HumanRelations(), "key", "value");
                    ViewBag.EmpDesignationList = new SelectList(EmployeesBAL.Get_EmpDesignations(), "key", "value", "--select--");
                    ViewBag.EmpLocationList = new SelectList(EmployeesBAL.Get_EmpLocations(), "key", "value", "--select--");
                    ViewBag.EmpAssetList = new SelectList(EmployeesBAL.Get_EmpAssets(), "key", "value", "--select--");
                    ViewBag.EmpRolesList = new SelectList(EmployeesBAL.Get_EmpRoles(), "key", "value", "--select--");
                    return View(AddEmployee);
                }
                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:AddEmployee");
                return null;
            }
            finally
            {

            }
        }

        [HttpPost]
        public ActionResult SavePersonalDetails(string AddEmployeeString)
        {
            var Result = false;
            try
            {
                AddEmployeeMDL AddEmployee = JsonConvert.DeserializeObject<AddEmployeeMDL>(AddEmployeeString);
                Result = EmployeesBAL.CheckExists_EmployeeNumber(AddEmployee.EmployeeNumber, BusinessId, null);
                if (Result)
                {
                    Result = EmployeesBAL.CheckExists_Employee(AddEmployee.FirstName, AddEmployee.LastName, BusinessId, null);
                    Result = true;
                    if (Result)
                    {
                        CommonMessages MessagesObj = new CommonMessages();
                        if (ModelState.IsValid)
                        {
                            AddEmployee.UserID = UserId;
                            AddEmployee.BusinessID = BusinessId;

                            MessagesObj = EmployeesBAL.SavePersonalDetails(AddEmployee);
                        }

                        if (MessagesObj.Result > 0)
                        {
                            Session["EmployeeResult"] = MessagesObj.Result;
                            return Json(EMSResources.SavedSuccessfully, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(MessagesObj.Message, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json("-3", JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    return Json("-2", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName: SavePersonalDetails,Parameters:AddEmployeeString=" + AddEmployeeString);
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally { }

        }

        [HttpPost]
        public ActionResult SaveProfessionalDetails(string AddEmployeeString1)
        {
            try
            {
                AddEmployeeMDL AddEmployee = JsonConvert.DeserializeObject<AddEmployeeMDL>(AddEmployeeString1);

                CommonMessages MessagesObj = new CommonMessages();

                AddEmployee.UserID = UserId;
                AddEmployee.BusinessID = BusinessId;

                MessagesObj = EmployeesBAL.SaveProfessionalDetails(AddEmployee);
                if (MessagesObj.Result > 0)
                {
                    return Json(EMSResources.SavedSuccessfully, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(MessagesObj.Message, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName: SaveProfessionalDetails, Parameters:AddEmployeeString1=" + AddEmployeeString1);
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally { }

        }

        [HttpPost]
        public ActionResult SaveEmployementDetails(string AddEmployeeString2)
        {
            try
            {
                AddEmployeeMDL AddEmployee = JsonConvert.DeserializeObject<AddEmployeeMDL>(AddEmployeeString2);

                CommonMessages MessagesObj = new CommonMessages();

                AddEmployee.UserID = UserId;
                AddEmployee.BusinessID = BusinessId;

                MessagesObj = EmployeesBAL.SaveEmployementDetails(AddEmployee);
                if (MessagesObj.Result > 0)
                {
                    return Json(EMSResources.SavedSuccessfully, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(MessagesObj.Message, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName: SaveEmployementDetails,Parameters:AddEmployeeString2=" + AddEmployeeString2);
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally { }
        }

        [HttpPost]
        public ActionResult SaveCommunicationDetails(string AddEmployeeString3)
        {
            try
            {
                AddEmployeeMDL AddEmployee = JsonConvert.DeserializeObject<AddEmployeeMDL>(AddEmployeeString3);

                CommonMessages MessagesObj = new CommonMessages();

                AddEmployee.UserID = UserId;
                AddEmployee.BusinessID = BusinessId;

                MessagesObj = EmployeesBAL.SaveCommunicationDetails(AddEmployee);
                if (MessagesObj.Result > 0)
                {
                    return Json(EMSResources.SavedSuccessfully, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(MessagesObj.Message, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName: SaveCommunicationDetails, Parameters:AddEmployeeString3" + AddEmployeeString3);
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally { }

        }

        [HttpPost]
        public ActionResult SaveBankDetails(string AddEmployeeString4)
        {
            try
            {
                AddEmployeeMDL AddEmployee = JsonConvert.DeserializeObject<AddEmployeeMDL>(AddEmployeeString4);

                CommonMessages MessagesObj = new CommonMessages();

                AddEmployee.UserID = UserId;
                AddEmployee.BusinessID = BusinessId;

                MessagesObj = EmployeesBAL.SaveBankDetails(AddEmployee);
                if (MessagesObj.Result > 0)
                {
                    return Json(EMSResources.SavedSuccessfully, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(MessagesObj.Message, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName: SaveBankDetails,Parameters:AddEmployeeString4" + AddEmployeeString4);
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally { }

        }

        [HttpPost]
        public ActionResult SaveFamilyDetails(string AddEmployeeFamilyString)
        {
            try
            {
                List<AddEmployeeFamilyMDL> AddEmployeeFamily = JsonConvert.DeserializeObject<List<AddEmployeeFamilyMDL>>(AddEmployeeFamilyString);
                AddEmployeeMDL AddEmployee = new AddEmployeeMDL();
                AddEmployee._listFamilyDetails = AddEmployeeFamily;

                CommonMessages MessagesObj = new CommonMessages();

                AddEmployee.UserID = UserId;
                AddEmployee.BusinessID = BusinessId;

                MessagesObj = EmployeesBAL.SaveFamilyDetails(AddEmployee);
                if (MessagesObj.Result > 0)
                {
                    return Json(EMSResources.SavedSuccessfully, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(MessagesObj.Message, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName: SaveFamilyDetails, Parameters:AddEmployeeFamilyString" + AddEmployeeFamilyString);
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally { }
        }

        [HttpPost]
        public ActionResult SaveAssetDetails(string AddEmployeeString6)
        {
            try
            {
                AddEmployeeMDL AddEmployee = JsonConvert.DeserializeObject<AddEmployeeMDL>(AddEmployeeString6);

                CommonMessages MessagesObj = new CommonMessages();

                AddEmployee.UserID = UserId;
                AddEmployee.BusinessID = BusinessId;

                MessagesObj = EmployeesBAL.SaveAssetDetails(AddEmployee);
                if (MessagesObj.Result > 0)
                {
                    return Json(EMSResources.SavedSuccessfully, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(MessagesObj.Message, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName: SaveAssetDetails, Parameters:AddEmployeeString6" + AddEmployeeString6);
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally { }

        }

        public ActionResult AddEmployeeFamilyBlank()
        {
            try
            {
                var Result = BAL.ValidateScreens.CheckPermission(16, GroupId);
                if (Result == 1)
                {
                    AddEmployeeFamilyMDL AddEmployeeFamily = new AddEmployeeFamilyMDL();
                    AddEmployeeFamily.GenderList = EmployeesBAL.Get_Genders(UserId).ToList();
                    AddEmployeeFamily.RelationList = EmployeesBAL.Get_HumanRelations().ToList();
                    return PartialView("FamilyDetails", AddEmployeeFamily);
                }
                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:AddEmployeeFamilyBlank");
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally
            {

            }
        }

        public ActionResult IsExistingEmp(string FirstName, string LastName, int? UserEmployeeId)
        {
            try
            {
                var Result = false;
                Result = EmployeesBAL.CheckExists_Employee(FirstName, LastName, BusinessId, UserEmployeeId);

                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:IsExistingEmp");
                return null;
            }
            finally { }
        }

        [HttpPost]
        public ActionResult IsExistEmpNumber(string EmployeeNumber, int? UserEmployeeId)
        {
            try
            {
                var Result = false;
                Result = EmployeesBAL.CheckExists_EmployeeNumber(EmployeeNumber, BusinessId, UserEmployeeId);

                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:IsExistEmpNumber, Parameters:EmployeeNumber=" + EmployeeNumber + ",UserEmployeeId=" + UserEmployeeId);
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally { }
        }

        #endregion AddEmployee

        #region EmployeeList

        [OutputCache(Duration = 10)]
        public ActionResult GetEmployees()
        {
            try
            {
                var Result = BAL.ValidateScreens.CheckPermission(15, GroupId);
                if (Result == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:GetEmployees");
                Elmah.ErrorSignal.FromCurrentContext().Raise(Ex);
                return null;
            }
            finally { }
        }

        [OutputCache(Duration = 10)]
        public ActionResult GetEmployeesNormalView()
        {
            var Result = BAL.ValidateScreens.CheckPermission(15, GroupId);
            if (Result == 1)
            {
                var roleId = RoleId;
                var UserEmplyeeId = UserSessionEmployeeId;
                var EmployeesList = EmployeesBAL.GetEmployeesList(BusinessId, UserId, roleId, UserEmplyeeId).ToList();
                return PartialView(EmployeesList);
            }
            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }

        [OutputCache(Duration = 10)]
        public ActionResult GetEmployeesGridView()
        {
            var Result = BAL.ValidateScreens.CheckPermission(15, GroupId);
            if (Result == 1)
            {
                var roleId = RoleId;
                var UserEmplyeeId = UserSessionEmployeeId;
                var EmployeesList = EmployeesBAL.GetEmployeesList(BusinessId, UserId, roleId, UserEmplyeeId).ToList();
                return PartialView(EmployeesList);
            }

            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }

        [OutputCache(Duration = 10)]
        public ActionResult DeleteEmployee(int EmployeeId, string EmpFullName)
        {
            ViewBag.UserEmployeeId = EmployeeId;
            EmploymentDetailsMDL EmpDet = new EmploymentDetailsMDL();
            EmpDet.UserEmployeeId = EmployeeId;
            EmpDet.EmployeeFullName = EmpFullName;
            EmpDet.BusinessId = BusinessId;
            EmpDet.UserId = UserId;

            EmploymentDetailsMDL EmpDetails = new EmploymentDetailsMDL();
            EmpDetails = EmployeesBAL.Validate_DeleteUserEmployee(EmpDet);
            EmpDet.Message = EmpDetails.Message;
            EmpDet.Result = EmpDetails.Result;

            return PartialView(EmpDet);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(EmploymentDetailsMDL EmpDetails)
        {
            try
            {
                ViewBag.UserEmployeeId = EmpDetails.UserEmployeeId;
                var Result1 = BAL.ValidateScreens.CheckPermission(15, GroupId);
                if (Result1 == 1)
                {
                    EmpDetails.BusinessId = BusinessId;
                    EmpDetails.UserId = UserId;

                    string Message = string.Empty;
                    var Result = EmployeesBAL.Delete_UserEmployee(EmpDetails);
                    if (Result)
                    {
                        Message = EMSResources.DeletedSuccessfully;
                    }
                    else
                    {
                        Message = EMSResources.DeleteFailed;
                    }
                    return Json(Message, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "MethodName:DeleteEmployee, Parameters:EmpDetails" + EmpDetails);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        public ActionResult EmployeeFullDetails(int id)
        {
            ViewBag.UserEmployeeId = id;
            ViewBag.BusinessId = BusinessId;
            ViewBag.screenID = 16;
            ViewBag.Id = id;
            return View();
        }

        public ActionResult PersonalOrEmploymentDetails(int UserEmployeeId)
        {
            EmploymentDetailsMDL EmpDetails = new EmploymentDetailsMDL();
            EmpDetails.UserEmployeeId = UserEmployeeId;
            EmpDetails.BusinessId = BusinessId;
            EmpDetails.UserId = UserId;
            EmpDetails = EmployeesBAL.Get_EmployeeDetails(EmpDetails);
            return PartialView(EmpDetails);
        }

        public ActionResult UpdatePersonalOrEmploymentDetails(int UserEmployeeId)
        {
            ViewBag.UserEmployeeId = UserEmployeeId;
            EmploymentDetailsMDL EmpDetails = new EmploymentDetailsMDL();
            EmpDetails.UserEmployeeId = UserEmployeeId;
            EmpDetails.BusinessId = BusinessId;
            EmpDetails.UserId = UserId;
            EmpDetails = EmployeesBAL.Get_EmployeeDetails(EmpDetails);

            ViewBag.GenderList = new SelectList(EmployeesBAL.Get_Genders(UserId), "key", "value");
            ViewBag.EmployeeModeList = new SelectList(EmployeesBAL.Get_EmploymentMode(UserId), "key", "value");
            ViewBag.EmployeeStatusList = new SelectList(EmployeesBAL.Get_EmplyeeStatus(UserId), "key", "value");
            ViewBag.PayMethodList = new SelectList(EmployeesBAL.Get_EmployeePaymentTypes(UserId), "key", "value");
            ViewBag.PayFrequencyList = new SelectList(EmployeesBAL.Get_EmployeePayFrequecy(UserId), "key", "value");

            return PartialView(EmpDetails);
        }

        [HttpPost]
        public ActionResult UpdatePersonalOrEmploymentDetails(EmploymentDetailsMDL EmpDetails)
        {
            try
            {
                ViewBag.UserEmployeeId = EmpDetails.UserEmployeeId;
                EmpDetails.VacationAllowed = EmpDetails.VacationAllowed == null ? 0 : EmpDetails.VacationAllowed;
                var Result1 = BAL.ValidateScreens.CheckPermission(15, GroupId);
                if (Result1 == 1)
                {
                    EmpDetails.BusinessId = BusinessId;
                    EmpDetails.UserId = UserId;
                    string Message = string.Empty;
                    CommonMessages MessagesObj = new CommonMessages();
                    MessagesObj = EmployeesBAL.Update_EmployeeDetails(EmpDetails);
                    if (MessagesObj.Result > 0)
                    {
                        Message = EMSResources.UpdatedSuccessfully;
                    }
                    else
                    {
                        Message = MessagesObj.Message;
                    }

                    return Json(Message, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:UpdatePersonalOrEmploymentDetails,Parameters: EmpDetails=" + EmpDetails);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        public ActionResult CommunicationDetails(int UserEmployeeId)
        {
            EmployeeCommunicationDetailsMDL EmpCommunicationDetails = new EmployeeCommunicationDetailsMDL();
            EmpCommunicationDetails.UserEmployeeId = UserEmployeeId;
            EmpCommunicationDetails.BusinessId = BusinessId;
            EmpCommunicationDetails.UserId = UserId;
            EmpCommunicationDetails = EmployeesBAL.Get_EmployeeCommunicationDetails(EmpCommunicationDetails);
            return PartialView(EmpCommunicationDetails);
        }

        public ActionResult UpdateCommunicationDetails(int UserEmployeeId)
        {
            ViewBag.UserEmployeeId = UserEmployeeId;
            EmployeeCommunicationDetailsMDL EmpCommunicationDetails = new EmployeeCommunicationDetailsMDL();
            EmpCommunicationDetails.UserEmployeeId = UserEmployeeId;
            EmpCommunicationDetails.BusinessId = BusinessId;
            EmpCommunicationDetails.UserId = UserId;
            EmpCommunicationDetails = EmployeesBAL.Get_EmployeeCommunicationDetails(EmpCommunicationDetails);
            return PartialView(EmpCommunicationDetails);
        }

        [HttpPost]
        public ActionResult UpdateCommunicationDetails(EmployeeCommunicationDetailsMDL EmpCommunicationDetails)
        {
            try
            {
                ViewBag.UserEmployeeId = EmpCommunicationDetails.UserEmployeeId;
                var Result1 = BAL.ValidateScreens.CheckPermission(15, GroupId);
                if (Result1 == 1)
                {
                    EmpCommunicationDetails.BusinessId = BusinessId;
                    EmpCommunicationDetails.UserId = UserId;
                    string Message = string.Empty;
                    CommonMessages MessagesObj = new CommonMessages();
                    MessagesObj = EmployeesBAL.Update_EmployeeCommunicationDetails(EmpCommunicationDetails);
                    if (MessagesObj.Result > 0)
                    {
                        Message = EMSResources.UpdatedSuccessfully;
                    }
                    else
                    {
                        Message = MessagesObj.Message;
                    }
                    return Json(Message, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:UpdateCommunicationDetails,Parameters: EmpCommunicationDetails=" + EmpCommunicationDetails);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        public ActionResult BankDetails(int UserEmployeeId)
        {
            ViewBag.UserEmployeeId = UserEmployeeId;
            EmployeeBankDetailsMDL EmpBankDetails = new EmployeeBankDetailsMDL();
            EmpBankDetails.UserEmployeeId = UserEmployeeId;
            EmpBankDetails.BusinessId = BusinessId;
            EmpBankDetails.UserId = UserId;
            EmpBankDetails = EmployeesBAL.Get_EmployeeBankDetails(EmpBankDetails);
            return PartialView(EmpBankDetails);
        }

        public ActionResult GetFamilyDetails(int UserEmployeeId)
        {
            List<EmployeeFamilyDetailsMDL> EmpFamilyDetails = new List<EmployeeFamilyDetailsMDL>();
            EmpFamilyDetails = EmployeesBAL.Get_EmployeeFamilyDetails(BusinessId, UserId, UserEmployeeId);
            ViewBag.UserEmployeeId = UserEmployeeId;
            return PartialView(EmpFamilyDetails);
        }

        public ActionResult AddFamilyDetails(int UserEmployeeId)
        {
            ViewBag.UserEmployeeId = UserEmployeeId;
            EmployeeFamilyDetailsMDL EmpFamilyDetails = new EmployeeFamilyDetailsMDL();
            EmpFamilyDetails.GenderList = EmployeesBAL.Get_Genders(UserId).ToList();
            EmpFamilyDetails.RelationList = EmployeesBAL.Get_HumanRelations().ToList();
            EmpFamilyDetails.UserEmployeeId = UserEmployeeId;
            return PartialView(EmpFamilyDetails);
        }

        [HttpPost]
        public ActionResult AddFamilyDetails(EmployeeFamilyDetailsMDL EmpFamilyDetails)
        {
            try
            {
                ViewBag.UserEmployeeId = EmpFamilyDetails.UserEmployeeId;
                EmpFamilyDetails.Phone = EmpFamilyDetails.Phone == null ? "" : EmpFamilyDetails.Phone;
                EmpFamilyDetails.Email = EmpFamilyDetails.Email == null ? "" : EmpFamilyDetails.Email;
                var Result1 = BAL.ValidateScreens.CheckPermission(15, GroupId);
                if (Result1 == 1)
                {
                    EmpFamilyDetails.BusinessId = BusinessId;
                    EmpFamilyDetails.UserId = UserId;
                    CommonMessages MessagesObj = new CommonMessages();
                    string Message = string.Empty;
                    MessagesObj = EmployeesBAL.Insert_EmployeeFamilyDetails(EmpFamilyDetails);
                    if (MessagesObj.Result > 0)
                    {
                        Message = EMSResources.SavedSuccessfully;
                    }
                    else
                    {
                        Message = MessagesObj.Message;
                    }
                    return Json(Message, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:AddFamilyDetails,Parameters: EmpFamilyDetails=" + EmpFamilyDetails);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        public ActionResult UpdateFamilyDetails(int UserEmployeeId, int FamilyDetailsId, int RelationId, String FirstName, string LastName, int GenderId, DateTime DOB, String Phone, String Email)
        {
            ViewBag.UserEmployeeId = UserEmployeeId;
            EmployeeFamilyDetailsMDL EmpFamilyDet = new EmployeeFamilyDetailsMDL();
            EmpFamilyDet.UserEmployeeId = UserEmployeeId;
            EmpFamilyDet.FamilyDetailsId = FamilyDetailsId;
            EmpFamilyDet.RelationId = RelationId;
            EmpFamilyDet.FirstName = FirstName;
            EmpFamilyDet.LastName = LastName;
            EmpFamilyDet.GenderId = GenderId;
            EmpFamilyDet.DOB = DOB;
            EmpFamilyDet.Phone = Phone;
            EmpFamilyDet.Email = Email;
            EmpFamilyDet.GenderList = EmployeesBAL.Get_Genders(UserId).ToList();
            EmpFamilyDet.RelationList = EmployeesBAL.Get_HumanRelations().ToList();
            return PartialView(EmpFamilyDet);
        }

        [HttpPost]
        public ActionResult UpdateFamilyDetails(EmployeeFamilyDetailsMDL EmpFamilyDetails)
        {
            try
            {
                ViewBag.UserEmployeeId = EmpFamilyDetails.UserEmployeeId;
                EmpFamilyDetails.Phone = EmpFamilyDetails.Phone == null ? "" : EmpFamilyDetails.Phone;
                EmpFamilyDetails.Email = EmpFamilyDetails.Email == null ? "" : EmpFamilyDetails.Email;
                var Result1 = BAL.ValidateScreens.CheckPermission(15, GroupId);
                if (Result1 == 1)
                {
                    EmpFamilyDetails.BusinessId = BusinessId;
                    EmpFamilyDetails.UserId = UserId;
                    string Message = string.Empty;
                    CommonMessages MessagesObj = new CommonMessages();
                    MessagesObj = EmployeesBAL.Update_EmployeeFamilyDetails(EmpFamilyDetails);
                    if (MessagesObj.Result > 0)
                    {
                        Message = EMSResources.UpdatedSuccessfully;
                    }
                    else
                    {
                        Message = MessagesObj.Message;
                    }
                    return Json(Message, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:UpdateFamilyDetails,Parameters: EmpFamilyDetails=" + EmpFamilyDetails);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        public ActionResult DeleteFamilyDetails(int UserEmployeeId, int FamilyDetailsId, string Name)
        {
            ViewBag.UserEmployeeId = UserEmployeeId;
            EmployeeFamilyDetailsMDL EmpFamilyDet = new EmployeeFamilyDetailsMDL();
            EmpFamilyDet.UserEmployeeId = UserEmployeeId;
            EmpFamilyDet.FamilyDetailsId = FamilyDetailsId;
            EmpFamilyDet.Name = Name;
            return PartialView(EmpFamilyDet);
        }

        [HttpPost]
        public ActionResult DeleteFamilyDetails(EmployeeFamilyDetailsMDL EmpFamilyDetails)
        {
            try
            {
                ViewBag.UserEmployeeId = EmpFamilyDetails.UserEmployeeId;
                var Result1 = BAL.ValidateScreens.CheckPermission(15, GroupId);
                if (Result1 == 1)
                {
                    EmpFamilyDetails.BusinessId = BusinessId;
                    EmpFamilyDetails.UserId = UserId;
                    string Message = string.Empty;
                    CommonMessages MessagesObj = new CommonMessages();
                    MessagesObj = EmployeesBAL.Delete_EmployeeFamilyDetails(EmpFamilyDetails);
                    if (MessagesObj.Result > 0)
                    {
                        Message = EMSResources.DeletedSuccessfully;
                    }
                    else
                    {
                        Message = MessagesObj.Message;
                    }
                    return Json(Message, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:DeleteFamilyDetails,Parameters: EmpFamilyDetails=" + EmpFamilyDetails);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        public ActionResult GetDeductionsOrContributions(int UserEmployeeId)
        {
            var Result = BAL.ValidateScreens.CheckPermission(15, GroupId);
            if (Result == 1)
            {
                ViewBag.UserEmployeeId = UserEmployeeId;
                List<EmployeeDeductionsMDL> EmpDeductionDetails = new List<EmployeeDeductionsMDL>();
                EmpDeductionDetails = EmployeesBAL.Get_EmployeeDeductions(BusinessId, UserId, UserEmployeeId);
                return PartialView(EmpDeductionDetails);
            }
            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }

        public ActionResult UpdateDeductionsOrContributions(int UserEmployeeId, int DeductionTypesId, string DeductionType, Decimal? DeductionPercent)
        {
            ViewBag.UserEmployeeId = UserEmployeeId;
            EmployeeDeductionsMDL EmpDeductions = new EmployeeDeductionsMDL();
            EmpDeductions.DeductionTypesId = DeductionTypesId;
            EmpDeductions.DeductionType = DeductionType;
            EmpDeductions.DeductionPercent = DeductionPercent;
            return PartialView(EmpDeductions);
        }

        [HttpPost]
        public ActionResult UpdateDeductionsOrContributions(EmployeeDeductionsMDL EmpDeductions)
        {
            try
            {
                ViewBag.UserEmployeeId = EmpDeductions.UserEmployeeId;
                EmpDeductions.DeductionPercent = EmpDeductions.DeductionPercent == null ? 0 : EmpDeductions.DeductionPercent;
                var Result1 = BAL.ValidateScreens.CheckPermission(15, GroupId);
                if (Result1 == 1)
                {
                    EmpDeductions.BusinessId = BusinessId;
                    EmpDeductions.UserId = UserId;
                    string Message = string.Empty;
                    CommonMessages MessagesObj = new CommonMessages();
                    MessagesObj = EmployeesBAL.Update_EmployeeDeductions(EmpDeductions);
                    if (MessagesObj.Result > 0)
                    {
                        Message = EMSResources.UpdatedSuccessfully;
                    }
                    else
                    {
                        Message = MessagesObj.Message;
                    }
                    return Json(Message, JsonRequestBehavior.AllowGet); ;
                }
                else
                {
                    return View("~/Views/Shared/ValidateScreens.cshtml");
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:UpdateDeductionsOrContributions,Parameters: EmpDeductions=" + EmpDeductions);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        [OutputCache(Duration = 10)]
        public ActionResult GetTimeSheets(int UserEmployeeId)
        {
            List<TimeSheetDetailsMDL> EmpTimeSheetDetails = new List<TimeSheetDetailsMDL>();
            EmpTimeSheetDetails = EmployeesBAL.Get_TimeSheets(BusinessId, UserId, UserEmployeeId);
            return PartialView(EmpTimeSheetDetails);
        }

        public ActionResult GetVacations(int UserEmployeeId)
        {
            List<VacationStatusMDL> EmpVacation = new List<VacationStatusMDL>();
            EmpVacation = EmployeesBAL.Get_Vacations(BusinessId, UserId, UserEmployeeId);
            return PartialView(EmpVacation);
        }

        public ActionResult GetPayrolls(int UserEmployeeId)
        {
            List<PayrollStatusMDL> EmpPayRoll = new List<PayrollStatusMDL>();
            EmpPayRoll = EmployeesBAL.Get_Payrolls(BusinessId, UserId, UserEmployeeId);
            return PartialView(EmpPayRoll);
        }

        public ActionResult EmployeeImageUpload(int UserEmployeeId)
        {
            ViewBag.UserEmployeeId = UserEmployeeId;
            return PartialView();
        }

        [HttpPost]
        public ActionResult EmployeeImageUpload(FormCollection FC, HttpPostedFileBase UploadImage)
        {
            var Result = BAL.ValidateScreens.CheckPermission(15, GroupId);
            if (Result == 1)
            {
                int UserEmployeeId = Convert.ToInt32(FC["UserEmployeeId"]);
                Images Image = new Images();
                Image.BusinessID = BusinessId;
                Image.UserID = UserEmployeeId;
                Image.UserTypeID = 4;
                var ImageName = Image.BusinessID + "-" + Image.UserTypeID + "-" + Image.UserID;
                string Extension = System.IO.Path.GetExtension(UploadImage.FileName);
                if (UploadImage.FileName != null)
                {
                    Image.ImagePath = Image.BusinessID + "/" + Image.UserTypeID + "/" + Image.UserID + "/" + ImageName + Extension;
                }
                else
                {
                    Image.ImagePath = "";
                }
                

                return RedirectToAction("EmployeeFullDetails", new { id = UserEmployeeId });
            }
            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }

        #endregion EmployeeList

        #region TimeSheet
        //Not using this function but dont remove -- Start
        public ActionResult DummyEmployeeTimeSheets(int? UserEmployeeId, string EmployeeName)
        {
            var Result = BAL.ValidateScreens.CheckPermission(17, GroupId);
            if (Result == 1)
            {
                ViewBag.UserEmployeeId = UserEmployeeId;
                ViewBag.EmployeeName = EmployeeName;

                return View();
            }
            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }
        //Not using this function but dont remove  -- End

        [HttpGet]
        public ActionResult EmployeeTimeSheets(int? UserEmployeeId, string EmployeeName)
        {
            ViewBag.UserId = UserId; ViewBag.RoleId = RoleId;
            ViewBag.UserName = UserName;
            var Result = BAL.ValidateScreens.CheckPermission(17, GroupId);
            if (Result == 1)
            {
                ViewBag.UserEmployeeId = UserEmployeeId;
                ViewBag.EmployeeName = EmployeeName;

                return View();
            }
            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }

        [OutputCache(Duration = 10)]
        public ActionResult GetTimeSheetDetails(int? UserEmployeeId, int? ProjectId, DateTime? FromDate, DateTime? ToDate)
        {
            ViewBag.RoleId = RoleId;
            int? employeeId =0;
            if (RoleId == 6)
            {
                employeeId = UserSessionEmployeeId;
            }
            else
            {
                employeeId = UserEmployeeId;
            }
            TimeSheetMDL TimeSheet = new TimeSheetMDL
            {
                BusinessId = BusinessId,
                UserId = UserId,
                UserEmployeeId = employeeId,
                ProjectId = ProjectId,
                FromDate = FromDate ?? DateTime.Now,
                ToDate = ToDate ?? DateTime.Now
            };

            var TimeSheetDetails = EmployeesBAL.Get_EmployeeTimeSheets(TimeSheet);
            return PartialView(TimeSheetDetails);
        }

        

        [OutputCache(Duration = 10)]
        [HttpGet]
        public ActionResult AddTimeSheet()
        {
            TimeSheetMDL TimeSheet = new TimeSheetMDL();
            ViewBag.RoleId = RoleId;
            ViewBag.UserId = UserId;
            ViewBag.UserName = UserName;
            ViewBag.UserSessionEmployeeId = UserSessionEmployeeId;
            return PartialView(TimeSheet);
        }

        [HttpPost]
        public ActionResult AddTimeSheet(string TimeSheetString)
        {
            try
            {
                string Message = string.Empty;
                CommonMessages MessagesObj = new CommonMessages();
                TimeSheetMDL TimeSheet = JsonConvert.DeserializeObject<TimeSheetMDL>(TimeSheetString);
                TimeSheet.BusinessId = BusinessId;
                TimeSheet.UserId = UserId;
                MessagesObj = EmployeesBAL.Insert_EmployeeTimeSheet(TimeSheet);
                if (MessagesObj.Result > 0)
                {
                    Message = EMSResources.SavedSuccessfully;
                }
                else if (MessagesObj.Result == -1)
                {
                    Message = EMSResources.LeavesCanNotAppliedToTheTimeSheetEntryDates;
                }
                else
                {
                    Message = MessagesObj.Message;
                }

                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:AddTimeSheet,Parameters: TimeSheetString=" + TimeSheetString);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        [OutputCache(Duration = 10)]
        [HttpGet]
        public ActionResult UpdateTimeSheet(DateTime Date, String Description, int RegularHours, int OverTimeHours, int? ProjectId, int? UserEmployeeId, int? TimeSheetId, String EmployeeName, String ProjectName)
        {
            TimeSheetMDL TimeSheet = new TimeSheetMDL
            {
                Date = Date,
                Description = Description,
                RegularHours = RegularHours,
                OverTimeHours = OverTimeHours,
                ProjectId = ProjectId,
                UserEmployeeId = UserEmployeeId,
                TimeSheetId = TimeSheetId,
                EmployeeName = EmployeeName,
                ProjectName = ProjectName
            };

            return PartialView(TimeSheet);
        }

        [HttpPost]
        public ActionResult UpdateTimeSheet(string TimeSheetString)
        {
            try
            {
                string Message = string.Empty;
                CommonMessages MessagesObj = new CommonMessages();
                TimeSheetMDL TimeSheet = JsonConvert.DeserializeObject<TimeSheetMDL>(TimeSheetString);
                TimeSheet.BusinessId = BusinessId;
                TimeSheet.UserId = UserId;
                MessagesObj = EmployeesBAL.Update_EmployeeTimeSheet(TimeSheet);
                if (MessagesObj.Result > 0)
                {
                    Message = EMSResources.UpdatedSuccessfully;
                }
                else
                {
                    Message = MessagesObj.Message;
                }

                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:UpdateTimeSheet,Parameters: TimeSheetString=" + TimeSheetString);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        [HttpGet]
        public ActionResult ViewTimeSheet(DateTime Date, String Description, int RegularHours, int OverTimeHours, String EmployeeName, String ProjectName)
        {
            TimeSheetMDL TimeSheet = new TimeSheetMDL
            {
                Date = Date,
                Description = Description,
                RegularHours = RegularHours,
                OverTimeHours = OverTimeHours,
                EmployeeName = EmployeeName,
                ProjectName = ProjectName
            };

            return PartialView(TimeSheet);
        }

        [HttpGet]
        public ActionResult DeleteTimeSheet(int TimesheetId, String EmployeeName)
        {
            TimeSheetMDL TimeSheet = new TimeSheetMDL
            {
                TimeSheetId = TimesheetId,
                EmployeeName = EmployeeName
            };

            return PartialView(TimeSheet);
        }

        [HttpPost]
        public ActionResult DeleteTimeSheet(TimeSheetMDL TimeSheet)
        {
            try
            {
                string Message = string.Empty;
                TimeSheet.BusinessId = BusinessId;
                TimeSheet.UserId = UserId;
                CommonMessages MessagesObj = new CommonMessages();
                MessagesObj = EmployeesBAL.Delete_EmployeeTimeSheet(TimeSheet);
                if (MessagesObj.Result > 0)
                {
                    Message = EMSResources.DeletedSuccessfully;
                }
                else
                {
                    Message = MessagesObj.Message;
                }

                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:DeleteTimeSheet,Parameters: TimeSheet=" + TimeSheet);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        public ActionResult Get_EmployeeTimeSheetDates(string Fromdate)
        {
            var DateDays = BAL.EmployeesBAL.Get_EmployeeTimeSheetDates(Fromdate);
            return Json(DateDays, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddWeeklyTimeSheet()
        {
            ViewBag.RoleId = RoleId;
            ViewBag.UserId = UserId;
            ViewBag.UserName = UserName;
            ViewBag.UserSessionEmployeeId = UserSessionEmployeeId;
            TimeSheetMDL TimeSheet = new TimeSheetMDL();
            ViewBag.EmployeeWeeklyTimeSheet = new SelectList(BAL.EmployeesBAL.GetEmployeeWeeklyTimeSheet(), "WeekStartDay", "ShowDay");
            return PartialView(TimeSheet);
        }

        [HttpPost]
        public ActionResult AddWeeklyTimeSheet(string TimeSheetString, string[] DatesStr, string[] RegularHoursStr, string[] OverTimeHoursStr)
        {
            try
            {
                string Message = string.Empty;
                CommonMessages MessagesObj = new CommonMessages();
                TimeSheetMDL TimeSheet = JsonConvert.DeserializeObject<TimeSheetMDL>(TimeSheetString);
                TimeSheet.BusinessId = BusinessId;
                TimeSheet.UserId = UserId;
                if (DatesStr == null)
                {
                    MessagesObj = EmployeesBAL.Weekly_EmployeeTimeSheet(TimeSheet, DatesStr, RegularHoursStr, OverTimeHoursStr);
                }
                else
                {
                    MessagesObj = EmployeesBAL.Weekly_EmployeeTimeSheet(TimeSheet,DatesStr,RegularHoursStr,OverTimeHoursStr);
                    //for (int i = 0; i < DatesStr.Length; i++)
                    //{
                    //    TimeSheet.Date = Convert.ToDateTime(DatesStr[i]);
                    //    TimeSheet.RegularHours = Convert.ToInt32(RegularHoursStr[i]);
                    //    TimeSheet.OverTimeHours = Convert.ToInt32(OverTimeHoursStr[i]);
                    //    MessagesObj = EmployeesBAL.Insert_EmployeeTimeSheet(TimeSheet);
                    //    if (MessagesObj.Result == 0)
                    //    {
                    //        break;
                    //    }
                    //}
                }
                if (MessagesObj.Result > 0)
                {
                    Message = EMSResources.SavedSuccessfully;
                }
                else
                {
                    Message = MessagesObj.Message;
                }

                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:AddWeeklyTimeSheet,Parameters: TimeSheetString=" + TimeSheetString + ",DatesStr=" + DatesStr + ",RegularHoursStr=" + RegularHoursStr + ",OverTimeHoursStr=" + OverTimeHoursStr);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        #endregion TimeSheet

        #region Vacation Schedule

        [HttpGet]
        public ActionResult EmployeeVacationSchedule(int? UserEmployeeId, string EmployeeName)
        {
            var Result = BAL.ValidateScreens.CheckPermission(18, GroupId);
            if (Result == 1)
            {
                ViewBag.UserEmployeeId = UserEmployeeId;
                ViewBag.EmployeeName = EmployeeName;

                return View();
            }
            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }

        public ActionResult GetVacationsDetails(int? UserEmployeeId, DateTime? FromDate, DateTime? ToDate)
        {
            var Result = BAL.ValidateScreens.CheckPermission(18, GroupId);
            if (Result == 1)
            {
                VacationMDL Vacation = new VacationMDL
                {
                    BusinessId = BusinessId,
                    UserId = UserId,
                    UserEmployeeId = UserEmployeeId,
                    FromDate = FromDate ?? DateTime.Now,
                    ToDate = ToDate ?? DateTime.Now
                };

                var VacationsDetails = EmployeesBAL.Get_EmployeeVacation(Vacation);
                return PartialView(VacationsDetails);
            }

            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }

        [HttpGet]
        public ActionResult AddVacationSchedule()
        {
            VacationMDL Vacation = new VacationMDL();
            ViewBag.VacationsList = new SelectList(EmployeesBAL.GetVacationsDD(), "LeaveStatusId", "LeaveStatus");
            return PartialView(Vacation);
        }

        [HttpPost]
        public ActionResult AddVacationSchedule(string VacationString)
        {
            string Message = string.Empty;
            CommonMessages MessagesObj = new CommonMessages();
            VacationMDL Vacation = JsonConvert.DeserializeObject<VacationMDL>(VacationString);
            Vacation.BusinessId = BusinessId;
            Vacation.UserId = UserId;
            MessagesObj = EmployeesBAL.Insert_EmployeeVacation(Vacation);
            if (MessagesObj.Result > 0)
            {
                Message = EMSResources.SavedSuccessfully;
                //Message = EMSResources.SavedSuccessfully;
            }
            else if (MessagesObj.Result == -1)
            {
                Message = EMSResources.LeavesCountIsMoreOvertheYear;
                //Message = EMSResources.LeavesCountIsMoreOvertheYear;
            }
            else if (MessagesObj.Result == -2)
            {
                Message = EMSResources.Vacationisalreadyavailablebetweenthesedates;
                //Message = EMSResources.Vacationisalreadyavailablebetweenthesedates;
            }
            else
            {
                Message = MessagesObj.Message;
            }

            return Json(Message, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UpdateVacationSchedule(DateTime FromDate, DateTime ToDate, int UserEmployeeId, int LeaveId, int LeaveStatusId, String EmployeeName, int NoOfDays)
        {
            VacationMDL Vacation = new VacationMDL
            {
                FromDate = FromDate,
                ToDate = ToDate,
                UserEmployeeId = UserEmployeeId,
                LeaveId = LeaveId,
                LeaveStatusId = LeaveStatusId,
                EmployeeName = EmployeeName,
                NoOfDays = NoOfDays
            };
            ViewBag.VacationsList = new SelectList(EmployeesBAL.GetVacationsDD(), "LeaveStatusId", "LeaveStatus");

            return PartialView(Vacation);
        }

        [HttpPost]
        public ActionResult UpdateVacationSchedule(string VacationString)
        {
            string Message = string.Empty;
            CommonMessages MessagesObj = new CommonMessages();
            VacationMDL Vacation = JsonConvert.DeserializeObject<VacationMDL>(VacationString);
            Vacation.BusinessId = BusinessId;
            Vacation.UserId = UserId;
            MessagesObj = EmployeesBAL.Update_EmployeeVacation(Vacation);
            if (MessagesObj.Result > 0)
            {
                Message = EMSResources.UpdatedSuccessfully;
            }
            else
            {
                Message = MessagesObj.Message;
            }

            return Json(Message, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewVacationSchedule(DateTime FromDate, DateTime ToDate, int LeaveStatusId, String EmployeeName, int NoOfDays, int UserEmployeeId)
        {
            VacationMDL Vacation = new VacationMDL
            {
                FromDate = FromDate,
                ToDate = ToDate,
                LeaveStatusId = LeaveStatusId,
                EmployeeName = EmployeeName,
                NoOfDays = NoOfDays,
                UserEmployeeId = UserEmployeeId
            };
            ViewBag.VacationsList = new SelectList(EmployeesBAL.GetVacationsDD(), "LeaveStatusId", "LeaveStatus");

            return PartialView(Vacation);
        }

        [HttpGet]
        public ActionResult DeleteVacationSchedule(int UserEmployeeId, int LeaveId, String EmployeeName)
        {
            VacationMDL Vacation = new VacationMDL
            {
                UserEmployeeId = UserEmployeeId,
                LeaveId = LeaveId,
                EmployeeName = EmployeeName,
            };

            return PartialView(Vacation);
        }

        [HttpPost]
        public ActionResult DeleteVacationSchedule(VacationMDL Vacation)
        {
            string Message = string.Empty;
            CommonMessages MessagesObj = new CommonMessages();
            Vacation.BusinessId = BusinessId;
            Vacation.UserId = UserId;
            MessagesObj = EmployeesBAL.Delete_EmployeeVacation(Vacation);
            if (MessagesObj.Result > 0)
            {
                Message = EMSResources.DeletedSuccessfully;
            }
            else
            {
                Message = MessagesObj.Message;
            }

            return Json(Message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VacationStatusChange(DateTime FromDate, DateTime ToDate, int UserEmployeeId, int LeaveId, string LeaveStatus, string EmployeeName, int NoOfDays)
        {

            VacationMDL Vacation = new VacationMDL
            {
                FromDate = FromDate,
                ToDate = ToDate,
                UserEmployeeId = UserEmployeeId,
                LeaveId = LeaveId,
                LeaveStatus = LeaveStatus,
                EmployeeName = EmployeeName,
                NoOfDays = NoOfDays
            };

            return PartialView(Vacation);
        }

        [HttpPost]
        public ActionResult VacationStatusChange(string VacationString)
        {
            string Message = string.Empty;
            CommonMessages MessagesObj = new CommonMessages();
            VacationMDL Vacation = JsonConvert.DeserializeObject<VacationMDL>(VacationString);
            Vacation.BusinessId = BusinessId;
            Vacation.UserId = UserId;
            MessagesObj = EmployeesBAL.Update_EmployeeVacationStatus(Vacation);
            if (MessagesObj.Result > 0)
            {
                Message = EMSResources.UpdatedSuccessfully;
            }
            else
            {
                Message = EMSResources.UpdationFailed;
            }

            return Json(Message, JsonRequestBehavior.AllowGet);
        }

        #endregion Vacation Schedule

        #region PartialViews

        #endregion PartialViews

        #region Payroll

        [OutputCache(Duration = 10)]
        public ActionResult EmployeePayrolls()
        {
            var Result = BAL.ValidateScreens.CheckPermission(18, GroupId);
            if (Result == 1)
            {
                ViewBag.HeadCount = (int)Session["HeadCount"];
                ViewBag.GrossSlary = String.Format("{0:0.00}", (decimal)Session["GrossSalary"]);
                ViewBag.TotalDeductions = String.Format("{0:0.00}", (decimal)Session["TotalDeductions"]);
                ViewBag.ProvidentFund = String.Format("{0:0.00}", (decimal)Session["ProvidentFund"]);
                ViewBag.SalaryPayOut = String.Format("{0:0.00}", (decimal)Session["GrossSalary"] - (decimal)Session["TotalDeductions"]);
                ViewBag.ProfessionTax = (int)Session["ProfessionTax"];
                ViewBag.TotalESIC = String.Format("{0:0.00}", (decimal)Session["TotalESIC"]);
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                DataSet dataset = new DataSet();
                using (SqlConnection conn = new SqlConnection("Data Source = 202.143.96.20,16222; Initial Catalog = EMS; Persist Security Info = True; User ID = sa; Password = DOTSOFT@12345"))
                {
                    conn.Open();
                    cmd = new SqlCommand("usp_ReportAllEmployeePayroll", conn);
                    cmd.Parameters.Add("@BusinessId", BusinessId);
                    cmd.Parameters.Add("@Month", null);
                    cmd.Parameters.Add("@Year", null);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataAdapter.SelectCommand = cmd;
                    DataAdapter.Fill(dataset);
                }
                ViewBag.Count = dataset.Tables[0].Rows;
                return View();
            }
            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }

        [OutputCache(Duration = 10)]
        public ActionResult GetPayrollsDetails(int? UserEmployeeId, DateTime? FromDate, DateTime? ToDate)
        {
            var Result = BAL.ValidateScreens.CheckPermission(18, GroupId);
            if (Result == 1)
            {
                ViewBag.PreferredCurrency = PreferredCurrency;

                PayrollMDL Payroll = new PayrollMDL
                {
                    BusinessId = BusinessId,
                    UserId = UserId,
                    UserEmployeeId = UserEmployeeId,
                    FromDate = FromDate ?? DateTime.Now,
                    ToDate = ToDate ?? DateTime.Now
                };

                var PayrollsDetails = EmployeesBAL.Get_EmployeePayrolls(Payroll);
                return PartialView(PayrollsDetails);
            }

            else
            {
                return View("~/Views/Shared/ValidateScreens.cshtml");
            }
        }

        [OutputCache(Duration = 10)]
        [HttpGet]
        public ActionResult AddPayroll()
        {
            PayrollMDL Payroll = new PayrollMDL();
            ViewBag.StatusList = new SelectList(EmployeesBAL.Get_EmployeePayrollStatus(BusinessId, UserId), "key", "value");
            return PartialView(Payroll);
        }

        [HttpPost]
        public ActionResult AddPayroll(string PayrollString)
        {
            try
            {
                string Message = string.Empty;
                CommonMessages MessagesObj = new CommonMessages();
                PayrollMDL Payroll = JsonConvert.DeserializeObject<PayrollMDL>(PayrollString);
                Payroll.BusinessId = BusinessId;
                Payroll.UserId = UserId;
                MessagesObj = EmployeesBAL.Insert_EmployeePayroll(Payroll);
                if (MessagesObj.Result > 0)
                {
                    Message = EMSResources.SavedSuccessfully;
                }
                else
                {
                    Message = MessagesObj.Message;
                }

                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:AddPayroll,Parameters: PayrollString=" + PayrollString);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        [HttpGet]
        public ActionResult UpdatePayroll(int UserEmployeeId, String EmployeeName, int RegularHours, int OverTimeHours, Decimal Amount, int StatusId, int BankAccountsId, int EmployeePayrollId, DateTime FromDate, DateTime ToDate, String BankName)
        {
            PayrollMDL Payroll = new PayrollMDL
            {
                UserEmployeeId = UserEmployeeId,
                EmployeeName = EmployeeName,
                RegularHours = RegularHours,
                OverTimeHours = OverTimeHours,
                Amount = Amount,
                StatusId = StatusId,
                BankAccountsId = BankAccountsId,
                EmployeePayrollId = EmployeePayrollId,
                FromDate = FromDate,
                ToDate = ToDate,
                BankName = BankName
            };
            ViewBag.StatusList = new SelectList(EmployeesBAL.Get_EmployeePayrollStatus(BusinessId, UserId), "key", "value");
            ViewBag.PreferredCurrency = PreferredCurrency;

            return PartialView(Payroll);
        }

        [HttpPost]
        public ActionResult UpdatePayroll(string PayrollString)
        {
            try
            {
                string Message = string.Empty;
                CommonMessages MessagesObj = new CommonMessages();
                PayrollMDL Payroll = JsonConvert.DeserializeObject<PayrollMDL>(PayrollString);
                Payroll.BusinessId = BusinessId;
                Payroll.UserId = UserId;
                MessagesObj = EmployeesBAL.Update_EmployeePayroll(Payroll);
                if (MessagesObj.Result > 0)
                {
                    Message = EMSResources.UpdatedSuccessfully;
                }
                else
                {
                    Message = MessagesObj.Message;
                }

                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:UpdatePayroll,Parameters: PayrollString=" + PayrollString);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        [HttpGet]
        public ActionResult ViewPayroll(int UserEmployeeId, String EmployeeName, int RegularHours, int OverTimeHours, Decimal Amount, int StatusId, int BankAccountsId, DateTime FromDate, DateTime ToDate, String BankName)
        {
            PayrollMDL Payroll = new PayrollMDL
            {
                UserEmployeeId = UserEmployeeId,
                EmployeeName = EmployeeName,
                RegularHours = RegularHours,
                OverTimeHours = OverTimeHours,
                Amount = Amount,
                StatusId = StatusId,
                BankAccountsId = BankAccountsId,
                FromDate = FromDate,
                ToDate = ToDate,
                BankName = BankName
            };
            ViewBag.StatusList = new SelectList(EmployeesBAL.Get_EmployeePayrollStatus(BusinessId, UserId), "key", "value");
            ViewBag.PreferredCurrency = PreferredCurrency;
            return PartialView(Payroll);
        }

        [HttpGet]
        public ActionResult DeletePayroll(int UserEmployeeId, int EmployeePayrollId, String EmployeeName)
        {
            PayrollMDL Payroll = new PayrollMDL
            {
                UserEmployeeId = UserEmployeeId,
                EmployeePayrollId = EmployeePayrollId,
                EmployeeName = EmployeeName,
            };

            return PartialView(Payroll);
        }

        [HttpPost]
        public ActionResult DeletePayroll(PayrollMDL Payroll)
        {
            try
            {
                string Message = string.Empty;
                CommonMessages MessagesObj = new CommonMessages();
                Payroll.BusinessId = BusinessId;
                Payroll.UserId = UserId;
                MessagesObj = EmployeesBAL.Delete_EmployeePayroll(Payroll);
                if (MessagesObj.Result > 0)
                {
                    Message = EMSResources.DeletedSuccessfully;
                }
                else
                {
                    Message = MessagesObj.Message;
                }

                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:DeletePayroll,Parameters: Payroll=" + Payroll);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        public ActionResult UpdatePayrollStatus(DateTime FromDate, DateTime ToDate, String EmployeeName, int RegularHours, int OverTimeHours, String Status, Decimal Amount, int EmployeePayrollId, int UserEmployeeId, int BankAccountsId, String BankName)
        {
            PayrollMDL Payroll = new PayrollMDL
            {
                FromDate = FromDate,
                ToDate = ToDate,
                EmployeeName = EmployeeName,
                RegularHours = RegularHours,
                OverTimeHours = OverTimeHours,
                Status = Status,
                Amount = Amount,
                EmployeePayrollId = EmployeePayrollId,
                UserEmployeeId = UserEmployeeId,
                BankAccountsId = BankAccountsId,
                BankName = BankName
            };

            return PartialView(Payroll);
        }

        [HttpPost]
        public ActionResult UpdatePayrollStatus(string PayrollString)
        {
            try
            {
                string Message = string.Empty;
                CommonMessages MessagesObj = new CommonMessages();
                PayrollMDL Payroll = JsonConvert.DeserializeObject<PayrollMDL>(PayrollString);
                Payroll.BusinessId = BusinessId;
                Payroll.UserId = UserId;
                MessagesObj = EmployeesBAL.Update_EmployeePayrollStatus(Payroll);
                if (MessagesObj.Result > 0)
                {
                    Message = EMSResources.UpdatedSuccessfully;
                }
                else
                {
                    Message = MessagesObj.Message;

                }

                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:UpdatePayrollStatus,Parameters: PayrollString=" + PayrollString);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        #endregion Payroll

        public ActionResult PayrollDashboard()
        {
            return View();
        }

        //#region EmployeeCommonMethods

        public JsonResult Get_EmpAutoFiling(string keyword)
        {
            return Json(EmployeesBAL.Get_EmpAutoFiling(BusinessId, UserId, keyword), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_EmpAutoText()
        {
            EmployeeListMDL AddEmployee = new EmployeeListMDL();
            AddEmployee.BusinessID = BusinessId; ;
            return Json(EmployeesBAL.Get_EmpAutoText(AddEmployee), JsonRequestBehavior.AllowGet);
        }

        #region Designation
        public ActionResult GetDesignation()
        {
            int EmployeeDesignationID = 0;
            //Designation _Designation = new Designation();
            var EmpDesignation = EmployeesBAL.Get_DesignationList(EmployeeDesignationID);
            ViewBag.EmpDesignationData = EmpDesignation;
            return View();
        }


        public ActionResult AddDesignation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDesignation(string DesignationName)
        {
            CommonMessages MessagesObj = new CommonMessages();
            string Message = string.Empty;

            Designation _Designation = new Designation
            {
                //EmployeeDesignationID= DesignationId,
                EmployeeDesignationName = DesignationName,
                LoggInUserId = UserId
            };

            MessagesObj = EmployeesBAL.SaveEmpDesignation(_Designation);

            if (MessagesObj.Result > 0)
            {
                Message = "Saved Successfully";
            }
            else
            {
                Message = MessagesObj.Message;
            }
            return Json(Message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateDesignation(int EmployeeDesignationID, string EmployeeDesignationName)
        {
            var EmpDesignation = EmployeesBAL.Get_DesignationList(EmployeeDesignationID);
            ViewBag.EmployeeDesignationName = EmployeeDesignationName;
            return View();
        }

        public ActionResult DeleteDesignation(int EmployeeDesignationID, string EmployeeDesignationName)
        {
            var EmpDesignation = EmployeesBAL.Get_DesignationList(EmployeeDesignationID);
            ViewBag.EmployeeDesignationName = EmployeeDesignationName;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateDesignation(UpdateDesignation _Designation)
        {
            CommonMessages MessagesObj = new CommonMessages();
            string Message = string.Empty;
            //Designation _Designation = new Designation
            //{
            //    EmployeeDesignationID = EmployeeDesignationID,
            //    EmployeeDesignationName = EmployeeDesignationName,
            //    LoggInUserId = UserId
            //};
            _Designation.LoggInUserId = UserId;

            MessagesObj = EmployeesBAL.UpdateEmpDesignation(_Designation);

            if (MessagesObj.Result > 0)
            {
                Message = EMSResources.UpdatedSuccessfully;
            }
            else
            {
                Message = MessagesObj.Message;
            }
            return Json(Message, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteDesignation(DeleteDesignation _Designation)
        {
            CommonMessages MessagesObj = new CommonMessages();
            string Message = string.Empty;

            MessagesObj = EmployeesBAL.DeleteEmpDesignation(_Designation);

            if (MessagesObj.Result > 0)
            {
                Message = EMSResources.DeletedSuccessfully;
            }
            else
            {
                Message = MessagesObj.Message;
            }
            return Json(Message, JsonRequestBehavior.AllowGet);

        }
        #endregion Designation

        public JsonResult GetProjectsAutofiling(string keyword)
        {
            return Json(EmployeesBAL.Get_ProjectAutoFiling(BusinessId, UserId, keyword, BusinessItemsTypes.Projects), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_EmployeePayrollBanksAutofill(string keyword)
        {
            return Json(EmployeesBAL.Get_UserBankAutoFiling(BusinessId, UserId, keyword), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_EmployeeDetails(int UserEmployeeId)
        {
            EmploymentDetailsMDL EmpDetails = new EmploymentDetailsMDL();
            EmpDetails.UserEmployeeId = UserEmployeeId;
            EmpDetails.BusinessId = BusinessId;
            EmpDetails.UserId = UserId;

            return Json(EmployeesBAL.Get_EmployeeDetails(EmpDetails), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_EmployeePTOFields(int UserEmployeeId)
        {
            return Json(EmployeesBAL.Get_EmployeePTOFields(BusinessId, UserId, UserEmployeeId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_EmployeeNextPayrollDates(int UserEmployeeId)
        {
            return Json(EmployeesBAL.Get_EmployeeNextPayrollDates(BusinessId, UserId, UserEmployeeId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckExists_EmployeePayrolls(string PayrollString)
        {
            PayrollMDL PayRoll = JsonConvert.DeserializeObject<PayrollMDL>(PayrollString);
            PayRoll.BusinessId = BusinessId;
            PayRoll.UserId = UserId;
            return Json(EmployeesBAL.CheckExists_EmployeePayrolls(PayRoll), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckExists_EmployeeTimesheet(string TimeSheetString)
        {
            TimeSheetMDL TimeSheet = JsonConvert.DeserializeObject<TimeSheetMDL>(TimeSheetString);
            TimeSheet.BusinessId = BusinessId;
            TimeSheet.UserId = UserId;
            return Json(EmployeesBAL.CheckExists_EmployeeTimesheet(TimeSheet), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckExists_EmployeeVacation(string VacationString)
        {
            VacationMDL Vacation = JsonConvert.DeserializeObject<VacationMDL>(VacationString);
            Vacation.BusinessId = BusinessId;
            Vacation.UserId = UserId;
            return Json(EmployeesBAL.CheckExists_EmployeeVacation(Vacation), JsonRequestBehavior.AllowGet);
        }

        #region Resignation

        [OutputCache(Duration = 10)]
        public ActionResult ExitResignation()
        {
            try
            {
                return View();
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:ExitResignation");
                return null;
            }
            finally { }
        }

        public ActionResult GetEmpResignDetails()
        {
            try
            {
                ExitResignation _ExitResignation = new ExitResignation
                {
                    BusinessId = BusinessId,
                    UserId = UserId,
                    UserEmployeeId = UserSessionEmployeeId,
                    RoleId = RoleId
                };

                var EmpResignDetails = BAL.EmployeesBAL.Get_EmpResignationList(_ExitResignation);
                ViewBag.EmpResignData = EmpResignDetails;

                return PartialView(EmpResignDetails);
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:GetEmpResignDetails");
                return null;
            }
            finally
            {
            }
        }

        public ActionResult SaveEmpResignDetails(DateTime ResignDate)
        {
            try
            {
                string Message = string.Empty;
                CommonMessages MessagesObj = new CommonMessages();
                ExitResignation _ExitResignation = new ExitResignation
                {
                    BusinessId = BusinessId,
                    UserId = UserId,
                    UserEmployeeId = UserSessionEmployeeId,
                    Date = ResignDate
                };

                MessagesObj = BAL.EmployeesBAL.SaveEmpResignDetails(_ExitResignation);

                return Json(MessagesObj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:SaveEmpResignDetails");
                return null;
            }
        }
        #endregion Resignation

        //#endregion EmployeeCommonMethods


        //#region ImportExcel


        //[HttpGet]
        //public ActionResult ImportEmployee()
        //{


        //    ViewBag.success = TempData["success"];
        //    //ViewBag.Failed = TempData["Failed"];
        //    //ViewBag.AlreadyExists = TempData["AlreadyExists"];
        //    ViewBag.msg = TempData["catch"];

        //    var tempdat = TempData["AlreadyExistsData"];

        //    ViewBag.AlreadyExistsData = TempData["AlreadyExistsData"];

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ImportEmployee(int dummy = 0)
        //{
        //    DataTable dterror = new DataTable();
        //    CommonMessages MessagesObj = new CommonMessages();
        //    string Message = string.Empty;
        //    bool validateVendor = false;
        //    TempData["Message"] = string.Empty;

        //    StringBuilder strExcel = new StringBuilder();

        //    string[] excelDate = new string[3];
        //    excelDate[0] = DateTime.Now.Year.ToString();
        //    excelDate[1] = DateTime.Now.Month.ToString();
        //    excelDate[2] = DateTime.Now.Day.ToString();

        //    HttpPostedFileBase file = Request.Files["excelUPload"];
        //    string extension = System.IO.Path.GetExtension(file.FileName);
        //    if (!Directory.Exists(strExcel.Append(Server.MapPath("~/UploadDocuments/ExcelImports")).ToString()))
        //    {
        //        Directory.CreateDirectory(strExcel.ToString());
        //    }
        //    if (!Directory.Exists(strExcel.Append("\\" + excelDate[0]).ToString()))
        //    {
        //        Directory.CreateDirectory(strExcel.ToString());
        //    }
        //    if (!Directory.Exists(strExcel.Append("\\" + excelDate[1]).ToString()))
        //    {
        //        Directory.CreateDirectory(strExcel.ToString());
        //    }
        //    if (!Directory.Exists(strExcel.Append("\\" + excelDate[2]).ToString()))
        //    {
        //        Directory.CreateDirectory(strExcel.ToString());
        //    }

        //    string path1 = string.Concat(strExcel.ToString(), extension);
        //    path1 = string.Concat(strExcel.ToString() + "\\" + file.FileName);
        //    Request.Files["excelUPload"].SaveAs(path1);

        //    string excelConnectionString = "";
        //    //connection String for xls file format.
        //    if (extension == ".xls")
        //    {
        //        excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";


        //    }
        //    //connection String for xlsx file format.
        //    else if (extension == ".xlsx")
        //    {
        //        excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

        //    }


        //    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
        //    try
        //    {
        //        OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]", excelConnection);
        //        excelConnection.Open();
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //        da.Fill(ds);
        //        dt = ds.Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            DataTable dtCopyCustomer;

        //            AddEmployeeMDL _upsertEmployeeMaster = new AddEmployeeMDL();
        //            Session["ExcelMessage"] = null;
        //            int SuccessCount = 0;
        //            //int FailedCount = 0;
        //            DataTable dttemp = dt.Clone();
        //            int emptyrows = 0;
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                if (row[0] != null && row[0].ToString() == "")
        //                {
        //                    emptyrows++;
        //                    if (emptyrows > 3)
        //                    {
        //                        break;
        //                    }

        //                }
        //                else
        //                {
        //                    dttemp.ImportRow(row);
        //                }
        //            }
        //            dtCopyCustomer = new DataTable();
        //            dtCopyCustomer = dttemp.Copy();
        //            dtCopyCustomer.Columns.Add("Status", typeof(string));
        //            dterror = dtCopyCustomer.Clone();
        //            if (dtCopyCustomer.Rows.Count != 0)
        //            {
        //                foreach (DataRow dr in dtCopyCustomer.Rows)
        //                {
        //                    bool success = false;
        //                    int res = 0;
        //                    try
        //                    {
        //                        if (dr["EmployeeNumber"] != null && dr["EmployeeFirstName"] != null && dr["EmployeeLastName"] != null
        //                       && dr["EmployeeNumber"].ToString() != "" && dr["EmployeeFirstName"].ToString() != "" && dr["EmployeeLastName"].ToString() != "")
        //                        {


        //                            var EmployeeNumber = dr["EmployeeNumber"].ToString();
        //                            var Number = BankAccountsBAL.Onlynumber(EmployeeNumber);
        //                            if (Number == "1")
        //                            {
        //                                _upsertEmployeeMaster.EmployeeNumber = EmployeeNumber;
        //                            }
        //                            else
        //                            {
        //                                dr["Status"] = "Enter Valid Employee number.";
        //                                _upsertEmployeeMaster.EmployeeNumber = EmployeeNumber;
        //                                success = false;
        //                            }

        //                            _upsertEmployeeMaster.FirstName = dr["EmployeeFirstName"].ToString();
        //                            _upsertEmployeeMaster.LastName = dr["EmployeeLastName"].ToString();

        //                            _upsertEmployeeMaster.UserID = UserId;
        //                            _upsertEmployeeMaster.BusinessID = BusinessId;
        //                            var GenderI = EmployeesBAL.Get_Genders(_upsertEmployeeMaster.UserID).ToList();
        //                            string Gender = dr["Gender"].ToString();
        //                            if (Gender != "" && Gender != null)
        //                            {
        //                                try
        //                                {
        //                                    var UserParentAccountsId = GenderI.Where(x => x.value == Gender).FirstOrDefault().key;
        //                                    _upsertEmployeeMaster.GenderID = Convert.ToInt16(UserParentAccountsId);
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    dr["Status"] = "Enter Valid Gender Name.";
        //                                    success = false;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                _upsertEmployeeMaster.GenderID = 1;
        //                            }

        //                            string Dateofbirth = dr["Dateofbirth"].ToString();

        //                            if (Dateofbirth != "" && Dateofbirth != null)
        //                            {
        //                                try
        //                                {
        //                                    _upsertEmployeeMaster.DOB = Convert.ToDateTime(Dateofbirth);

        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    dr["Status"] = "Enter Valid Date of birth.";
        //                                    success = false;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                _upsertEmployeeMaster.DOB = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));
        //                            }

        //                            string JoiningDate = dr["JoiningDate"].ToString();

        //                            if (JoiningDate != "" && JoiningDate != null)
        //                            {
        //                                try
        //                                {
        //                                    _upsertEmployeeMaster.JoiningDate = Convert.ToDateTime(JoiningDate);
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    dr["Status"] = "Enter Valid Joining Date.";
        //                                    success = false;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                _upsertEmployeeMaster.JoiningDate = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));
        //                            }

        //                            _upsertEmployeeMaster.EmployeeStatusID = 1;
        //                            _upsertEmployeeMaster.EmployeeModeID = 1;
        //                            _upsertEmployeeMaster.PayFrequencyID = 1;
        //                            _upsertEmployeeMaster.PaymentTypeID = 2;
        //                            _upsertEmployeeMaster.VacationAllowed = 0;


        //                            validateVendor = EmployeesBAL.CheckExists_EmployeeNumber(_upsertEmployeeMaster.EmployeeNumber, _upsertEmployeeMaster.BusinessID, null);
        //                            if (validateVendor)
        //                            {
        //                                validateVendor = EmployeesBAL.CheckExists_Employee(_upsertEmployeeMaster.FirstName, _upsertEmployeeMaster.LastName, _upsertEmployeeMaster.BusinessID, null);
        //                                if (validateVendor)
        //                                {
        //                                    _upsertEmployeeMaster.DeductionInsEmpId = 1;
        //                                    _upsertEmployeeMaster.DeductionInsEmplId = 2;
        //                                    _upsertEmployeeMaster.PensionInsEmpId = 3;
        //                                    _upsertEmployeeMaster.PensionInsEmplId = 4;


        //                                    _upsertEmployeeMaster.DeductionInsEmpPercent = _upsertEmployeeMaster.DeductionInsEmpPercent == null ? 0 : _upsertEmployeeMaster.DeductionInsEmpPercent;
        //                                    _upsertEmployeeMaster.DeductionInsEmplPercent = _upsertEmployeeMaster.DeductionInsEmplPercent == null ? 0 : _upsertEmployeeMaster.DeductionInsEmplPercent;
        //                                    _upsertEmployeeMaster.PensionInsEmpPercent = _upsertEmployeeMaster.PensionInsEmpPercent == null ? 0 : _upsertEmployeeMaster.PensionInsEmpPercent;
        //                                    _upsertEmployeeMaster.PensionInsEmplPercent = _upsertEmployeeMaster.PensionInsEmplPercent == null ? 0 : _upsertEmployeeMaster.PensionInsEmplPercent;

        //                                    MessagesObj = EmployeesBAL.AddEmployee(_upsertEmployeeMaster);

        //                                    if (MessagesObj.Result > 0)
        //                                    {
        //                                        SuccessCount++;
        //                                        TempData["success"] = "Successfully Saved Records : " + SuccessCount;
        //                                        success = true;
        //                                    }
        //                                    else
        //                                    {
        //                                        //FailedCount++;
        //                                        //TempData["Failed"] = MessagesObj.Message + "Failed :" + FailedCount;
        //                                        //dr["Status"] = "System Error.";
        //                                        //success = false;

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    dr["Status"] = EMSResources.FirstNameLastNamealreadyexists;
        //                                    success = false;
        //                                }

        //                            }
        //                            else
        //                            {
        //                                dr["Status"] = EMSResources.EmployeeNumberAlreadyExist;
        //                                success = false;
        //                            }

        //                        }

        //                        else
        //                        {
        //                            dr["Status"] = "Missing required data.";
        //                            success = false;
        //                        }

        //                    }
        //                    catch (Exception exp)
        //                    {

        //                        if (dr["EmployeeNumber"] != null && dr["EmployeeFirstName"] != null && dr["EmployeeLastName"] != null
        //                      && dr["EmployeeNumber"].ToString() != "" && dr["EmployeeFirstName"].ToString() != "" && dr["EmployeeLastName"].ToString() != "")
        //                        {
        //                            TempData["success"] = "Excel columns does not belongs to this Employee ";
        //                            //TempData["success"] = "Missing required data (or) Excel columns does not belongs to this Chart of account ";
        //                            res = 1;
        //                        }
        //                        else
        //                        {
        //                            success = false;
        //                        }

        //                    }
        //                    if (!success)
        //                        dterror.Rows.Add(dr.ItemArray);

        //                    TempData["AlreadyExistsData"] = dterror;

        //                    if (res == 1)
        //                        TempData["AlreadyExistsData"] = null;

        //                }
        //            }
        //            else
        //            {
        //                TempData["success"] = "Excel File Is Empty";
        //                TempData["mismatch"] = "1";
        //            }
        //        }
        //        else
        //        {
        //            Message = "Excel File Is Empty";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["success"] = "Excel columns does not belongs to this Employee ";
        //        TempData["AlreadyExistsData"] = null;
        //    }
        //    finally
        //    {
        //        excelConnection.Close();
        //    }

        //    return RedirectToAction("ImportEmployee");

        //}



        //public ActionResult DownloadSampleExcel()
        //{

        //    Response.ClearHeaders();
        //    Response.ClearContent();
        //    Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
        //    Response.Charset = "windows-1254";
        //    Response.ContentType = "application/ms-excel";
        //    Response.AppendHeader("Content-Disposition", "attachment;filename=SampleEmployee.xls");
        //    string FilePath = Server.MapPath("~/UploadDocuments/ExcelImports/SampleEmployee.xls");
        //    return File(FilePath, "application/vnd.ms-excel");

        //}

        //#endregion ImportExcel

    }
}
