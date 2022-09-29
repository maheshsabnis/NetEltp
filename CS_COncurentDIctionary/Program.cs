using System.Collections.Concurrent;
// See https://aka.ms/new-console-template for more information

 

ConcurrentDictionary<string, int> concurrentDataDict = new ConcurrentDictionary<string, int>();
Task task3 = Task.Factory.StartNew(() => { putDataInConcurrentDataDictionary(); });
Task task4 = Task.Factory.StartNew(() => { putDataInConcurrentDataDictionary(); });

//task3.Start();
//task4.Start();

Task.WaitAll(task3,task4);

Console.WriteLine($"Records in Concurrent Data Dictionary using Tasks {concurrentDataDict.Values.Count}");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Main THread {i}");
}


Console.ReadLine();

void putDataInConcurrentDataDictionary()
{
    try
    {

        for (int i = 0; i <= 10; i++)
        {
            concurrentDataDict.TryAdd(Guid.NewGuid().ToString(), i);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error in Method {ex.Message}");
    }
}
