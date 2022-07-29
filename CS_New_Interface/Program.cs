using CS_New_Interface.Models;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Demo ABstract Class && Interfaces");

StaffLogic staff = new DoctorLogic(29999);

Console.WriteLine($"Doc INcome {staff.GetIncome()}");
// Tax Result from Doctor
var tds = ((ITax)staff).CalculateTax(29999);

// GST Result for the Doctor
var gst = ((IGstTax)staff).CalculateTax(5555);


Console.ReadLine(); 