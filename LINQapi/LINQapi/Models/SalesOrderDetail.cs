using System.Collections.Generic;

namespace LINQapi.Models
{
    public class SalesOrderDetail
    {
        public SalesOrderDetail(int SalesOrderDetailID, int SalesOrderID, short OrderQty, int ProductID, decimal UnitPrice,
            decimal UnitPriceDiscount, decimal LineTotal, List<SalesOrderHeader> SalesOrderHeaders, List<Product> Products)
        {
            this.SalesOrderDetailID = SalesOrderDetailID;
            this.SalesOrderID = SalesOrderID;
            this.OrderQty = OrderQty;
            this.ProductID = ProductID;
            this.UnitPrice = UnitPrice;
            this.UnitPriceDiscount = UnitPriceDiscount;
            this.LineTotal = LineTotal;
            this.SalesOrderHeader = SalesOrderHeaders.Find(soh => soh.SalesOrderID == this.SalesOrderID);
            this.Product = Products.Find(prod => prod.ProductID == this.ProductID);
        }
        private int SalesOrderID { get; set; }
        private int ProductID { get; set; }

        public int SalesOrderDetailID { get; set; }
        public SalesOrderHeader SalesOrderHeader { get; set; }
        public short OrderQty { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
    }
}
