// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Threading;

namespace CS_MultiThreads
{
   

    class Program
    {
        static List<string> lstInt = new List<string>();

        static void Main()
        {
            Console.WriteLine("Add Data in Collection");

            //Thread thread1 = new Thread(() => AddDataToCollection($"{Thread.CurrentThread.Name} 10"));
            //thread1.Start();


            //Thread thread2 = new Thread(() => AddDataToCollection($"{Thread.CurrentThread.Name} 20"));
            //thread2.Start();

           // Thread[] Threads = new Thread[4];

            for (int i = 0; i < 4; i++)
            {
                //Thread thread = new Thread(() => ThreadMainCollection($"{Thread.CurrentThread.Name } -- {i.ToString()}"));
                Thread thread = new Thread(new ParameterizedThreadStart(ThreadMainCollection));

                thread.Start($"{Thread.CurrentThread.Name} -- {i.ToString()}");
                //Console.WriteLine(JsonSerializer.Serialize(lstInt));
            }

            //for (int i = 0; i < 3; i++)

            //{
            //    Thread thread = new Thread(new ThreadStart(ThreadMain));
            //    thread.Name = String.Concat("Thread - ", i);
            //    thread.Start();

            //}

            Console.ReadLine();
        }


        static void AddDataToCollection(object  d)
        {
            lstInt.Add(d.ToString());

             Console.WriteLine(JsonSerializer.Serialize(lstInt));
        }

        static void ThreadMainCollection(object d)
        {
            Thread.Sleep(800);    // Simulate Some work
            AddDataToCollection(d);       // Access a shared resource / critical section
        }


        static void ThreadMain()
        {
            Thread.Sleep(800);    // Simulate Some work
            WriteToFile();          // Access a shared resource / critical section
        }

        static void WriteToFile()
        {
            String ThreadName = Thread.CurrentThread.Name;
            using (StreamWriter sw = new StreamWriter(@"c:\Coditas\MyMovedFile.txt", true))
            {
                sw.WriteLine(ThreadName);
            }
        }

    }
}





  


