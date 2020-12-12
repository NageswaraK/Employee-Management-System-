using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class CountryStateCityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
