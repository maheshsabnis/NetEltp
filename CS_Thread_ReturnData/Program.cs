namespace CS_Thread_ReturnData
{
    class Program
    {
        static void Main()
        {
            // Main THread DEclarations
            string res1 = string.Empty;
            string res2 = string.Empty;
            FileOperations operations = new FileOperations();

            // OPeratoins on Worker THreads
            Thread t1 = new Thread(() => { res1 = operations.ReadFileOne(); });

            Thread t2 = new Thread(() => { res2 = operations.ReadFileTwo(); });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();  

            Console.WriteLine($"Result 1 {res1}");
            Console.WriteLine($"Resylt 2 {res2}");

            Console.ReadLine();
        }
    }


    class FileOperations
    {
        public string ReadFileOne()
        {
            string contents = String.Empty;

            using (StreamReader reader = new StreamReader(@"c:\Coditas\MyFile.txt"))
            {
                contents = reader.ReadToEnd();
            }

           return contents;
        }

        public string ReadFileTwo()
        {
            string contents = String.Empty;
            using (StreamReader reader = new StreamReader(@"c:\Coditas\MyFileSync.txt"))
            {
                contents = reader.ReadToEnd();
            }
            return contents;
        }
    }
}