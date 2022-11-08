using System;
using System.Collections.Generic;

namespace Coditas.EComm.DataAccess.Models
{
    public partial class NewCustomer
    {
        public int CustomerId { get; set; }
        public string City { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
    }
}
