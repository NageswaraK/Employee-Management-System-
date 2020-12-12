using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class MyProfileMDL
    {

        public string UserFirstName { get; set; }



        public string UserLastName { get; set; }


        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "StateIsRequired")]
        public string State { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "CountryIsRequired")]
        public string Country { get; set; }

        public int BusinessId { get; set; }

        public int UserId { get; set; }

        public string Password { get; set; }

        public int LogMeOutId { get; set; }

        public String ImagePath { get; set; }


        public string Email { get; set; }

        public string Fax { get; set; }

        public string AddressLine1 { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "BusinessNameIsRequired")]
        public string BusinessName { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "StateIsRequired")]
        public int StateId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EMSModelResources), ErrorMessageResourceName = "CountryIsRequired")]
        public int CountryId { get; set; }


        public int Licences { get; set; }

        public int LogMeOut1 { get; set; }

        public DateTime? EndDate { get; set; }

        public int CityId { get; set; }
    }
}
