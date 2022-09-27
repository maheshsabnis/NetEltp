// See https://aka.ms/new-console-template for more information
Console.WriteLine("USing Parallel INvoke");

string res1 = string.Empty;
string res2 = string.Empty;
FileOperations operations = new FileOperations();
Parallel.Invoke(() => {
    res1 = operations.ReadFileOne();
     res2 = operations.ReadFileTwo();
});

Console.WriteLine($"Res1 {res1}");
Console.WriteLine($"Res2 {res2}");

Console.ReadLine();



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