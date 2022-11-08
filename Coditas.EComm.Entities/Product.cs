using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Coditas.EComm.Entities
{
    public partial class Product
    {
        
        public int ProductUniqueId { get; set; }
        [Required(ErrorMessage = "Product Id is required")]
        public string ProductId { get; set; } = null!;
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; } = null!;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Product Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Category Id is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Manufacturer is required")]
        public string Manufacturer { get; set; } = null!;

        public virtual Category? Category { get; set; }
    }
}
