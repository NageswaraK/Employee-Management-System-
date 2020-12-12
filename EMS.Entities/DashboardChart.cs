using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class DashboardChart
    {
        public int SNo { get; set; }

        public int UserCustomerId { get; set; }

        public int UserVendorId { get; set; }

        public Decimal TotalSales { get; set; }

        public int NumberOfSales { get; set; }

        public Decimal AverageSales { get; set; }

        public Decimal LargestSales { get; set; }

        public Decimal TotalPurchase { get; set; }

        public int NumberOfPurchase { get; set; }

        public Decimal AveragePurchase { get; set; }

        public Decimal LargestPurchase { get; set; }

        public String Month { get; set; }

        public String Quarter { get; set; }

        public String Customer { get; set; }

        public String Vendor { get; set; }

        public Decimal TotalOwing { get; set; }

        public DateTime Date { get; set; }

        public String InvoiceNumber { get; set; }

        public Decimal Sales { get; set; }

        public Decimal Purchase { get; set; }

        public Decimal Paid { get; set; }

        public Decimal Owed { get; set; }

        public Decimal Tax { get; set; }

        public String Color { get; set; }

        public int Year { get; set; }

        public String BankAccountName { get; set; }

        public String AccountName { get; set; }

        public Decimal ClosingBalance { get; set; }

        public Decimal Amount { get; set; }

    }

    public class DashboardDocs
    {
        public int CountOfNoOfLeaves { get; set; }
        public int CountOfPendingTimeSheets { get; set; }
        public int CountOfNoOfResignations { get; set; }
        public int CountOfNoOfNewJoinees { get; set; }

        public int LeavesCount { get; set; }

        public int ResignationsCount { get; set; }

        public int pendingTimesheetsCount { get; set; }

        public int NewJoineesCount { get; set; }

        public int NoOfEmployees { get; set; }

        public decimal GrossSalary { get; set; }

        public decimal TotalESIC { get; set; }

        public decimal ProvidentFund { get; set; }

        public int ProfessionTax { get; set; }

        public decimal TotalDeductions { get; set; }

        public List<NoOfLeaves> NoOfLeaves { get; set; }
        public List<PendingTimeSheets> PendingTimeSheets { get; set; }
        public List<NoOfResignations> NoOfResignations { get; set; }
        public List<NoOfNewJoinees> NoOfNewJoinees { get; set; }
        public List<NoOfEmployessInfo> NoOfEmployessInfo { get; set; }
        public List<GrossSalaryInfo> GrossSalaryInfo { get; set; }
        public List<DeductionsInfo> DeductionsInfo { get; set; }

    }
    public class NoOfLeaves
    {
        public int CountOfNoOfLeaves { get; set; }
    }
    public class PendingTimeSheets
    {
        public int CountOfPendingTimeSheets { get; set; }
    }
    public class NoOfResignations
    {
        public int CountOfNoOfResignations { get; set; }
    }
    public class NoOfNewJoinees
    {
        public int CountOfNoOfNewJoinees { get; set; }
    }
    public class NoOfEmployessInfo
    {
        public int NoOfEmployees { get; set; }
    }
    public class GrossSalaryInfo
    {
        public decimal GrossSalary { get; set; }
        public decimal TotalESIC { get; set; }
    }
    public class DeductionsInfo
    {
        public decimal ProvidentFund { get; set; }
        public int ProfessionTax { get; set; }
        public decimal TotalDeductions { get; set; }
    }
}
