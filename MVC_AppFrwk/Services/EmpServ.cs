using MVC_AppFrwk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppFrwk.Services
{
    public interface IServ
    {
        List<Employee> GetEmployees(); 
    }

    public class EmployeeService : IServ
    {
        List<Employee> IServ.GetEmployees()
        {
            return new EmployeedDb();
        }
    }
}