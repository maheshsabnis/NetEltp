using CS_Parallel_For;
using System.Diagnostics;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("USing Parallel For");

var nonParallelTimer = Stopwatch.StartNew();
var empList = new EmployeeList();
for (int i = 0; i < empList.Count; i++)
{
    empList[i] = ProcessTax.CalculateTax(empList[i]);
    Console.WriteLine($"Sequential Tax of {empList[i].EmpNo} {empList[i].EmpName} is = {empList[i].TDS}");
}

Console.WriteLine($"Non-Parallel Timing {nonParallelTimer.Elapsed.TotalSeconds}");
Console.WriteLine();

var parallelTimer = Stopwatch.StartNew();



Parallel.For(0, empList.Count, (i) =>
{
    empList[i] = ProcessTax.CalculateTax(empList[i]);
    Console.WriteLine($"Parallel Tax of   {empList[i].EmpNo}  {empList[i].EmpName} is = {empList[i].TDS}");
});
Console.WriteLine($"Parallel Timing {parallelTimer.Elapsed.TotalSeconds}");
Console.ReadLine(); 