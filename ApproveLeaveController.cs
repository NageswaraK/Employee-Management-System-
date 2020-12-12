using EMS.BAL;
using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.IO;
using System.Web.UI;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
using System.Reflection;

namespace EMS.Controllers
{
    public class ApproveLeaveController : Controller
    {

        private int _userId;
        private int _businessId;
        private int _GroupNameId;
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
        #endregion
        public ActionResult ApproveLeave()
        {
            try
            {
                return View();
            }
            catch(Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:ApproveLeave");
                return null;
            }
        }

        [HttpGet]
        public ActionResult GetApproveLeaves()
        {
            try
            {
                return View();
            }
            catch(Exception Ex)
            {
                ExceptionLog.WriteLog(Ex, "MethodName:GetApproveLeaves");
                return null;
            }
        }

        public ActionResult ApproveWeeklyOff()
        {
            return View();
        }

        public ActionResult ApproveHolidays()
        {
            return View();
        }
        public JsonResult Get_EmpAutoFiling(string keyword)
        {
            return Json(EmployeesBAL.Get_EmpAutoFiling(BusinessId, UserId, keyword), JsonRequestBehavior.AllowGet);
        }
    }
}