using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Abstract_Override.Logic
{
    public class Accounts
    {
        /// <summary>
        /// Dynamic Polymorphism
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public decimal GetStaffIncome(StaffLogicAbstract staff)
        {
            decimal NetIncome = staff.CalculateIncome() - staff.ShareToHospital();
            return NetIncome;
        }
    }
}
