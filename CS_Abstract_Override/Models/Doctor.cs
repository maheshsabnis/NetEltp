using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Abstract_Override.Models
{
    /// <summary>
    /// DOcer is-a Staff. Derived from Staff 
    /// </summary>
    public class Doctor : Staff
    {
        public string? Specialization { get; set; }
        public int Fees { get; set; }
        public int MaxPatientsPerDay { get; set; }
    }
}
