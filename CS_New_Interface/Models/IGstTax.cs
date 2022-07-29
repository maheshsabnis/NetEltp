using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_New_Interface.Models
{
    public interface IGstTax
    {
        decimal CalculateTax(decimal taxableAmount);
    }
}
