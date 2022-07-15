using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Generics");

List<string> lstString = new List<string>();

lstString.Add("James Bond");
lstString.Add("Jack Rayan");
lstString.Add("Jack Reacher");
lstString.Add("Ethan Hunt"); 
lstString.Add("Indiana Jones");
lstString.Add("Jsosn Bourn");
PrintStringList(lstString);
lstString.Sort();
Console.WriteLine("After Sort");
PrintStringList(lstString);
lstString.Reverse();
Console.WriteLine("After Reverse");
PrintStringList(lstString);

lstString.Remove("Ethan Hunt");
Console.WriteLine("After Remove");
PrintStringList(lstString);

List<int> lstInt = new List<int>();

lstInt.Add(10);
lstInt.Add(20);
lstInt.Add(30);
lstInt.Add(40);
lstInt.Add(50);
lstInt.Add(60);

List<Person> PersonList = new List<Person>();


Person p1 = new Person();
p1.Id = 101;
p1.Name = "James Bond";

Person p2 = new Person();
p2.Id = 102;
p2.Name = "Jack Rayan";

Person p3 = new Person();
p3.Id = 103;
p3.Name = "Ethan Hunt";

PersonList.Add(p1);
PersonList.Add(p2);
PersonList.Add(p3);

foreach (var person in PersonList)
{
    Console.WriteLine($"Person Id = {person.Id} and Name = {person.Name}");
}


Console.ReadLine();


static void PrintStringList(List<string> lst)
{
    foreach (var item in lst)
    {
        Console.WriteLine($"Record = {item}");
    }
}

/// <summary>
/// Class
/// </summary>
public class Person
{
    public int Id;
    public string Name = String.Empty;
}