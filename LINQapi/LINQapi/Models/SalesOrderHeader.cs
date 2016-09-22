using System;

namespace LINQapi.Models
{
    class SalesOrderHeader
    {
        public int SalesOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public byte Status { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public int ShipToAddressID { get; set; }
        public int BillToAddressID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
    }
}
