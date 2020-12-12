using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS.Entities;
using EMS.BAL;
using System.Configuration;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;
using Elmah;

namespace EMS.Controllers
{
    public class LMSController : Controller
    {
        private int _userId;
        private int _businessId;
        private int _roleId;
        private string msg;
        private int _useremployeeId;
        private string _UserName;
        private EMS.BAL.LoggedUser loggedUser = null;

        #region CommonMethods


        public ActionResult SessionExpires()
        {
            return RedirectToAction("Logout", "Home");
        }

        public int BusinessId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _businessId = loggedUser.BusinessId;
                    return _businessId;
                }
                else
                {
                    SessionExpires();
                    return 0;
                }

            }
        }

        public int UserId
        {
            get
            {
                if (Session["userInfo"] != null)
                {
                    loggedUser = (EMS.BAL.LoggedUser)Session["userInfo"];
                    _userId = loggedUser.UserId;
                    return _userId;
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
                    _UserName = loggedUser.UserName;
                    return _UserName;
                }
                else
                {
                    SessionExpires();
                    return "";
                }

            }
        }

        #endregion CommonMethods
        public ActionResult ApplyLeave()
        {
            LMS _ApplyLeave = new LMS();

            ViewBag.EmployeeList = new SelectList(LMSBAL.Get_Employees(UserId, BusinessId), "key", "value");
            ViewBag.LeaveList = new SelectList(LMSBAL.Get_LeaveType(UserId), "key", "value");
            ViewBag.ReasonList = new SelectList(LMSBAL.Get_ReasonType(UserId), "key", "value");
            ViewBag.UserName = UserName;
            ViewBag.RoleId = RoleId;
            ViewBag.UserEmployeeId = UserSessionEmployeeId;
            var balance = BAL.PreferencesBAL.GetManageLeaveDetails(this.BusinessId).FirstOrDefault();
            if (balance == null)
            {
                ViewBag.CurrentBalance = 0;
            }
            else
            {
                ViewBag.CurrentBalance = balance.Leavevalue;
            }
            return View();
        }

        [HttpGet]
        public ActionResult ViewApplyLeave()
        {
            ViewBag.UserId = UserId;
            ViewBag.UserName = UserName;
            ViewBag.RoleId = RoleId;
            ViewBag.EmployeeList = new SelectList(LMSBAL.Get_Employees(UserId, BusinessId), "key", "value");
            ViewBag.LeaveYearList = new SelectList(LMSBAL.Get_Years(UserId), "key", "value");
            //ViewBag.UserEmployeeId = UserEmployeeId;
            //ViewBag.EmployeeName = EmployeeName;

            return View();
        }

        public JsonResult Get_EmpAutoFiling(string keyword)
        {
            return Json(EmployeesBAL.Get_EmpAutoFiling(BusinessId, UserId, keyword), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployeeLeaveDetails(int EmployeeID, int LeaveYearID)
        {
            ViewApplyLeave _EmpLeave = new ViewApplyLeave
            {
                BusinessId = BusinessId,
                UserId = UserId,
                UserEmployeeId = EmployeeID,
                Year = LeaveYearID
            };
            ViewBag.RoleId = RoleId;
            var UserEmplyeeId = UserSessionEmployeeId;
            var EmpLeaveDetails = LMSBAL.Get_EmpLeaveDetailsList(_EmpLeave, RoleId, UserEmplyeeId);
            ViewBag.EmployeeLeaveData = EmpLeaveDetails;

            return PartialView(EmpLeaveDetails);

        }



        public ActionResult ModifyWeeklyOff()
        {
            ViewBag.EmployeeList = new SelectList(LMSBAL.Get_Employees(UserId, BusinessId), "key", "value");
            return View();
        }

        [HttpPost]
        public ActionResult AddApplyLeave(string EmployeeID, string FromDate, string ToDate, string LeaveTypeId, string LeaveReasonId, string Description)
        {
            string Message = string.Empty;

            ExceptionLog.WriteDebugLog("methodname:SaveDocuments", "FromDate=" + FromDate + "ToDate=" + ToDate + "EmployeeID=" + EmployeeID + "LeaveTypeId=" + LeaveTypeId + "LeaveReasonId=" + LeaveReasonId + "Description=" + Description);
            try
            {
                HttpPostedFileBase file1 = null;
                string fname1 = "";

                LMS _LMS = new LMS();
                _LMS.BusinessId = BusinessId;
                _LMS.UserId = UserId;
                _LMS.UserEmployeeId = Convert.ToInt32(EmployeeID);
                _LMS.FromDate = DateTime.ParseExact(FromDate, "MM/dd/yyyy", null);
                _LMS.ToDate = DateTime.ParseExact(ToDate, "MM/dd/yyyy", null);
                _LMS.LeaveTypeId = Convert.ToInt32(LeaveTypeId);
                _LMS.LeaveReasonId = Convert.ToInt32(LeaveReasonId);
                _LMS.CurrentLeaveBalance = 0;
                _LMS.EffectiveLeave = 0;
                _LMS.Description = Description;


                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files1 = Request.Files;
                    for (int i = 0; i < files1.Count; i++)
                    {
                        file1 = files1[i];

                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file1.FileName.Split(new char[] { '\\' });
                            fname1 = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname1 = file1.FileName;
                        }
                    }
                }
                //_DocumentCabinet.FilePath =Path.Combine(ConfigurationManager.AppSettings["FilepathPdf"].ToString());
                _LMS.FilePath = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["LeavesFilePath"].ToString()), fname1);
                CommonMessages MessagesObj = new CommonMessages();
                MessagesObj = BAL.LMSBAL.SaveEmployeeLeave(_LMS);
                if (MessagesObj.Result > 0)
                {
                    string extension = Path.GetExtension(fname1);
                    fname1 = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["LeavesFilePath"].ToString()), MessagesObj.Result + extension);
                    if (System.IO.File.Exists(fname1))
                    {
                        System.IO.FileInfo fileinfo = new System.IO.FileInfo(fname1);
                        fileinfo.Delete();
                        file1.SaveAs(fname1);
                    }
                    else
                    {
                        //file1.SaveAs(fname1);
                    }
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
                ExceptionLog.WriteLog(ex, "Method:AddApplyLeave,Parameters: EmployeeID=" + EmployeeID + ",FromDate=" + FromDate + ",ToDate=" + ToDate + ",LeaveTypeId=" + LeaveTypeId + ",LeaveReasonId=" + LeaveReasonId + ",Description=" + Description);
                ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }

        
        [HttpGet]
        public ActionResult CancelLeave(int UserEmployeeId, int EmployeeLeaveId, int LeaveStatusId, string LeaveType, string FromDate, string ToDate, string EffectiveLeave)
        {
            ViewApplyLeave _CancelLeave = new ViewApplyLeave
            {
                UserEmployeeId = UserEmployeeId,
                EmployeeLeaveId = EmployeeLeaveId,
                BusinessId = BusinessId,
                LeaveStatusId = LeaveStatusId
                //EmployeeName = EmployeeName
            };
            ViewBag.LeaveStatusId = LeaveStatusId;
            ViewBag.LeaveType = LeaveType;
            ViewBag.FromDate = FromDate;
            ViewBag.ToDate = ToDate;
            ViewBag.EffectiveLeave = EffectiveLeave;
            if (LeaveStatusId == 2)
            {
                ViewBag.msg = "Approved";
            }
            else if (LeaveStatusId == 4)
            {
                ViewBag.msg = "Revoked";
            }
            else if (LeaveStatusId == 3)
            {
                ViewBag.msg = "Availed";
            }
            else
            {
                ViewBag.msg = "Cancel";
            }
            return PartialView(_CancelLeave);
        }

       

        [HttpPost]
        public ActionResult CancelLeave(ViewApplyLeave _CancelLeave)
        {
            string Message = string.Empty;
            CommonMessages MessagesObj = new CommonMessages();
            _CancelLeave.BusinessId = BusinessId;
            _CancelLeave.UserId = UserId;
            if (_CancelLeave.LeaveStatusId == 2)
            {
                msg = "Approved";
            }
            if (_CancelLeave.LeaveStatusId == 3)
            {
                msg = "Availed";
            }
            if (_CancelLeave.LeaveStatusId == 4)
            {
                msg = "Revoke";
            }
            MessagesObj = LMSBAL.CancelLeave(_CancelLeave);
            if (MessagesObj.Result > 0)
            {
                Message = "Leave " + msg + " Successfully";
            }
            else
            {
                Message = MessagesObj.Message;
            }

            return Json(Message, JsonRequestBehavior.AllowGet);
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

        public ActionResult HolidaysMapping()
        {
            HolidaysMapping _HolidaysMapping = new HolidaysMapping();

            ViewBag.EmployeeList = new SelectList(LMSBAL.Get_Employees(UserId, BusinessId), "key", "value");
            ViewBag.Locations = new SelectList(LMSBAL.Get_Locations(), "key", "value");
            ViewBag.CompanyNames =new SelectList(LMSBAL.GetCompanyName(BusinessId, UserId), "key", "value");
            ViewBag.UserName = UserName;
            ViewBag.RoleId = RoleId;
            return View();
        }

    }
}