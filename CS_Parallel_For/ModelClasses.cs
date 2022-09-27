namespace CS_Parallel_For
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; } = String.Empty;
        public int Salary { get; set; }
        public decimal TDS { get; set; }
    }

    public static class ProcessTax
    {
        public static Employee CalculateTax(Employee emp)
        {
            System.Threading.Thread.Sleep(100);
            emp.TDS = emp.Salary * Convert.ToDecimal(0.1);
            return emp;
        }
    }

    public class EmployeeList : List<Employee>
    {
        public EmployeeList()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Abhay", Salary = 11000 });
            Add(new Employee() { EmpNo = 102, EmpName = "Baban", Salary = 22000 });
            Add(new Employee() { EmpNo = 103, EmpName = "Chaitanya", Salary = 33000 });
            Add(new Employee() { EmpNo = 104, EmpName = "Deepak", Salary = 44000 });
            Add(new Employee() { EmpNo = 105, EmpName = "Eshwar", Salary = 55000 });
            Add(new Employee() { EmpNo = 106, EmpName = "Falgun", Salary = 66000 });
            Add(new Employee() { EmpNo = 107, EmpName = "Ganpat", Salary = 77000 });
            Add(new Employee() { EmpNo = 108, EmpName = "Hitesh", Salary = 88000 });
            Add(new Employee() { EmpNo = 109, EmpName = "Ishan", Salary = 99000 });
            Add(new Employee() { EmpNo = 110, EmpName = "Jay", Salary = 31000 });
            Add(new Employee() { EmpNo = 111, EmpName = "Kaushubh", Salary = 21000 });
            Add(new Employee() { EmpNo = 112, EmpName = "Lakshman", Salary = 22000 });
            Add(new Employee() { EmpNo = 113, EmpName = "Mohan", Salary = 23000 });
            Add(new Employee() { EmpNo = 114, EmpName = "Naveen", Salary = 24000 });
            Add(new Employee() { EmpNo = 115, EmpName = "Omkar", Salary = 25000 });
            Add(new Employee() { EmpNo = 116, EmpName = "Prakash", Salary = 26000 });
            Add(new Employee() { EmpNo = 117, EmpName = "Qumars", Salary = 27000 });
            Add(new Employee() { EmpNo = 118, EmpName = "Ramesh", Salary = 28000 });
            Add(new Employee() { EmpNo = 119, EmpName = "Sachin", Salary = 29000 });
            Add(new Employee() { EmpNo = 120, EmpName = "Tushar", Salary = 30000 });
            Add(new Employee() { EmpNo = 121, EmpName = "Umesh", Salary = 31000 });
            Add(new Employee() { EmpNo = 122, EmpName = "Vivek", Salary = 32000 });
            Add(new Employee() { EmpNo = 123, EmpName = "Waman", Salary = 33000 });
            Add(new Employee() { EmpNo = 124, EmpName = "Xavier", Salary = 34000 });
            Add(new Employee() { EmpNo = 125, EmpName = "Yadav", Salary = 35000 });
            Add(new Employee() { EmpNo = 126, EmpName = "Zishan", Salary = 36000 });

        }
    }
}
