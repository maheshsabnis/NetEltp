using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Destructor_NetFrwk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main");
            MyClass obj = new MyClass();
            obj.Print();
            obj.Dispose();
            Console.ReadLine();
        }
    }


    public class MyClass : IDisposable
    {
        public MyClass()
        {
            Console.WriteLine("Constructor Called");
        }
        public void Print()
        {
            Console.WriteLine("I Am Print");
        }

        public void Dispose()
        {
            // Immediately Call the FInalize to Kill The Object and Release it
             GC.SuppressFinalize(this);
            
        }

        ~MyClass()
        {
            Console.WriteLine("Destructor Called");
            Console.ReadLine();
        }
    }
}
