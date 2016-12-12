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
            this.SalesOrder = SalesOrderHeaders.Find(soh => soh.SalesOrderID == this.SalesOrderID);
            this.Product = Products.Find(prod => prod.ProductID == this.ProductID);
        }
        private int SalesOrderID { get; }
        private int ProductID { get; }

        public int SalesOrderDetailID { get; }
        public SalesOrderHeader SalesOrder { get; }
        public short OrderQty { get; }
        public Product Product { get; }
        public decimal UnitPrice { get; }
        public decimal UnitPriceDiscount { get; }
        public decimal LineTotal { get; }
    }
}
