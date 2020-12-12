using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class UsersRegistration
    {
        public User UsersInfo { get; set; }
        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterCaptcha")]
        public string Captcha { get; set; }
    }

    
    public class ManageLeaveMDL
    {
        public int BusinessID { get; set; }
        public Nullable<decimal> Leavevalue { get; set; }
        public int BusinessLeaveDetailId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int ModifiedByUserId { get; set; }
        public bool IsActive { get; set; }

    }

    public class UserCustomers
    {
        public long UserCustomerId { get; set; }
        public int BusinessID { get; set; }
        public string CompanyName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public Nullable<short> BusinessTypeId { get; set; }
        public Nullable<bool> IsProfitType { get; set; }
        public string Website { get; set; }
        public Nullable<short> CreditPeriodTypeId { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public Nullable<short> PaymentTypesId { get; set; }
        public string CreditCardToken { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedByUserId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<long> UserAccountsId { get; set; }
        public Nullable<bool> IsTaxable { get; set; }
        public string Title { get; set; }

    }

    public class OfferLetterMDL
    {
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public int EmployeeDesignationID { get; set; }
        public string EmployeeDesignationName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public Nullable<decimal> Basic { get; set; }
        public Nullable<decimal> HouseAllowance { get; set; }
        public Nullable<decimal> TransportAllowance { get; set; }
        public Nullable<decimal> MedicalAllowance { get; set; }
        public Nullable<decimal> EducationAllowance { get; set; }
        public Nullable<decimal> PPE { get; set; }
        public Nullable<decimal> OtherAllowance { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime Date { get; set; }
    }
}
