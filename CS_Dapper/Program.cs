using CS_Dapper.DataAccessServices;
using CS_Dapper.Models;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("using Dapper");
try
{
    DepartmentDataAccessService deptServ = new DepartmentDataAccessService();

    var result = await deptServ.GetAsync();

    Console.WriteLine($"Data \n");
    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result));

    var dept = new Department()
    {
        DeptNo = 9001, DeptName = "Test 12356",Location="MUmbai", Capacity=988
    };

    //var resp1 = await deptServ.CreateAsync(dept);

    //var resp1 = await deptServ.UpdateAsync(dept.DeptNo,dept);

    var resp1 = await deptServ.DeleteAsync(dept.DeptNo);
}
catch (Exception ex)
{
    Console.WriteLine($"Error {ex.Message}");
}
Console.ReadLine(); 
