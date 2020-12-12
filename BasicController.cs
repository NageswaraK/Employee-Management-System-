using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    [Authorize]
    public class BasicController : Controller
    {
        private int _userId;
        private int _businessId;
        private int _roleId;
        private int _useremployeeId;
        private string _userName;
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

        public int RoleId
        {
            get
            {
                if (Session["userInfo"] !=null)
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


        public string UserName
        {
            get
            {
                if(Session["userInfo"] !=null)
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

                //if (_userId == 0)
                //{
                //    if (HttpRuntime.Cache["UserId"] == null)
                //    {
                //        SessionExpires();
                //    }
                //    _userId = Convert.ToInt32(HttpRuntime.Cache["UserId"]);
                //}
                //_businessId = Convert.ToInt32(HttpRuntime.Cache["BusinessId"]);//db.BusinessRegistrations.Find(this._userId).BusinessID; //1;
                //return _businessId;
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

    }
}