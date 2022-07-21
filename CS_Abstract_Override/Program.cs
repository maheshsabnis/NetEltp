using CS_Abstract_Override.Logic;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Play with Inheritence with BAsed and Derived classes");

//StaffLogic sLogic = new StaffLogic(10000);
//Console.WriteLine($"Staff Income =  {sLogic.CalculateIncome()}");


DoctorLogic dLogic = new DoctorLogic(50000, 500, 10);
// Console.WriteLine($"Doctro Income is = {dLogic.CalculateIncome()}");

// Lets Type-Cast the DoctorLogic instance to StaffLogic
// Polymorphic behavior to method using an Instance Casting
var income =    ((StaffLogic)dLogic).CalculateIncome();
Console.WriteLine($"Income = {income}");

Console.WriteLine();
Console.WriteLine("Using An Accountant GAteway to Get an INome");

StaffLogicAbstract staff = new DoctorLogicEx(300, 4);

Accounts accounts = new Accounts();

Console.WriteLine($"Net Income for First Staff = {accounts.GetStaffIncome(staff)}");
Console.WriteLine();

staff = new NurseLogicEx(1000, 60);

Console.WriteLine($"Net Income for Second Staff = {accounts.GetStaffIncome(staff)}");


Console.ReadLine();
