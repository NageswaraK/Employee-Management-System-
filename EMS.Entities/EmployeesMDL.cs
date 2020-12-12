using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class TimeSheetMDL
    {
        public string AllDates { get; set; }
        public string AllDays { get; set; }
        public int BusinessId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string EmployeeName { get; set; }
        public DateTime FromDate { get; set; }
        public bool IsTimeSheet { get; set; }
        public int OverTimeHours { get; set; }
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int RegularHours { get; set; }
        public string SelectDate { get; set; }
        public string ShowDay { get; set; }
        public int SNo { get; set; }
        public int? TimeSheetId { get; set; }
        public DateTime ToDate { get; set; }
        public int? UserEmployeeId { get; set; }
        public int UserId { get; set; }
        public string WeekEndDay { get; set; }
        public string WeekStartDay { get; set; }
        public int TimesheetstatusId { get; set; }

    }

    public class VacationMDL
    {
        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public int? UserEmployeeId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int? LeaveId { get; set; }

        public int LeaveStatusId { get; set; }

        public String LeaveStatus { get; set; }

        public int SNo { get; set; }

        public int NoOfDays { get; set; }

        public String EmployeeName { get; set; }

        public int PTOAvailable { get; set; }

        public int PTOUsed { get; set; }

        public int PTORemaining { get; set; }

        public int PTOPlannedOrApproved { get; set; }

        public String Status { get; set; }

    }

    public class PayrollMDL
    {
        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public int? UserEmployeeId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime Date { get; set; }

        public int RegularHours { get; set; }

        public int OverTimeHours { get; set; }

        public String EmployeeName { get; set; }

        public Decimal Amount { get; set; }

        public String Status { get; set; }

        public int StatusId { get; set; }

        public int BankAccountsId { get; set; }

        public int? EmployeePayrollId { get; set; }

        public String BankName { get; set; }

        public String PayFromDate { get; set; }

        public String PayToDate { get; set; }
    }

    public class AddEmployeeMDL
    {
        public string Password { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidEmail")]
        public string Email { get; set; }

        public int BusinessID { get; set; }

        public int UserID { get; set; }

        public long UserEmployeeID { get; set; }

        public String EmployeeNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "GenderIdIsRequired")]
        public int GenderID { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "FirstNameIsRequired")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "LastNameIsRequired")]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        [RegularExpression(@"^[0-9]{9,9}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "SocialSecurityNumberIsNotValid")]
        public string SSN { get; set; }

        public string Title { get; set; }

        [Required(ErrorMessage = "EmployeeStatusId is Required")]
        public int EmployeeStatusID { get; set; }

        [Required(ErrorMessage = "EmploymentModeId is Required")]
        public int EmployeeModeID { get; set; }

        [Required(ErrorMessage = "PaymentFrequecyId is Required")]
        public int PayFrequencyID { get; set; }

        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "PaymentMethodId is Required")]
        public int PaymentTypeID { get; set; }

        public int? VacationAllowed { get; set; }

        public int DeductionInsEmpId { get; set; }

        [RegularExpression(@"^((0|[1-9]\d?)(\.\d{1,2})?|100(\.00?)?)$",
           ErrorMessage = "%age is  not valid")]
        public decimal? DeductionInsEmpPercent { get; set; }

        public int DeductionInsEmplId { get; set; }

        [RegularExpression(@"^((0|[1-9]\d?)(\.\d{1,2})?|100(\.00?)?)$",
           ErrorMessage = "%age is  not valid")]
        public decimal? DeductionInsEmplPercent { get; set; }

        public int PensionInsEmpId { get; set; }

        [RegularExpression(@"^((0|[1-9]\d?)(\.\d{1,2})?|100(\.00?)?)$",
           ErrorMessage = "%age is  not valid")]
        public decimal? PensionInsEmpPercent { get; set; }

        public int PensionInsEmplId { get; set; }

        [RegularExpression(@"^((0|[1-9]\d?)(\.\d{1,2})?|100(\.00?)?)$",
           ErrorMessage = "%age is  not valid")]
        public decimal? PensionInsEmplPercent { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
           ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidEmail")]
        public string OfficeEmail { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
           ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidEmail")]
        public string PersonalEmail { get; set; }

        public string HomeAddress { get; set; }

        public string AlternateAddress { get; set; }

        public string HomePhone { get; set; }

        public string HomeFax { get; set; }

        [RegularExpression(@"^[0-9]{10,12}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public string PersonalMobile { get; set; }

        [RegularExpression(@"^[0-9]{10,12}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public string OfficeMobile { get; set; }

        public string BankName { get; set; }

        public string AccountNum { get; set; }

        public int? BankAccountTypeID { get; set; }

        //[RegularExpression(@"^[0-9]{1,15}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "RoutingNumberIsNotValid")]
        public string RoutingNum { get; set; }

        public string BankAddress { get; set; }

        public string AccountTypeDesc { get; set; }

        public int? BankAccountTypeId { get; set; }

        public List<AddEmployeeFamilyMDL> _listFamilyDetails { get; set; }

        public int EmployeeDesignationID { get; set; }

        public int ReportManagerTo { get; set; }

        public decimal EmployeeCTC { get; set; }

        public string PAN { get; set; }

        public string PF { get; set; }

        public string UAN { get; set; }

        public int LocationId { get; set; }

        public string EmployeeAssetId { get; set; }

        public string EmployeeAssetMake { get; set; }

        public string EmployeeAssetModel { get; set; }

        public string EmployeeAssetBarcode { get; set; }

        public int EmployeeRoleId { get; set; }
    }

    public class AddEmployeeFamilyMDL
    {
        public int BusinessID { get; set; }

        public int UserID { get; set; }

        public long UserEmployeeID { get; set; }

        public int FamilyRelationID { get; set; }

        public string FamilyFirstName { get; set; }

        public string FamilyLastName { get; set; }

        public int FamilyGenderID { get; set; }

        public DateTime FamilyDOB { get; set; }

        [RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$",
          ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public string FamilyPhone { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
             ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidEmail")]
        public string FamilyEmail { get; set; }

        public List<KeyValueVM> GenderList { get; set; }

        public List<KeyValueVM> RelationList { get; set; }
    }

    public class EmployeeListMDL
    {
        public long UserEmployeeId { get; set; }

        public int BusinessID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string SSN { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string EmployeeStatus { get; set; }

        public string EmploymentMode { get; set; }

        public string PayFrequency { get; set; }

        public int GenderId { get; set; }

        public int StatusId { get; set; }

        public int EmploymentModeId { get; set; }

        public int PayFrequecyId { get; set; }

        public int UserAccountsId { get; set; }

        public string PersonalMobile { get; set; }

        public string FullName { get; set; }

        public int Result { get; set; }

        public string DisplayName { get; set; }

    }

    public class EmploymentDetailsMDL
    {
        public int BusinessId { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "FirstNameIsRequired")]
        //[Remote("IsExistingEmp", "Employees", AdditionalFields = "LastName,UserEmployeeId", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "FirstNameAlreadyExists")]
        public String FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "LastNameIsRequired")]
        //[Remote("IsExistingEmp", "Employees", AdditionalFields = "FirstName,UserEmployeeId", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "LastNameAlreadyExists")]
        public String LastName { get; set; }

        public String Gender { get; set; }

        public String Title { get; set; }

        public String Status { get; set; }

        [RegularExpression(@"^[0-9]{9,9}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "SocialSecurityNumberIsNotValid")]
        public String SocialSecurityNumber { get; set; }

        public String Employment { get; set; }

        public String ContractSince { get; set; }

        public String PaymentMethod { get; set; }

        public String PaymentFrequency { get; set; }

        public String ImagePath { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "GenderIdIsRequired")]
        public int GenderId { get; set; }

        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "EmployeeStatusId is Required")]
        public int EmployeeStatusId { get; set; }

        [Required(ErrorMessage = "EmploymentModeId is Required")]
        public int EmploymentModeId { get; set; }

        [Required(ErrorMessage = "PaymentMethodId is Required")]
        public int PaymentMethodId { get; set; }

        [Required(ErrorMessage = "PaymentFrequecyId is Required")]
        public int PaymentFrequecyId { get; set; }

        public DateTime JoiningDate { get; set; }

        public int PaymentTypeId { get; set; }

        public int? VacationAllowed { get; set; }

        public int UserEmployeeId { get; set; }

        public int UserAccountsId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterEmployeeNumber")]
        //[Remote("IsExistEmpNumber", "Employees", HttpMethod = "POST", AdditionalFields = "UserEmployeeId", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "EmployeeNumberAlreadyExists")]
        public string EmployeeNumber { get; set; }

        public String EmployeeFullName { get; set; }

        public int Result { get; set; }

        public String Message { get; set; }

        public String JoinedDate { get; set; }

        public string PAN { get; set; }

        public string PF { get; set; }

        public string UAN { get; set; }
    }

    public class EmployeeCommunicationDetailsMDL
    {
        public int BusinessId { get; set; }

        public int UserId { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
           ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidEmail")]
        public String OfficieEmail { get; set; }

        [RegularExpression(@"^[0-9]{10,12}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public String OfficeMobile { get; set; }

        [RegularExpression(@"^[0-9]{10,12}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public String PersonalMobile { get; set; }

        public String HomeAddress { get; set; }

        public String HomePhone { get; set; }

        public String HomeFAX { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
           ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidEmail")]
        public String PersonalEmail { get; set; }

        public String AlternateAddress { get; set; }

        public int UserEmployeeId { get; set; }
    }

    public class EmployeeBankDetailsMDL
    {
        public int BusinessId { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "BankNameIsRequired")]
        public String BankName { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidAccountNumber")]
        public String Account { get; set; }

        public String AccountType { get; set; }

        [RegularExpression(@"^[0-9]{1,15}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "RoutingNumberCannotBeEmpty")]
        public String Routing { get; set; }

        public String BankAddress { get; set; }

        public int BankAccountsId { get; set; }

        public int BankAccountTypeId { get; set; }

        public int UserEmployeeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "AccountTypeIsRequired")]
        public String AccountTypeName { get; set; }

    }

    public class EmployeeFamilyDetailsMDL
    {
        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public String Relation { get; set; }

        public String Name { get; set; }

        public String Gender { get; set; }

        public DateTime DOB { get; set; }

        [RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$",
           ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public String Phone { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidEmail")]
        public String Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "FirstNameIsRequired")]
        public String FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "LastNameIsRequired")]
        public String LastName { get; set; }

        public int GenderId { get; set; }

        public int RelationId { get; set; }

        public int UserEmployeeId { get; set; }

        public int FamilyDetailsId { get; set; }

        public List<KeyValueVM> GenderList { get; set; }

        public List<KeyValueVM> RelationList { get; set; }

    }

    public class EmployeeDeductionsMDL
    {
        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public int UserEmployeeId { get; set; }

        public int DeductionTypesId { get; set; }

        public String DeductionType { get; set; }

        [RegularExpression(@"^((0|[1-9]\d?)(\.\d{1,2})?|100(\.00?)?)$",
           ErrorMessage = "%age is  not valid")]
        public Decimal? DeductionPercent { get; set; }
    }

    public class TimeSheetDetailsMDL
    {
        public string EmployeeName { set; get; }

        public int TimesheetId { get; set; }

        public DateTime Date { get; set; }

        public String Description { get; set; }

        public String RegularHours { get; set; }

        public String OverTimeHours { get; set; }

        public int UserEmployeeId { get; set; }

        public int ProjectId { get; set; }

        public int SNo { get; set; }

        public String Project { get; set; }

        public int TimesheetstatusId { get; set; }
    }

    public class VacationStatusMDL
    {
        public int LeaveId { get; set; }

        public int UserEmployeeId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int LeaveStatusId { get; set; }

        public String LeaveStatus { get; set; }

        public int Days { get; set; }

        public int SNo { get; set; }

        public String EmployeeName { get; set; }
    }

    public class PayrollStatusMDL
    {
        public DateTime Date { get; set; }

        public String RegularHours { get; set; }

        public String OverTimeHours { get; set; }

        public String Amount { get; set; }

        public String Status { get; set; }

        public int StatusId { get; set; }

        public String EmployeeName { get; set; }

        public int BankAccountsId { get; set; }

        public int EmployeePayrollId { get; set; }

        public int UserEmployeeId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

    }
}
