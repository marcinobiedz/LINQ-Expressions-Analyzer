using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQapi.Models
{
    public class Customer
    {
        public Customer(int CustomerID, string FirstName, string LastName, string EmailAddress, string Phone)
        {
            this.CustomerID = CustomerID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.EmailAddress = EmailAddress;
            this.Phone = Phone;
        }

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
    }
}
