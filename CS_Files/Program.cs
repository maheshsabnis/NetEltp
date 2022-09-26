// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
FileOprations oprations = new FileOprations();

//Thread tFileOne = new Thread(new ParameterizedThreadStart(oprations.WriteFirstFile));

//tFileOne.Start("FileFirst.txt");


//Thread tFileTwo = new Thread(new ParameterizedThreadStart(oprations.WriteSecondFile));

//tFileTwo.Start("FileSecond.txt");

Thread tFile1 = new Thread(new ParameterizedThreadStart(oprations.WriteFile));
tFile1.Start("MyFile.txt");
tFile1.Join();

Thread tFile2 = new Thread(new ParameterizedThreadStart(oprations.WriteFile));
tFile2.Start("MyFile.txt");






Console.ReadLine();




class FileOprations
{
    public void WriteFile(object fileName)
    {
        using (StreamWriter sw = new StreamWriter($@"c:\Coditas\{fileName}", true))
        {
            sw.WriteLine("Hellow First File");
        }
    }

    public void WriteFirstFile(object fileName)
    {
        using (StreamWriter sw = new StreamWriter ($@"c:\Coditas\{fileName}", true))
        {
            sw.WriteLine("Hellow First File");
        }
    }

    public void WriteSecondFile(object fileName)
    {
        using (StreamWriter sw = new StreamWriter($@"c:\Coditas\{fileName}", true))
        {
            sw.WriteLine("Hellow Second File");
        }
    }
}