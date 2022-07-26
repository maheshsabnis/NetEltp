using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Simple_Interface.Models
{
    /// <summary>
    /// Implicit Implementation
    /// </summary>
    public class SimpleMath : ISimpleMath
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
}
