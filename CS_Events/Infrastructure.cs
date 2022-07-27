using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Events
{
    // 1. Declare a delegate for events
    // IMP: The delegate must be 'void' is it is used for declaring event
    public delegate void TransactionEventHandler(decimal amout);

    public class Banking
    {
        decimal NetBalance = 0;

        // 2. Declare Events

        public event TransactionEventHandler OverBalance;
        public event TransactionEventHandler UnderBalance;


        public Banking(decimal netBalance)
        {
            NetBalance = netBalance;
        }

        public void Deposit(decimal amount)
        {
            NetBalance += amount;
            // 3. Raise an event
            if (NetBalance > 100000)
            {
                // The paraeter is called as 'EventArguments'
                OverBalance(NetBalance);
            }
        }
        public void Withdrawal(decimal amount)
        {
            NetBalance -= amount;
            // 3. Raise an event
            if (NetBalance < 5000)
            {
                UnderBalance(NetBalance);
            }
        }

        public decimal GetNetBalance()
        {
            return NetBalance;
        }
    }

    /// <summary>
    /// The class that will be used to Listen to event
    /// </summary>
    public class EventListener
    {
        private Banking bank;
        /// <summary>
        /// 4. The EventListener Subscribe to the Bank Object
        /// </summary>
        /// <param name="bank"></param>
        public EventListener(Banking bank)
        {
            this.bank = bank;
            // 5. Define an INfrastructure to Notify the Data to CLient
            // when an event is raised
            // Method Linking to an EVent so that when an event is raised
            // this method will be invoked
            bank.OverBalance += Bank_OverBalance;
            bank.UnderBalance += Bank_UnderBalance;
             
        }

        private void Bank_UnderBalance(decimal amout)
        {
            decimal underbalance = 5000 - amout;
            Console.WriteLine($"Your current balamce is Rs.{underbalance} so please maintain Rs.5000 in your account");
        }

        private void Bank_OverBalance(decimal amout)
        {
            decimal TaxableAmount = amout - 100000;
            decimal Tax = TaxableAmount * Convert.ToDecimal( 0.2);
            Console.WriteLine($"Dear Account Holder, your next balane is Rs.{amout} which is Rs.{TaxableAmount} more than Rs 100000 so Please pay tax of amout Rs.{Tax} immediately, else Mr. Modi will catch you.");
        }
    }
}
