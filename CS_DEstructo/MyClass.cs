using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DEstructo
{
    public class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("Constructor Called");
        }
        public void Print()
        {
            Console.WriteLine("I Am Print");
        }
        ~MyClass()
        {
            Console.WriteLine("Destructor Called");
            Console.ReadLine(); 
        }
    }
}
