using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_CodeFirst.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        // one custoimer with Many Orders
        public ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderItem { get; set; }
        public int Price { get; set; }
        // One Order with multiple customers
        public ICollection<Customer> Customers { get; set; }
    }
}
