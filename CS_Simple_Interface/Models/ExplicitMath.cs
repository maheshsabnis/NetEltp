using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Simple_Interface.Models
{
    /// <summary>
    /// Let the class Implement the interface Explicitly
    /// </summary>
    public class ExplicitMath : ISimpleMath
    {
        int ISimpleMath.Add(int x, int y)
        {
            return x + y;
        }
        int ISimpleMath.Sub(int x, int y)
        {
            return x - y;   
        }
    }
}
