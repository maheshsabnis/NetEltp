using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Inheritence.Models
{
    /// <summary>
    /// Class with Auto-Impmented Properties C# 3.0
    /// </summary>
    public class Staff
    {
        public Staff()
        {
            Console.WriteLine("CTOR for Staff");
        }
        public int StaffId { get; set; }
        public string StaffName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public int ContactNo { get; set; }
        public string? Education { get; set; }
        public int ShiftStartTime { get; set; }
        public int ShiftEndTime { get; set; }
        protected int BasicPay { get; set; }
    }
}
