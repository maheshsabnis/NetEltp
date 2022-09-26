using System.Diagnostics;
using System.Threading;
namespace CS_Threads_First
{
    class Program
    {
        static void Main()
        {
            MyClass obj = new MyClass();
            //obj.Increment();

            Thread t1 = new Thread(obj.Increment);
            //t1.Priority = ThreadPriority.Highest;
            Console.WriteLine();
            //obj.Decrement();

            Thread t2 = new Thread(obj.Decrement);
           // t2.Priority = ThreadPriority.Lowest;
            Console.WriteLine($"State {t1.ThreadState} and {t2.ThreadState}");
            t1.Start();
            t1.Join();
            t2.Start();
            Console.WriteLine($"State {t1.ThreadState} and {t2.ThreadState}");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main THread i = {i}");
            }


            Console.ReadLine();
        }
    }


    public class MyClass
    {
        public void Increment()
        {
            var start = Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Increment {i}");
                //Thread.Sleep(1000);
            }
            var totalTime = start.Elapsed.TotalMilliseconds;

            Console.WriteLine($"Time for INcrement {totalTime}");
        }
        public void Decrement()
        {
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine($"Decrement {i}");
            }
        }
    }
}