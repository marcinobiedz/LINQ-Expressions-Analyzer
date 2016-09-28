using LINQapi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace LINQapi.Helpers
{
    public class MyDbSet
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"Database\";
        public List<Address> Addresses { get; }
        public List<Customer> Customers { get; }
        public List<Product> Products { get; }
        public List<ProductCategory> ProductCategories { get; }
        public List<SalesOrderDetail> SalesOrderDetails { get; }
        public List<SalesOrderHeader> SalesOrderHeaders { get; }
        public Dictionary<string, int> ColectionSizes = new Dictionary<string, int>();

        public MyDbSet()
        {
            this.Addresses = new List<Address>();
            this.setAddresses();
            this.Customers = new List<Customer>();
            this.setCustomers();
            this.Products = new List<Product>();
            this.setProducts();
            this.ProductCategories = new List<ProductCategory>();
            this.setProductCategories();
            this.SalesOrderDetails = new List<SalesOrderDetail>();
            this.setSalesOrderDetails();
            this.SalesOrderHeaders = new List<SalesOrderHeader>();
            this.setSalesOrderHeaders();
            ColectionSizes.Add("Addresses", Addresses.Count);
            ColectionSizes.Add("Customers", Customers.Count);
            ColectionSizes.Add("Products", Products.Count);
            ColectionSizes.Add("ProductCategories", ProductCategories.Count);
            ColectionSizes.Add("SalesOrderDetails", SalesOrderDetails.Count);
            ColectionSizes.Add("SalesOrderHeaders", SalesOrderHeaders.Count);
        }

        private void setSalesOrderHeaders()
        {
            var reader = new StreamReader(File.OpenRead(path + @"SalesOrderHeader.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.SalesOrderHeaders.Add(new SalesOrderHeader()
                {
                    SalesOrderID = Int32.Parse(values[0]),
                    OrderDate = DateTime.Parse(values[1]),
                    DueDate = DateTime.Parse(values[2]),
                    Status = byte.Parse(values[3]),
                    SalesOrderNumber = values[4],
                    PurchaseOrderNumber = values[5],
                    AccountNumber = values[6],
                    CustomerID = Int32.Parse(values[7]),
                    ShipToAddressID = Int32.Parse(values[8]),
                    BillToAddressID = Int32.Parse(values[9]),
                    SubTotal = decimal.Parse(values[10]),
                    TaxAmt = decimal.Parse(values[11]),
                    Freight = decimal.Parse(values[12]),
                    TotalDue = decimal.Parse(values[13])
                });
            }
        }

        private void setSalesOrderDetails()
        {
            var reader = new StreamReader(File.OpenRead(path + @"SalesOrderDetail.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.SalesOrderDetails.Add(new SalesOrderDetail()
                {
                    SalesOrderDetailID = Int32.Parse(values[0]),
                    SalesOrderID = Int32.Parse(values[1]),
                    OrderQty = short.Parse(values[2]),
                    ProductID = int.Parse(values[3]),
                    UnitPrice = decimal.Parse(values[4]),
                    UnitPriceDiscount = decimal.Parse(values[5]),
                    LineTotal = decimal.Parse(values[6])
                });
            }
        }

        private void setProductCategories()
        {
            var reader = new StreamReader(File.OpenRead(path + @"ProductCategory.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.ProductCategories.Add(new ProductCategory()
                {
                    ProductCategoryID = Int32.Parse(values[0]),
                    Name = values[1]
                });
            }
        }

        private void setProducts()
        {
            var reader = new StreamReader(File.OpenRead(path + @"Product.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.Products.Add(new Product()
                {
                    ProductID = Int32.Parse(values[0]),
                    Name = values[1],
                    ProductNumber = values[2],
                    StandardCost = decimal.Parse(values[3]),
                    ListPrice = decimal.Parse(values[4]),
                    ProductCategoryID = int.Parse(values[5]),
                    SellStartDate = DateTime.Parse(values[6])
                });
            }
        }

        private void setCustomers()
        {
            var reader = new StreamReader(File.OpenRead(path + @"Customer.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.Customers.Add(new Customer()
                {
                    CustomerID = Int32.Parse(values[0]),
                    FirstName = values[1],
                    LastName = values[2],
                    EmailAddress = values[3],
                    Phone = values[4]
                });
            }
        }

        private void setAddresses()
        {
            var reader = new StreamReader(File.OpenRead(path + @"Address.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.Addresses.Add(new Address()
                {
                    AddressID = Int32.Parse(values[0]),
                    AddressLine = values[1],
                    City = values[2],
                    CountryRegion = values[3],
                    PostalCode = values[4]
                });
            }
        }
    }
}