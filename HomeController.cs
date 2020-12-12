using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS.Entities;
using System.Configuration;
using System.Web.Security;
using EMS.BAL;
using System.Web.Caching;
using System.Security.Policy;
using System.IO;
using Elmah;
using System.Data;
using System.Data.SqlClient;
//using EMS.Helper;

namespace EMS.Controllers
{

    [AllowAnonymous]
    public class HomeController : BasicController
    {

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult GetCompanyName(string Name)
        {
            ViewBag.Name = Name;
            ViewBag.CustomersRename = CustomersRename;

            return PartialView(BAL.Users.GetCompanyName(BusinessId, UserId));
        }
        //[AllowAnonymous]
        //public CaptchaImageResult ShowCaptchaImage()
        //{
        //    return new CaptchaImageResult();
        //}

        #region Dashboard(AR)

        //[Authorize]
        //[OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Dashboard()
        {
            if (Session["userInfo"] == null)
            {
                return Redirect(@Url.Action("Index"));
            }
            DashboardDocs _DashboardDocs = null;
            ViewBag.RoleId = RoleId;
            ViewBag.UserId = UserId;
            ViewBag.UserName = UserName;
            ViewBag.UserSessionEmployeeId = UserSessionEmployeeId;
            var balance = BAL.PreferencesBAL.GetManageLeaveDetails(this.BusinessId).FirstOrDefault();
            ViewBag.NoOfLeaves = balance == null ? 0 : balance.Leavevalue;
            _DashboardDocs = BAL.Dashboard.GetDashboardDocs(BusinessId, UserId, RoleId, UserSessionEmployeeId);
           // ViewBag.NoOfLeaves = _DashboardDocs.CountOfNoOfLeaves;
            ViewBag.NoOfResignations = _DashboardDocs.CountOfNoOfResignations;
            ViewBag.PendingTimesheets = _DashboardDocs.CountOfPendingTimeSheets;
            ViewBag.NoOfNewJoinees = _DashboardDocs.CountOfNoOfNewJoinees;
            ViewBag.PayrollHeadCount = _DashboardDocs.NoOfEmployees;
            ViewBag.PayrollFnfPending = 0;
            ViewBag.PayrollOnNotice = 0;
            Session["HeadCount"] = _DashboardDocs.NoOfEmployees;
            Session["GrossSalary"] = _DashboardDocs.GrossSalary;
            Session["TotalDeductions"] = _DashboardDocs.TotalDeductions;
            Session["ProvidentFund"] = _DashboardDocs.ProvidentFund;
            Session["ProfessionTax"] = _DashboardDocs.ProfessionTax;
            Session["TotalESIC"] = _DashboardDocs.TotalESIC;
            var loggeduserinfo = (BAL.LoggedUser)Session["userInfo"];
            if (loggeduserinfo.BusinessStatusId != (int)BusinessStatus.Activated)
                return Redirect(@Url.Action("Index"));

            return View();
        }

        

        public ActionResult SalesdashBoardYear(int Year)
        {
            TempData["ARYear"] = Year;
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public ActionResult DashboradChart(int Year)
        {
            return Json(BAL.Dashboard.QuartersChart(BusinessId, Year), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalesByYear(int Year)
        {
            ViewBag.Year = Year;
            ViewBag.PreferredCurrency = PreferredCurrency;
            return PartialView(BAL.Dashboard.SalesByYear(BusinessId, Year));
        }

        public ActionResult FirstQuarter(int Year)
        {
            ViewBag.Year = Year;
            ViewBag.PreferredCurrency = PreferredCurrency;
            return PartialView(BAL.Dashboard.Quarters(BusinessId, Year, 1));
        }

        public ActionResult SecondQuarter(int Year)
        {
            ViewBag.Year = Year;
            ViewBag.PreferredCurrency = PreferredCurrency;
            return PartialView(BAL.Dashboard.Quarters(BusinessId, Year, 2));
        }

        public ActionResult ThirdQuarter(int Year)
        {
            ViewBag.Year = Year;
            ViewBag.PreferredCurrency = PreferredCurrency;
            return PartialView(BAL.Dashboard.Quarters(BusinessId, Year, 3));
        }

        public ActionResult FourthQuarter(int Year)
        {
            ViewBag.Year = Year;
            ViewBag.PreferredCurrency = PreferredCurrency;
            return PartialView(BAL.Dashboard.Quarters(BusinessId, Year, 4));
        }

        public ActionResult TopTenCustomers(int Year)
        {
            ViewBag.Year = Year;
            ViewBag.PreferredCurrency = PreferredCurrency;
            return PartialView(BAL.Dashboard.TopTenCustomers(BusinessId, Year));
        }

        public ActionResult CustomersOwing(int Year)
        {
            ViewBag.Year = Year;
            ViewBag.PreferredCurrency = PreferredCurrency;
            return PartialView(BAL.Dashboard.CustomersOwing(BusinessId, Year));
        }



        #endregion Dashboard(AR)


        
        public FileResult GetLogoImage()
        {
            var folderpath = ConfigurationManager.AppSettings["LogoImageFolder"].ToString();
            string imagename = folderpath + "/" + "avatar.png";
            var actualpath = System.Web.HttpContext.Current.Server.MapPath(folderpath);
            var searchstring = BusinessId.ToString();
            var files = Directory.GetFiles(actualpath, searchstring + ".*");
            if (files.Length > 0)
            {
                imagename = folderpath + "/" + Path.GetFileName(files[0]);

            }
            return File(imagename, "image/jpg");

        }

        public string GetLogoImageName()
        {

            var folderpath = ConfigurationManager.AppSettings["LogoImageFolder"].ToString();
            string imagename = folderpath + "/" + "avatar.png";
            imagename = imagename.Replace("~", "");
            var actualpath = System.Web.HttpContext.Current.Server.MapPath(folderpath);
            var searchstring = BusinessId.ToString();
            var files = Directory.GetFiles(actualpath, searchstring + ".*");
            if (files.Length > 0)
            {
                imagename = folderpath + "/" + Path.GetFileName(files[0]);
                imagename = @Url.Content(imagename);
            }
            return imagename;
        }



        #region MyProfile

        [Authorize]
        [HttpGet]
        public ActionResult MyProfile()
        {
            try
            {

                ViewBag.LogmeOut = new SelectList(BAL.Users.Get_LogmeOut(), "key", "value");
                var profile = BAL.Users.GetProfileDetails(UserId, BusinessId);
                ViewBag.RenewalDate = profile.EndDate.ToPreferenceDateTime((string)ViewBag.PreferenceDt);
                return View(profile);
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                ModelState.AddModelError("", "ErrorwhilegettingdataTryagain");
                return View("MyProfile");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult MyProfile(MyProfileMDL users)
        {
            string Message = string.Empty;
            try
            {
                bool saveFlag = false;
                //int userId = 16;
                saveFlag = BAL.Users.SaveProfileDetails(users, BusinessId, UserId);
                var user = BAL.Users.GetProfileDetails(UserId, BusinessId);
                ViewBag.RenewalDate = user.EndDate.ToPreferenceDateTime((string)ViewBag.PreferenceDt);
                ViewBag.LogmeOut = new SelectList(BAL.Users.Get_LogmeOut(), "key", "value");
                ViewBag.Success = "SavedSuccessfully";
                // MyPorfileImage(UploadImage);
                ViewBag.UserId = UserId;
                if (saveFlag)
                {
                    Message = "Success";
                }
                else
                {
                    Message = "Failed";
                }
                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Success ="Errorwhilesavingyourprofile";
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            ViewBag.LogmeOut = new SelectList(BAL.Users.Get_LogmeOut(), "key", "value");
            return View("MyProfile", users);
        }


        public ActionResult MyProfileImageUpload()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult MyProfileImageUpload(HttpPostedFileBase UploadImage)
        {
            try
            {
                Images Image = new Images();
                Image.BusinessID = BusinessId;
                Image.UserID = UserId;
                Image.UserTypeID = 2;
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
                

                return RedirectToAction("MyProfile", new { id = UserId });
            }
            catch(Exception ex)
            {
                ExceptionLog.WriteLog(ex, "Method:MyProfileImageUpload,Parameters: UploadImage=" + UploadImage);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }
        }
        [HttpPost]
        public ActionResult Upload()
        {

            string Message = string.Empty;
            try
            {
                HttpPostedFileBase UploadImage = Request.Files[0];

                Images Image = new Images();
                Image.BusinessID = BusinessId;
                Image.UserID = UserId;
                Image.UserTypeID = 2;
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
                Message = "Success";
                
                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // ViewBag.Success = StratusResources.Errorwhilesavingyourprofile;
                //ErrorSignal.FromCurrentContext().Raise(ex);
                Message = ex.Message;
            }
            // ViewBag.LogmeOut = new SelectList(BAL.Users.Get_LogmeOut(), "key", "value");
            return Json(Message, JsonRequestBehavior.AllowGet);

            //return View("MyProfile", users);


        }

        #endregion MyProfile

        #region Logout

        [Authorize]
        public ActionResult Logout()
        {
            BAL.UserValidation.UpdateSessionDetails(UserId, BusinessId, HttpContext.Session.SessionID);
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.RemoveAll();
            return Redirect("Index");
        }

        #endregion Logout

        #region ForgetPassword

        [AllowAnonymous]
        public JsonResult ForgetPassword(string email)
        {
            bool chckEmail = false;
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    int userID = BAL.UserValidation.IsExistedEmail(email);
                    if (userID > 0)
                    {
                        Guid newPwd = Guid.NewGuid();
                        string newGuidPwd = (newPwd.ToString()).Substring(0, 6);
                        //save in db
                        chckEmail = BAL.UserValidation.UpdatePassword(newGuidPwd.GetSHA1(), userID);
                    }
                }
                return Json("sucess", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return Json("Failure", JsonRequestBehavior.AllowGet); ;
            }
        }

        #endregion ForgetPassword

        
    }


}
