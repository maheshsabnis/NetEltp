namespace CS_Monitor
{
    class Program
    {
        static object locker = new object();
        static void ThreadMain()
        {
            Thread.Sleep(800);    // Simulate Some work
            WriteToFile();          // Access a shared resource / critical section
        }
        static void WriteToFile()
        {
            String ThreadName = Thread.CurrentThread.Name;
            Console.WriteLine("{0} using Threading Synchronization", ThreadName);
            Monitor.Enter(locker);
            try

            {
                using (StreamWriter sw = new StreamWriter(@"c:\Coditas\MyMovedFile.txt", true))
                {
                    sw.WriteLine(ThreadName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Monitor.Exit(locker);
                Console.WriteLine("{0} releasing Thread", ThreadName);
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)

            {
                Thread thread = new Thread(new ThreadStart(ThreadMain));
                thread.Name = String.Concat("Thread - ", i);
                thread.Start();

            }
            Console.Read();
        }
    }

}    





