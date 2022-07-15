using System.Collections;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Array List");

ArrayList arrayList = new ArrayList();

// Adding Data into the ArrayList


arrayList.Add("Mahesh");
arrayList.Add("Sabnis");
arrayList.Add(200);
arrayList.Add(50);
arrayList.Add('A');
arrayList.Add('B');
arrayList.Add('C');

Person p1 = new Person();
p1.Id = 101;
p1.Name = "James Bond";

Person p2 = new Person();
p2.Id = 102;
p2.Name = "Jack Rayan";

arrayList.Add(p1);
arrayList.Add(p2);

 
Console.WriteLine();
 
Console.WriteLine();
 
Console.WriteLine();
PrintData(arrayList);

Console.WriteLine();
PrintDataWitType(arrayList, "string");

Console.ReadLine();


static void PrintDataWitType(ArrayList array, string datatype)
{
    foreach (var record in array)
    {
        if (datatype == "string")
        {
            Console.WriteLine($"Tytpe of record = {record.GetType()} and value of record = {(string)record}");
        }
        //if (record.GetType() == typeof(int))
        //{
        //    Console.WriteLine($"Tytpe of record = {record.GetType()} and value of record = {(int)record}");
        //}
        //if (record.GetType() == typeof(char))
        //{
        //    Console.WriteLine($"Tytpe of record = {record.GetType()} and value of record = {(char)record}");
        //}
        //if (record.GetType() == typeof(Person))
        //{
        //    Console.WriteLine($"Tytpe of record = {record.GetType()} and " +
        //        $"value of record Id = {((Person)record).Id} and Name = {((Person)record).Name}");
        //}
    }
}


static void PrintData(ArrayList array)
{
    foreach (var record in array)
    {
        if (record.GetType() == typeof(string))
        {
            Console.WriteLine($"Tytpe of record = {record.GetType()} and value of record = {(string)record}");
        }
        if (record.GetType() == typeof(int))
        {
            Console.WriteLine($"Tytpe of record = {record.GetType()} and value of record = {(int)record}");
        }
        if (record.GetType() == typeof(char))
        {
            Console.WriteLine($"Tytpe of record = {record.GetType()} and value of record = {(char)record}");
        }
        if (record.GetType() == typeof(Person))
        {
            Console.WriteLine($"Tytpe of record = {record.GetType()} and " +
                $"value of record Id = {((Person)record).Id} and Name = {((Person)record).Name}");
        }
    }
}


/// <summary>
/// Class
/// </summary>
public class Person
{
    public int Id;
    public string Name =  String.Empty;
}

