using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Inheritence.Models
{
    /// <summary>
    /// DOcer is-a Staff. Derived from Staff 
    /// </summary>
    public class Doctor : Staff
    {
        public Doctor()
        {
            Console.WriteLine("CTOR for Doctor");
        }
        public string? Specialization { get; set; }
        public int Fees { get; set; }
        public int MaxPatientsPerDay { get; set; }

        public void SetBasicPay(int pay)
        {
            this.BasicPay = pay;
        }

        public int GetBasicPay()
        {
            return this.BasicPay;
        }


    }
}
