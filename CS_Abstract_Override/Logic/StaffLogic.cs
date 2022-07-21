using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Abstract_Override.Logic
{
    public class StaffLogic
    {
        protected decimal BasicPay = 0;

        public StaffLogic(decimal basicPay)
        {
            BasicPay = basicPay;
        }

        public decimal CalculateIncome()
        {
            return BasicPay;
        }
    }



    public class DoctorLogic : StaffLogic
    {
        private int PatientsDiagonsed = 0;
        private int OperationsPerDay = 0;

        /// <summary>
        /// Calling the BAse Class CTOR and passing parameter to it
        /// </summary>
        /// <param name="sal"></param>
        /// <param name="patientsDiagonsed"></param>
        /// <param name="operationsPerDay"></param>
        public DoctorLogic(decimal sal, int patientsDiagonsed, int operationsPerDay): base(sal)
        {
            PatientsDiagonsed = patientsDiagonsed;
            OperationsPerDay = operationsPerDay;
        }

        /// <summary>
        /// Shadowed Method
        /// </summary>
        /// <returns></returns>
        public new decimal CalculateIncome()
        {
            decimal operationFees = OperationsPerDay * 30 * 10000;
            decimal patientsFessReceived = PatientsDiagonsed * 30 * 500;
            // Call BAse CLass Implementation to ger return value
            return base.CalculateIncome() + operationFees + patientsFessReceived;
        }

    }
       
}
