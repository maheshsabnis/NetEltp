// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("TAsk Return");

var timer = Stopwatch.StartNew();

// Task That Return Data
FileOperations Operations = new FileOperations();
Task<string> t1 = Task.Factory.StartNew<string>(() => {
    string str = Operations.ReadFileOne();
    return str;
});

Task<string> t2 = Task.Factory.StartNew<string>(() => {
    string str = Operations.ReadFileTwo();
    return str;
});

var res1 = t1.Result;
var res2 = t2.Result;
var totalTime = timer.Elapsed.TotalMilliseconds;
Console.WriteLine($"Total Time to read files = {totalTime}");

Console.WriteLine(res1);
Console.WriteLine(res2);



Console.WriteLine();
Console.WriteLine("USing Async Methods for File IO Provided by .NET ");
AsyncFileOperations asyncFile = new AsyncFileOperations();

var asyncTimer = Stopwatch.StartNew();
var f1 = await asyncFile.ReadFileOneAsync();
var f2 = await asyncFile.ReadFileTwoAsync();
var asynTotalTime = asyncTimer.Elapsed.TotalMilliseconds;
Console.WriteLine($"Async File REading {asynTotalTime}");
Console.WriteLine($"Async {f1}");

Console.WriteLine($"Async {f2}");
Console.WriteLine("Ends Here");

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



class AsyncFileOperations
{
    public async Task<string> ReadFileOneAsync()
    {
        string contents = String.Empty;

        using (StreamReader reader = new StreamReader(@"c:\Coditas\MyFile.txt"))
        {
            contents = await reader.ReadToEndAsync();
        }

        return contents;
    }

    public async Task<string> ReadFileTwoAsync()
    {
        string contents = String.Empty;
        using (StreamReader reader = new StreamReader(@"c:\Coditas\MyFileSync.txt"))
        {
            contents = await reader.ReadToEndAsync();
        }
        return contents;
    }
}