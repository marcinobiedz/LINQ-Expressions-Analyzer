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
        private int ShipToAddressID { get; }
        private int BillToAddressID { get; }
        private int CustomerID { get; }

        public int SalesOrderID { get; }
        public DateTime OrderDate { get; }
        public DateTime DueDate { get; }
        public byte Status { get; }
        public Customer Customer { get; }
        public Address BillToAddress { get; }
        public Address ShipToAddress { get; }
        public string SalesOrderNumber { get; }
        public string PurchaseOrderNumber { get; }
        public string AccountNumber { get; }
        public decimal SubTotal { get; }
        public decimal TaxAmt { get; }
        public decimal Freight { get; }
        public decimal TotalDue { get; }
    }
}
