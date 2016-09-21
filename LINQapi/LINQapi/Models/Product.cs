using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVcreator.Models
{
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int ProductCategoryID { get; set; }
        public DateTime SellStartDate { get; set; }
    }
}
