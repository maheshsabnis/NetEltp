using CS_Conditional_Read;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("USing Take Skeip");

var employees = new EmployeeCollection();

var take_1 = employees.Take(4);

Print(take_1);

Console.WriteLine();
var take_2 = (from emp in employees
             select emp).Take(2);

Print(take_2);

Console.WriteLine();
var skip_1 = employees.Skip(3);
Print(skip_1);

// TAke the First  EMployee with DeptNAme as ACCTS

var firstEmpACCTS = (from emp in employees
                    where emp.DeptName == "ACCTS"
                    select emp).Take(1);

Print(firstEmpACCTS);

// Get second Highest Salary

var secongHighestSalary = (from emp in employees
                          orderby emp.Salary descending
                          select emp).Skip(1).Take(1);
Print(secongHighestSalary);   


Console.ReadLine();

static void Print(IEnumerable<Employee> emps)
{
    foreach (var item in emps)
    {
        Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName} {item.Salary}");
    }
}
