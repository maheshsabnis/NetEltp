using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_New_Interface.Models
{
    public abstract class StaffLogic
    {
        private decimal BasicSalary = 0;
        public StaffLogic(decimal basicSalary)
        {
            BasicSalary = basicSalary;
        }

        public virtual decimal GetIncome()
        {
            return BasicSalary;
        }
    }

    public class DoctorLogic : StaffLogic, ITax, IGstTax
    {
        public DoctorLogic(decimal sal):base(sal)
        {

        }
        public override decimal GetIncome()
        {
            return base.GetIncome();
        }

        decimal ITax.CalculateTax(decimal taxableAmount)
        {
            return Convert.ToDecimal(222222);
        }

        decimal IGstTax.CalculateTax(decimal taxableAmount)
        {
            return Convert.ToDecimal(111111 * 18/100);
        }
    }

    public class NurseLogic : StaffLogic, ITax
    {
        public NurseLogic(decimal sal) : base(sal)
        {

        }
        public override decimal GetIncome()
        {
            return base.GetIncome();
        }

        decimal ITax.CalculateTax(decimal taxableAmount)
        {
            return Convert.ToDecimal(111111);
        }
    }


}
