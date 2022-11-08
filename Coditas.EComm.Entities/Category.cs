using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Coditas.EComm.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Required(ErrorMessage ="Category Id is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; } = null!;
        [Required(ErrorMessage = "Base Price is required")]
        public decimal BasePrice { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
