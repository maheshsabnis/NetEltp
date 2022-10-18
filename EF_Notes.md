# EF COre COde First

1. CReate a Class with public Members (Entity with Properties)
	 - APply Annotations on it
		- Key
		- Constratints
	 - create a DbCOntext class that contains DbSet<T> where T is entity class and OnCOnfiguring Method that contains COnnection string 
2. CReate Migrations, a class that contains C# code to Map Class with Expected Table with its COlumns
	- CreateTable()
	- DropTable()

	- Migration COmmand
		- dotnet ef migrations add [NAME-OF-THE-MGRATION] -c [NAMESPACE.DBCOTEXTCLASS-NAME]
		- dotnet ef migrations add firstMigration -c CS_EF_CodeFirst.Models.InfoDbContext
	
	
3. Update Database, execute Magrations and will connect to database over connestion string and generate tables with Entities Mapping 
	- dotnet ef database update -c  [NAMESPACE.DBCOTEXTCLASS-NAME]
	- dotnet ef database update -c CS_EF_CodeFirst.Models.InfoDbContext


4. How to DEfine One-to-Many Relationships
	- Parent and CHild Table

5. HasMany().WithMany()
	- Extension Methods for ModeelBuilder class
	- Entity.HasMany() Related Entities, and Reated Entities has relationship WithMany() entities


# Accessing SP using EF COe

using Microsoft.EntityFrameworkCore;
using EF_Core_SP.Models;
using Microsoft.Data.SqlClient;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Calling SP");

//GetAllEmployees();

// GetAllEmployeesByDeptNo();

//InsertDept();

//ExecptionSP();

Print();

Console.ReadLine();


static void GetAllEmployees()
{
    UCompanyContext context = new UCompanyContext();

    var employees = context.Employees.FromSqlRaw("sp_getAllEmployees").ToList();

    foreach (var emp in employees)
    {
        Console.WriteLine($"{emp.EmpNo} {emp.EmpName} {emp.Designation} {emp.Salary} {emp.Salary}");
    }
}

static void GetAllEmployeesByDeptNo()
{
    UCompanyContext context = new UCompanyContext();

    SqlParameter param = new SqlParameter();
    param.ParameterName = "@DeptNo";
    param.DbType = System.Data.DbType.Int32;
    param.Direction = System.Data.ParameterDirection.Input;
    param.Value = 20;
    

    var employees = context.Employees.FromSqlRaw("sp_getEmployeesByDeptNo @DeptNo", param).ToList();

    foreach (var emp in employees)
    {
        Console.WriteLine($"{emp.EmpNo} {emp.EmpName} {emp.Designation} {emp.Salary} {emp.DeptNo}");
    }
}


static void InsertDept()
{
    UCompanyContext context = new UCompanyContext();

    var pDeptNo = new SqlParameter("@DeptNo", 222);
    var pDeptName = new SqlParameter("@DeptName",System.Data.SqlDbType.VarChar, 200);
    pDeptName.Value = "Dept_2222";
    var pLocation = new SqlParameter("@Location", System.Data.SqlDbType.VarChar, 100);
    pLocation.Value = "Pune";
    var pCapacity = new SqlParameter("@Capacity", System.Data.SqlDbType.Int);
    pCapacity.Value = 700;

    var result = context.Database.ExecuteSqlRaw("sp_InsertDept @DeptNo,@DeptName,@Location,@Capacity", new[] {pDeptNo,pDeptName,pLocation,pCapacity } );

    GetAllEmployees();
}

static void ExecptionSP()
{
    try
    {

        UCompanyContext context = new UCompanyContext();

        SqlParameter param = new SqlParameter();
        param.ParameterName = "@DeptNo";
        param.DbType = System.Data.DbType.Int32;
        param.Direction = System.Data.ParameterDirection.Input;
        param.Value = -20;

        var res = context.Database.ExecuteSqlRaw("EXEC sp_getSumOfSalByDeptNo @DeptNo", param);


        Console.WriteLine($"Result =  {res}");

        //var employees = context.Employees.FromSqlRaw("sp_getSumOfSalByDeptNo @DeptNo", param).ToList();

        //foreach (var emp in employees)
        //{
        //    Console.WriteLine($"{emp.EmpNo} {emp.EmpName} {emp.Designation} {emp.Salary} {emp.DeptNo}");
        //}
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void Print()
{
    UCompanyContext context = new UCompanyContext();
    var result = context.Employees.FromSqlRaw("Select * from Employee");

    foreach (var emp in result)
    {
        Console.WriteLine(emp.EmpName);
    }



}
