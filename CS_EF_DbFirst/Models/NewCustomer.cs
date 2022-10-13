using System;
using System.Collections.Generic;

namespace CS_EF_DbFirst.Models
{
    public partial class NewCustomer
    {
        public int CustomerId { get; set; }
        public string City { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
    }
}
