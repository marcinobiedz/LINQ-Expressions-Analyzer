using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQapi.Models
{
    class Address
    {
        public int AddressID { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
    }
}
