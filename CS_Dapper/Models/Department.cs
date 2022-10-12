using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Dapper.Models
{
    internal class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; } =  string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
