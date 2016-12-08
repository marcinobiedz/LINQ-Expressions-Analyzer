using System;
using System.Collections.Generic;

namespace LINQapi.Models
{
    public class SalesOrderHeader
    {
        public SalesOrderHeader(int SalesOrderID, DateTime OrderDate, DateTime DueDate, byte Status, string SalesOrderNumber,
            string PurchaseOrderNumber, string AccountNumber, int CustomerID, int ShipToAddressID, int BillToAddressID,
            decimal SubTotal, decimal TaxAmt, decimal Freight, decimal TotalDue, List<Customer> Customers, List<Address> Addresses)
        {
            this.SalesOrderID = SalesOrderID;
            this.OrderDate = OrderDate;
            this.DueDate = DueDate;
            this.Status = Status;
            this.SalesOrderNumber = SalesOrderNumber;
            this.PurchaseOrderNumber = PurchaseOrderNumber;
            this.AccountNumber = AccountNumber;
            this.CustomerID = CustomerID;
            this.ShipToAddressID = ShipToAddressID;
            this.BillToAddressID = BillToAddressID;
            this.SubTotal = SubTotal;
            this.TaxAmt = TaxAmt;
            this.Freight = Freight;
            this.TotalDue = TotalDue;
            Customer = Customers.Find(cus => cus.CustomerID == this.CustomerID);
            ShipToAddress = Addresses.Find(ad => ad.AddressID == this.ShipToAddressID);
            BillToAddress = Addresses.Find(ad => ad.AddressID == this.BillToAddressID);
        }
        private int ShipToAddressID { get; set; }
        private int BillToAddressID { get; set; }
        private int CustomerID { get; set; }

        public int SalesOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public byte Status { get; set; }
        public Customer Customer { get; set; }
        public Address BillToAddress { get; set; }
        public Address ShipToAddress { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
    }
}
