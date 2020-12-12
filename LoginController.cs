using EMS.BAL;
using EMS.Entities;
//using EMS.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Security;

namespace EMS.Controllers
{
    public class LoginController : BasicController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }




        [HttpPost]
        [AllowAnonymous]
        public ActionResult UserVerification(User usermodel)//(string userName, string password, string captchaText, bool rememberToCheck = false)
        {
            #region Captcha code
            string userName = usermodel.Email;
            string password = usermodel.UserPassword;
            string captchaText = usermodel.Captcha;
            //string Skipcaptcha = "false";

            try
            {
                Session["userRole"] = null;
                var validation = new UserValidation();
                var loggedUser = validation.IsValidUser(userName, password.GetSHA1());

                //userDet = loggedUser.UserId;
                if (loggedUser == null)
                {
                    ModelState.AddModelError("Email", EMSResources.LoginFailed);
                    ViewBag.Pwd = usermodel.UserPassword;
                    //return View("Index");
                    return RedirectToAction("Index", "Home");
                }
                if (loggedUser.IsActive == false)
                {
                    ModelState.AddModelError("", EMSResources.DeactivatedUser);
                    ViewBag.Pwd = usermodel.UserPassword;
                    return View("Index");
                }
                //return Redirect("/SuperAdmin/ClientsList");
                if (loggedUser.BusinessStatusId == (int)BusinessStatus.Email_Not_Verified)
                {
                    ModelState.AddModelError("", EMSResources.AccountVerification);
                    ViewBag.Pwd = usermodel.UserPassword;
                    return View("Index");
                }
                //todo: Add LogMeout field value here
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    loggedUser.UserName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(100),//loggedUser.TimeLimit
                    usermodel.isRemember,
                    "Stratus User Data",
                    FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                // Redirect back to original URL.
                //Response.Redirect(FormsAuthentication.GetRedirectUrl(loggedUser.UserName, usermodel.isRemember));
                //FormsAuthentication.SetAuthCookie(loggedUser.UserName, usermodel.isRemember);
                Session["userInfo"] = loggedUser;
                BAL.UserValidation.LogSessionDetails(UserId, BusinessId, HttpContext.Session.SessionID);
                if (loggedUser.RoleName.Equals(EMSResources.SuperUserRole))
                {
                    Session["userRole"] = loggedUser.RoleName;
                    return RedirectToAction("ClientsList", "SuperAdmin");
                    //return Redirect(Url.Action("ClientsList", "SuperAdmin"));
                }


                if (loggedUser.BusinessStatusId == (int)BusinessStatus.Email_Verified)
                {
                    return RedirectToAction("MyProfile", "Home");
                    //return Redirect(Url.Action("MyProfile", "Home"));
                }
                if (loggedUser.BusinessStatusId == (int)BusinessStatus.Deactivated)
                {
                    ModelState.AddModelError("", EMSResources.AccountVerification);
                    return Redirect(@Url.Action("Index"));
                }
                
                var Result = BAL.ValidateScreens.CheckPermission(37, GroupId);
                if (Result == 1)
                {
                    ViewBag.Menus = new SelectList(BAL.Privileges.GetPrivileges());
                    Session["organization"] = ViewBag.Menus.Items[0].Module;
                    Session["OrganizationScreenId"] = ViewBag.Menus.Items[0].ModuleId;
                    Session["Employees"] = ViewBag.Menus.Items[1].Module;
                    Session["EmployeeScreenId"] = ViewBag.Menus.Items[1].ModuleId;
                    Session["LMS"] = ViewBag.Menus.Items[2].Module;
                    Session["LMSScreenId"] = ViewBag.Menus.Items[2].ModuleId;
                    Session["Approvals"] = ViewBag.Menus.Items[3].Module;
                    Session["ApprovalsScreenId"] = ViewBag.Menus.Items[3].ModuleId;
                    Session["Downloads"] = ViewBag.Menus.Items[4].Module;
                    Session["DownloadScreenId"] = ViewBag.Menus.Items[4].ModuleId;
                    Session["Chat History"] = ViewBag.Menus.Items[5].Module;
                    Session["ChatScreenId"] = ViewBag.Menus.Items[5].ModuleId;
                    Session["Payroll"] = ViewBag.Menus.Items[6].Module;
                    Session["PayrollScreenId"] = ViewBag.Menus.Items[6].ModuleId;
                    Session["Reports"] = ViewBag.Menus.Items[7].Module;
                    Session["ReportsScreenId"] = ViewBag.Menus.Items[7].ModuleId;
                }
                ViewBag.Permissions = new SelectList(BAL.Privileges.GetAllSCreensPermissions(BusinessId, GroupId, UserId));
                

                DateTime today = DateTime.Today; // As DateTime
                string RenewalDate = today.ToString("yyyy-MM-dd");

                DateTime Curr_date = Convert.ToDateTime(RenewalDate);
                DateTime Renew_date = Convert.ToDateTime(loggedUser.RenewalDate);

                if (Curr_date > Renew_date)
                {
                    TempData["RenewalDate"] = "1";
                    ViewBag.BusinessId = BusinessId;
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    TempData["RenewalDate"] = "0";
                    ViewBag.BusinessId = BusinessId;
                    return RedirectToAction("Dashboard", "Home");
                }

            }
            catch (MembershipCreateUserException e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                ModelState.AddModelError("", e.Message);
                return Redirect(@Url.Action("Index"));
            }

            // Entitiestate.AddModelError("", EMSResources.CaptchaVerificationFailed);
            ViewBag.Pwd = usermodel.UserPassword;
            //return View("Index");

            //return Redirect(@Url.Action("Index"));
            return RedirectToAction("Dashboard", "Home");

            #endregion Captcha code
        }

    }
}