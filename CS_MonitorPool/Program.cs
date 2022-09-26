using System;
using System.Threading;
namespace CS_MonitorPool
{
    class Program
    {
        private const int threads = 3;
        private const int workitems = 20;
        private static Object locker = new Object();
        static void Worker()
        {
            while (true)
            {
                lock (locker)
                {
                    Monitor.Wait(locker);
                }
                System.Console.WriteLine("The Request {0} access the Web Resource", Thread.CurrentThread.Name);
                Thread.Sleep(100);
            }
        }
        [STAThread]
        static void Main(string[] args)
        {
            Thread[] t = new Thread[threads];
            for (int k = 0; k < threads; k++)
            {
                t[k] = new Thread(new ThreadStart(Worker));
                t[k].Name = "user " + k;
                t[k].IsBackground = true;
                t[k].Start();
            }
            for (int i = 0; i < workitems; i++)
            {
                Thread.Sleep(1000);
                lock (locker)
                {
                    // Pulse signals are used to notify waiting threads about changes to an object's state.
                    Monitor.Pulse(locker);
                }
            }
            Console.Read();
        }
    }
}