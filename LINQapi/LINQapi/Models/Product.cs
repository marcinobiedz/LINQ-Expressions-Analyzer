using System;
using System.Collections.Generic;

namespace LINQapi.Models
{
    public class Product
    {
        public Product(int ProductID, string Name, string ProductNumber, decimal StandardCost,
            decimal ListPrice, int ProductCategoryID, DateTime SellStartDate, List<ProductCategory> ProductCategories)
        {
            this.ProductID = ProductID;
            this.Name = Name;
            this.ProductNumber = ProductNumber;
            this.StandardCost = StandardCost;
            this.ListPrice = ListPrice;
            this.ProductCategoryID = ProductCategoryID;
            this.SellStartDate = SellStartDate;
            ProductCategory = ProductCategories.Find(cat => cat.ProductCategoryID == this.ProductCategoryID);
        }
        private int ProductCategoryID { get; set; }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public DateTime SellStartDate { get; set; }
    }
}
