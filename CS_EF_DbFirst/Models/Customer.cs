using System;
using System.Collections.Generic;

namespace CS_EF_DbFirst.Models
{
    public partial class Customer
    {
        public int CustomerUniqueId { get; set; }
        public int CustomerId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public int? Age { get; set; }
    }
}
