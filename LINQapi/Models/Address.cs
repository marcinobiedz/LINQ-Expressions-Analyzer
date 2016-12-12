using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQapi.Models
{
    public class Address
    {
        public Address(int AddressID, string AddressLine, string City, string CountryRegion, string PostalCode)
        {
            this.AddressID = AddressID;
            this.AddressLine = AddressLine;
            this.City = City;
            this.CountryRegion = CountryRegion;
            this.PostalCode = PostalCode;
        }

        public int AddressID { get; }
        public string AddressLine { get; }
        public string City { get; }
        public string CountryRegion { get; }
        public string PostalCode { get; }
    }
}
