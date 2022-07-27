using CS_Events;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Demo Events");
Banking bank = new Banking(70000);
// Subscribe to the EVentListener
EventListener listener = new EventListener(bank);

Console.WriteLine($"Initial NetBalance = Rs.{bank.GetNetBalance()}");
bank.Deposit(80000);
Console.WriteLine($"Deposite NetBalance = Rs.{bank.GetNetBalance()}");

bank.Withdrawal(145000);
Console.WriteLine($"Withdrawal NetBalance = Rs.{bank.GetNetBalance()}");

Console.ReadLine();    
