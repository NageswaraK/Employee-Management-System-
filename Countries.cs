using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMS.Controllers
{
    public class CountriesApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<EMS.Entities.CountryStateCityDto> GetCountries(string query = "")
        {
            return EMS.BAL.CountryStateCity.GetCountryStateCity(query, "country", 0);
        }

        // GET api/<controller>
        public IEnumerable<EMS.Entities.CountryStateCityDto> GetStates(int country,string query = "")
        {
            return EMS.BAL.CountryStateCity.GetCountryStateCity(query, "state", country);
        }

        // GET api/<controller>
        public IEnumerable<EMS.Entities.CountryStateCityDto> GetCity(int state, string query = "")
        {
            return EMS.BAL.CountryStateCity.GetCountryStateCity(query, "city", state);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}