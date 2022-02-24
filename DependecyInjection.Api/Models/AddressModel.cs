using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependecyInjection.Api.Models
{

#pragma warning disable 1591
#pragma warning disable 8618

    public class AddressModel
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
    }
}
