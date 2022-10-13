
using CS_EF_DbFirst.DataAccess;
using CS_EF_DbFirst.Models;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("EF COre DB First");
try
{
    //EmployeeDataAccess empds = new EmployeeDataAccess();

    //Console.WriteLine($"USing Traditional DbCOntext = {JsonSerializer.Serialize( await empds.GetDataAsync())}");
    //Console.WriteLine();
    //Console.WriteLine($"USing LINQ = {JsonSerializer.Serialize( await empds.GetDataLINQAsync())}");
    //Console.WriteLine();
    //Console.WriteLine($"Using Orderby {JsonSerializer.Serialize( await empds.GetDataLINQOrderByAsync())}");


    //Console.WriteLine($"Using Sync {JsonSerializer.Serialize(JsonSerializer.Serialize(empds.GetDataLINQSync()))}");

    DepartentDataAccess deprds = new DepartentDataAccess();

    var res = await deprds.GetAsync();
    Print(res);
    Console.WriteLine();
    var deptSIngle = await deprds.GetAsync(202);
    Console.WriteLine(deptSIngle.DeptName); 
    Console.WriteLine();
    var d = new Department() { DeptNo = 203, DeptName = "DEpt_203", Location = "Pune", Capacity = 2100 };
    //   await deprds.CreateAsync(d);
    // await deprds.UpdateAsync(d.DeptNo, d);
    await deprds.DeleteAsync(d.DeptNo);
    Console.WriteLine();
    res = await deprds.GetAsync();
    Print(res);
}
catch (Exception ex)
{
    Console.WriteLine($"Error Occrred {ex.Message}");
}

Console.ReadLine();

static void Print(IEnumerable<Department> dept)
{
    Console.WriteLine(JsonSerializer.Serialize(dept));
}
