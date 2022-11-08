using System;
using System.Collections.Generic;

namespace Coditas.EComm.DataAccess.Models
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
