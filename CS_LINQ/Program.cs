using CS_LINQ;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using LINQ");


var person = new { PersonId = 1, PersonName = "MAhesh" };


EmployeeCollection employees = new EmployeeCollection();

//foreach (var item in employees)
//{
//    if (item.DeptName == "IT" && item.EmpName.StartsWith('Y'))
//    {
//        Console.WriteLine(item.EmpName);
//    }
//}

// Retrieve only those employees having DeptName as IT
var EmpByDname = employees.Where(emp => emp.DeptName == "IT");
Print(EmpByDname);

Console.WriteLine();
var EmpInSortedByEmpame = EmpByDname.OrderBy(emp=>emp.EmpName);
Print(EmpInSortedByEmpame);
Console.WriteLine();
var EmpInSortedByEmpameDesc = EmpByDname.OrderByDescending(emp => emp.EmpName);

var FInalResult = employees.Where(emp => emp.DeptName == "IT").OrderBy(emp => emp.EmpName);


// USing the LINQ Query Approach

var empByDeptName = from emp in employees
                    where emp.DeptName == "IT"
                    select emp;

Print(empByDeptName);
Console.WriteLine();


var empByDeptNameOrder = from emp in employees
                    where emp.DeptName == "IT"
                    orderby emp.EmpName ascending
                    select emp;


Print(empByDeptNameOrder);


Console.WriteLine("");
Console.WriteLine("Sum of Salary Group by DeptName");

var sumlgroupbydeptname = (from emp in employees
                          // Group on DeptNAme ponuted by the deptgroup
                          group emp by emp.DeptName into deptgroup
                          // selecting each record from each group to calculate Sum of salary
                          // and stored it in Anonymous Type
                          select new
                          {
                              DeptName = deptgroup.Key, // The Group Name
                              Salary = deptgroup.Sum(e=>e.Salary)
                          }).ToList(); // COnvert the result into List


foreach (var item in sumlgroupbydeptname)
{
    Console.WriteLine($"DeptName = {item.DeptName} and Salary = {item.Salary}");
}


static void Print(IEnumerable<Employee> emps)
{
    foreach (var item in emps)
    {
        Console.WriteLine(item.EmpName);
    }
}




Console.ReadLine(); 
