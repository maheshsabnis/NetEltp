using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SimleDataAccess.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } =  string.Empty;
        public decimal BasePrice { get; set; }
    }

    public class Product
    {
        public int ProductUniqueId { get; set; }
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

}
