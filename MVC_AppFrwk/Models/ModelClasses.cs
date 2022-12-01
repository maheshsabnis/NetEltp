using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppFrwk.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
    }

    public class EmployeedDb : List<Employee> 
    {
        public EmployeedDb()
        {
            Add(new Employee() {EmpNo=1,EmpName = "A"});
            Add(new Employee() { EmpNo = 2, EmpName = "B" });
        }
    }
}