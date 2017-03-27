using LINQapi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace LINQapi.Helpers
{
    public class MyDbSet
    {
        private string basePath = AppDomain.CurrentDomain.BaseDirectory;
        private string path;
        public List<Address> Addresses { get; }
        public List<Customer> Customers { get; }
        public List<Product> Products { get; }
        public List<ProductCategory> ProductCategories { get; }
        public List<SalesOrderDetail> SalesOrderDetails { get; }
        public List<SalesOrderHeader> SalesOrderHeaders { get; }
        public List<int> Numbers { get; }
        public Dictionary<string, int> ColectionSizes = new Dictionary<string, int>();

        public MyDbSet()
        {
            path = basePath + (ConfigurationManager.AppSettings["DB_PATH"] == "Prod" ? @"Database\Large\" : @"Database\Small\");
            Addresses = new List<Address>();
            setAddresses();
            Customers = new List<Customer>();
            setCustomers();
            ProductCategories = new List<ProductCategory>();
            setProductCategories();
            Products = new List<Product>();
            setProducts();
            SalesOrderHeaders = new List<SalesOrderHeader>();
            setSalesOrderHeaders();
            SalesOrderDetails = new List<SalesOrderDetail>();
            setSalesOrderDetails();
            Numbers = Enumerable.Range(0, 1000000).ToList();
            ColectionSizes.Add("Addresses", Addresses.Count);
            ColectionSizes.Add("Customers", Customers.Count);
            ColectionSizes.Add("Products", Products.Count);
            ColectionSizes.Add("ProductCategories", ProductCategories.Count);
            ColectionSizes.Add("SalesOrderDetails", SalesOrderDetails.Count);
            ColectionSizes.Add("SalesOrderHeaders", SalesOrderHeaders.Count);
            ColectionSizes.Add("Numbers", Numbers.Count);
        }

        private void setSalesOrderHeaders()
        {
            var reader = new StreamReader(File.OpenRead(path + @"SalesOrderHeader.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.SalesOrderHeaders.Add(new SalesOrderHeader(int.Parse(values[0]), DateTime.Parse(values[1]),
                    DateTime.Parse(values[2]), byte.Parse(values[3]), values[4], values[5], values[6], int.Parse(values[7]),
                    int.Parse(values[8]), int.Parse(values[9]), decimal.Parse(values[10]), decimal.Parse(values[11]),
                    decimal.Parse(values[12]), decimal.Parse(values[13]), Customers, Addresses));
            }
        }

        private void setSalesOrderDetails()
        {
            var reader = new StreamReader(File.OpenRead(path + @"SalesOrderDetail.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.SalesOrderDetails.Add(new SalesOrderDetail(int.Parse(values[0]), int.Parse(values[1]), short.Parse(values[2]),
                    int.Parse(values[3]), decimal.Parse(values[4]), decimal.Parse(values[5]), decimal.Parse(values[6]),
                    SalesOrderHeaders, Products));
            }
        }

        private void setProductCategories()
        {
            var reader = new StreamReader(File.OpenRead(path + @"ProductCategory.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.ProductCategories.Add(new ProductCategory(Int32.Parse(values[0]), values[1]));
            }
        }

        private void setProducts()
        {
            var reader = new StreamReader(File.OpenRead(path + @"Product.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.Products.Add(new Product(int.Parse(values[0]), values[1], values[2], decimal.Parse(values[3]),
                    decimal.Parse(values[4]), int.Parse(values[5]), DateTime.Parse(values[6]), this.ProductCategories));
            }
        }

        private void setCustomers()
        {
            var reader = new StreamReader(File.OpenRead(path + @"Customer.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.Customers.Add(new Customer(Int32.Parse(values[0]), values[1], values[2], values[3], values[4]));
            }
        }

        private void setAddresses()
        {
            var reader = new StreamReader(File.OpenRead(path + @"Address.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                this.Addresses.Add(new Address(Int32.Parse(values[0]), values[1], values[2], values[3], values[4]));
            }
        }
    }
}