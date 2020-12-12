using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Data;
using EMS.Entities;
using System.Data;

namespace EMS.BAL
{
    public static class Users
    {
        public static EMS.Entities.MyProfileMDL GetProfileDetails(int UserId, int BusinessId)
        {
            EMS.Entities.MyProfileMDL user = new EMS.Entities.MyProfileMDL();
            using (DBSqlCommand cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(UserId, CommonConstants.UserId, System.Data.SqlDbType.Int);
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, System.Data.SqlDbType.Int);
                    System.Data.IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_MyAccountDetails);

                    while (ireader.Read())
                    {
                        var userDet = new EMS.Entities.MyProfileMDL
                        {
                            UserFirstName = ireader.GetString(CommonColumns.FirstName),
                            UserLastName = ireader.GetString(CommonColumns.LastName),
                            Email = ireader.GetString(CommonColumns.UserEmail),
                            Fax = ireader.GetString(CommonColumns.BusinessFax),
                            AddressLine1 = ireader.GetString(CommonColumns.UserAddressLine1),
                            City = ireader.GetString(CommonColumns.City),
                            State = ireader.GetString(CommonColumns.State),
                            Country = ireader.GetString(CommonColumns.Country),
                            //RenewalDate = ireader.GetDateTime(CommonColumns.UserAccountExpiryDate),
                            Licences = ireader.GetInt16(CommonColumns.Licences),
                            BusinessName = ireader.GetString(CommonColumns.BusinessName),
                            LogMeOutId = ireader.GetInt32(CommonColumns.LogMeOutId),
                            EndDate = ireader.GetNullLocalDateTime(CommonColumns.UserAccountExpiryDate),
                            CityId = ireader.GetInt32(CommonColumns.CityId),
                            StateId = ireader.GetInt32(CommonColumns.StateId),
                            CountryId = ireader.GetInt16(CommonColumns.CountryId),
                            ImagePath = ireader.GetString(CommonColumns.ImagePath)
                        };
                        user = userDet;
                    }
                    return user;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }



        public static bool SaveProfileDetails(MyProfileMDL user, int businessId, int userId)
        {
                try
                {
                    using (DBSqlCommand cmd = new DBSqlCommand())
                    {
                        cmd.AddParameters(userId, CommonConstants.UserId, System.Data.SqlDbType.Int);
                        cmd.AddParameters(businessId, CommonConstants.BusinessID, System.Data.SqlDbType.Int);
                        cmd.AddParameters(user.UserFirstName, CommonConstants.FirstName, System.Data.SqlDbType.VarChar);
                        cmd.AddParameters(user.UserLastName, CommonConstants.LastName, System.Data.SqlDbType.VarChar);
                        cmd.AddParameters(user.BusinessName, CommonConstants.BusinessName, System.Data.SqlDbType.VarChar);
                        cmd.AddParameters(user.Email, CommonConstants.Email, System.Data.SqlDbType.VarChar);
                        cmd.AddParameters(user.Fax, CommonConstants.BusinessFax, System.Data.SqlDbType.VarChar);
                        cmd.AddParameters(user.AddressLine1, CommonConstants.BusinessAddress, System.Data.SqlDbType.VarChar);
                        cmd.AddParameters(user.City, CommonConstants.City, System.Data.SqlDbType.VarChar);
                        cmd.AddParameters(1, CommonConstants.CityId, System.Data.SqlDbType.Int);
                        cmd.AddParameters(user.StateId, CommonConstants.StateId, System.Data.SqlDbType.Int);
                        cmd.AddParameters(user.CountryId, CommonConstants.CountryId, System.Data.SqlDbType.Int);
                        //cmd.AddParameters(user.LogMeOut, "@LogMeOut", System.Data.SqlDbType.Int);
                        cmd.AddParameters(user.LogMeOutId, "@LogMeOutId", System.Data.SqlDbType.Int);
                        cmd.AddParameters(user.Licences, "@Licences", System.Data.SqlDbType.Int);
                        cmd.ExecuteNonQuery(SqlProcedures.Update_MyAccountDetails);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Exception in SaveProfileDetails. Exception :" + ex.Message);
                }
        }


        public static IList<KeyValueVM> Get_LogmeOut()
        {
            try
            {
                using (DBSqlCommand cmd = new DBSqlCommand())
                {
                    var reader = cmd.ExecuteDataReader(SqlProcedures.Get_LogMeOut);
                    var keyValues = new List<KeyValueVM>();
                    while (reader.Read())
                    {
                        var keyValue = new KeyValueVM();
                        keyValue.value = reader.GetString("Description");
                        keyValue.key = reader.GetInt32("LogMeOutId");
                        keyValues.Add(keyValue);
                    }
                    return keyValues;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception in Get_LogmeOut. Exception:" + ex.Message);
            }
        }





        public static Company GetCompanyName(int BusinessId, int UserId)
        {
            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    cmd.AddParameters(BusinessId, CommonConstants.BusinessID, SqlDbType.Int);
                    cmd.AddParameters(UserId, CommonConstants.UserId, SqlDbType.Int);

                    var CompanyDetails = new Company();

                    IDataReader ireader = cmd.ExecuteDataReader(SqlProcedures.Get_CompanyName);
                    while (ireader.Read())
                    {
                        var GetCompany = new Company
                        {
                            BusinessId = ireader.GetInt32(CommonColumns.BusinessID),
                            BusinessName = ireader.GetString(CommonColumns.BusinessName),
                            MyprofileBusinessName = ireader.GetString(CommonColumns.MyprofileBusinessName),
                            ImagePath = ireader.GetString(CommonColumns.ImagePath),
                        };

                        CompanyDetails = GetCompany;
                    }
                    return CompanyDetails;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
