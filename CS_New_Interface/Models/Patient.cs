using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_New_Interface.Models
{
    public class Patient : ITax, IGstTax
    {
        public void RegisterPatient()
        { 
            // Logic Here
        }

        decimal ITax.CalculateTax(decimal taxableAmount)
        {
            return Convert.ToDecimal(3333);
        }

        decimal IGstTax.CalculateTax(decimal taxableAmount)
        {
            return Convert.ToDecimal(222222 * 18/100);
        }
    }
}
