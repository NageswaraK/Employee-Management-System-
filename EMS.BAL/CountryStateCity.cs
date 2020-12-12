using EMS.Data;
using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BAL
{
    public class CountryStateCity
    {
        public static List<CountryStateCityDto> GetCountryStateCity(string searchKey, string column, int? itemId)
        {
            using (var cmd = new DBSqlCommand())
            {
                try
                {
                    var ireader = cmd.ExecuteDataReader(SqlProcedures.Get_MasterAddress);
                    var listItems = new List<CountryStateCityDto>();
                    while (ireader.Read())
                    {
                        var item = new CountryStateCityDto
                        {
                            CountryId = ireader.GetInt16(CommonConstants.CountryId),
                            CountryName = ireader.GetString(CommonConstants.Country),
                            CityId = ireader.GetInt16(CommonConstants.CityId),
                            CityName = ireader.GetString(CommonConstants.City),
                            StateId = ireader.GetInt16(CommonConstants.StateId),
                            StateName = ireader.GetString(CommonConstants.State)
                        };
                        listItems.Add(item);
                    }
                    var retlist = listItems.GroupBy(x => x.CountryId).Select(g => g.First()).ToList<CountryStateCityDto>();
                    switch (column)
                    {
                        case "country":
                            var returnlist = retlist.Where(x => x.CountryName.ToUpper().StartsWith(searchKey.ToUpper())).ToList();
                            return returnlist;
                        case "state":
                            return listItems.Where(item => item.StateName.ToUpper().StartsWith(searchKey.ToUpper()) && item.CountryId.Equals(itemId)).Distinct().ToList();
                        case "city":
                            return listItems.Where(item => item.CityName.ToUpper().StartsWith(searchKey.ToUpper()) && item.StateId.Equals(itemId)).ToList();
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
