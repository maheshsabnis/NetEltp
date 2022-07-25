using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sealed
{
    /// <summary>
    ///  Cannot be inherited
    /// </summary>
    public sealed class StringOperations
    {
        public int GetLength(string str)
        {
            return str.Length;
        }
    }

    public class StringEnhancer : StringOperations
    { 
    }
}
