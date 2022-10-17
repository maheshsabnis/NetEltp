using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_CodeFirst.Models
{
    public class Category
    {
        [Key]
        public int CategoryRowId { get; set; }
        [Required]
        [StringLength(700)]
        public string CategoryId { get; set; }
        [Required]
        [StringLength(700)]
        public string CategoryName { get; set; }
        public int BasePrice { get; set; }
        // Expected One-to-Many Relation
        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductRowId { get; set; }
        [Required]
        [StringLength(700)]
        public string ProductId { get; set; }
        [Required]
        [StringLength(700)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(700)]
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        // Foreign Key (Expected)
       public int CategoryRowId { get; set; }
        // Expected REferential INtegrity
        public Category Category { get; set; }
    }
}
