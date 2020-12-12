using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public enum BusinessStatus
    {
        Email_Not_Verified = 1,
        Email_Verified,
        Activated,
        Deactivated,
        Expired
    }

    public enum BusinessItemsTypes
    {
        Services = 1,
        Projects,
        Products,
        Preferences
    }

    public enum LedgerTypes
    {
        Ledger,
        DayWise,
        MonthWise,
        ScheduleWise
    }

    /// <summary>
    /// 
    /// </summary>
    public enum UserType
    {
        Business = 1,
        BusinessUsers,
        Customer,
        Employee,
        Vendor,
        Others
    }

    /// <summary>
    /// Preferences Types
    /// </summary>
    /// 
    public enum PrefferedFormats
    {
        DateFormat = 1,
        NumberFormat,
        Fisicalyear,
        Currency
    }

    public enum MasterScreens
    {
        Logo = 1,
        Preferences,
        AddAsset,
        AddVendor,
        NewPO,
        NewInvoice_Purchase,
        AddCustomer,
        SaveCustomize,
        AddEmployee,
        AddEstimate,
        NewInvoice_Sales
    }

    public enum SerialNo
    {
        BusinessId = 1,
        UserId,
        UserParentAccountsId,
        UserAccountsId,
        BankAccountsId,
        ServicesId,
        ProductsId,
        ProjectsId,
        AssetsId,
        UserVendorId,
        UserCustomerId,
        UserEmployeeId,
        EmployeesBankId,
        PurchaseOrderId,
        PODetailsId,
        PurchaseInvoiceId,
        PurchaseInvoiceDetailsId,
        ExpensesId,
        PurchaseInvoicePaymentId,
        PaymentsId,
        EstimatesId,
        EstimatesDetailsId,
        SalesInvoiceId,
        SalesInvoiceDetailsId,
        SalesReceiptId,
        ReceiptId,
        JournalId,
        TimesheetId,
        LeaveId,
        LeaveBillingDetailsId,
        EmployeePayrollId,
        BranchId,
        AssetTypeId,
        ItemId,
    }

    public enum PaymentTypes
    {
        Cash = 1,
        Card,
        Cheque,
    }
    public enum ModuleEnums
    {
        Organizations,
        Transactions,
        Employees,
        Customers,
        Vendors,
        Reports,
        Administration,
        Common
    }
    public enum ActionEnums
    {
        AddVendors,
        UpdatePreferences
    }
}
