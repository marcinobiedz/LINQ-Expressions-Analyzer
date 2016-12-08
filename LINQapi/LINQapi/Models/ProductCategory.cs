using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQapi.Models
{
    public class ProductCategory
    {
        public ProductCategory(int ProductCategoryID, string Name)
        {
            this.ProductCategoryID = ProductCategoryID;
            this.Name = Name;
        }

        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
    }
}
