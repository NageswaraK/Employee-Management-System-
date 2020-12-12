using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class Employees_DTO
    {
        public EmployeeListDetails EmployeeListDetails { get; set; }

        public EmployeeBankDetails EmployeeBankDetails { get; set; }

        public EmployeeCommunicationDetails EmployeeCommunicationDetails { get; set; }

        public EmployeeFamilyDetails EmployeeFamilyDetails { get; set; }

        public EmployeeDeductions EmployeeDeductions { get; set; }

        public EmployeePayrollStatus EmployeePayrollStatus { get; set; }

        public EmployeeVacationStatus EmployeeVacationStatus { get; set; }

        public EmployeeTimeSheetDetails EmployeeTimeSheetDetails { get; set; }
    }

    public class EmployeeListDetails
    {
        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "FirstNameIsRequired")]
        //[Remote("IsExistingEmp", "Employees", AdditionalFields = "LastName,UserEmployeeId", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "FirstNameLastNameAlreadyExists")]
        public String FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "LastNameIsRequired")]
        //[Remote("IsExistingEmp", "Employees", AdditionalFields = "FirstName,UserEmployeeId", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "FirstNameLastNameAlreadyExists")]
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

    }

    public class EmployeeBankDetails
    {
        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "BankNameIsRequired")]
        public String BankName { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidAccountNumber")]
        public String Account { get; set; }

        public String AccountType { get; set; }

        [RegularExpression(@"^[0-9]{9,9}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "RoutingNumberCannotBeEmpty")]
        public String Routing { get; set; }

        public String BankAddress { get; set; }

        public int BankAccountsId { get; set; }

        public int BankAccountTypeId { get; set; }

        public int UserEmployeeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "AccountTypeIsRequired")]
        public String AccountTypeName { get; set; }



    }

    public class EmployeeCommunicationDetails
    {
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
           ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidEmail")]
        public String OfficieEmail { get; set; }

        [RegularExpression(@"^[0-9]{10,12}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public String OfficeMobile { get; set; }

        [RegularExpression(@"^[0-9]{10,12}$", ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public String PersonalMobile { get; set; }

        public String HomeAddress { get; set; }

        //[RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$",
        //   ErrorMessage = "Home Phone is  not valid")]
        public String HomePhone { get; set; }

        //[RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$",
        //   ErrorMessage = "Home Fax is  not valid")]
        public String HomeFAX { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
           ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "PleaseEnterValidEmail")]
        public String PersonalEmail { get; set; }

        public String AlternateAddress { get; set; }

        public int UserEmployeeId { get; set; }
    }

    public class EmployeeFamilyDetails
    {
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

    public class EmployeeDeductions
    {
        public int UserEmployeeId { get; set; }

        public int DeductionTypesId { get; set; }

        public String DeductionType { get; set; }

        [RegularExpression(@"^((0|[1-9]\d?)(\.\d{1,2})?|100(\.00?)?)$",
           ErrorMessage = "%age is  not valid")]
        public Decimal? DeductionPercent { get; set; }
    }

    public class EmployeePayrollStatus
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

    public class EmployeeVacationStatus
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

    public class EmployeeTimeSheetDetails
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
    }

}
