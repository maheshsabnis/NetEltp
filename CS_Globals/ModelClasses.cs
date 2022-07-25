using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Globals
{
    public class Standard
    {
        // the static Member
        static int x = 0;

        public void Increment()
        {
            Console.WriteLine($"Original x = {x}");
            x++;
            Console.WriteLine($"Increment x = {x}");
        }

        public void Decrement()
        {
            Console.WriteLine($"Decrement Original x = {x}");
            x = x * 4;
            Console.WriteLine($"Decrement x = {x}");
        }

    }
}
