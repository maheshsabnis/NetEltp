// See https://aka.ms/new-console-template for more information

namespace MonitorEx
{
    class Program
    {
        static object locked = new object();
        static void Main()
        {
            Console.WriteLine("USing Monitor Object");

            for (int i = 0; i < 5; i++)
            {
                Thread t = new Thread(new ThreadStart(ControlWrites));
                t.Name = $" Thread ----- {i.ToString()}";
                t.Start();
            }


            Console.ReadLine();
        }
        static void ControlWrites()
        {
            Thread.Sleep(100);
            WriteFile();
        }
        /// Implement the SYnchronization
        static void WriteFile()
        {
            // REad the Name of the THread That will Acquire the Lock
            string ThreadName = Thread.CurrentThread.Name;
            Console.WriteLine($"Current Thread using the file is {ThreadName}");
            try
            {
                // STart The Loack Acquire
                Monitor.Enter(locked);
                using (StreamWriter sw = new StreamWriter($@"c:\Coditas\MyFileSync.txt", true))
                {
                    sw.WriteLine($"The Current ENtr is From THread {ThreadName}");
                }
                Console.WriteLine($"File Is writte by {ThreadName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erroc Occurred {ex.Message}");
            }
            finally
            {
                // Releasing the Lock for the Current THread
                Monitor.Exit(locked);
            }

        }

    }



}



