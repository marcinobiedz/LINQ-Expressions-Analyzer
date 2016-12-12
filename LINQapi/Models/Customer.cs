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

        public int CustomerID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public string Phone { get; }
    }
}
