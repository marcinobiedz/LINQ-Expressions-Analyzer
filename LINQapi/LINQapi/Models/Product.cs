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
        private int ProductCategoryID { get; }

        public int ProductID { get; }
        public string Name { get; }
        public string ProductNumber { get; }
        public decimal StandardCost { get; }
        public decimal ListPrice { get; }
        public ProductCategory ProductCategory { get; }
        public DateTime SellStartDate { get; }
    }
}
