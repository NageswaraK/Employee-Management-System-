using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMS.Entities
{
    public partial class User
    {
        public string ConfirmPassword { get; set; }

        public string AddressLine1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public DateTime RenewalDate { get; set; }

        public string BusinessFax { get; set; }

        public int CityId { get; set; }

        public int StateId { get; set; }

        public int CountryId { get; set; }

        public int LogMeOutId { get; set; }

        public string Email { get; set; }
        public string UserPassword { get; set; }



        public string OldPassword { get; set; }

        //[Required]
        public string NewPassword { get; set; }

        public bool isRemember { get; set; }

        [Required(ErrorMessage = "Please enter Captcha")]
        public string Captcha { get; set; }

    }

    public partial class BusinessRegistration
    {
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public string Password { get; set; }

        public int LogMeOutId { get; set; }

        public String ImagePath { get; set; }

        public String BusinessWebsite { get; set; }

        public string BusinessName { get; set; }

        public string AddressLine1 { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public Nullable<short> CountryId { get; set; }

        public Nullable<int> Licences { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public int CreatedByUserId { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

    }

    public partial class UserProfile 
    {
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string BusinessName { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string AddressLine1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public string Password { get; set; }

        public int StateId { get; set; }

        public int CountryId { get; set; }

        public int Licences { get; set; }

        public int LogMeOut1 { get; set; }

        public DateTime? EndDate { get; set; }

        public int CityId { get; set; }
    }

    public partial class Reconcile : ModelHelper
    {
        public string AccountName { get; set; }

        public decimal Balance { get; set; }

        public bool CheckIsVerified { get; set; }
    }

    public partial class LicencingUsers : ModelHelper
    {
    }

    public partial class Asset
    {
        public string AssetTypeName { get; set; }

        public string AssetDispositionName { get; set; }

        public string Vendor { get; set; }

        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public string assetname { get; set; }
    }

    public partial class UMst_UserAccounts : ModelHelper
    {
        ///
        public string CategoryType { get; set; }

        public decimal Balance { get; set; }

        public int ParentAccountsId { get; set; }

        public int Sno { get; set; }
    }

    public partial class UMst_TaxDetails
    {
        public string TaxName { get; set; }

        public string Message { get; set; }

        public string TaxTypeID_Value { get; set; }
    }
    public partial class UMst_PayStructureDetails
    {
        public string PayStructureTypesName { get; set; }

        public string Message { get; set; }

        public string PayStructureTypeID_Value { get; set; }
    }

    public partial class CustomersAddress
    {
        public string AddressType { get; set; }

        public string State { get; set; }

        //public string Street { get; set; }
        public string City { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public string Website { get; set; }

        public string BillingStreet { get; set; }

        public int BillingCityId { get; set; }

        public string BillingCity { get; set; }

        public string ShippingCity { get; set; }

        public string BillingState { get; set; }

        public int BillingStateId { get; set; }

        public short BillingCountryId { get; set; }

        public string BillingCountry { get; set; }

        public string ShippingStreet { get; set; }

        public int ShippingCityId { get; set; }

        public string ShippingState { get; set; }

        public int ShippingStateId { get; set; }

        public short ShippingCountryId { get; set; }

        public string ShippingCountry { get; set; }

        public string Billingzip { get; set; }

        public string ShippingZip { get; set; }

        public bool ShippingIsBilling { get; set; }
    }

    public partial class UserBankAccount
    {
        public decimal Amount { get; set; }

        public string AccountName { get; set; }

        public int UserCustomerId { get; set; }

        public string AccountTypeName { get; set; }

        public string AccountTypeDesc { get; set; }

        public DateTime OpeningBalanceEffectiveDate { get; set; }


    }

    public partial class PurchaseInvoicePayment
    {
        ///
        public string Account { get; set; }

        public string Instrument { get; set; }

        public string PaidTo { get; set; }

        public string Status { get; set; }

        public string ReceivedFor { get; set; }

        public string Tags { get; set; }

        public int BankAccountId { get; set; }

        public int BankCashAccountsId { get; set; }

        public string BankCashAccount { get; set; }

        public string AccountName { get; set; }

        public int SNo { get; set; }

        public string InvoiceNumber { get; set; }

        //public int BankAccountsId { get; set; }
        public int CurrentPaymentStatusId { get; set; }

        public int NextPaymentStatusId { get; set; }

        public string CurrentPaymentStatus { get; set; }

        public string NextPaymentStatus { get; set; }

        public int BusinessID { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime shrtDate { get; set; }

        public string NextPaymentStatusIds { get; set; }

        public Int64 UserVendorId { get; set; }

        public string VendorName { get; set; }

        public string PaymentMethod { get; set; }

        public Nullable<decimal> Balance { get; set; }

        public string Description { get; set; }
    }

    public partial class UserCustomer : ModelHelper
    {
        public string PhoneNo { get; set; }

        public decimal Payable { get; set; }

        public string CreditPeriod { get; set; }

        public string PreferredPaymentMethod { get; set; }

        public string LifeTimePayment { get; set; }

        public string YearToDatePayments { get; set; }

        public string LastYearPayments { get; set; }

        public string BankName { get; set; }

        public string AccountNum { get; set; }

        public string AccountTypeDesc { get; set; }

        public string RountingNum { get; set; }

        public string Address { get; set; }

        public int BankAccountTypeId { get; set; }

        public long BankAccountsId { get; set; }

        public short TaxTypesId { get; set; }

        public string Email { set; get; }

        [RegularExpression((@"^\d{1,2}(.\d{1,2})?"), ErrorMessage = "Enter valid percentage.")]
        public Nullable<decimal> FederalTaxValue { get; set; }

        [RegularExpression((@"^\d{1,2}(\.\d{1,2})?"), ErrorMessage = "Enter valid percentage.")]
        public Nullable<decimal> StateTaxValue { get; set; }

        [RegularExpression((@"^\d{1,2}(\.\d{1,2})?"), ErrorMessage = "Enter valid percentage.")]
        public Nullable<decimal> CityTaxValue { get; set; }

        [RegularExpression((@"^\d{1,2}(\.\d{1,2})?"), ErrorMessage = "Enter valid percentage.")]
        public Nullable<decimal> CountyTaxValue { get; set; }

        [RegularExpression((@"^\d{1,2}(\.\d{1,2})?"), ErrorMessage = "Enter valid percentage.")]
        public Nullable<decimal> ExtraTaxValue { get; set; }

        // public bool IsTaxable { get; set; }
        //[RegularExpression((@"^\d{1,2}$"), ErrorMessage = "Enter valid 2-digit number.")] /*Cmmntd due to TaxID's allow Character's & maxlength is 15 */
        public string FederalTaxNum { get; set; }

        //[RegularExpression((@"^\d{1,2}$"), ErrorMessage = "Enter valid 2-digit number.")]
        public string StateTaxNum { get; set; }

        //[RegularExpression((@"^\d{1,2}$"), ErrorMessage = "Enter valid 2-digit number.")]
        public string CityTaxNum { get; set; }

        //[RegularExpression((@"^\d{1,2}$"), ErrorMessage = "Enter valid 2-digit number.")]
        public string CountyTaxNum { get; set; }

        //[RegularExpression((@"^\d{1,2}$"), ErrorMessage = "Enter valid 2-digit number.")]
        public string ExtraTaxNum { get; set; }
    }

    public partial class UserVendor : ModelHelper
    {
        [System.ComponentModel.DefaultValue(100)]
        public string PhoneNo { get; set; }

        public decimal Payable { get; set; }

        public string PreferredPaymentMethod { get; set; }

        public string LifeTimePayment { get; set; }

        public string YearToDatePayments { get; set; }

        public string LastYearPayments { get; set; }

        public string BankName { get; set; }

        public string AccountNum { get; set; }

        public string AccountTypeDesc { get; set; }

        public string RountingNum { get; set; }

        public string Address { get; set; }

        public int BankAccountTypeId { get; set; }

        public long BankAccountsId { get; set; }

        public short TaxTypesId { get; set; }

        public string Email { get; set; }

        [RegularExpression((@"\d+(.\d{1,2})?"), ErrorMessage = "Enter valid percentage.")]
        public Nullable<decimal> FederalTaxValue { get; set; }

        [RegularExpression((@"^\d{1,2}\.\d{1,2}"), ErrorMessage = "Enter valid percentage.")]
        public Nullable<decimal> StateTaxValue { get; set; }

        [RegularExpression((@"^\d{1,2}\.\d{1,2}"), ErrorMessage = "Enter valid percentage.")]
        public Nullable<decimal> CityTaxValue { get; set; }

        [RegularExpression((@"^\d{1,2}\.\d{1,2}"), ErrorMessage = "Enter valid percentage.")]
        public Nullable<decimal> CountyTaxValue { get; set; }

        // public bool IsTaxable { get; set; }
        [RegularExpression((@"^\d{1,2}$"), ErrorMessage = "Enter valid 2-digit number.")]
        public string FederalTaxNum { get; set; }

        [RegularExpression((@"^\d{1,2}$"), ErrorMessage = "Enter valid 2-digit number.")]
        public string StateTaxNum { get; set; }

        [RegularExpression((@"^\d{1,2}$"), ErrorMessage = "Enter valid 2-digit number.")]
        public string CityTaxNum { get; set; }

        [RegularExpression((@"^\d{1,2}$"), ErrorMessage = "Enter valid 2-digit number.")]
        public string CountyTaxNum { get; set; }
    }

    

    public partial class VendorsAddress
    {
        public string State { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string AddressType { get; set; }

        public string County { get; set; }

        public string WebSite { get; set; }

        public string BillingStreet { get; set; }

        public int BillingCityId { get; set; }

        public string BillingState { get; set; }

        public int BillingStateId { get; set; }

        public string BillingCountry { get; set; }

        public short BillingCountryId { get; set; }

        public string ShippingStreet { get; set; }

        public int ShippingCityId { get; set; }

        public string ShippingState { get; set; }

        public int ShippingStateId { get; set; }

        public string ShippingCountry { get; set; }

        public short ShippingCountryId { get; set; }

        public string Billingzip { get; set; }

        public string ShippingZip { get; set; }

        public string BillingCity { get; set; }

        public string ShippingCity { get; set; }

        public bool ShippingIsBilling { get; set; }
    }

    public partial class PurchaseOrder
    {
        public int SNo { get; set; }

        public string VendorName { get; set; }

        public string CompanyName { get; set; }

        public string Tax { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }

        public string ExpiryDtString { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime shrtDate { get; set; }

        public string ShippingAddress { get; set; }

        public string BillingAddress { get; set; }

        public decimal ShippingAmount { get; set; }

        public decimal HandlingCharges { get; set; }

        public Nullable<System.DateTime> POrderDate { get; set; }

        public string purchaseProduct { get; set; }

        public string Item { get; set; }

        public string CustomField1Label { get; set; }

        public string CustomField2Label { get; set; }

        public string CustomField3Label { get; set; }
    }

    

    public partial class UMst_BusinessItems
    {
        public string Item_Amt { get; set; }

        public decimal Amount { get; set; }
    }

    

    public partial class AccountsClosing
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int BusinessId { get; set; }

        public int AccountsClosingId { get; set; }
    }

    public partial class UserCustomer
    {
        public string ImagePath { get; set; }
    }

    public partial class UserVendor
    {
        public string ImagePath { get; set; }
    }

    public partial class Images
    {
        public int BusinessID { get; set; }

        public int UserID { get; set; }

        public int UserTypeID { get; set; }

        public string ImagePath { get; set; }

        public string CustomerName { get; set; }
    }

    public partial class UMst_EmailSettings
    {
        public int BusinessID { get; set; }

        public int CreatedByUserId { get; set; }

        
        public string UserName { get; set; }

        public string Password { get; set; }

        public string SMTPServer { get; set; }

        public string PortNo { get; set; }

        public bool EnableSSL { get; set; }

        public string EnableSSLString { get; set; }

        public bool IsBodyHtml { get; set; }

        public string IsBodyHtmlString { get; set; }

        public string YourName { get; set; }

        public string FromMail { get; set; }
    }

    public partial class UMst_UserGreetingEmails
    {
        public short? newGreetingsListId { get; set; }
    }

    public partial class Mst_GreetingsList
    {
        public short? newGreetingsListId { get; set; }
    }

    public partial class Company
    {
        public int BusinessId { get; set; }

        public string BusinessName { get; set; }

        public string MyprofileBusinessName { get; set; }

        public string CustomersRename { get; set; }

        public string ImagePath { get; set; }
    }

    public partial class AddCategory
    {
        public long Id { get; set; }

        public string AccountName { get; set; }

        public string AccountNo { get; set; }

        public string AccountTypeName { get; set; }

        public long Balance { get; set; }

        public int AccountTypeId { get; set; }

        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public int ItemTypeId { get; set; }

        public long UserAccountsId { get; set; }
    }

    public class CommonMessages
    {
        public int Result { get; set; }

        public string Message { get; set; }

        public string ErrorSeverity { get; set; }

        public string ErrorState { get; set; }

    }

    


    public class CommonDropDwons 
    {
        public int DropdownId { get; set; }

        public String DropdownValue { get; set; }

        public List<SelectListItem> DropdownList { get; set; }

    }
}
