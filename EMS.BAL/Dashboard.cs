using EMS.Data;
using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BAL
{
    public static class Dashboard
    {
        public static DashboardChart SalesByYear(int BusinessId, int Year)
        {
            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Year, CommonConstants.Year, SqlDbType.SmallInt);

                    var SalesByYear = new DashboardChart();

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_SalesByYear);
                    while (ireader.Read())
                    {
                        var SalesByYearDet = new DashboardChart
                        {
                            TotalSales = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalSales)),
                            NumberOfSales = ireader.GetInt32(CommonColumns.SalesCount),
                            AverageSales = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.AverageSales)),
                            LargestSales = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.LargestSales))
                        };

                        SalesByYear = SalesByYearDet;
                    }
                    return SalesByYear;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in SalesByYear. Exception :" + ex.Message);
                }
            }
        }

        public static List<DashboardChart> Quarters(int BusinessId, int Year, int QuarterNumber)
        {
            var Quarters = new List<DashboardChart>();

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    DateTime FromDate = new DateTime(Year, 1, 1);
                    DateTime ToDate = new DateTime(Year, 12, 31);

                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(FromDate, CommonConstants.FromDate, SqlDbType.DateTime);
                    cmd.AddParameters(ToDate, CommonConstants.ToDate, SqlDbType.DateTime);
                    cmd.AddParameters(QuarterNumber, CommonConstants.QuarterNum, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_SalesByMonth);
                    while (ireader.Read())
                    {
                        var QuartersDet = new DashboardChart
                        {
                            Quarter = ireader.GetString(CommonColumns.Quarter),
                            Month = ireader.GetString(CommonColumns.Month),
                            TotalSales = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalSales))
                        };

                        Quarters.Add(QuartersDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in Quarters. Exception :" + ex.Message);
                }
            }

            return Quarters;
        }

        public static List<DashboardChart> QuartersChart(int BusinessId, int Year)
        {
            var QuartersChart = new List<DashboardChart>();

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    DateTime FromDate = new DateTime(Year, 1, 1);
                    DateTime ToDate = new DateTime(Year, 12, 31);

                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(FromDate, CommonConstants.FromDate, SqlDbType.DateTime);
                    cmd.AddParameters(ToDate, CommonConstants.ToDate, SqlDbType.DateTime);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_SalesByMonth);
                    while (ireader.Read())
                    {
                        var QuartersChartDet = new DashboardChart
                        {
                            Month = ireader.GetString(CommonColumns.Month),
                            TotalSales = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalSales)),
                            Color = "#0D8ECF"
                        };

                        QuartersChart.Add(QuartersChartDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in QuartersChart. Exception :" + ex.Message);
                }
            }

            return QuartersChart;
        }

        public static List<DashboardChart> TopTenCustomers(int BusinessId, int Year)
        {
            var TopTenCustomers = new List<DashboardChart>();
            DateTime FromDate = new DateTime(Year, 1, 1);
            DateTime ToDate = new DateTime(Year, 12, 31);

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    //cmd.AddParameters(Year, CommonConstants.Year, SqlDbType.SmallInt);
                    cmd.AddParameters(FromDate, CommonConstants.FromDate, SqlDbType.DateTime);
                    cmd.AddParameters(ToDate, CommonConstants.ToDate, SqlDbType.DateTime);
                    cmd.AddParameters(10, CommonConstants.Top, SqlDbType.Int);
                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_SalesDetailsByCustomers);

                    while (ireader.Read())
                    {
                        var TopTenCustomersDet = new DashboardChart
                        {
                            UserCustomerId = ireader.GetInt16(CommonColumns.UserCustomerId),
                            Customer = ireader.GetString(CommonColumns.Customer),
                            TotalSales = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalSales)),
                            TotalOwing = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalOwing)),
                        };

                        TopTenCustomers.Add(TopTenCustomersDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in TopTenCustomers. Exception :" + ex.Message);
                }
            }

            return TopTenCustomers;
        }

        public static List<DashboardChart> CustomersOwing(int BusinessId, int Year)
        {
            var CustomersOwing = new List<DashboardChart>();

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    DateTime FromDate = new DateTime(Year, 1, 1);
                    DateTime ToDate = new DateTime(Year, 12, 31);

                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    //cmd.AddParameters(Year, CommonConstants.Year, SqlDbType.SmallInt);
                    cmd.AddParameters(FromDate, CommonConstants.FromDate, SqlDbType.DateTime);
                    cmd.AddParameters(ToDate, CommonConstants.ToDate, SqlDbType.DateTime);
                    //IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_SalesOwingByCustomers);
                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_SalesDetailsByCustomers);
                    while (ireader.Read())
                    {
                        var CustomersOwingDet = new DashboardChart
                        {
                            //SNo = ireader.GetInt32(CommonColumns.Sno),
                            UserCustomerId = ireader.GetInt32(CommonColumns.UserCustomerId),
                            Customer = ireader.GetString(CommonColumns.Customer),
                            TotalOwing = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalOwing)),
                        };

                        CustomersOwing.Add(CustomersOwingDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in CustomerOwing. Exception :" + ex.Message);
                }
            }

            return CustomersOwing;
        }

        public static DashboardChart PurchasesByYear(int BusinessId, int Year)
        {
            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Year, CommonConstants.Year, SqlDbType.SmallInt);

                    var PurchasesByYear = new DashboardChart();

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_PurchaseByYear);
                    while (ireader.Read())
                    {
                        var PurchasesByYearDet = new DashboardChart
                        {
                            TotalPurchase = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalPurchase)),
                            NumberOfPurchase = ireader.GetInt32(CommonColumns.PurchaseCount),
                            AveragePurchase = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.AveragePurchase)),
                            LargestPurchase = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.LargestPurchase))
                        };

                        PurchasesByYear = PurchasesByYearDet;
                    }
                    return PurchasesByYear;
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in PurchasesByYear. Exception :" + ex.Message);
                }
            }
        }

        public static List<DashboardChart> QuartersPuchase(int BusinessId, int Year, int QuarterNumber)
        {
            var QuartersPuchase = new List<DashboardChart>();

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    DateTime FromDate = new DateTime(Year, 1, 1);
                    DateTime ToDate = new DateTime(Year, 12, 31);

                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(FromDate, CommonConstants.FromDate, SqlDbType.DateTime);
                    cmd.AddParameters(ToDate, CommonConstants.ToDate, SqlDbType.DateTime);
                    cmd.AddParameters(QuarterNumber, CommonConstants.QuarterNum, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_PurchaseByMonth);
                    while (ireader.Read())
                    {
                        var QuartersPuchaseDet = new DashboardChart
                        {
                            Quarter = ireader.GetString(CommonColumns.Quarter),
                            Month = ireader.GetString(CommonColumns.Month),
                            TotalPurchase = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalPurchase))
                        };

                        QuartersPuchase.Add(QuartersPuchaseDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in QuartersPuchase. Exception :" + ex.Message);
                }
            }

            return QuartersPuchase;
        }

        public static List<DashboardChart> QuartersPuchaseChart(int BusinessId, int Year)
        {
            var QuartersPuchaseChart = new List<DashboardChart>();

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    DateTime FromDate = new DateTime(Year, 1, 1);
                    DateTime ToDate = new DateTime(Year, 12, 31);

                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(FromDate, CommonConstants.FromDate, SqlDbType.DateTime);
                    cmd.AddParameters(ToDate, CommonConstants.ToDate, SqlDbType.DateTime);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_PurchaseByMonth);
                    while (ireader.Read())
                    {
                        var QuartersPuchaseChartDet = new DashboardChart
                        {
                            Month = ireader.GetString(CommonColumns.Month),
                            TotalPurchase = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalPurchase)),
                            Color = "#B0DE09"
                        };

                        QuartersPuchaseChart.Add(QuartersPuchaseChartDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in QuartersPuchaseChart. Exception :" + ex.Message);
                }
            }

            return QuartersPuchaseChart;
        }

        public static List<DashboardChart> TopTenVendors(int BusinessId, int Year)
        {
            var TopTenVendors = new List<DashboardChart>();

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    DateTime FromDate = new DateTime(Year, 1, 1);
                    DateTime ToDate = new DateTime(Year, 12, 31);
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(FromDate, CommonConstants.FromDate, SqlDbType.DateTime);
                    cmd.AddParameters(ToDate, CommonConstants.ToDate, SqlDbType.DateTime);
                    cmd.AddParameters(10, CommonConstants.Top, SqlDbType.Int);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_PurchasesDetailsByVendors);
                    while (ireader.Read())
                    {
                        var TopTenVendorsDet = new DashboardChart
                        {
                            UserVendorId = ireader.GetInt16(CommonColumns.UserVendorId),
                            Vendor = ireader.GetString(CommonColumns.Vendor),
                            TotalPurchase = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalPurchases)),
                            TotalOwing = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalOwing)),
                        };

                        TopTenVendors.Add(TopTenVendorsDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in TopTenVendors. Exception :" + ex.Message);
                }
            }

            return TopTenVendors;
        }

        public static List<DashboardChart> VendorsOwing(int BusinessId, int Year)
        {
            var VendorsOwing = new List<DashboardChart>();

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    DateTime FromDate = new DateTime(Year, 1, 1);
                    DateTime ToDate = new DateTime(Year, 12, 31);
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(FromDate, CommonConstants.FromDate, SqlDbType.DateTime);
                    cmd.AddParameters(ToDate, CommonConstants.ToDate, SqlDbType.DateTime);
                    //IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_PurchaseOwingToVendors);
                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_PurchasesDetailsByVendors);
                    while (ireader.Read())
                    {
                        var VendorsOwingDet = new DashboardChart
                        {
                            //SNo = ireader.GetInt32(CommonColumns.Sno),
                            UserVendorId = ireader.GetInt32(CommonColumns.UserVendorId),
                            Vendor = ireader.GetString(CommonColumns.Vendor),
                            TotalOwing = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.TotalOwing))
                        };

                        VendorsOwing.Add(VendorsOwingDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in VendorsOwing. Exception :" + ex.Message);
                }
            }

            return VendorsOwing;
        }

        public static List<DashboardChart> BankAccounts(int BusinessId, int Year)
        {
            var BankAccounts = new List<DashboardChart>();

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Year, CommonConstants.Year, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_BankAccounts);
                    while (ireader.Read())
                    {
                        var BankAccountsDet = new DashboardChart
                        {
                            SNo = ireader.GetInt32(CommonColumns.Sno),
                            BankAccountName = ireader.GetString(CommonColumns.BankAccountName),
                            ClosingBalance = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.ClosingBalance))
                        };

                        BankAccounts.Add(BankAccountsDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in BankAccounts. Exception :" + ex.Message);
                }
            }

            return BankAccounts;
        }

        public static List<DashboardChart> DashboardExpensesAccounts(int BusinessId, int Year)
        {
            var ExpensesAccounts = new List<DashboardChart>();

            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(Year, CommonConstants.Year, SqlDbType.SmallInt);

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_DashboardExpenseAccounts);
                    while (ireader.Read())
                    {
                        var ExpensesAccountsDet = new DashboardChart
                        {
                            SNo = ireader.GetInt32(CommonColumns.Sno),
                            AccountName = ireader.GetString(CommonColumns.AccountName),
                            Amount = ireader.GetDecimal(ireader.GetOrdinal(CommonColumns.Amount))
                        };

                        ExpensesAccounts.Add(ExpensesAccountsDet);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    throw new ArgumentException("Exception in DashboardExpensesAccounts. Exception :" + ex.Message);
                }
            }

            return ExpensesAccounts;
        }

        public static List<KeyValueVM> Rpt_BindYears()
        {
            List<KeyValueVM> YearsList = new List<KeyValueVM>();
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand(CommandType.StoredProcedure))
                {

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Rpt_BindYears);
                    while (ireader.Read())
                    {
                        var Year = new KeyValueVM
                        {
                            value = ireader.GetString(CommonColumns.Year),
                            key = Convert.ToInt32(ireader.GetString(CommonColumns.Year))

                        };
                        YearsList.Add(Year);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Rpt_BindYears. Exception :" + ex.Message);
            }
            return YearsList;
        }

        public static DashboardDocs GetDashboardDocs(int BusinessId, int UserId, int RoleId, int UserSessionEmployeeId)
        {
            DashboardDocs _DashboardDocs = new DashboardDocs();
            List<NoOfLeaves> _NoOfLeaves = new List<NoOfLeaves>();
            List<PendingTimeSheets> _PendingTimeSheets = new List<PendingTimeSheets>();
            List<NoOfResignations> _NoOfResignations = new List<NoOfResignations>();
            List<NoOfNewJoinees> _NoOfNewJoinees = new List<NoOfNewJoinees>();
            List<NoOfEmployessInfo> _NoOfEmployessInfo = new List<NoOfEmployessInfo>();
            List<GrossSalaryInfo> _GrossSalaryInfo = new List<GrossSalaryInfo>();
            List<DeductionsInfo> _DeductionsInfo = new List<DeductionsInfo>();

            int UserEmployeeId = UserSessionEmployeeId;

            using (var Cmd = new DBSqlCommand())
            {
                try
                {
                    Cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    Cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);
                    Cmd.AddParameters(RoleId, CommonConstants.RoleId, SqlDbType.Int);
                    Cmd.AddParameters(UserEmployeeId, CommonConstants.UserEmployeeId, SqlDbType.Int);

                    DataSet ireader = Cmd.ExecuteDataDataSet(SqlProcedures.usp_EmployeeDashboardDetails);
                    DataSet ireader1 = Cmd.ExecuteDataDataSet(SqlProcedures.usp_HRDashboardDetails);

                    for (var i = 0; i < ireader.Tables[0].Rows.Count; i++)
                    {

                        _DashboardDocs.CountOfNoOfLeaves = (int)ireader.Tables[0].Rows[i]["CountOfNoOfLeaves"];
                    }
                    _DashboardDocs.NoOfLeaves = _NoOfLeaves;

                    for (var i = 0; i < ireader.Tables[0].Rows.Count; i++)
                    {

                        _DashboardDocs.CountOfPendingTimeSheets = (int)ireader.Tables[0].Rows[i]["CountOfPendingTimeSheets"];

                    }
                    _DashboardDocs.PendingTimeSheets = _PendingTimeSheets;

                    for (var i = 0; i < ireader.Tables[0].Rows.Count; i++)
                    {

                        _DashboardDocs.CountOfNoOfResignations = (int)ireader.Tables[0].Rows[i]["CountOfNoOfResignations"];

                    }
                    _DashboardDocs.NoOfResignations = _NoOfResignations;

                    for (var i = 0; i < ireader.Tables[0].Rows.Count; i++)
                    {

                        _DashboardDocs.CountOfNoOfNewJoinees = (int)ireader.Tables[0].Rows[i]["CountOfNoOfNewJoinees"];

                    }
                    _DashboardDocs.NoOfNewJoinees = _NoOfNewJoinees;

                    for (var i = 0; i < ireader1.Tables[0].Rows.Count; i++)
                    {
                        _DashboardDocs.NoOfEmployees = (int)ireader1.Tables[0].Rows[i]["EmployeeCount"];
                    }
                    _DashboardDocs.NoOfEmployessInfo = _NoOfEmployessInfo;

                    for (var i = 0; i < ireader1.Tables[1].Rows.Count; i++)
                    {
                        _DashboardDocs.GrossSalary = (decimal)ireader1.Tables[1].Rows[i]["GrossSalary"];
                        _DashboardDocs.TotalESIC = (decimal)ireader1.Tables[1].Rows[i]["TotalESIC"];
                    }
                    _DashboardDocs.GrossSalaryInfo = _GrossSalaryInfo;

                    for (var i = 0; i < ireader1.Tables[3].Rows.Count; i++)
                    {
                        _DashboardDocs.ProvidentFund = (decimal)ireader1.Tables[3].Rows[i]["ProvidentFund"];
                        _DashboardDocs.ProfessionTax = (int)ireader1.Tables[3].Rows[i]["ProfessionTax"];
                        _DashboardDocs.TotalDeductions = (decimal)ireader1.Tables[3].Rows[i]["TotalDeductions"];
                    }
                    _DashboardDocs.DeductionsInfo = _DeductionsInfo;


                    return _DashboardDocs;

                }
                catch (Exception Ex)
                {
                    throw Ex;
                    throw new ArgumentException("Exception in GetDashboardDocs. Exception :" + Ex.Message);
                }
                finally
                {
                    _DashboardDocs = null;

                }
            }
        }
    }
}
