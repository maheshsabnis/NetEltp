// See https://aka.ms/new-console-template for more information


namespace CS_Delegate
{
    // Declare the Delegate
    // This will be used to accept reference of the a method
    // that has 2 integer input parameters and int output parameter
    public delegate int OperationHandler(int a, int b);

    class Program
    {
        static void Main()
        {
            Console.WriteLine("USing Delegate");

            // 1. TRditional Direct Method Call
            var res = Add(10, 20);
            Console.WriteLine($"Direct Method Call {res}");

            // Using a Delegate
            // 2. CReate a Delegate Type INstance and PAss a  
            //Method Address to it (JUST NAME OF THE METHOD)
            OperationHandler handler = new OperationHandler(Add);
            // 2.a. Invoke the method by PAssing Parameters to Delegate Type Instace
            int Result_1 = handler(400, 500);
            Console.WriteLine($"Access the Add using Delegate = {Result_1}");
            // 2.b.
            // directly pass the implementation to a delegate
            // C# 2.0 Anonymous Method (Method w/o name)
            OperationHandler handler_1 = delegate (int x, int y) { return x * y; };
            // 2.c. Pass the delegate to Bridge() method
            Bridge(handler_1);

            // 3. C# 3.0 USing Lambda Expression
            // Expression Tree
            // OPerands, OPerators and Expressions with Precedences
            // THis will be into Binary Form
            Bridge((a, b) => { return (a * a) + 2 * a * b + (b * b); });
            Console.ReadLine();

        }
        static int Add(int x, int y)
        {
            return x + y;
        }
        /// <summary>
        /// A Methdo with Delegate as an INput Parameter
        /// And the method implements the code by passing two parameters 
        /// to delegate
        /// </summary>
        /// <param name="handler"></param>
        static void Bridge(OperationHandler handler)
        {
            Console.WriteLine($"Result From OPerations = {handler(500, 200)}");
        }
    }

}


