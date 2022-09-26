
using System;
using System.Collections;
using System.Threading;
namespace CS_AccessCollection
{
    class Program
    {
        private static Mutex mutex = new Mutex();
        private const int numhits = 1;
        private const int numThreads = 4;
        private static List<string> strList = new List<string>();
        private static void ThreadProcess()
        {
            for (int i = 0; i < numhits; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    UseSync(j);
                }
                
            }
        }

        private static void PrintList()
        {
            foreach (string str in strList)
            {
                Console.WriteLine($"Record in List is = {str}");
            }
        }
        private static void UseSync(int j)
        {
            mutex.WaitOne();   // Wait until it is safe to enter.  
            Console.WriteLine("Thread ==>> {0} has entered in the collection",
                Thread.CurrentThread.Name);
            strList.Add($"{Thread.CurrentThread.Name} == {j}");
            PrintList();
            // Place code to access non-reentrant resources here.  
            Thread.Sleep(500);    // Wait until it is safe to enter.  
            Console.WriteLine("Thread ==>> {0} is leaving the collection\r\n",
                Thread.CurrentThread.Name);
            mutex.ReleaseMutex();    // Release the Mutex.  
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < numThreads; i++)
            {
                Thread mycorner = new Thread(new ThreadStart(ThreadProcess));
                mycorner.Name = String.Format("Thread{0}", i + 1);
                mycorner.Start();
               
            }
            var d = strList;
           
            Console.Read();
        }
    }
}