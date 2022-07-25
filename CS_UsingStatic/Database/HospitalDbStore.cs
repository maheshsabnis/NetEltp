using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_UsingStatic.Entities;
namespace CS_UsingStatic.Database
{
    public class HospitalDbStore
    {
        /// <summary>
        /// Global Store
        /// </summary>
        public static List<Staff>? GlobalStaffStore { get; set; } = new List<Staff>();

    }
}
