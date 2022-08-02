using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace CS_Serialization
{
    /// <summary>
    /// The SerializableAttribute class
    /// Provide the Behavior to Employee class that the state of its object
    /// Can be strored in 'Stream'
    /// </summary>
    [Serializable]
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
    }
}
